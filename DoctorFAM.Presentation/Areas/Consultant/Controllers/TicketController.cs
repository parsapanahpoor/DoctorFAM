using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.UserPanel.Ticket;
using DoctorFAM.Web.Consultant.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Consultant.Controllers
{
    public class TicketController : ConsultantBaseController
    {
        #region Ctor

        private readonly ITicketService _ticketService;
        public IStringLocalizer<TicketController> _localizer;
        private readonly IOrganizationService _organziationService;

        public TicketController(ITicketService ticketService, IStringLocalizer<TicketController> localizer, IOrganizationService organziationService)
        {
            _ticketService = ticketService;
            _localizer = localizer;
            _organziationService = organziationService;
        }

        #endregion

        #region Filter Tickets

        public async Task<IActionResult> FilterTickets(FilterSiteTicketViewModel filter)
        {
            #region Get User Organization

            var organization = await _organziationService.GetOrganizationByUserId(User.GetUserId());
            if (organization == null) return NotFound();

            #endregion

            var result = await _ticketService.FilterSiteTicket(filter, organization.OwnerId);

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
            #region Get User Organization

            var organization = await _organziationService.GetOrganizationByUserId(User.GetUserId());
            if (organization == null) return NotFound();

            #endregion

            #region Validation Model State

            if (string.IsNullOrEmpty(create.Message))
            {
                TempData[ErrorMessage] = _localizer["Text entry required"].Value;
                return View(create);
            }

            #endregion

            #region Add Ticket Method 

            var result = await _ticketService.CreateTicket(create, organization.OwnerId, Domain.Enums.Ticket.TicketSenderType.FromDoctor);

            if (result != 0)
            {
                TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                return RedirectToAction("TicketDetail", "Ticket", new { area = "Consultant", id = result });
            }

            #endregion

            TempData[ErrorMessage] = _localizer["An error occurred Please try again"].Value;

            return View(create);
        }

        #endregion

        #region Ticket Detail

        public async Task<IActionResult> TicketDetail(ulong id)
        {
            #region Get User Organization

            var organization = await _organziationService.GetOrganizationByUserId(User.GetUserId());
            if (organization == null) return NotFound();

            #endregion

            #region Fill View Model

            var result = await _ticketService.GetUserPanelTicketDetailViewModel(id, organization.OwnerId);

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
            #region Get User Organization

            var organization = await _organziationService.GetOrganizationByUserId(User.GetUserId());
            if (organization == null) return NotFound();

            #endregion

            #region Model State Validations

            if (ModelState.IsValid)
            {
                var result = await _ticketService.AnswerTicketByUser(answer, User.GetUserId());

                if (result)
                {
                    TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                    return RedirectToAction("TicketDetail", "Ticket", new { area = "Nurse", id = answer.TicketId });
                }
            }

            #endregion

            var viewModel = await _ticketService.GetUserPanelTicketDetailViewModel(answer.TicketId, organization.OwnerId);

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
