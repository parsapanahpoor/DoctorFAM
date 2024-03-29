﻿using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Web.Areas.Admin.ViewComponents
{
    public class AdminChatBarViewComponent : ViewComponent
    {
        #region Ctor

        private readonly INotificationService _notificationService;

        public AdminChatBarViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        #endregion

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _notificationService.GetListOfSupporterNotificationByUserId(User.GetUserId());
            return View("AdminChatBar" , model);
        }
    }
}
