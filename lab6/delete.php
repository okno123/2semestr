<?php
    $person_id = $_GET['person_id'];
    $user = 'u52860';
    $password = '5556290';
    $database = new PDO('mysql:host=localhost;dbname=u52860', $user, $password, [PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);
    $result = $database -> exec("DELETE FROM User_Information  WHERE ID_User = '$person_id'");
    $result = $database -> exec("DELETE FROM Connection WHERE person_id = '$person_id'");
    header('Location: ./admin.php');
?>