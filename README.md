# MVP
Capstone Assessment
	> Contributors: 
		> Ernest C. King : Mobile # 801-631-2160
		> Terrell R Payne
		> David Dornbrack : Mobile # 719-510-9031
		> Zachary W Janouskovec : Mobile # 440-413-3158
		

--------------------------- README STARTUP INSTRUCTIONS ---------------------------
1. Navigate to "Scripts" folder found in the root folder of the project and run the following SQL scripts in SQL Server.
	a. Schema.SQL (run first)
	b. SeedData.SQL (run second)
	c. LongestHealthPools.SQL 
	d. LongestCampaigns.SQL

2. Open "Capstone.sln" (found in the root folder) in Visual Studio.
	a. Run "Capstone.Web" solution in Visual Studio

3. Open "CampaignManager" project in VS Code. Project can be found in the Angular folder. 
	a. Open terminal and enter "npm start".

4. Click on "Go to page" for "Campaign Manager" to access the rest of the site. 
	a. You will need to login through the login page found in the navbar dropdown to access any main CRUD features. 


--------------------------- API ROUTES ---------------------------

(**) Requires a valid auth token to use. 
({}) Requires a valid model sent as JSON body.
(id) Requires ID after route name (route/{id})

1. Login
	a. POST - https://localhost:5001/api/authentications/login (username, password)

2. Campaigns
	a. GET -    https://localhost:5001/api/campaigns
	b. GET -    https://localhost:5001/api/campaigns (id)
	c. POST -   https://localhost:5001/api/campaigns (**)
	d. PUT -    https://localhost:5001/api/campaigns (**) ({})
	e. DELETE - https://localhost:5001/api/campaigns (**) (id)

3. Characters
	a. GET -    https://localhost:5001/api/characters
	b. GET -    https://localhost:5001/api/characters (id)
	c. POST -   https://localhost:5001/api/characters (**)
	d. PUT -    https://localhost:5001/api/characters (**) ({})
	e. DELETE - https://localhost:5001/api/characters (**) (id)

4. Weapons
	a. GET -    https://localhost:5001/api/weapons
	b. GET -    https://localhost:5001/api/weapons    (id)
	c. POST -   https://localhost:5001/api/weapons    (**)
	d. PUT -    https://localhost:5001/api/weapons    (**) ({})
	e. DELETE - https://localhost:5001/api/weapons    (**) (id)

5. Players
	a. GET -    https://localhost:5001/api/players
	b. GET -    https://localhost:5001/api/players    (id)
	c. POST -   https://localhost:5001/api/players    (**)
	d. PUT -    https://localhost:5001/api/players    (**) ({})
	e. DELETE - https://localhost:5001/api/players    (**) (id)