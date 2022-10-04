using DoctorFAM.Domain.Entities.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Application.StaticTools
{
    public static class PermissionsList
    {
        public static List<Permission> Permissions
        {
            get
            {
                List<Permission> list = new List<Permission>();

                var date = new DateTime(2021, 08, 12);

                #region Add Permissions

                #region Admin Panel

                #region Dashboard

                list.Add(new Permission
                {
                    Id = 1,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "Dashboard",
                    Title = "داشبورد",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                #endregion

                #region Manage Access

                list.Add(new Permission
                {
                    Id = 2,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "ManageAccess",
                    Title = "مدیریت دسترسی ها",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                list.Add(new Permission
                {
                    Id = 3,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 2,
                    PermissionUniqueName = "CreateRole",
                    Title = "ایجاد نقش جدید",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                list.Add(new Permission
                {
                    Id = 4,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 2,
                    PermissionUniqueName = "FilterRoles",
                    Title = "لیست نقش ها",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                list.Add(new Permission
                {
                    Id = 5,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 2,
                    PermissionUniqueName = "EditRole",
                    Title = "ویرایش نقش",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                list.Add(new Permission
                {
                    Id = 6,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 2,
                    PermissionUniqueName = "DeleteRole",
                    Title = "حذف نقش",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                #endregion

                #region Manage Account

                list.Add(new Permission
                {
                    Id = 7,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "ManageAccount",
                    Title = "مدیریت کاربران",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                list.Add(new Permission
                {
                    Id = 8,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 7,
                    PermissionUniqueName = "UsersList",
                    Title = "لیست کاربران",
                    PermissionType = Domain.Enums.Permission.PermissionType.AdminPanel
                });

                #endregion

                #endregion

                #region Supporter Panel

                list.Add(new Permission
                {
                    Id = 8,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "SupporterPanel",
                    Title = "پنل پشتیبان",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 9,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "HomeVisit",
                    Title = "ویزیت در منزل",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 10,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "HomeNurse",
                    Title = "پرستار در منزل",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 11,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "HomePharmacy",
                    Title = "داروخانه در منزل",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 12,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "HomeLaboratory",
                    Title = "آزمایشگاه در منزل",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 13,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "PetientTransport",
                    Title = "انتقال بیمار",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                list.Add(new Permission
                {
                    Id = 14,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 8,
                    PermissionUniqueName = "DeathCertificate",
                    Title = "صدور گواهی فوت",
                    PermissionType = Domain.Enums.Permission.PermissionType.SupporterPanel
                });

                #endregion

                #region Laboratory Panel 

                list.Add(new Permission
                {
                    Id = 15,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "LaboratoryDashboard",
                    Title = "داشبورد داروخانه",
                    PermissionType= Domain.Enums.Permission.PermissionType.LaboratoryPanel
                });


                #region Tickets

                list.Add(new Permission
                {
                    Id = 16,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = null,
                    PermissionUniqueName = "ManageTickets",
                    Title = "مدیریت تیکت ها",
                    PermissionType = Domain.Enums.Permission.PermissionType.LaboratoryPanel
                });

                list.Add(new Permission
                {
                    Id = 17,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 16,
                    PermissionUniqueName = "ListOfTickets",
                    Title = "لیست تیکت ها",
                    PermissionType = Domain.Enums.Permission.PermissionType.LaboratoryPanel
                });

                list.Add(new Permission
                {
                    Id = 18,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 16,
                    PermissionUniqueName = "CreateNowTiceket",
                    Title = "افزودن تیکت جدید",
                    PermissionType = Domain.Enums.Permission.PermissionType.LaboratoryPanel
                });

                list.Add(new Permission
                {
                    Id = 19,
                    CreateDate = date,
                    IsDelete = false,
                    ParentId = 16,
                    PermissionUniqueName = "TicketDetail",
                    Title = "مشاهده ی جزییات تیکت",
                    PermissionType = Domain.Enums.Permission.PermissionType.LaboratoryPanel
                });

                #endregion

                #endregion

                #endregion

                // Last Id Use is : 19

                return list;
            }
        }
    }
}
