USE [CLINIC]
GO

Select *from [USER] 1051;
--------------------------------------
CREATE LOGIN [Anna Mozol] WITH PASSWORD = '1';
CREATE USER [Anna Mozol] FOR LOGIN [Anna Mozol];

select *from TimeDoctor

---------------------------------------SEARCH_USER есть ли такой пользоатель----
create function [dbo].[SearchUser]
( @login nvarchar(20),
 @password nvarchar(50))
returns int
as begin
Declare @a int =0;
if  exists (select [LOGIN] from [dbo].[USER] where [LOGIN]=@login and [PASSWORD]=@password) set @a=1;  
	else set @a=0;
	return @a;
end
GO
-------------------------------------Getting_access---------------------------------
create function [dbo].[Getting_access]
(
@login nvarchar(20)
)
 returns int
 as begin 
 Declare @id int;
 select @id = [ACCESS] from [USER]
 where LOGIN=@login
 return @id
 end
 GO

  --------------------------------------------Take_id_user_ByLogin----------------
 create function Take_iduser_byLog
(
@login nvarchar(20)
)
 returns int
 as begin 
 Declare @id int = (select [Id_user] from [dbo].[USER] where [Login]=@login);
 return @id;
 end
 go
 
 ----------------------------------------IfEmpty-----------------------
create function IfEmpty (@login nvarchar(20))
returns int
as begin 
Declare @a int =0;
if  exists (select [LOGIN] from [dbo].[USER] where LOGIN=@login) set @a=1;  
	else set @a=0;
	return @a;
	END;
	go

------------------------------------------InsertUser--------------------------
Alter PROCEDURE InsertUser
	@login nvarchar(20),
	@password nvarchar(50),
	@access int
	AS BEGIN
	begin try
		INSERT INTO [dbo].[USER] ([LOGIN], [PASSWORD], [Access])
			VALUES(@login, @password, @access); 
		 declare @id_us int = (select top(1) [Id_user] from [dbo].[USER]  where [Login] = @login order by [Id_user] desc); 
		 exec CreateProfile @id_us;
		 exec CreateCard @id_us;
			COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

---------------------------INSERT DOCTOR----------------
	Create PROCEDURE InsertDoc
	@login nvarchar(20),
	@password nvarchar(50),
	@access int
	AS BEGIN
	begin try
		INSERT INTO [dbo].[USER] ([LOGIN], [PASSWORD], [Access])
			VALUES(@login, @password, @access); 
		 declare @id_us int = (select top(1) [Id_user] from [dbo].[USER]  where [Login] = @login order by [Id_user] desc); 
		 exec CreateProfile @id_us;
		 exec CDoctor @id_us;
			COMMIT
			end try
begin catch
print error_message()
end catch
	END;
	GO

	exec InsertDoc @login = 'doc',@password = '123456', @access = '1';
	select *from [USER];
	select *from [Profile];
	select *from [DOCTOR];

drop procedure InsertDoc;
--------------------------------------CREATE PROFILE------------------
Alter Procedure CreateProfile
(@id_us int)
as begin
begin try insert [dbo].[Profile](Id_user) values (@id_us);
commit
 end try
begin catch
print error_message()
end catch
 END;
	GO

--------------------------------------CREATE HEALTH CARD------------------
Create Procedure CreateCard
(@id_us int)
as begin
begin try insert [dbo].[Health_card](Id_user) values (@id_us);
commit
 end try
begin catch
print error_message()
end catch
 END;
	GO

--------------------------------------CREATE DOCTOR------------------
Create Procedure cDoctor
(@id_us int)
as begin
begin try insert [dbo].[DOCTOR](Id_user) values (@id_us);
commit
 end try
begin catch
print error_message()
end catch
 END;
	GO

--------------------------------UPDATE PROFILE
Create PROCEDURE Update_Profile
@id_us int,
@Name nvarchar(20),
@Surname nvarchar(40),
@Ages date,
@Phone_number nvarchar(50),
@Address nvarchar(50),
@Image nvarchar(max),
@Init nvarchar(40)
AS
	UPDATE [Profile] 
	SET
		[Name] = @Name,
		[Surname] = @Surname,
		[Age] = @Ages,
		[Phone_number] = @Phone_number,
		[Address] = @Address,
		[Image] = @Image,
		[Init] = @Init
	WHERE [Profile].[Id_user] = @id_us;
GO

--------------------------------Add_Doc's_Init
Create PROCEDURE [Add_Doc's_Init]
@id_us int,
@Init nvarchar(40)
AS
	UPDATE [DOCTOR] 
	SET
		[Initial_doc] = @Init
	WHERE [DOCTOR].[Id_user] = @id_us;
GO
  
  select *from [Profile];
  exec  [Add_Doc's_Init]  @id_us = '1024', @Init = 'Mozol Anya';
  select *from [DOCTOR];

----------------------------------Loading_Name-------------------------------
CREATE Alter PROCEDURE Loading_Name
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Name] FROM [dbo].[Profile] WHERE [Id_user] = @id_us) = NULL
	begin
	SELECT 'A' AS QWE;
	end
	ELSE
	begin
	SELECT [Name] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
		 end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO
