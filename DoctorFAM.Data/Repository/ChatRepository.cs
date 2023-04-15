using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Chat;
using DoctorFAM.Domain.Interfaces.EFCore;
using DoctorFAM.Domain.ViewModels.ChatRoom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class ChatRepository : IChatRepository
    {
        #region Ctor 

        private readonly DoctorFAMDbContext _context;

        public ChatRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Chat Room Area 

        //Get Group By User Id And receiver Id
        public async Task<ChatGroup?> GetGroupByUserIdAndreceiverId(ulong userId, ulong receiverId)
        {
            return await _context.ChatGroups.FirstOrDefaultAsync(p => !p.IsDelete &&
                                                                (p.OwnerId == userId && p.ReceiverId == receiverId)
                                                                ||
                                                                (p.OwnerId == receiverId && p.ReceiverId == userId));
        }

        //Get Chat Group By Group Id 
        public async Task<List<ChatViewModel>> GetChatGroup(ulong groupId)
        {
            return await _context.Chats
                .Where(g => g.GroupId == groupId)
                .Select(s => new ChatViewModel()
                {
                    UserName = _context.Users.FirstOrDefault(p=> !p.IsDelete && p.Id == s.UserId).Username,
                    CreateDate = $"{s.CreateDate.Hour}:{s.CreateDate.Minute}",
                    ChatBody = s.ChatBody,
                    GroupName = _context.ChatGroups.FirstOrDefault(p=> !p.IsDelete && p.Id == s.GroupId).GroupTitle,
                    UserId = s.UserId,
                    GroupId = s.GroupId,
                    FileAttach = s.FileAttach
                }).ToListAsync();
        }

        //Get Groups User Ids For Send Notification 
        public async Task<List<string>> GetUserIds(ulong groupId)
        {
            return await _context.ChatGroupMembers.Where(g => g.GroupId == groupId)
                                     .Select(s => s.UserId.ToString()).ToListAsync();
        }

        //Add Chat Message To The Data Base 
        public async Task AddChatMessageToTheDataBase(Chat chat)
        {
            await _context.Chats.AddAsync(chat);
            await _context.SaveChangesAsync();
        }

        //Add Group To The Data Base 
        public async Task AddChatGroupToTheDataBase(ChatGroup chatGroup)
        {
            await _context.ChatGroups.AddAsync(chatGroup);
            await _context.SaveChangesAsync();
        }

        //Get Current User Chat Rooms By Owner Id
        public async Task<List<ChatGroup>?> GetCurrentUserChatRoomsByOwnerId(ulong userId)
        {
            return await _context.ChatGroups.Where(p => !p.IsDelete && p.OwnerId == userId)
                                                   .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Get List Of User Chat Groups Id By User Id
        public async Task<List<ulong>> GetListOfUserChatGroupsIdByUserId(ulong userId)
        {
            //Get User Chat Groups 
            return await _context.ChatGroupMembers.Where(p => !p.IsDelete && p.UserId == userId)
                                    .Select(p => p.GroupId).ToListAsync();
        }

        //Get Chat By Chat Group Id
        public async Task<List<Chat>?> GetChatsListByChatGroupId(ulong chatGroupId)
        {
            return await _context.Chats.Where(p => !p.IsDelete && p.GroupId == chatGroupId)
                                                .OrderByDescending(p => p.CreateDate).ToListAsync();
        }

        //Add Chat Group Member To The Data Base
        public async Task AddChatGroupMemberToTheDataBase(ChatGroupMember member)
        {
            await _context.ChatGroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        //Search Chat Group Name With String Of Title 
        public async Task<List<SearchChatRoomResultViewModel>> SearchChatGroupNameWithStringOfTitle(string title)
        {
            return await _context.ChatGroups.Where(g => !g.IsDelete && !g.IsPrivate && g.GroupTitle.Contains(title)).OrderByDescending(p => p.CreateDate)
                .Select(s => new SearchChatRoomResultViewModel()
                {
                    ImageName = s.ImageName,
                    Token = s.GroupToken,
                    IsUser = false,
                    Title = s.GroupTitle
                }).ToListAsync();
        }

        //Search User Name With String Of Title 
        public async Task<List<SearchChatRoomResultViewModel>> SearchUserNameWithStringOfUsername(string title)
        {
            return await _context.Users.Where(g => !g.IsDelete && g.Username.Contains(title)).OrderByDescending(p => p.CreateDate)
                .Select(s => new SearchChatRoomResultViewModel()
                {
                    ImageName = (string.IsNullOrEmpty(s.Avatar) ? "DefaultAvatar.png" : s.Avatar),
                    Token = s.Id.ToString(),
                    IsUser = true,
                    Title = s.Username
                }).ToListAsync();
        }

        //Get Group By Token 
        public async Task<ChatGroup?> GetGroupByToken(string token)
        {
            return await _context.ChatGroups.FirstOrDefaultAsync(p => !p.IsDelete && p.GroupToken == token);
        }

        //Get Chat Group By Id 
        public async Task<ChatGroup?> GetChatGroupById(ulong chatGroupId)
        {
            return await _context.ChatGroups.FirstOrDefaultAsync(p => !p.IsDelete && p.Id == chatGroupId);
        }

        //Is Exist User In Chat Group 
        public async Task<bool> IsExistUserInChatGroup(ulong chatGroupId , ulong userId)
        {
            return await _context.ChatGroupMembers.AnyAsync(p => !p.IsDelete && p.GroupId == chatGroupId && p.UserId == userId);
        }

        //Join User To The Chat Group 
        public async Task JoinUserToTheChatGroup(ChatGroupMember member)
        {
            await _context.ChatGroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        //Join User To The Chat Group 
        public async Task JoinUserToTheChatGroup(List<ChatGroupMember> members)
        {
            await _context.ChatGroupMembers.AddRangeAsync(members);
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
