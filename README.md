# Nova Hook | Open Source VB.NET Cheat Loader

Hello! My name is Thaisen! I got bored so I started to build a basic cheat loader for whatever you need!
The loader currently works off of MyBB for logging in, is HWID locked and validates the user's rank.

[Click here to download the source](https://github.com/ThaisenPM/CheatLoader/archive/master.zip)

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

3. The DLLs don't delete themselves, just hide. Fix that (Not gonna give a fully working source for free)

4. Congrats you can now sell your shit paste.

*If you have any questions, contact Thaisen#1989 on Discord. I'll maybe help you out*
