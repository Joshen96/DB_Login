<?php
$servername = "localhost"; //�����̸�
$username = "root";			//����� �̸�
$password = "asdf1234";		//��й�ȣ
$dbname = "db_login";		//db�̸�

$loginUser = $_POST["id"]; //��ũ��Ʈ ���� ������ ���� ���� ���� 
$loginPass = $_POST["pw"];



$conn = new mysqli($servername, $username, $password, $dbname); //����



$sql = "SELECT * FROM tb_login1 WHERE id='".$loginUser."'";
$result = $conn->query($sql);


if($result->num_rows>0)  //foreach �������� �ڵ�
{
	
	while($row = $result->fetch_assoc()){
		if($row["pw"]==$loginPass){
			echo "Login success!!"; // ���ڴ� Ŭ���̾�Ʈ�� ���� �ڵ�.  ��)�α���Ȯ�� �ڵ�
			$conn->close();
			exit;
		}
	}
	echo "Wrong password..."; //�н����� Ʋ��
}
else
{
	echo "ID not Found.."; // id ��ã
}

$conn->close();

?>