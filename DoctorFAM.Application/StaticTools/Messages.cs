﻿using DoctorFAM.Domain.Entities.Doctors;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using SixLabors.ImageSharp.ColorSpaces;

namespace DoctorFAM.Application.StaticTools;

public static class Messages
{
    //Wellcoming Message
    public static string WellcomingMessage(string userName)
    {
        return
            $"{userName} عزیز خوش آمدید. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

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

    //Send SMS For Accepted Request From Nurse 
    public static string SendSMSForAcceptedRequestFromNurse()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست شما برای پرستار از سمت پرستار تایید شده است. . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Accept Online Visit Request From Doctor  
    public static string SendSMSForAcceptOnlineVisitRequestFromDoctor()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست ویزیت آنلاین شما توسط پزشک تایید شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Accept Consultant Request 
    public static string SendSMSForAcceptConsultantRequest()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست مشاوره ی شما توسط مشاور موردنطر تایید شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Decline Consultant Request 
    public static string SendSMSForDeclineConsultantRequest()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست مشاوره ی شما توسط مشاور موردنطر رد شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Accept Home Visit Request From Doctor  
    public static string SendSMSForAcceptHomeVisitRequestFromDoctor()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست ویزیت درمنزل شما توسط پزشک تایید شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send Activation Register Code 
    public static string SendSMSForLinkOfHomeVisitRequestFromDoctor(string link)
    {
        return
            $"لطفا از طریق لینک زیر درخواست ویزیت در منزل خود را تایید کنید :{Environment.NewLine} {link} . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Accept Home Visit Request From User   
    public static string SendSMSForAcceptHomeVisitRequestFromUser(int price)
    {
        return
            $"ضمن عرض سلام و خسته نباشید . {Environment.NewLine} اعلام آمادگی شما توسط کاربر تایید شده و مبلغ - ریال به کیف پول شما در سایت واریز شده است. {Environment.NewLine} لطفا در زمان اعلام شده نسبت به اعزام به محل درخواست اقدام فرمایید. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Decline Home Visit Request From User   
    public static string SendSMSForDeclineHomeVisitRequestFromUser()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست ویزیت درمنزل همراه با اطلاعات شما توسط کاربر تایید نگردید . {Environment.NewLine} از همکاری شما متشکریم. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Cancelation Home Visit Request From User   
    public static string SendSMSForCancelationHomeVisitRequestFromUser()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست ویزیت درمنزل توسط کاربر لغو شده است . {Environment.NewLine} از همکاری شما متشکریم. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Death Certificate Request From Doctor  
    public static string SendSMSForAcceptDeathCertificateRequestFromDoctor()
    {
        return
            $"باعرض سلام . {Environment.NewLine} درخواست صدورگواهی فوت شما توسط پزشک تایید شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send Show Doctor Details 
    public static string SendSMSForLinkOfDeathCertificateRequestFromDoctor(string link)
    {
        return
            $"شما میتوانید از طریق لینک زیر اطلاعات پزشک را مشاهده فرمایید : {link} . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS From Doctor To The Users That Income From Parsa System
    public static string SendSMSFromDoctorToTheUsersThatIncomeFromParsaSystem(string smsBody)
    {
        return
            $"{smsBody} {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS To The Master Of Population Cover
    public static string SendSMSToTheMasterOfPopulationCover(string nationalId, string mobile)
    {
        return
                 $"فردی از جمعیت تحت پوشش شما با شماره موبایل : {mobile} و کدملی : {nationalId} عضو سایت شده است.{ Environment.NewLine} این کاربر از جمعیت تحت پوشش شما خارج می گردد . {Environment.NewLine} {PathTools.SiteFarsiName}" ;
    }

    //Send SMS For Weekly Usage Of Drug 
    public static string SendSMSForWeeklyUsageOfDrug(string DrugName)
    {
        return
                 $"باعرض سلام . داروهای مصرفی امروز شما : {DrugName} . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Priodic Test Alarm 
    public static string SendSMSForPriodicTestAlarm(string priodicTestName)
    {
        return
                 $"باعرض سلام . فردا نوبت آزمایش {priodicTestName} شما می باشد. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS For Medical Examination Alarm 
    public static string SendSMSForMedicalExaminationAlarm(string medicalExaminationName)
    {
        return
                 $"باعرض سلام . فردا نوبت معاینه ی  {medicalExaminationName} شما می باشد. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS To The Doctor For Accept His Send SMS Request 
    public static string SendSMSToTheDoctorForAcceptHisSendSMSRequest(string dateTime)
    {
        return
         $" باعرض سلام .{Environment.NewLine} درخواست ارسال پیامک شما برای کاربران سایت تایید و پیامک مورد نظر شما در تاریخ {dateTime} ارسال گردید. {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS To The Doctor For Reject His Send SMS Request 
    public static string SendSMSToTheDoctorForRejectHisSendSMSRequest(string rejectDescription)
    {
        return
         $" باعرض سلام .{Environment.NewLine}  درخواست ارسال پیامک شما به دلیل '{rejectDescription}' رد شده است . {Environment.NewLine} {PathTools.SiteFarsiName}";
    }

    //Send SMS From Doctor To The Patient 
    public static string SendSMSFromDoctorToThePatient(string textBody)
    {
        return
         $" {textBody} {Environment.NewLine} {PathTools.SiteFarsiName}";
    }
}