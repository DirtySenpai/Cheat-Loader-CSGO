# Cheat Loader

Hello! My name is Thaisen! I got bored so I started to build a basic cheat loader for whatever you need!
The loader currently works off of MyBB for logging in, is HWID locked and validates the user's rank.

REQUIREMENTS:

A MyBB forum

A website

An undetected cheat

Some SUPER BASIC knowledge of PHP and SQL

Some decent knowledge of VB.NET


# SETUP:

## SQL

Firstly, enter your PHPMyAdmin (Or whatever tool you use for SQL managment) and navigate to your mybb_users.

Click on the "Structure" tab at the top of PHPMyAdmin.

Now add a new column named "hwid" that is a "varchar" with a max limit of "255"


## Web

Upload the following files to your webserver:

hwid.php

hwid_get.php

status.txt

usercheck.php

usercheck_get.php

version.txt

OPTIONAL:

ayyware.dll (A paste that's probably detected to test injections. Run your game with the "-insecure" flag)


## Web Files

Now navigate to the "hwid_get.php" and "usercheck_get.php" files on your website.

At the top of the files are "$link" and "$database".

Modify them to work for your website's setup.

In usercheck_get.php, modify the usergroup numbers to match your forums.


## Loader VB

Inside of "Form1.vb" find "Dim address As String = "http://localhost/version.txt"" and change "localhost" to your website.

Now naviagte to line 66 and edit the file names to whatever you like

The lines commented from 76-95 check if the loader is on a USB and if steam is open or not. Uncomment if you want those features.

Go to line 187 and again edit the domain to your website's MyBB forums (MAKE SURE it has "/member.php?action=login" on the end)

Find any lines with "localhost" and change them to your domain


Goto Form3.vb

Change any instance of "localhost" with your domain.


Goto Form5.vb

Change the domain in line 77 to your own (This one is the cheat itself)



Build your loader now, take it and rename it to "loader.exe" and upload it to your website.


## Updater VB

On line 45, change the domain to your own.

Build your updater now, take it and rename it to "Updater.exe" and upload it to your website.


## Use Instructions

If you update the loader, change the version number in the loader's Form1.vb to the new number and change version.txt on your webserver

Change the folders from "C:\temp\Nova" to whatever you want

The DLLs don't delete themselves, just hide. Fix that (Not gonna give a fully working source for free)

Congrats you can now sell your shit paste.


If you have any questions, contact Thaisen#1989 on Discord. I'll maybe help you out
