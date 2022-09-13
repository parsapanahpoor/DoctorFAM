using DoctorFAM.Domain.Entities.Doctors;
using SixLabors.ImageSharp.ColorSpaces;

namespace DoctorFAM.Application.StaticTools;

public static class Messages
{
    //This is for sample
    public static string GetMessageForSetConsultationDate(string date, string time, string phone)
    {
        return
            $"باسلام  {Environment.NewLine}در خواست مشاوره شما برای روز {date + " - ساعت  " + time}.{Environment.NewLine} تنظیم شد. لطفا در تاریخ و زمان مقرر با شماره {phone} تماس بگیرید.{Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Wellcoming For Login 
    public static string SendSMSForLogin()
    {
        return
            $"با سلام ،ورود به حساب با موفقیت انجام شده است .{Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send Activation Register Code 
    public static string SendActivationRegisterSms(string activationCode)
    {
        return
            $"باعرض سلام . {Environment.NewLine} کد فعال سازی شما : {activationCode} . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //The invoice of your request has been provided by the pharmacy.
    public static string SendSMSForProvideInvoiceFromPharmacy()
    {
        return
            $"باعرض سلام . {Environment.NewLine} فاکتور درخواست شما از سمت داروخانه ارائه گردیده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //The invoice of your request has been provided by the pharmacy.
    public static string SendSMSForAccepteDrugRequestFromPharamcy()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست سفارش داروی شما از سمت داروخانه قبول شده است . لطفا تا ارائه ی پیش فاکتور صبور باشید. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Delivery Drug By Courier.
    public static string SendSMSForDeliveryDrugByCourier()
    {
        return
            $"باعرض سلام . {Environment.NewLine} بسته ی سفارشی شما تحویل پیک داده شده است و درحال ارسال به شما می باشد. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Accept Family Doctor Request 
    public static string SendSMSForAcceptFamilyDoctorRequest()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست پزشک خانواده ی شما توسط پزشک موردنطر تایید شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Decline Family Doctor Request 
    public static string SendSMSForDeclineFamilyDoctorRequest()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست پزشک خانواده ی شما توسط پزشک موردنطر رد شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }
}