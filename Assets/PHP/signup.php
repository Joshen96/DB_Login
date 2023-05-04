<?php

$servername = "localhost";
$username = "root";
$password = "asdf1234";
$dbname = "db_login";

$id = $_POST["id"];
$pw = $_POST["pw"];
$name = $_POST["name"];
$age = $_POST["age"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM tb_login1 WHERE id = '" . $id . "'";
$result = $conn->query($sql);

if($result->num_rows > 0) {
	$update_sql = "UPDATE tb_login1 SET pw = '" . $pw . "' WHERE id = '" . $id . "'";
	$conn->query($update_sql);
}
else {
	$insert_sql = "INSERT INTO tb_login1 (id, pw , name , age)
				   VALUES ('" . $id . "', '" . $pw . "','" . $name . "','" . $age . "')";
	$conn->query($insert_sql);
}

$conn->close();

?>