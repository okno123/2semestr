<?php

//  Отправляем браузеру кодировку
header('Content-Type: text/html; charset=UTF-8');
setlocale(LC_ALL, "ru_RU.UTF-8");

if ($_SERVER['REQUEST_METHOD'] == 'GET') {
    //  Массив для хранения сообщений пользователю
    $messages = array();
    // В суперглобальном массиве $_COOKIE PHP хранит все имена и значения куки текущего запроса.
    if (!empty($_COOKIE['save'])) {
        setcookie('save', '', time() + 24 * 60 * 60);
        $messages[] = 'Ваши данные сохранены!';
    }
    //  Массив для хранения ошибок
    $errors = array();
    $errors['Name'] = !empty($_COOKIE['Name_error']);
    $errors['Email'] = !empty($_COOKIE['Email_error']);
    $errors['Date'] = !empty($_COOKIE['Date_error']);
    $errors['Gender'] = !empty($_COOKIE['Gender_error']);
    $errors['Limb'] = !empty($_COOKIE['Limb_error']);
    $errors['Superpowers'] = !empty($_COOKIE['Superpowerss_error']);
    $errors['bio'] = !empty($_COOKIE['bio_error']);
    $errors['contract'] = !empty($_COOKIE['signed_error']);

    //  Сообщения об ошибках
    if ($errors['Name']) {
        setcookie('Name_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Введите Имя.</div>';
    }
    if ($errors['Email']) {
        setcookie('Email_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Введите Email.</div>';
    }
    if ($errors['Date']) {
        setcookie('Date_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Выберите год рождения.</div>';
    }
    if ($errors['Gender']) {
        setcookie('Gender_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Выберите пол.</div>';
    }
    if ($errors['Limb']) {
        setcookie('Limb_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Выберите кол-во конечностей.</div>';
    }
    if ($errors['Superpowers']) {
        setcookie('Superpowerss_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Выберите суперсилы.</div>';
    }
    if ($errors['contract']) {
        setcookie('signed_error', '', time() + 24 * 60 * 60);
        $messages[] = '<div class="error">Согласитесь с условиями контракта.</div>';
    }

    //  Сохраняем значения полей в массив
    $values = array();
    $values['Name'] = empty($_COOKIE['Name_value']) ? '' : $_COOKIE['Name_value'];
    $values['Email'] = empty($_COOKIE['Email_value']) ? '' : $_COOKIE['Email_value'];
    $values['Date'] = empty($_COOKIE['Date_value']) ? '' : $_COOKIE['Date_value'];
    $values['Gender'] = empty($_COOKIE['Gender_value']) ? '' : $_COOKIE['Gender_value'];
    $values['Limb'] = empty($_COOKIE['Limbs_value']) ? '' : $_COOKIE['Limbs_value'];
    $values['Superpowers'] = empty($_COOKIE['Superpowerss_value']) ? '' : $_COOKIE['Superpowerss_value'];
    $values['bio'] = empty($_COOKIE['bio_value']) ? '' : $_COOKIE['bio_value'];
    $values['contract'] = empty($_COOKIE['signed_value']) ? '' : $_COOKIE['signed_value'];

    //  Включаем файл form.php
    //  в него передаются переменные $messages, $errors, $values
    include('form.php');
} else {
    //  Если метод был POST
    //  Флаг для отлова ошибок полей
    $errors = FALSE;
    if (empty($_POST['Name'])) {
        setcookie('Name_error', '1', time() + 24 * 60 * 60);
        $errors = TRUE;
    } else {
        if (!preg_match('/^[a-zA-Zа-яёА-ЯЁ\s\-]+$/u', $_POST['Name'])) {
            setcookie('Name_error', '2', time() + 24 * 60 * 60);
            $errors = TRUE;
        } else {
            setcookie('Name_value', $_POST['Name'], time() + 31 * 24 * 60 * 60);
        }
    }
    if (empty($_POST['Email'])) {
        setcookie('Email_error', '1', time() + 24 * 60 * 60);
        $errors = TRUE;
    } else {
        if (!preg_match('/^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$/', $_POST['Email'])) {
            setcookie('Email_error', '2', time() + 24 * 60 * 60);
            $errors = TRUE;
        } else {
            setcookie('Email_value', $_POST['Email'], time() + 31 * 24 * 60 * 60);
        }
    }
    if (empty($_POST['Date'])) { setcookie('Date_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Date'] == "0001-01-01")
                {
                    setcookie('Date_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Date_value', $_POST['Date'], time() + 60 * 60 * 24 * 31);
            }

    if (empty($_POST['Gender'])) { setcookie('Gender_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Gender'] != "Female" && $_POST['Gender'] != "Male")
                {
                    setcookie('Gender_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Gender_value', $_POST['Gender'], time() + 60 * 60 * 24 * 31);
            }
    if (empty($_POST['Limb'])) { setcookie('Limb_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Limb'] != 4 && $_POST['Limb'] != 5 && $_POST['Limb'] != 6)
                {
                    setcookie('Limb_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Limb_value', $_POST['Limb'], time() + 60 * 60 * 24 * 31);
            }

    if (empty($_POST['Superpowers'])) { setcookie('Superpowerss_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
    else
    {
        setcookie("Superpowerss_error","",1000000);
        setcookie("1","",1000000);
        setcookie("2","",1000000);
        setcookie("3","",1000000);
        $super=$_POST["Superpowers"];
        foreach($super as $cout){
          if($cout =="1"){
            setcookie("1","true");
          }
          if($cout =="2"){
            setcookie("2","true");
          }
          if($cout =="3"){
            setcookie("3","true");
          }
        }
    }


    setcookie('bio_value', $_POST['bio'], time() + 60 * 60 * 24 * 31);



    if (empty($_POST['contract'])) {
        setcookie('signed_error', '1', time() + 24 * 60 * 60);
        $errors = TRUE;
    } else {
        if (!preg_match('/^\d+$/', $_POST['contract'])) {
            setcookie('signed_error', '2', time() + 24 * 60 * 60);
            $errors = TRUE;
        } 
        else {
            setcookie('signed_value', $_POST['contract'], time() + 31 * 24 * 60 * 60);
        }
    }


    if ($errors) {
        header('Location: index.php');
        exit();
    } else {
        setcookie('Name_error', '', 100000);
        setcookie('Email_error', '', 100000);
        setcookie('Date_error', '', 100000);
        setcookie('Gender_error', '', 100000);
        setcookie('Limb_error', '', 100000);
        setcookie('Superpowerss_error', '', 100000);
        setcookie('bio_error', '', 100000);
        setcookie('signed_error', '', 100000);
    }
    //*************************

    $user = 'u52860';
    $password = '5556290';

try{
$database = new PDO('mysql:host=localhost;dbname=u52860', $user, $password, [PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);
print('Ваши данные отправлены.<br/>');
}
catch (PDOException $e)
{
print('Error: ' .$e -> getMessage());
exit();
}

$statement = $database -> prepare("INSERT INTO Person (Name, Email, Date, Gender, Limb, bio, contract) VALUES (:Name, :Email, :Date, :Gender, :Limb, :bio, :contract)");
$statement -> execute(['Name' => $_POST['Name'], 'Email' => $_POST['Email'], 'Date' => $_POST['Date'], 'Gender' => $_POST['Gender'], 'Limb' => $_POST['Limb'], 'bio' => $_POST['bio'], 'contract' => $_POST['contract']]);
$id_connection = $database -> lastInsertId();
$statement = $database -> prepare("INSERT INTO Connection (person_id, ability_id) VALUES (:person_id, :ability_id)");
foreach ($_POST['Superpowers'] as $superpowers)
{
    if ($superpowers != false)
    {
        $statement -> execute(['person_id' => $id_connection, 'ability_id' => $superpowers]);
    }
}

    //*************************
    setcookie('save', '1');
    header('Location: index.php');
}