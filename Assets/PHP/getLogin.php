<?php

$servername = "localhost"; //�����̸�
$username = "root";			//����� �̸�
$password = "asdf1234";		//��й�ȣ
$dbname = "db_login";		//db�̸�


$conn = new mysqli($servername, $username, $password, $dbname); //����


if($conn->connect_error) {  //����ó��
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