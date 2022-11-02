Use master;
GO

ALTER DATABASE CampaignManagerLoginDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;

Drop Database if exists CampaignManagerLoginDB;
GO

Create Database CampaignManagerLoginDB;
GO

Use CampaignManagerLoginDB;
GO

Create Table [Login]
(
	Id Uniqueidentifier Primary Key,
	UserName varchar (256) not null,
	[Password] nvarchar (256) not null,
	DateCreated date not null Default GetDate(),
	IsValid bit not null
);


Begin Tran
Insert Into [Login] (UserName, [Password], Id, IsValid) 
Values ('johncitizen',	PwdEncrypt('abc@123'), NewID(), 1)

Select * From [Login]
Commit;


-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ernest
-- Create date: 2022-October-17
-- Description:	Verify User Login Information
-- =============================================
Use CampaignManagerLoginDB;
GO

CREATE PROCEDURE LoginVerification
	-- Add the parameters for the stored procedure here
	@userId nvarchar (265),
	@password nvarchar (256)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
		l.Id,
		l.UserName,
		l.DateCreated,
		l.IsValid
	From [Login] As l
	Where l.UserName = @userId
		And PWDCOMPARE(@password, l.[Password]) = 1
		And l.IsValid = 1
END
GO

Exec LoginVerification @userId = 'johncitizen', @password = 'abc@123';