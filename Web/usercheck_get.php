<?php
$link = mysqli_connect('localhost','database_username','database_password');
$database = mysqli_select_db($link,'database_name');

$user = $_GET['username'];

$sql = "SELECT * FROM mybb_users WHERE username = '". mysqli_real_escape_string($link,$user) ."'" ;
$result = $link->query($sql);

if ($result->num_rows > 0) {
	// Outputting the rows
	while($row = $result->fetch_assoc()) {
		
		if (strpos($row['usergroup'], '7') !== FALSE)
		{
			echo "User is banned<br>";
		}
		else
		{
			if (strpos($row['usergroup'], '8') !== FALSE)
			{
				echo "User is premium<br>";
			}
			else if (strpos($row['additionalgroups'], '8') !== FALSE)
			{
				echo "User is premium<br>";
			}
			else
			{
				echo "User is not premium<br>";
			}
		}
		
		if (strpos($row['additionalgroups'], '7') !== FALSE)
		{
			echo "User is banned<br>";
		}
		else
		{

		}
		/*echo "Username: " . $row['username'] . "<br>";
		echo "Primary Group: " . $row['usergroup'] . "<br>";
		echo "Additonal Groups: " . $row['additionalgroups'] . "<br>";
		echo "<br>";*/
		
		// Usergroup check
		
		
		
	}
} 
else
{
	echo "No user with the username " . $user;
}
//2: Registered <br> 3: Super Moderator <br> 4: Administrators <br> 5: Awaiting Activation <br> 6: Moderator <br> 7: Banned <br> 8: Premium
?>

<html>
<head>
<title>PHP account check return</title>
<meta http-equiv="refresh" content="1" />
</head>

<body>
<!-- <br><br><a href="/usercheck.php">Return</a> -->

<!---------------------------------------------------
' Coded by /id/Thaisen! Free loader source
' https://github.com/ThaisenPM/Cheat-Loader-CSGO
' Note to the person using this, removing this
' text is in violation of the license you agreed
' to by downloading. Only you can see this so what
' does it matter anyways.
' Copyright © ThaisenPM 2017
' Licensed under a MIT license
' Read the terms of the license here
' https://github.com/ThaisenPM/Cheat-Loader-CSGO/blob/master/LICENSE
'---------------------------------------------------->

</body>
