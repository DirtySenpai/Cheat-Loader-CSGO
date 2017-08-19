# Nova Hook | Open Source VB.NET Cheat Loader

Hello! My name is Thaisen! I got bored so I started to build a basic cheat loader for whatever you need! The loader currently works off of MyBB for logging in, is HWID locked and validates the user's rank upon logging in. You can setup multiple ranks being allowed, blocking banned users from accessing the program and blocking users who do not fit the needed rank from accessing the program.

I recommend getting the font [Bebas Neue](http://www.dafont.com/bebas-neue.font) as it is just so clean, as well as it's the loader's default font.

The source in here is in no way refined, I spent 3-4 days on this, the first day being 100% dedicated to making the EXTREMELY basic "API" (Really just a database reader) for MyBB.

Although it comes pre-built for MyBB, you could easily update this to work with other forum softwares such as Xenforo. This loader can also be used for other games by going into the source and changing "csgo" to whatever process you want!

I will not be actively updating this project, but I may bring in some new features from time to time when I am bored and have nothing else to do. If you need support, first read the [FAQ](https://github.com/ThaisenPM/CheatLoader/blob/master/README.md#faq). If you still need help contact me on Discord at Thaisen#1989 or [on my Discord server](https://discord.gg/gSkGahq)!

[Click here to download the source](https://github.com/ThaisenPM/CheatLoader/archive/master.zip). By downloading and using the source you agreed to the [License](#license) that comes with the loader.

Do you like what I'm doing with this repo? Wanna show me some love with one click? Why not click that "Star" button up above! It might keep me into this project and keep coming out with new versions for you guys to enjoy with new features you request, better security and overall cleaner code because it's a rats nest right now.

Please read the "known issues" section as it will give some insight to why your loader may not be working. I will try to update it with new information as they become known.

## Contents
- Pre-Setup
    * [Screenshots](#screenshots)

    * [Requirements](#requirements)

- Setup
    * [Video Tutorial](https://github.com/ThaisenPM/Cheat-Loader#video-tutorial)

    * [SQL Setup](#sql)

    * [Web Files](#web)

    * [Web Setup](#web-files)

    * [Loader Setup](#loader-vb)

    * [Updater Setup](#updater-vb)
    
- Post-Setup
    * [Use Instructions](#use-instructions)

    * [Known Issues](#known-issues)

    * [License](#license)

    * [FAQ](#faq)

    * [Credits](#credits)

    * [Possible Updates](#possible-updates)

## Screenshots

<p align="center">
 <img src="https://i.gyazo.com/2bdf51f218a3896a22430b8282922a84.png">
</p>

<p align="center">
 <img src="https://i.gyazo.com/f02408535691e1af49464a14c244d6e3.png">
</p>

<p align="center">
 <img src="https://i.gyazo.com/3c63fa098965ec581d9091c66dbedcf1.png">
</p>

<p align="center">
 <img src="https://i.gyazo.com/fc8abe95befe5915f833739ac9e86f7d.png">
</p>

<p align="center">
 <img src="https://i.gyazo.com/24e7c1aa8d90ddff11827448d3fa67ec.png">
</p>

## Requirements

- A MyBB forum

- An undetected cheat

- Some SUPER BASIC knowledge of PHP and SQL

- Some decent knowledge of VB.NET

## Video tutorial

Coming soon!

## SQL

1. Enter your PHPMyAdmin (Or whatever tool you use for SQL managment) and navigate to your mybb_users.

2. Click on the "Structure" tab at the top of PHPMyAdmin.

3. Now add a new column named "hwid" that is a "varchar" with a max limit of "255"

## Web

Upload the following files to your webserver:

- hwid.php

- hwid_get.php

- status.txt

- usercheck.php

- usercheck_get.php

- version.txt

**OPTIONAL:**

- add a .dll of a cheat to your web server. Re-name it to ayyware.dll and put it into the root of your website (public_html/ayyware.dll)

## Web Files

1. Now navigate to the "hwid_get.php" and "usercheck_get.php" files on your website.

2. At the top of the files are "$link" and "$database".

3. Modify them to work for your website's setup.
    * The checks currently use forums_users, the default install of MyBB will make it mybb_users. Please make sure that they coincide correctly.
    * $link refers to your MySQL login... **NOT** your cPanel login... didn't think I'd have to put that in here

4. In usercheck_get.php, modify the usergroup numbers to match your forums.

5. Go to your MyBB admin panel -> configuration -> general configuration.

6. Set the CAPTCHA field to none.

7. Now to go configuration -> login and registration options

8. Set "Number of times to allow failed logins" to 0

## Loader VB

**Goto Form1.vb**

1. Find "Dim address As String = "http://localhost/version.txt"" and change "localhost" to your website.

2. Now naviagte to line 66 and edit the file names to whatever you like

3. The lines commented from 76-95 check if the loader is on a USB and if steam is open or not. Uncomment if you want those features.

4. Go to line 187 and again edit the domain to your website's MyBB forums (MAKE SURE it has "/member.php?action=login" on the end)

5. Find any lines with "localhost" and change them to your domain

**Goto Form2.vb**

1. Change localhost to your domain

**Goto Form3.vb**

1. Change any instance of "localhost" with your domain.

**Goto Form5.vb**

1. Change the domain in line 77 to your own (This one is the cheat itself)

**Build your loader now, take it and rename it to "loader.exe" and upload it to your website.**

## Updater VB

1. On line 45, change the domain to your own.

2. Build your updater now, take it and rename it to "Updater.exe" and upload it to your website.

## Use Instructions

1. If you update the loader, change the version number in the loader's Form1.vb to the new number and change version.txt on your webserver

2. Change the folders from "C:\temp\Nova" to whatever you want. Do not leave them in this spot.

3. Status.txt on your webserver works like so. 0 = offline. 1 = online. 2 = maintenance.

4. For making an external cheat to work with the menu, create a new form and code it in VB.NET.

5. If you do not want an external cheat, remove the label and adjust the other labels on Form3.vb under the groupbox named cheats.

6. To change where the cheat downloads from goto Form5.vb and edit the link on line 77.

**Congrats you can now sell your paste!**

## Known issues

1. Always getting "Password incorrect" while entering the correct password? Click the "Trouble Logging In? Click Here?" button and sign in and MAKE SURE you click "Remember me". Then click the button on the bottom left and try to sign in again.

2. The usercheck_get.php file DOES NOT work on 000webhost. For whatever reason it will not load on their servers. If you need EXTREMELY cheap hosting, I recommend Hosting24.com. Use the code 1CENT for the first month to cost 1 cent so you have time to setup your loader, cheat and such.

3. If the domains don't change, go to the design tab. On Form1, expand the form size to be big. You will see 3 white boxes. The top right is the MyBB forum link, the bottom right is the usercheck.php and the bottom left is the hwid.php. Change those as well to be sure. Make sure to do the same thing on Form2 so that users experiencing the login failed issue can still get in to their account.

## License

This repo is listed with a [MIT license](https://github.com/ThaisenPM/Cheat-Loader/blob/master/LICENSE) which allows this to be used for commercial use, personal use and distribution and allows for modification of the source BUT does NOT allow me to be liable for what you do with the source and does not offer any warranty.

## FAQ

**Q: Is this a cheat for Counter Strike?**

A: No, this is a tool for being able to sell cheats without giving your .dll file to your users

**Q: Is this only for Counter Strike?**

A: Learn to read the text I wrote... No. In the loader, goto Form5.vb and change line 105 to whatever game you want.

**Q: Is this detected by VAC?**

A: At the time of writing no. But make sure you change the signature of the loader to some extent.

**Q: If I am using this, do I have to give you credit?**

A: [The license for the project](https://github.com/ThaisenPM/Cheat-Loader/blob/master/LICENSE)

**Q: Can I use this for a massive P2C?**

A: Yes, but your stuff WILL get leaked eventually. I'd recommend using this for a private cheat for your friends with a max of like 30 members.

**Q: Do I need a website?**

A: Yes and no. You can make it local only by using a tool such as XAMPP but if you want it to be available for others to use you should get a website. Port forwarding would work too but I advise against it.

## Credits

[JackkTutorials](https://www.youtube.com/channel/UC64x_rKHxY113KMWmprLBPA) for the HWID creation and encryption code.

## Possible Updates

A few things I would possibly do, but don't get your hopes up.

To do:

- [ ] Auto-check user group after being logged in
- [ ] MyBB admin panel to change status and version
- [ ] Clean up login heavily
- [ ] Delayed injections
- [ ] Add a MOTD function

Completed:

- [X] Make dll's remove themselves automatically
