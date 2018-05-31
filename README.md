# Titans of URF

[www.titansofurf.com](http://www.titansofurf.com "Titans of URF")

Titans of URF was made for Riot's API contest.  We recorded data from 1,500 Ultra Rapid Fire games from 4/5/2015 to 4/11/2015. Specifically, we looked at the top 5 played champions and top 5 banned champions.  This contest was a lot of fun and a big challenge!

## What does it do?

#### Front-End 
- Displays the top 5 played champions and how frequently they are played (percentage of all URF games)
- Displays top 5 banned champions and how frequently they are banned (percentage of all URF games)
- Displays champions with randomized skin selection

#### Admin-Section
- Downloads URF matches from API (api-challenge-v4.1 not updating as of 4/11/2014)
- Match data from returned URF match IDs will be downloaded (using match-v2.2 endpoint)

#### Back-End
- URF match IDs and match information are stored in the database
- Top 5 Played and Banned Champs are calculated on site load


## Technology Stack
- ASP.NET MVC 4.0 (Routing and collecting data from API)
- NHibernate (MySQL Database)
- Bootstrap + Razor (Front-End)

## Get up and running

Disclaimer: We are pretty new to ASP.NET and haven't shared a project before.



1. Clone or download the repo 
2. Launch MySQL database (I recommend XAMPP if on windows)
3. Import Database backup provided
3. Enter your API key into the config.cs class
4. Enter your database information in the connection string of the web.config
5. Launch the site (fingers crossed)

## To-do List
- Design points:
	- HEX design for champion display
	- Ban symbols over banned champion display
	- Font, logo, and color theme updates
- Finish Up the Admin Section
- Add the ability to pull data from different End points
- Add the ability for admin to display different top 5 lists on the front end
- Clean up API and database fetching code

## Created By
- Sam Russell







