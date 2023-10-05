#region Using

using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Security;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Application.StaticTools;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using Microsoft.EntityFrameworkCore;

#endregion

namespace DoctorFAM.Application.Services.Implementation;

public class ChatService : IChatService
{
    #region Ctor

    private readonly IChatRepository _chatRepository;

    private readonly IUserService _userService;

    public ChatService(IChatRepository chatRepository, IUserService userService)
    {
        _chatRepository = chatRepository;
        _userService = userService;
    }

    #endregion

    #region Chat Room Area 

    //Join To The Private Group
    public async Task<JoinUserToTheGroupViewModel?> JoinToThePrivateGroup(ulong userId, ulong receiverId)
    {
        #region Get Chat Group

        var group = await _chatRepository.GetGroupByUserIdAndreceiverId(userId , receiverId);

        #endregion

        #region Create Private Group 

        if (group == null)
        {
            //Create ChatGroup Instance
            var groupCreated = new ChatGroup()
            {
                CreateDate = DateTime.Now,
                GroupTitle = await _userService.GetUsernameByUserID(receiverId),
                GroupToken = Guid.NewGuid().ToString(),
                ImageName = "Default.jpg",
                IsPrivate = true,
                OwnerId = userId,
                ReceiverId = receiverId
            };

            //Add To The Data Base
            await  _chatRepository.AddChatGroupToTheDataBase(groupCreated);
            await _chatRepository.SaveChangesAsync();

            return new JoinUserToTheGroupViewModel()
            {
                ChatGroup = await GetChatGroupById(groupCreated.Id),
                Chats = await _chatRepository.GetChatGroup(groupCreated.Id)
            };
        }

        #endregion

        return new JoinUserToTheGroupViewModel()
        {
            ChatGroup = group,
            Chats = await _chatRepository.GetChatGroup(group.Id)
        };
    }

    //Get Groups User Ids For Send Notification 
    public async Task<List<string>> GetUserIds(ulong groupId)
    {
        return await _chatRepository.GetUserIds(groupId);
    }

    //Send Message 
    public async Task<ChatViewModel?> SendMessage(SendMessageViewModel chat)
    {
        #region Get Group By Id 

        var group = await GetChatGroupById(chat.GroupId);
        if (group == null) return null;

        #endregion

        #region Create Instance

        Chat model = new Chat()
        {
            CreateDate = DateTime.Now,
            GroupId = chat.GroupId,
            UserId = chat.UserId
        };

        #endregion

        #region If AttachMent File was Upoloaded

        if (chat.FileAttach != null)
        {
            //Upload File To The Server
            var fileName = await chat.FileAttach.SaveFile("wwwroot/Content/ChatRoomFiles/");

            //Fill Chat Body
            model.ChatBody = chat.FileAttach.FileName;

            //Fill Atachment File 
            model.FileAttach = fileName;

            //Add To The Data Base 
            await _chatRepository.AddChatMessageToTheDataBase(model);

            return new ChatViewModel()
            {
                UserName = chat.Username,
                CreateDate = $"{model.CreateDate.Hour}:{model.CreateDate.Minute}",
                ChatBody = model.ChatBody,
                GroupName = group.GroupTitle,
                GroupId = group.Id,
                UserId = chat.UserId,
                FileAttach = fileName
            };
        }

        #endregion

        #region If Attachment file Was Empty

        model.ChatBody = chat.ChatBody;

        //Add To The Data Base 
        await _chatRepository.AddChatMessageToTheDataBase(model);

        return new ChatViewModel()
        {
            UserName = " ",
            CreateDate = $"{model.CreateDate.Hour}:{model.CreateDate.Minute}",
            ChatBody = model.ChatBody,
            GroupName = group.GroupTitle,
            GroupId = group.Id,
            UserId = chat.UserId
        };

        #endregion
    }

