using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFAM.Domain.Enums.OnlineVisitRequest
{
    public enum OnlineVisitRequestType
    {
        [Display(Name = "مشاوره ی اورژانس")]
        EmergencyConsultation,
        [Display(Name = "مشاوره ی بیماری")]
        DiseaseCounseling,
        [Display(Name = "مشاوره ی دارویی")]
        DrugCounseling,
        [Display(Name = "مشاوره ی پاراکلینیک")]
        ParaclinicalCounseling, 
        [Display(Name = "مشاوره ی روان")]
        PsychologicalCounseling,
    }
}
