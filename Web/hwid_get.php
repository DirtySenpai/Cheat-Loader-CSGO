<?php
$link = mysqli_connect('localhost','root','');
$database = mysqli_select_db($link,'mybb');

$user = $_GET['username'];
$hwid = $_GET['hwidin'];

$sql = "SELECT * FROM forums_users WHERE username = '". mysqli_real_escape_string($link,$user) ."'" ;
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
				$sql = "UPDATE forums_users SET hwid='$hwid' WHERE username='$user'";
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
</body>
</html>