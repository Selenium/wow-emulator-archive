<?php


if($accname == ""){
	echo "Account name can't be empty!";
	Echo "Account Creation presented by: Afinda, Spacey";
	exit;
	}else{
if($accname > 6){
	echo "Account name to Short, must be at least 6 Characters long!";
	Echo "Account Creation presented by: Afinda, Spacey";
	exit;
	}
}

if(file_exists($accname)){
	echo "Account name does already exist, please choose another one!";
	Echo "Account Creation presented by: Afinda, Spacey";
	exit;
	}
if($password == ""){
	echo "Passwort can't be empty!";
	exit;
	}

$sessID="SessionID=";
$lastlog="LastLogin=";
$content="Name=$accname, Password=$password, $sessID, $lastlog";


$filename = tempnam("", "f00");
rename($filename, $accname);
$handle=fopen($accname,"w");
fwrite($handle,$content);
fclose($handle);
<html>
<body>
HELLO
</body>
</html>
Echo "Account successfull Created, Enjoy your stay!<br>";
Echo "Account Creation presented by: Afinda, Spacey";
?>