    //Fill Search Chat Room Result View Model 
    public async Task<List<SearchChatRoomResultViewModel>> FillSearchChatRoomResultViewModel(string title)
    {
        //Create Instance
        List<SearchChatRoomResultViewModel> result = new List<SearchChatRoomResultViewModel>();

        if (string.IsNullOrWhiteSpace(title)) return result;

        //Get Chat Rooms By Title 
        var groups = await _chatRepository.SearchChatGroupNameWithStringOfTitle(title);

        //Get Users By User name 
        var users = await _chatRepository.SearchUserNameWithStringOfUsername(title);

        result.AddRange(groups);
        result.AddRange(users);

        return result;
    }

    //Create Chat Group From User
    public async Task<ChatGroup?> CreateChatGroupFromUser(CreateGroupViewModel incomingModel)
    {
        #region Get User By Id 

        var user = await _userService.GetUserById(incomingModel.UserId);
        if (user is null) return null;

        #endregion

        #region Create Chat Group 

        ChatGroup model = new ChatGroup()
        {
            CreateDate = DateTime.Now,
            GroupTitle = incomingModel.GroupName.SanitizeText(),
            OwnerId = incomingModel.UserId,
            GroupToken = Guid.NewGuid().ToString()
        };

        #region Image

        if (incomingModel.ImageFile != null && incomingModel.ImageFile.IsImage())
        {
            var imageName = Guid.NewGuid() + Path.GetExtension(incomingModel.ImageFile.FileName);
            incomingModel.ImageFile.AddImageToServer(imageName, PathTools.UserAvatarPathServer, 400, 300, PathTools.UserAvatarPathThumbServer);
            model.ImageName = imageName;
        }

        #endregion

        //Add To The Data Base
        await _chatRepository.AddChatGroupToTheDataBase(model);

        #endregion

        #region Add Chat Group Member

        ChatGroupMember member = new ChatGroupMember()
        {
            GroupId = model.Id,
            UserId = incomingModel.UserId,
            CreateDate = DateTime.Now,
        };

        #endregion

        return model;
    }

    //Get List Of User Chat Groups Id By User Id
    public async Task<List<ulong>> GetListOfUserChatGroupsIdByUserId(ulong userId)
    {
        return await _chatRepository.GetListOfUserChatGroupsIdByUserId(userId);
    }

    //Get List Of User Lists
    public async Task<List<ListOfCurrentUserChatRooms>?> GetListOfUserLists(ulong userId)
    {
        #region Get User By Id 

        var user = await _userService.GetUserById(userId);
        if (user is null) return null;

        #endregion

        #region List OF Chat Groups

        //Create New Instance For Returned Model 
        List<ListOfCurrentUserChatRooms> model = new List<ListOfCurrentUserChatRooms>();

        //Get Current User Chat Rooms Ids
        List<ulong> chatGroups = await _chatRepository.GetListOfUserChatGroupsIdByUserId(user.Id);
        if (chatGroups is null) return null;

        foreach (var item in chatGroups)
        {
            var chatGroup = await GetChatGroupById(item);
            if (chatGroup is null) return null;

            var chatLists = await _chatRepository.GetChatsListByChatGroupId(item);

            ListOfCurrentUserChatRooms subModel = new ListOfCurrentUserChatRooms()
            {
                Chat = chatLists.FirstOrDefault(),
            };

            if (!chatGroup.ReceiverId.HasValue)
            {
                subModel.ChatGroup = new ChatGroup()
                {
                    CreateDate = chatGroup.CreateDate,
                    GroupTitle = chatGroup.GroupTitle,
                    GroupToken = chatGroup.GroupToken,
                    Id = chatGroup.Id,
                    ReceiverId = chatGroup.ReceiverId,
                    ImageName = chatGroup.ImageName,
                    IsDelete = chatGroup.IsDelete,
                    IsPrivate = chatGroup.IsPrivate,
                    OwnerId = chatGroup.OwnerId
                };
            }
            else
            {
                subModel.ChatGroup = new ChatGroup()
                {
                    CreateDate = chatGroup.CreateDate,
                    GroupTitle = chatGroup.GroupTitle,
                    GroupToken = chatGroup.GroupToken,
                    Id = chatGroup.Id,
                    ReceiverId = chatGroup.ReceiverId,
                    ImageName = (await _userService.GetUserImageNameByUserId(chatGroup.ReceiverId.Value) != null ? await _userService.GetUserImageNameByUserId(chatGroup.ReceiverId.Value) : null),
                    IsDelete = chatGroup.IsDelete,
                    IsPrivate = chatGroup.IsPrivate,
                    OwnerId = chatGroup.OwnerId
                };
            }

            model.Add(subModel);
        }

        #endregion

        return model;
    }

