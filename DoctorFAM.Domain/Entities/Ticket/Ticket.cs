using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorFAM.Domain.Entities.Account;
using DoctorFAM.Domain.Entities.Common;
using DoctorFAM.Domain.Enums;
using DoctorFAM.Domain.Enums.Ticket;

namespace DoctorFAM.Domain.Entities.Contact
{
    public class Ticket : BaseEntity
    {
        #region Properties

        [Display(Name = "ارسال کننده")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong OwnerId { get; set; }

        [Display(Name = "کاربر هدف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public ulong? TargetUserId { get; set; }

        [Display(Name = "عنوان")]
        [MaxLength(200, ErrorMessage = "تعداد کاراکتر های {0} نمیتواند بیشتر از {1} باشد")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "وضعیت تیکت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public TicketStatus TicketStatus { get; set; }

        public bool IsReadByAdmin { get; set; }

        public bool IsReadByOwner { get; set; }

        public bool IsReadByTargetUser { get; set; }

        public bool OnWorking { get; set; }

        public bool OnlineVisitRequest { get; set; }

        public bool ConsultantRequest { get; set; }

        public bool TicketForAdminAndSupporters { get; set; }

        public ulong? RequestId { get; set; }

        public ulong? RequesConsultanttId { get; set; }

        public TicketSenderType TicketSenderType { get; set; }

        #endregion

        #region Relations

        [ForeignKey("OwnerId")]
        [InverseProperty("Tickets")]
        public User Owner { get; set; }

        [ForeignKey("TargetUserId")]
        [InverseProperty("TicketTargetUser")]
        public User? TargetUser { get; set; }

        public ICollection<TicketMessage> TicketMessages { get; set; }

        #endregion
    }
}
