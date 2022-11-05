use [DoctorFAMDb]

--Get List Of VIP Users Incoming 
select * From dbo.VIPUserInsertedFromDoctorSystem

--Get List OF Labeled Sicknesses
select * From dbo.LabelOfVIPDoctorInsertedPatient

--Get List Of SMSs That Sent For VIP Patient From Doctor 
select * From dbo.LogForSendSMSToVIPUsersIncomeFromDoctorSystem