    //Get Group By Token 
    public async Task<ChatGroup?> GetGroupByToken(string token)
    {
        return await _chatRepository.GetGroupByToken(token);
    }

    //Fill Join User To The Group View Model
    public async Task<JoinUserToTheGroupViewModel?> FillJoinUserToTheGroupViewModel(string token)
    {
        #region Get User Chat Group 

        var chatGroup = await GetGroupByToken(token);
        if (chatGroup == null) return null;

        #endregion

        #region Get Chat 

        var chat = await _chatRepository.GetChatsListByChatGroupId(chatGroup.Id);

        #endregion

        #region Fill Return Model

        JoinUserToTheGroupViewModel model = new JoinUserToTheGroupViewModel()
        {
            ChatGroup = chatGroup,
            Chats = await  _chatRepository.GetChatGroup(chatGroup.Id)
        };

        #endregion

        return model;
    }

    //Get Chat Group By Id 
    public async Task<ChatGroup?> GetChatGroupById(ulong chatGroupId)
    {
        return await _chatRepository.GetChatGroupById(chatGroupId);
    }

    //Is User In Group 
    public async Task<bool> IsUserInGroup(ulong userId, ulong groupId)
    {
        #region Check That User Is Member Of Chat Group 

        return await _chatRepository.IsExistUserInChatGroup(groupId, userId);

        #endregion
    }

    //Join To The Group 
    public async Task JoinToTheGroup(ulong userId, ulong groupId)
    {
        #region Create Instance Of Model 

        ChatGroupMember model = new ChatGroupMember()
        {
            UserId = userId,
            GroupId = groupId
        };

        #endregion

        //Add To The Data Base 
        await _chatRepository.JoinUserToTheChatGroup(model);
    }

    //Join User To The Chat Group 
    public async Task JoinUserToTheChatGroup(List<ChatGroupMember> members)
    {
        await _chatRepository.JoinUserToTheChatGroup(members);
    }

    #endregion

    #region Online Visit 

    //Create Online Visit Chat Room
    public async Task<ulong> CreateOnlineVisitChatRoom(ulong doctorUserId , ulong patientUserId , string ShiftTime)
    {
        //Create ChatGroup Instance
        var groupCreated = new ChatGroup()
        {
            CreateDate = DateTime.Now,
            GroupTitle = $"نوبت آنلاین - {ShiftTime}",
            GroupToken = Guid.NewGuid().ToString(),
            ImageName = "Default.jpg",
            IsPrivate = true,
            OwnerId = doctorUserId,
            ReceiverId = patientUserId
        };

        //Add To The Data Base
        await _chatRepository.AddChatGroupToTheDataBase(groupCreated);

        while (groupCreated.Id == 0)
        {
            try
            {
                await _chatRepository.SaveChangesAsync();

                return groupCreated.Id;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return 0;
            }
        }

        return 0;
    }

    //Online Visit Join Members To The Group
    public async Task OnlineVisitJoinMembersToTheGroup(ulong chatGroup, ulong doctorUserId, ulong patientUserId)
    {
        List<ChatGroupMember> members = new List<ChatGroupMember>();

        members.Add(new ChatGroupMember()
        {
            CreateDate = DateTime.Now,
            GroupId = chatGroup,
            UserId = doctorUserId,
        });

        members.Add(new ChatGroupMember()
        {
            CreateDate = DateTime.Now,
            GroupId = chatGroup,
            UserId = patientUserId,
        });

        //Join Members To This Group 
        await JoinUserToTheChatGroup(members);
    }

    #endregion
}
