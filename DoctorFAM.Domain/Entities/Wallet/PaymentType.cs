using System.ComponentModel.DataAnnotations;

namespace DoctorFAM.Domain.Entities.Wallet;

public enum PaymentType
{
    [Display(Name = "Charge Wallet")]
    ChargeWallet = 0,

    [Display(Name = "Buy")]
    Buy = 1,

    [Display(Name = "HomeVisit")]
    HomeVisit = 2,

    [Display(Name = "HomeNurse")]
    HomeNurse = 3,

    [Display(Name = "DeathCertificate")]
    DeathCertificate = 4,

    [Display(Name = "HomeLabortory")]
    HomeLaboratory = 5,

    [Display(Name = "HomePatientTransport")]
    HomePatientTransport = 6,

    [Display(Name = "HomePharmacy")]
    HomePharmacy = 7,

    [Display(Name = "Reservation")]
    Reservation = 8,
}