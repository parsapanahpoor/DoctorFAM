using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.Ticket;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.UserPanel.Controllers
{
    public class TicketController : UserBaseController
    {
        #region Ctor

        private readonly ITicketService _ticketService;
        public IStringLocalizer<TicketController> _localizer;

        public TicketController(ITicketService ticketService, IStringLocalizer<TicketController> localizer)
        {
            _ticketService = ticketService;
            _localizer = localizer;
        }

        #endregion

        #region Filter Tickets

        public async Task<IActionResult> FilterTickets(FilterSiteTicketViewModel filter)
        {
            var result = await _ticketService.FilterSiteTicket(filter, User.GetUserId());

            return View(result);
        }

        #endregion

        #region Create Ticket

        [HttpGet]
        public async Task<IActionResult> CreateTicket()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket(CreateTicketViewModel create)
        {
            #region Validation Model State

            if (string.IsNullOrEmpty(create.Message))
            {
                TempData[ErrorMessage] = _localizer["Text entry required"].Value;
                return View(create);
            }

            #endregion

            #region Add Ticket Method 

            var result = await _ticketService.CreateTicket(create, User.GetUserId() , Domain.Enums.Ticket.TicketSenderType.FromUser);

            if (result != 0)
            {
                TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                return RedirectToAction("TicketDetail", "Ticket", new { area = "UserPanel", id = result });
            }

            #endregion

            TempData[ErrorMessage] = _localizer["An error occurred Please try again"].Value;

            return View(create);
        }

        #endregion

        #region Ticket Detail

        public async Task<IActionResult> TicketDetail(ulong id)
        {
            #region Fill View Model

            var result = await _ticketService.GetUserPanelTicketDetailViewModel(id, User.GetUserId());

            if (result == null) return NotFound();

            #endregion

            ViewData["TicketDetailViewModel"] = result;

            return View(new AnswerTicketViewModel
            {
                TicketId = id
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketDetail(AnswerTicketViewModel answer)
        {
            #region Model State Validations

            if (ModelState.IsValid)
            {
                var result = await _ticketService.AnswerTicketByUser(answer, User.GetUserId());

                if (result)
                {
                    TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                    return RedirectToAction("TicketDetail", "Ticket", new { area = "UserPanel", id = answer.TicketId });
                }
            }

            #endregion

            var viewModel = await _ticketService.GetUserPanelTicketDetailViewModel(answer.TicketId, User.GetUserId());

            if (viewModel == null)
            {
                TempData[ErrorMessage] = _localizer["An error occurred Please try again"].Value;
                return RedirectToAction("FilterTickets", "Ticket");
            }

            ViewData["TicketDetailViewModel"] = viewModel;

            TempData[ErrorMessage] = _localizer["Text entry required"].Value;

            return View(answer);
        }

        #endregion

    }
}
