USE MASTER;

ALTER DATABASE CampaignManager_DB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;


DROP DATABASE IF EXISTS CampaignManager_DB
GO



CREATE DATABASE CampaignManager_DB
GO



USE CampaignManager_DB;



CREATE TABLE Campaign(
    Id int primary key identity(1,1),
    [Name] varchar(50) not null,
    DateStarted date not null,
    DateEnded date null
);



CREATE TABLE Player(
    Id int primary key identity(1,1),
    [Name] varchar(50) not null,
    Phone varchar(50) null,
    Email varchar(50) null,
    City varchar(50) null
);



CREATE TABLE Weapon(
    Id int primary key identity(1,1),
    [Name] varchar(50),
    Damage int not null default(4),
    [Range] int not null,
    [Description] varchar(100) not null
);



GO
CREATE TABLE [Character](
    Id int primary key identity(1,1),
    PlayerId int not null,
    CampaignId int null,
	[Name] varchar(50) not null,
    [Level] int not null default(1),
    ArmorClass int not null default(1),
    HitPoints int not null default(1),
    Strength int not null default(1),
    Dexterity  int not null default(1),
    Constitution  int not null default(1),
    Intelligence  int not null default(1),
    Wisdom  int not null default(1),
    Charisma  int not null default(1),
    Race varchar(50) not null,
    Alignment varchar(50) not null,
    Class varchar(50) not null,
    [Image] varchar(250) null
    constraint fk_Character_Player_PlayerId
        foreign key(PlayerId)
        references Player(Id),
    constraint fk_Character_Campaign_CampaignId
        foreign key(CampaignId)
        references Campaign(Id),
);



CREATE TABLE CharacterWeapon(
    CharacterId int not null,
    WeaponId int not null,
    Quantity int not null default(1),
    constraint fk_CharacterWeapon_Character_CharacterId
        foreign key(CharacterId)
        references Character(Id),
    constraint fk_CharacterWeapon_Weapon_WeaponId
        foreign key(WeaponId)
        references Weapon(Id),
   constraint pk_CharacterWeapon_CharacterId_WeaponId
        primary key(CharacterId, WeaponId)
);


Create Table [Login]
(
	Id Uniqueidentifier Primary Key,
	UserName varchar (256) not null,
	[Password] nvarchar (256) not null,
	DateCreated date not null Default GetDate(),
	PlayerId int null
);


Begin Tran
Insert Into [Login] (UserName, [Password], Id) 
Values 
	('johncitizen',	PwdEncrypt('abc@123'), NewID()),
	('ErnestKing',	PwdEncrypt('MySpecialPassword!23'), NewID())


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
Use CampaignManager_DB;
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
		l.PlayerId
	From [Login] As l
	Where l.UserName = @userId
		And PWDCOMPARE(@password, l.[Password]) = 1
END
GO

CREATE PROCEDURE AddLogin
	-- Add the parameters for the stored procedure here
	@userId nvarchar (265),
	@password nvarchar (256),
	@playerId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Insert Into [Login] (UserName, [Password], Id, PlayerId)
	Values 
		(@userId,	PwdEncrypt(@password), NewID(), @playerId)
END
GO

CREATE PROCEDURE DeleteLogin
	-- Add the parameters for the stored procedure here
	@userId nvarchar (265)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete From [Login]
	Where UserName = @userId
END
GO

Exec LoginVerification @userId = 'johncitizen', @password = 'abc@123';