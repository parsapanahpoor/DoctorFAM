using DoctorFAM.Data.DbContext;
using DoctorFAM.Domain.Entities.Wallet;
using DoctorFAM.Domain.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Wallet;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Data.Repository
{
    public class WalletRepository : IWalletRepository
    {
        #region Ctor

        private readonly DoctorFAMDbContext _context;

        public WalletRepository(DoctorFAMDbContext context)
        {
            _context = context;
        }

        #endregion

        #region Wallet

        public async Task<FilterWalletViewModel> FilterWalletsAsync(FilterWalletViewModel filter)
        {
            var query = _context.Wallets
                .Include(w => w.User).Where(w => w.IsFinally)
                .AsQueryable();

            #region Order

            switch (filter.OrderType)
            {
                case FilterWalletViewModel.FilterWalletOrderType.Price:
                    query = query.OrderBy(w => w.Price).AsQueryable();
                    break;

                case FilterWalletViewModel.FilterWalletOrderType.PriceDesc:
                    query = query.OrderByDescending(w => w.Price).AsQueryable();
                    break;

                case FilterWalletViewModel.FilterWalletOrderType.CreateDate:
                    query = query.OrderBy(w => w.CreateDate).AsQueryable();
                    break;

                case FilterWalletViewModel.FilterWalletOrderType.CreateDateDesc:
                    query = query.OrderByDescending(w => w.CreateDate).AsQueryable();
                    break;

                default:
                    query = query.OrderByDescending(w => w.CreateDate).AsQueryable();
                    break;
            }

            #endregion

            #region Filters

            if (filter.UserId.HasValue)
            {
                query = query.Where(w => w.UserId == filter.UserId).AsQueryable();
            }
            else if (!string.IsNullOrEmpty(filter.UserFilter))
            {
                query = query.Where(w =>
                            EF.Functions.Like(w.User.Email, $"%{filter.UserFilter}%") ||
                            EF.Functions.Like(w.User.Username , $"%{filter.UserFilter}%")
                        )
                    .AsQueryable();
            }

            if (filter.TransactionType.HasValue)
            {
                query = query.Where(w => w.TransactionType == filter.TransactionType).AsQueryable();
            }

            if (filter.GatewayType.HasValue)
            {
                query = query.Where(w => w.GatewayType == filter.GatewayType).AsQueryable();
            }

            if (filter.PaymentType.HasValue)
            {
                query = query.Where(w => w.PaymentType == filter.PaymentType).AsQueryable();
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(w => w.Price >= filter.MinPrice).AsQueryable();
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(w => w.Price <= filter.MaxPrice).AsQueryable();
            }

            if (filter.MinCreateDate.HasValue)
            {
                query = query.Where(w => w.CreateDate >= filter.MinCreateDate).AsQueryable();
            }

            if (filter.MaxCreateDate.HasValue)
            {
                query = query.Where(w => w.CreateDate <= filter.MaxCreateDate).AsQueryable();
            }

            if (!string.IsNullOrEmpty(filter.Description))
            {
                query = query.Where(w => w.Description != null && EF.Functions.Like(w.Description, $"%{filter.Description}%"));
            }

            if (filter.IsDelete.HasValue)
            {
                query = query.IgnoreQueryFilters().Where(w => w.IsDelete == filter.IsDelete).AsQueryable();
            }

            #endregion

            #region Paging

            await filter.Paging(query);

            #endregion

            return filter;
        }

        public Task<Wallet?> GetWalletByWalletIdAsync(ulong walletId)
        {
            return Task.FromResult(_context.Wallets.FirstOrDefault(w => w.Id == walletId));
        }

        public Task<int> GetSumUserWalletAsync(ulong userId)
        {
            return Task.FromResult(_context.Wallets.Where(u => u.Id == userId && u.IsFinally).Sum(w => w.TransactionType == TransactionType.Deposit ? w.Price : w.Price * -1));
        }

        public async Task CreateWalletAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
            await SaveChangesAsync();

        }

        public async Task ConfirmPayment(ulong payId, string authority, string refId)
        {
            var payment = await _context.Wallets.FirstOrDefaultAsync(w => w.Id == payId);
            if (payment != null)
            {
                payment.IsFinally = true;

                _context.Wallets.Update(payment);
                await SaveChangesAsync();
                var paymentData = new WalletData()
                {
                    Token = authority,
                    WalletId = payId,
                    CreateDate = DateTime.Now,
                    GatewayType = payment.GatewayType,
                    TrackingCode = refId
                };

                _context.WalletData.Add(paymentData);
                await SaveChangesAsync();

            }
        }

        public async Task EditWalletAsync(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
            await SaveChangesAsync();
        }

        public Task<AdminEditWalletViewModel?> GetWalletForEditAsync(ulong walletId)
        {
            return Task.FromResult(_context.Wallets
                .Include(w => w.User)
                .Where(w => w.Id == walletId)
                .Select(w => new AdminEditWalletViewModel
                {
                    User = w.User,
                    Description = w.Description,
                    GatewayType = w.GatewayType,
                    PaymentType = w.PaymentType,
                    Price = w.Price,
                    TransactionType = w.TransactionType,
                    UserId = w.UserId,
                    WalletId = w.Id
                }).FirstOrDefault());
        }

        public async Task<Wallet?> GetWalletById(ulong id)
        {
            return await _context.Wallets.Include(w => w.User)
                .Include(w => w.WalletData)
                .FirstOrDefaultAsync(w => !w.IsDelete && w.Id == id && !w.IsFinally);
        }

        public async Task<ulong> CreateWallet(Wallet charge)
        {
            await _context.Wallets.AddAsync(charge);
            await SaveChangesAsync();
            return charge.Id;
        }

        #endregion

        #region Save Changes

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
