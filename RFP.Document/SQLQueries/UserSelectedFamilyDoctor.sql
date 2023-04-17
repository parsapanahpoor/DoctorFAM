use [DoctorFAMDb]

--Update All Of Last Fields From 1402 For New Update After 1402--
UPDATE UserSelectedFamilyDoctor
SET IsUserInDoctorPopulationCoveredOutOfDoctorFAM = 1
WHERE IsDelete = 0;