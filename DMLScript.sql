USE CampaignManager_DB;

INSERT INTO Campaigns([Name], DateStarted, DateEnded)
	VALUES 
		('Strixhaven', '07-12-2020', '08-20-2021'),
		('Tales From Ravnica', '08-20-2020', '10-20-2021'),
		('The Waldorf Chronicles', '01-14-2014', '10-05-2017'),
		('Descent Into Avernus', '04-20-2015', '07-26-2017'),
		('The Fall of the Saltmarshes', '03-15-2010', '10-14-2016'),
		('The West Marches', '09-12-2015', '09-15-2016'),
		('The Botanists Curse', '09-12-2015', '09-15-2016'),
		('Curse of Strahd', '08-10-2012', '01-05-2013'),
		('Journey into Waterdeep', '04-29-2019', '04-05-2020');

INSERT INTO Players([Name], Phone, Email, City)
	VALUES 
		('Zachary Janouskovec', '4404133158', 'Zachary_W_Janouskovec@Progressive.com', 'Painesville'),
		('Ernest King', '1234567890', 'Ernest_King@Progressive.com', 'Mentor'),
		('Terrell Payne', '1234567890', 'Terrell_Payne@Progressive.com', 'Seattle'),
		('David Dornbrack', '1234567890', 'David_Dornbrack@Progressive.com', 'San Jose');

INSERT INTO Weapons([Name], Damage, [Range], [Description])
	VALUES 
		('Club', '4', '5', '1d4 Bludgeoning Damage, Light'),
		('Dagger', '4', '5', '1d4 Piercing, Finesse, Light, Thrown (Range 20/60)'),
		('Great Club', '8', '10', '1d4 Piercing, Finesse, Light, Thrown (Range 20/60)'),
		('Handaxe', '6', '5', '1d8 Bludgeoning, Two-Handed'),
		('Javelin', '6', '5', '1d6 Piercing	Thrown, (Range 30/120)'),
		('Light Hammer', '4', '5', 'Light, Thrown (Range 20/60)'),
		('Spear', '6', '10', 'Thrown (Range 20/60), Versatile (1d8)');

INSERT INTO Characters(PlayerId, CampaignId, [Level], ArmorClass, HitPoints, Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma, Race, Alignment, Class, [Image])
	VALUES 
		('1', '1', '5', '18', '46', '18', '8', '14', '8', '9', '14', 'Aasimar', 'Lawful Good', 'Paladin', 'https://www.imageoofsomethingorother.com'),
		('2', '1', '5', '14', '22', '8', '14', '12', '18', '8', '16', 'Tiefling', 'Chaotic Neutral', 'Wizard', 'https://www.imageoofsomethingorother2.com'),
		('3', '1', '5', '15', '36', '10', '16', '14', '10', '18', '12', 'Half-Orc', 'Neutral Evil', 'Warlock', 'https://www.imageoofsomethingorother3.com'),
		('4', '1', '5', '16', '52', '16', '12', '18', '8', '8', '16', 'Human', 'Neutral Good', 'Cleric', 'https://www.imageoofsomethingorother4.com');


INSERT INTO CharacterWeapons(CharacterId, WeaponId, Quantity)
	VALUES
		('1', '3', '1'),
		('2', '5', '1'),
		('3', '2', '2'),
		('4', '4', '2');

SELECT * FROM Weapons
