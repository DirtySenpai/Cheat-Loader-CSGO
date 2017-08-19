<?php
$link = mysqli_connect('localhost','database_username','database_password');
$database = mysqli_select_db($link,'database_name');

$user = $_GET['username'];
$hwid = $_GET['hwidin'];

$sql = "SELECT * FROM mybb_users WHERE username = '". mysqli_real_escape_string($link,$user) ."'" ;
$result = $link->query($sql);

if(strlen($hwid) < 1)
{
	echo "HWID value left empty";
}
else
{
	if ($result->num_rows > 0) {
		while($row = $result->fetch_assoc()) {
			if (strlen($row['hwid']) > 1)
			{
				if ($hwid != $row['hwid'])
				{
					echo "HWID is not correct";
				}
				else
				{
					echo "HWID is correct";
				}
			}
			else
			{
				$sql = "UPDATE mybb_users SET hwid='$hwid' WHERE username='$user'";
				if(mysqli_query($link, $sql))
				{
					echo $row['hwid'];
				}
				else
				{
					echo "ERROR: Could not able to execute $sql. " . mysqli_error($link);
				}
			}
		}
	}
}



?>

<html>
<head>
<title>PHP account check return</title>
<meta http-equiv="refresh" content="1" />
</head>

<body>

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
</html>
