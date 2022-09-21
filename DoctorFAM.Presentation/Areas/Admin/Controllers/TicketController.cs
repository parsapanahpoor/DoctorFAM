using DoctorFAM.Application.Extensions;
using DoctorFAM.Application.Services.Interfaces;
using DoctorFAM.Domain.ViewModels.Admin.Ticket;
using DoctorFAM.Web.HttpManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace DoctorFAM.Web.Areas.Admin.Controllers
{
    public class TicketController : AdminBaseController
    {
        #region Ctor

        public ITicketService _ticketService;

        public IUserService _userService;

        public IStringLocalizer<TicketController> _localizer;

        public TicketController(ITicketService ticketService, IUserService userService, IStringLocalizer<TicketController> localizer)
        {
            _ticketService = ticketService;
            _userService = userService;
            _localizer = localizer;
        }

        #endregion

        #region Filter Tickets

        public async Task<IActionResult> FilterTickets(AdminFilterTicketViewModel filter)
        {
            var result = await _ticketService.FilterAdminTicketViewModel(filter);
            return View(result);
        }

        #endregion

        #region Create Ticket

        [HttpGet]
        public async Task<IActionResult> CreateTicket(ulong? resiverId)
        {
            #region Fill Mode For Page

            if (resiverId != null)
            {
                var user = await _userService.GetUserById(resiverId.Value);
                if (user == null)
                {
                    return NotFound();
                }
                var model = new AddTicketViewModel()
                {
                    userName = user.Username,
                    userId = user.Id
                };

                return View(model);
            }

            #endregion

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTicket(AddTicketViewModel ticket)
        {
            #region User Validation

            if (ticket.userId.HasValue == false)
            {
                TempData[ErrorMessage] = _localizer["The submitted data is not valid"].Value;

                return View(ticket);
            }

            var user = await _userService.GetUserById(ticket.userId.Value);
            if (user == null)
            {
                TempData[ErrorMessage] = _localizer["The submitted data is not valid"].Value;

                return View(ticket);
            }

            #endregion

            #region Valdiation of Model State

            if (!ModelState.IsValid)
            {
                return View(ticket);
            }

            #endregion

            var res = await _ticketService.AddTicketFromAdminPanel(ticket, User.GetUserId());

            if (res)
            {
                TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                return RedirectToAction("FilterTickets", "Ticket", new { area = "Admin" });
            }

            TempData[ErrorMessage] = _localizer["The submitted data is not valid"].Value;

            return View(ticket);
        }

        #endregion

        #region Ticket Detail

        [HttpGet]
        public async Task<IActionResult> TicketDetail(ulong id)
        {
            #region Get Ticket By Id

            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null) return NotFound();

            #endregion

            #region Read Ticket

            await _ticketService.ReadTicketByAdmin(ticket);

            #endregion

            #region Get Tickets Messages For Show In Page Model

            var messages = await _ticketService.GetTicketMessages(id);

            ViewData["Ticket"] = ticket;
            ViewData["TicketMessages"] = messages;

            #endregion

            return View(new AnswerTicketAdminViewModel
            {
                TicketId = id
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> TicketDetail(AnswerTicketAdminViewModel answer)
        {
            #region Model State Validations

            if (!ModelState.IsValid)
            {
                ViewData["Ticket"] = await _ticketService.GetTicketById(answer.TicketId);
                ViewData["TicketMessages"] = await _ticketService.GetTicketMessages(answer.TicketId);
                return View(answer);
            }

            #endregion

            #region Create Ticket 

            var result = await _ticketService.CreateAnswerTicketAdmin(answer, User.GetUserId());

            if (result)
            {
                TempData[SuccessMessage] = _localizer["mission accomplished"].Value;
                return RedirectToAction("TicketDetail", "Ticket", new { area = "Admin", id = answer.TicketId });
            }

            #endregion

            TempData[ErrorMessage] = _localizer["An error occurred Please try again"];
            ViewData["Ticket"] = await _ticketService.GetTicketById(answer.TicketId);
            ViewData["TicketMessages"] = await _ticketService.GetTicketMessages(answer.TicketId);

            return View(answer);
        }

        #endregion

        #region Change Ticket Status

        public async Task<IActionResult> ChangeTicketStatus(int status, ulong ticketId)
        {
            var result = await _ticketService.ChangeTicketStatus(status, ticketId);

            if (result != string.Empty)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, result, "Success");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "Faild");
        }

        #endregion

        #region Chaneg Ticket On Working Status

        public async Task<IActionResult> ChangeTicketOnWorkingStatus(ulong ticketId)
        {
            var result = await _ticketService.ChangeOnWorkingTicketStatus(ticketId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "Success");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "Faild");
        }

        #endregion

        #region Delete Ticket Message

        public async Task<IActionResult> DeleteTicketMessage(ulong messageId)
        {
            var result = await _ticketService.DeleteTicketMessage(messageId);

            if (result)
            {
                return ApiResponse.SetResponse(ApiResponseStatus.Success, null, "Success");
            }

            return ApiResponse.SetResponse(ApiResponseStatus.Danger, null, "Faild");
        }

        #endregion
    }
}
