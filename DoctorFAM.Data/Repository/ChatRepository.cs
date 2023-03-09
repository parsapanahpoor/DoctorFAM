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

        //Get Chat By Chat Group Id
        public async Task<List<Chat>?> GetChatsListByChatGroupId(ulong chatGroupId)
        {
            return await _context.Chats.Where(p => p.IsDelete && p.GroupId == chatGroupId)
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
            return await _context.ChatGroups.Where(g => g.GroupTitle.Contains(title)).OrderByDescending(p => p.CreateDate)
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
            return await _context.Users.Where(g => g.Username.Contains(title)).OrderByDescending(p => p.CreateDate)
                .Select(s => new SearchChatRoomResultViewModel()
                {
                    ImageName = (string.IsNullOrEmpty(s.Avatar) ? "DefaultAvatar.png" : s.Avatar),
                    Token = s.Id.ToString(),
                    IsUser = true,
                    Title = s.Username
                }).ToListAsync();
        }

        #endregion
    }
}
