<?php

$servername = "localhost"; //서버이름
$username = "root";			//사용자 이름
$password = "asdf1234";		//비밀번호
$dbname = "db_login";		//db이름


$conn = new mysqli($servername, $username, $password, $dbname); //선언


if($conn->connect_error) {  //예외처리
	die ("connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM tb_login1";
$result = $conn->query($sql);


if($result->num_rows>0)
{
	echo "[";
	while($row = $result->fetch_assoc()){
		echo "{'id': '".$row['id']."', 'pw': '".$row['pw']."','name': '".$row['name']."', 'age': '".$row['age']."'},";
	}
	echo "]";
}



$conn->close();

?>