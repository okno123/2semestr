<?php
    header('Content-Type: text/html; charset=UTF-8');
    try
    {
        if ($_SERVER['REQUEST_METHOD'] == 'GET')
        {
            $messages = array();

            if (!empty($_COOKIE['save']))
            {
                setcookie('save', '', time() + 60 * 60 * 24);
                $messages[] = 'Данные были сохранены!';
            }

            $errors = array();
            $errors['Name'] = !empty($_COOKIE['Name_error']);
            $errors['Email'] = !empty($_COOKIE['Email_error']);
            $errors['Date'] = !empty($_COOKIE['Date_error']);
            $errors['Gender'] = !empty($_COOKIE['Gender_error']);
            $errors['Limb'] = !empty($_COOKIE['Limb_error']);
            $errors['Superpowers'] = !empty($_COOKIE['Superpowers_error']);
            $errors['bio'] = !empty($_COOKIE['bio_error']);
            $errors['contract'] = !empty($_COOKIE['contract_error']);

            if ($errors['Name']) { setcookie('Name_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Имя!</div>'; }
            if ($errors['Email']) { setcookie('Email_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Почта!</div>'; }
            if ($errors['Date']) { setcookie('Date_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Дата!</div>'; }
            if ($errors['Gender']) { setcookie('Gender_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите Пол!</div>'; }
            if ($errors['Limb']) { setcookie('Limb_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите кол-во Конечностей!</div>'; }
            if ($errors['Superpowers']) { setcookie('Superpowers_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите Суперспособность(и)!</div>'; }
            if ($errors['bio']) { setcookie('bio_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Биография!</div>'; }
            if ($errors['contract']) { setcookie('contract_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Поставьте галочку Ознакомления!</div>'; }

            $values = array();
            $values['Name'] = empty($_COOKIE['Name_value']) ? '' : $_COOKIE['Name_value'];
            $values['Email'] = empty($_COOKIE['Email_value']) ? '' : $_COOKIE['Email_value'];
            $values['Date'] = empty($_COOKIE['Date_value']) ? '' : $_COOKIE['Date_value'];
            $values['Gender'] = empty($_COOKIE['Gender_value']) ? '' : $_COOKIE['Gender_value'];
            $values['Limb'] = empty($_COOKIE['Limb_value']) ? '' : $_COOKIE['Limb_value'];
            $values['Superpowers'] = empty($_COOKIE['Superpowers_value']) ? '' : $_COOKIE['Superpowers_value'];
            $values['bio'] = empty($_COOKIE['bio_value']) ? '' : $_COOKIE['bio_value'];
            $values['contract'] = empty($_COOKIE['contract_value']) ? '' : $_COOKIE['contract_value'];

            include('form.php');
        }

        else
        {
            $errors = FALSE;
            if (empty($_POST['Name'])) { setcookie('Name_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if (empty($_POST['Name']) || is_numeric($_POST['Name']) || !preg_match('/^([А-ЯЁ]{1}[а-яё])|([A-Z]{1}[a-z])+$/u', $_POST['Name']))
                {
                    setcookie('Name_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Name_value', $_POST['Name'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['Email'])) { setcookie('Email_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if (empty($_POST['Email']) || is_numeric($_POST['Email']) || !preg_match('/^[_a-z0-9-]+(\.[_a-z0-9-])*@[a-z0-9-]+(\.[a-z0-9-])*(\.[a-z]{2,4})$/', $_POST['Email']))
                {
                    setcookie('Email_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Email_value', $_POST['Email'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['Date'])) { setcookie('Date_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Date'] == "0001-01-01" || empty($_POST['Date']))
                {
                    setcookie('Date_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Date_value', $_POST['Date'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['Gender'])) { setcookie('Gender_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Gender'] != "Male" && $_POST['Gender'] != "Female")
                {
                    setcookie('Gender_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Gender_value', $_POST['Gender'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['Limb'])) { setcookie('Limb_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['Limb'] != 3 && $_POST['Limb'] != 4 && $_POST['Limb'] != 5)
                {
                    setcookie('Limb_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('Limb_value', $_POST['Limb'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['Superpowers'])) { setcookie('Superpowers_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                setcookie("Superpowers_error", "", time() + 24 * 60 * 60);
                setcookie("1", "", time() + 24 * 60 * 60);
                setcookie("2", "", time() + 24 * 60 * 60);
                setcookie("3", "", time() + 24 * 60 * 60);
                $superpowers = $_POST["Superpowers"];
                foreach ($superpowers as $cout)
                {
                    if ($cout == "1") setcookie("1", "true");
                    if ($cout == "2") setcookie("2", "true");
                    if ($cout == "3") setcookie("3", "true");
                }
            }
            if (empty($_POST['bio'])) { setcookie('bio_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if (empty($_POST['bio']) || is_numeric($_POST['bio']) || !preg_match('/^[a-zA-Zа-яёА-ЯЁ0-9]/', $_POST['bio']))
                {
                    setcookie('bio_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('bio_value', $_POST['bio'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['contract'])) { setcookie('contract_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['contract'] == null)
                {
                    setcookie('contract_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('contract_value', $_POST['contract'], time() + 60 * 60 * 24 * 31);
            }

            if ($errors)
            {
                header('Location: index.php');
                exit();
            }
            else
            {
                setcookie('Name_error', '', time() + 24 * 60 * 60);
                setcookie('Email_error', '', time() + 24 * 60 * 60);
                setcookie('Date_error', '', time() + 24 * 60 * 60);
                setcookie('Gender_error', '', time() + 24 * 60 * 60);
                setcookie('Limb_error', '', time() + 24 * 60 * 60);
                setcookie('Superpowers_error', '', time() + 24 * 60 * 60);
                setcookie('bio_error', '', time() + 24 * 60 * 60);
                setcookie('contract_error', '', time() + 24 * 60 * 60);
            }

            $user = 'u52860';
            $password = '5556290';
            $database = new PDO('mysql:host=localhost;dbname=u52860', $user, $password, [PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);
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
            setcookie('save', '1');
            header('Location: index.php');
        }

    }

    catch (PDOException $e)
    {
        print('Error: ' .$e -> getMessage());
        exit();
    }

?>