use master;
Drop database if exists CampaignManager_DB
GO
Create database CampaignManager_DB
GO

Use CampaignManager_DB;

create table Campaigns(
    id int primary key identity(1,1),
    [Name] varchar(50) not null,
    DateStarted date not null,
    DateEnded date null
);

create table Players(
    id int primary key identity(1,1),
    [Name] varchar(50) not null,
    Phone varchar(50) null,
    Email varchar(50) null,
    City varchar(50) null
);

create table Weapons(
    id int primary key identity(1,1),
    [Name] varchar(50),
    Damage int not null,
    [Range]int not null
);

GO
create table [Characters](
    id int primary key identity(1,1),
    PlayerId int not null,
    CampaignId int not null,
    [Level] int not null,
    ArmorClass int not null,
    HitPoints int not null,
    Strength int not null,
    Dexterity  int not null,
    Constitution  int not null,
    Intelligence  int not null,
    Wisdom  int not null,
    Charisma  int not null,
    Race varchar(50) not null,
    Alignment varchar(50) not null,
    Class varchar(50) not null,
    [Image] varchar(250) not null
    constraint fk_Character__Players_PlayerId
        foreign key(PlayerId)
        references Players(Id),
    constraint fk_Character__Campaigns_CampaignId
        foreign key(CampaignId)
        references Campaigns(Id),
);

create table CharacterWeapons(
    CharacterId int not null,
    WeaponId int not null,
    Quantity int not null default(1),
    constraint fk_CharacterWeapons__Characters_CharacterId
        foreign key(CharacterId)
        references Characters(Id),
    constraint fk_CharacterWeapons__Weapons_WeaponId
        foreign key(WeaponId)
        references Weapons(Id),
   constraint Pk_CharacterWeapon_CharacterId_WeaponId
        primary key(CharacterId, WeaponId)
);