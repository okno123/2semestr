<?php
header('Content-Type: text/html; charset=UTF-8');

    $errors = FALSE;
      
    if (empty($_POST['name'])) {
        print('Имя не может быть пустым <br/>');
        $errors = TRUE;
      }

    if (is_numeric($_POST['name']) && !preg_match('/^[a-zA-Z\s]+$/', $_POST['name']) && !preg_match('/^[а-яА-Я\s]+$/', $_POST['name'])) {
        print('Заполните имя корректно <br/>');
        $errors = TRUE;
     }
    
    if (empty($_POST['email'])) {
        print('Почта не может быть пустой <br/>');
        $errors = TRUE;
    }
    if (!preg_match('/[0-9a-z]+@[a-z]/', $_POST['email'])) {
        print('Заполните email корректно <br/>');
        $errors = TRUE;
     }
          
    if ($errors) {
        exit();
    }

    if ($_POST['date'] == "гггг-мм-дд") exit ("Поле ДАТА не заполнено!");
    if ($_POST['gender'] == false) exit ("ПОЛ не выбран!");
    if ($_POST['limb'] == false) exit ("КОЛ-ВО КОНЕЧНОСТЕЙ не выбрано!");
    if (empty($_POST['bio'])) exit ("Поле БИОГРАФИЯ не заполнено!");
    if ($_POST['contract'] == false) exit ("Кнопка КОНТРАКТ не нажата!");
    if($_POST['Superpowers'] == 0)
    {
        exit ("Выбрано некорректное значение СУПЕРСПОСОБНОСТЕЙ!");
    }
    else{
    foreach ($_POST['Superpowers'] as $superpowers)
        {
            if (!$superpowers > 0 && !$superpowers < 4) 
            exit ("Выбрано некорректное значение СУПЕРСПОСОБНОСТЕЙ!");
        }
    }

    try{
        $user = 'u52860';
        $password = '5556290';
        $database = new PDO('mysql:host=localhost;dbname=u52860',
        $user,$password,[PDO::ATTR_PERSISTENT => true]);
        $statement = $database->prepare("INSERT INTO Person (name,email,date,gender,limb,bio,contract) VALUES (:name,:email,:date,:gender,:limb,:bio,:contract)");
        $statement -> execute(['name'=>$_POST['name'], 'email'=>$_POST['email'], 'date'=>$_POST['date'], 'gender'=>$_POST['gender'], 'limb'=>$_POST['limb'], 'bio'=>$_POST['bio'], 'contract'=>$_POST['contract']]);
        $id_connection = $database->lastInsertId();
        $statement = $database -> prepare("INSERT INTO Connection (person_id, ability_id) VALUES (:person_id, :ability_id)");
        foreach ($_POST['Superpowers'] as $superpowers)
        {
            if ($superpowers != false)
            {
                $statement -> execute(['person_id' => $id_connection, 'ability_id' => $superpowers]);
            }
        }
    }
    catch (PDOException $e)
    {
        print('Error: ' .$e->getMessage());
        exit();
    }
?>