<?php
$servername = "localhost"; //서버이름
$username = "root";			//사용자 이름
$password = "asdf1234";		//비밀번호
$dbname = "db_login";		//db이름

$loginUser = $_POST["id"]; //스크립트 에서 던지는 값들 디비로 보낼 
$loginPass = $_POST["pw"];



$conn = new mysqli($servername, $username, $password, $dbname); //선언



$sql = "SELECT * FROM tb_login1 WHERE id='".$loginUser."'";
$result = $conn->query($sql);


if($result->num_rows>0)  //foreach 같은형식 코드
{
	
	while($row = $result->fetch_assoc()){
		if($row["pw"]==$loginPass){
			echo "Login success!!"; // 에코는 클라이언트에 던질 코드.  예)로그인확인 코드
			$conn->close();
			exit;
		}
	}
	echo "Wrong password..."; //패스워드 틀림
}
else
{
	echo "ID not Found.."; // id 못찾
}

$conn->close();

?>