# Nova Hook | Open Source VB.NET Cheat Loader

Hello! My name is Thaisen! I got bored so I started to build a basic cheat loader for whatever you need! The loader currently works off of MyBB for logging in, is HWID locked and validates the user's rank upon logging in. You can setup multiple ranks being allowed, blocking banned users from accessing the program and blocking users who do not fit the needed rank from accessing the program.

The source in here is in no way refined, I spent 3-4 days on this, the first day being 100% dedicated to making the EXTREMELY basic "API" (Really just a database reader) for MyBB.

Although it comes pre-built for MyBB, you could easily update this to work with other forum softwares such as Xenforo. This loader can also be used for other games by going into the source and changing "csgo" to whatever process you want!

I will not be actively updating this project, but I may bring in some new features from time to time when I am bored and have nothing else to do. If you need support, first read the [FAQ](https://github.com/ThaisenPM/CheatLoader/blob/master/README.md#faq). If you still need help contact me on Discord at Thaisen#1989 or [on my Discord server](https://discord.gg/gSkGahq)!

[Click here to download the source](https://github.com/ThaisenPM/CheatLoader/archive/master.zip)

## Contents
- Pre-Setup:

    * [Screenshots](https://github.com/ThaisenPM/Cheat-Loader#screenshots)


    * [Requirements](https://github.com/ThaisenPM/Cheat-Loader#requirements)

- Setup:
    * [Video Tutorial](https://github.com/ThaisenPM/Cheat-Loader#video-tutorial)

    * [SQL Setup](https://github.com/ThaisenPM/Cheat-Loader#sql)

    * [Web Files](https://github.com/ThaisenPM/Cheat-Loader#web)


    * [Web Setup](https://github.com/ThaisenPM/Cheat-Loader#web-files)


    * [Loader Setup](https://github.com/ThaisenPM/Cheat-Loader#loader-vb)


    * [Updater Setup](https://github.com/ThaisenPM/Cheat-Loader#updater-vb)
- Post-Setup

    * [Use Instructions](https://github.com/ThaisenPM/Cheat-Loader#use-instructions)

    * [Known Issues](https://github.com/ThaisenPM/Cheat-Loader#known-issues)

    * [License](https://github.com/ThaisenPM/Cheat-Loader#license)

    * [FAQ](https://github.com/ThaisenPM/Cheat-Loader#faq)

    * [Credits](https://github.com/ThaisenPM/Cheat-Loader#credits)

    * [Possible Updates](https://github.com/ThaisenPM/Cheat-Loader#possible-updates)

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

- ayyware.dll (A paste that's probably detected to test injections. Run your game with the "-insecure" flag)

## Web Files

1. Now navigate to the "hwid_get.php" and "usercheck_get.php" files on your website.

2. At the top of the files are "$link" and "$database".

3. Modify them to work for your website's setup.

4. In usercheck_get.php, modify the usergroup numbers to match your forums.

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

2. Change the folders from "C:\temp\Nova" to whatever you want

**Congrats you can now sell your paste!**

## Known issues

1. Always getting "Password incorrect" while entering the correct password? Click the "having trouble" button and sign in and MAKE SURE you click "Remember me"

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

**Q: Do I need a website?**

A: Yes and no. You can make it local only by using a tool such as XAMPP but if you want it to be available for others to use you should get a website. Port forwarding would work too but I advise against it.

## Credits

[JackkTutorials](https://www.youtube.com/channel/UC64x_rKHxY113KMWmprLBPA) for the HWID creation and encryption code.

## Possible Updates

A few things I would possibly do, but don't get your hopes up.

- [ ] Auto-check user group after being logged in
- [X] Make dll's remove themselves automatically
- [ ] MyBB admin panel to change status and version
- [ ] Clean up login heavily