----------------------------------Loading_Surname-------------------------------
CREATE Alter PROCEDURE Loading_Surname
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Surname] FROM [dbo].[Profile] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Surname] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

----------------------------------Loading_Phone-------------------------------
CREATE Alter PROCEDURE Loading_Phone
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Phone_number] FROM [dbo].[Profile] WHERE [Id_user] = @id_us) = NULL
		SELECT 'A' AS QWE
		else
		SELECT [Phone_number] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

----------------------------------Loading_Address-------------------------------
CREATE Alter PROCEDURE Loading_Address
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Address] FROM [dbo].[Profile] WHERE [Id_user] = @id_us) = NULL
		SELECT 'A' AS QWE
		else
		SELECT [Address] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

----------------------------------Loading_Image-------------------------------
CREATE ALTER PROCEDURE Loading_Image
@id_us int
AS BEGIN
	begin try
		SELECT [Image] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

--------------------------------Update_Information_About_Doctor
Create PROCEDURE [Update_Information_About_Doctor]
@id_us int,
@About_doctor nvarchar(max),
@Id_specialty int
AS
	UPDATE [DOCTOR] 
	SET
		[Id_specialty] = @Id_specialty,
		[About_doctor] = @About_doctor
	WHERE [DOCTOR].[Id_user] = @id_us;
GO

--------------------------------Update_TimeDoctor
Create PROCEDURE Update_TimeDoctor
@id_us int,
@kol int,
@day int
AS
	UPDATE [TimeDoctor]
	SET [Day] = @day
	WHERE [TimeDoctor].[Id_doctor] = @id_us;
GO

----------------------------------Get_id_doc_by_id_user-------------------------------
create function Get_IdDoc
(@id_us int)
returns int
 AS BEGIN
 Declare @id_doc int = (select [Id_doctor] from [dbo].[DOCTOR] where [Id_user]=@id_us);  
  return @id_doc;
  END;
	GO

----------------------------------DeletTimeDoctor_by_day------------------------------
CREATE PROCEDURE DeletTimeDoctor_by_day
@id_doc int,
@day int
AS BEGIN
	begin try
		DELETE FROM [dbo].[TimeDoctor] WHERE [Id_doctor] = @id_doc and [Day] = @day;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

-----!!!!!
--------------------------------Loading_TimeDoctor if the first smena
create procedure iitd
@id_doc int,
@day int
AS
begin
DECLARE @kol int
set @kol = 1
while (@kol<12)
begin 
insert into [TimeDoctor] (Id_doctor, Day, Id_time) values (@id_doc, @day,@kol)
set @kol = @kol +1
END
end
select *from TimeDoctor 
--------------------------------Loading_TimeDoctor if the second smena
create procedure iitd2
@id_doc int,
@day int
AS
begin
DECLARE @kol int
set @kol = 12
while (@kol<24)
begin 
insert into [TimeDoctor] (Id_doctor, Day, Id_time) values (@id_doc, @day,@kol)
set @kol = @kol +1
END
end

-----------------------------------Update_Information_In_Health_Card
Create alter PROCEDURE Update_Information_In_Health_Card
(
@id_us int,
@Chronic_disease nvarchar(max),
@Test_results nvarchar(max),
@Diagnosis nvarchar(max),
@Treatment nvarchar(max)
)
AS UPDATE [Health_card]
	SET
[Chronic_disease] = @Chronic_disease,
[Test_results] = @Test_results,
[Diagnosis]= @Diagnosis,
[Treatment] = @Treatment
WHERE [Health_card].[Id_user] = @id_us;
go

------------------------------------Loading_IdCard_by_Id_us-------------------------------
CREATE PROCEDURE Loading_IdCard_by_Id_us
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Id_card] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Id_card] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Height-------------------------------
CREATE PROCEDURE Loading_Height
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Height] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Height] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Age-------------------------------
CREATE PROCEDURE Loading_Age
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Age] FROM [dbo].[Profile] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Age] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO
------------------------------------Loading_Weight-------------------------------
CREATE PROCEDURE Loading_Weight
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Weight] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Weight] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Chronic_disease-------------------------------
CREATE PROCEDURE Loading_Chronic_disease
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Chronic_disease] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Chronic_disease] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Test_Result-------------------------------
CREATE PROCEDURE Loading_Test_Result
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Test_results] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Test_results] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Diagnosis-------------------------------
CREATE PROCEDURE Loading_Diagnosis
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Diagnosis] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Diagnosis] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_Treatment-------------------------------
CREATE PROCEDURE Loading_Treatment
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Treatment] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us) = NULL
	begin
	 SELECT 'A' AS QWE;	 
	 end
  else 
  begin
  SELECT [Treatment] FROM [dbo].[Health_card] WHERE [Id_user] = @id_us;
  end
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_specialty
CREATE ALTER PROCEDURE Loading_specialty
@id_us int
AS BEGIN
	begin try
	IF (SELECT [Name_specialty] FROM [dbo].[Specialty] WHERE [Id_specialty] = (select [Id_specialty] from [dbo].[DOCTOR] where [Id_user] = @id_us)) = NULL
	BEGIN
	SELECT 'A' AS QWE
	END
			else
			BEGIN
			select Name_specialty from Specialty
			where Id_specialty = (SELECT [Id_specialty] FROM [dbo].[DOCTOR] WHERE [Id_user] = @id_us);
			END
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Loading_About_Doctor
CREATE ALTER PROCEDURE Loading_AboutDoc
@id_us int
AS BEGIN
	begin try
	IF (SELECT [About_doctor] FROM [dbo].[DOCTOR] WHERE [Id_user] = @id_us) = NULL
	BEGIN
		SELECT 'A' AS QWE
		END
		else
		BEGIN
		SELECT [About_doctor] FROM [dbo].[DOCTOR] WHERE [Id_user] = @id_us;
		END
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO
----------!!!!!!
-------------------------------------Get_work_time---выводим выбранное врачом время
CREATE alter PROCEDURE Get_work_time
@id_doc int
AS BEGIN
	begin try
