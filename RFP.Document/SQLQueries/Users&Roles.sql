use [DoctorFAMDb]

--Active New Incoming User
update dbo.Users
set IsMobileConfirm = 1
where Mobile = '09117878822'

--Get User By Mobile 
select * 
from dbo.Users
where Mobile = '09217878804'

--Get User By User Id
select * 
from dbo.Users
where Id = 78

--Get Users That Has Role
select dbo.Users.Id as UserId , userRoles.RoleId as RoleId
from dbo.Users
inner Join UserRoles as userRoles
On Users.Id = userRoles.UserId
where dbo.Users.Mobile = '09117878822'

--Get Users Without Role
select dbo.Users.Id as UserId , userRoles.RoleId as RoleId
from dbo.Users
left Join UserRoles as userRoles
On Users.Id = userRoles.UserId
where userRoles.Id IS NULL

--Get Roles
select * 
from Roles

--Get All Of Users Cooperation Request 
select * from CooperationRequests

---List OF Doctors With Thier User Informations 
SELECT Users.Username, Users.NationalId , Users.LastName , Users.FirstName
FROM Doctors
INNER JOIN Users ON Doctors.UserId = Users.Id;

--- List Of Users Whitout Doctors ---
SELECT FirstName , LastName  , Username , NationalId , Mobile 
FROM Users 
WHERE Users.Id  NOT IN  (SELECT Users.Id
					FROM Users
					INNER JOIN Doctors ON  Users.Id =Doctors.UserId);
             

