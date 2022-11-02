USE MASTER;



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
    CampaignId int not null,
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
    [Image] varchar(250) not null
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