select distinct tu.[AllTime] AS time_doc, td.[Day] as day_doc from TimeUser tu
	join TimeDoctor td on tu.Id = td.Id_time
	where td.Id_doctor = @id_doc; 
 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

-----------------------------------GetTimeDoctor------------------------получаем разрешённое время доктора
Alter PROCEDURE GetTimeDoctor
@id_doctor int,
@date_doctor int
AS BEGIN
	begin try
	select [Time] from TimeUser
		where Id in (select Id_time from TimeDoctor 
						where Id_doctor = @id_doctor
							and [Day] = @date_doctor
							and [IsBusy] = 0)
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

---------------------------Get_Talon_Doctor
CREATE Alter PROCEDURE GetTalonDoctor
@id_user int,
@time_doctor nvarchar(20)
AS BEGIN
	begin try
	update TimeDoctor
		set IsBusy = 1
			where Id_time = (select Id  from TimeUser where [Time] = @time_doctor)
	insert into Timetable (Id_time_doctor, Id_card)
		values ((select Id_time_doctor from TimeDoctor where Id_time = (select Id  from TimeUser where [Time] = @time_doctor)), @id_user);
	
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

------------------------------------Get_AboutDoc_by_Init_doc
CREATE function Get_AboutDoc_by_Init_doc
(@init_doc nchar(30))
returns nvarchar(max)
AS begin 
		declare @Ab_doc nvarchar(max) = (SELECT [About_doctor] FROM [dbo].[DOCTOR] WHERE [Initial_doc] = @init_doc);
		return @Ab_doc;
	END; 
GO
------------------------------------Get_Id_doc_by_Init_doc
CREATE Alter function Get_Id_doc_by_Init_doc
(@init_doc nchar(30))
returns int
AS begin 
		declare @id_doc int = (SELECT [Id_doctor] FROM [dbo].[DOCTOR] WHERE [Initial_doc] = @init_doc);
		return @id_doc;
	END; 
GO

------------------------------------Get_Id_us_by_Init_us
Alter function Get_Id_us_by_Init_us
(@init_us nvarchar(40))
returns int
AS begin 
		declare @id_us int = (SELECT [Id_user] FROM [dbo].[Profile] WHERE [Init] = @init_us);
		return @id_us;
	END; 
GO
------------------------------------GetAboutSpeciltybyId
CREATE function Get_About_Specilty_byId
(
@id_spec int)
returns nvarchar(max)
as begin
declare @ab_spec nvarchar(max) = (select [About_specialty] from [dbo].[Specialty] where [Id_specialty]=@id_spec);
	return @ab_spec	;
	END
GO

drop proc Get_doc_by_doc

------------------------------------GetDoctordyIdSpec
CREATE PROCEDURE Get_doc_by_idspec
@id_spec int
AS BEGIN
	begin try
		SELECT [Initial_doc] FROM [dbo].[DOCTOR] WHERE [Id_specialty] = @id_spec;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO
-------------------------список пациентов у врача
CREATE PROCEDURE Get_users_for_doctor
@id_doc int
AS BEGIN
	begin try
	select [Init] from [Profile]
		where Id_user in (select Id_user from Health_card
							where Id_card in (select Id_card from Timetable
												where Id_time_doctor in (select Id_time_doctor from [TimeDoctor]
																			where Id_doctor = @id_doc)));
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO

----------------------------------------SearchAboutDoctor---------------------------------
Create PROCEDURE SearchDoc
@name nvarchar(60)
 AS BEGIN
 begin try
 declare @name2 nvarchar(60)='FORMSOF(INFLECTIONAL,"'+@name+'")'; 
select [About_specialty] from [dbo].[Spec] where CONTAINS([About_specialty],@name2);
 end try
 begin catch
print error_message()
end catch
  END;
	GO


	-----------------------------------------
	------------------------------------------
	--------------------------------------------
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	Create PROCEDURE Loading_Use
@id_us int
AS BEGIN
	begin try
		SELECT [Init] FROM [dbo].[Profile] WHERE [Id_user] = @id_us;
		 IF (@@error <> 0)
        ROLLBACK
			COMMIT;
			end try
begin catch
print error_message()
end catch
	END; 
GO