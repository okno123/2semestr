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
                setcookie('login', '', time() + 60 * 60 * 24);
                setcookie('password', '', time() + 60 * 60 * 24);
                $messages[] = '<div style = "margin-left: 50px;">Данные были сохранены!</div>';
                if (!empty($_COOKIE['password']))
                {
                    $messages[] = sprintf('<div style = "margin-left: 50px;">Вы можете войти с этими данными для изменения внесённых ранее:</div>
                    <div style = "margin-left: 50px;">Логин: %s</div>
                    <div style = "margin-left: 50px;">Пароль: %s</div>',
                    strip_tags($_COOKIE['login']),
                    strip_tags($_COOKIE['password'])
                    );
                }
            }
            $errors = array();
            $errors['name'] = !empty($_COOKIE['name_error']);
            $errors['email'] = !empty($_COOKIE['email_error']);
            $errors['date'] = !empty($_COOKIE['date_error']);
            $errors['gender'] = !empty($_COOKIE['gender_error']);
            $errors['limb'] = !empty($_COOKIE['limb_error']);
            $errors['Superpowers'] = !empty($_COOKIE['Superpowers_error']);
            $errors['bio'] = !empty($_COOKIE['bio_error']);
            $errors['contract'] = !empty($_COOKIE['contract_error']);

            if ($errors['name']) { setcookie('name_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Имя</div>'; }
            if ($errors['email']) { setcookie('email_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Почта</div>'; }
            if ($errors['date']) { setcookie('date_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Дата</div>'; }
            if ($errors['gender']) { setcookie('gender_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите Пол</div>'; }
            if ($errors['limb']) { setcookie('limb_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите кол-во Конечностей</div>'; }
            if ($errors['Superpowers']) { setcookie('Superpowers_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Выберите Суперспособность(и)</div>'; }
            if ($errors['bio']) { setcookie('bio_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Проверьте поле Биография</div>'; }
            if ($errors['contract']) { setcookie('contract_error', '', time() + 60 * 60 * 24); $messages[] = '<div class="error">Поставьте галочку Ознакомления</div>'; }

            if (!empty($_COOKIE[session_name()]) && session_start() && !empty($_SESSION['login']))
            {
                $user = 'u52860';
                $password = '5556290';
                $database = new PDO('mysql:host=localhost;dbname=u52860', $user, $password, [PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);

                $statement = $database -> prepare("SELECT * FROM Person WHERE person_id = ?");
                $statement -> execute([$_SESSION['uid']]);
                $line = $statement -> fetch(PDO::FETCH_ASSOC);

                $values = array();
                $values['name'] = $line['name'];
                $values['email'] = $line['email'];
                $values['date'] = $line['date'];
                $values['gender'] = $line['gender'];
                $values['limb'] = $line['limb'];
                $values['bio'] = $line['bio'];
                $values['contract'] = $line['contract'];
                if ($_SESSION['login'] == 'Admin')
                {
                    $messages[] = '<div style = "margin-left: 30px;">Вы редактируете данные как Администратор:</div>';
                }
                else
                {
                $messages[] = sprintf('<div style = "margin-left: 50px;">Вы вошли с этими данными:</div>
                    <div style = "margin-left: 50px;">Ваш логин: %s</div>
                    <div style = "margin-left: 50px;">Ваш номер: %s</div>',
                    strip_tags($_SESSION['login']),
                    strip_tags($_SESSION['uid'])
                    );
                }
            }

            else
            {
                $values = array();
                $values['name'] = empty($_COOKIE['name_value']) ? '' : $_COOKIE['name_value'];
                $values['email'] = empty($_COOKIE['email_value']) ? '' : $_COOKIE['email_value'];
                $values['date'] = empty($_COOKIE['date_value']) ? '' : $_COOKIE['date_value'];
                $values['gender'] = empty($_COOKIE['gender_value']) ? '' : $_COOKIE['gender_value'];
                $values['limb'] = empty($_COOKIE['limb_value']) ? '' : $_COOKIE['limb_value'];
                $values['Superpowers'] = empty($_COOKIE['Superpowers_value']) ? '' : $_COOKIE['Superpowers_value'];
                $values['bio'] = empty($_COOKIE['bio_value']) ? '' : $_COOKIE['bio_value'];
                $values['contract'] = empty($_COOKIE['contract_value']) ? '' : $_COOKIE['contract_value'];
            }

            include('form.php');
        }
        else
        {
            $errors = FALSE;
            if (empty($_POST['name'])) { setcookie('name_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if (empty($_POST['name']) || is_numeric($_POST['name']) || !preg_match('/^([А-ЯЁ]{1}[а-яё])|([A-Z]{1}[a-z])+$/u', $_POST['name']))
                {
                    setcookie('name_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('name_value', $_POST['name'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['email'])) { setcookie('email_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if (empty($_POST['email']) || is_numeric($_POST['email']) || !preg_match('/^[_a-z0-9-]+(\.[_a-z0-9-])*@[a-z0-9-]+(\.[a-z0-9-])*(\.[a-z]{2,4})$/', $_POST['email']))
                {
                    setcookie('email_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('email_value', $_POST['email'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['date'])) { setcookie('date_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['date'] == "0001-01-01" || empty($_POST['date']))
                {
                    setcookie('date_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('date_value', $_POST['date'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['gender'])) { setcookie('gender_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['gender'] != "Male" && $_POST['gender'] != "Female")
                {
                    setcookie('gender_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('gender_value', $_POST['gender'], time() + 60 * 60 * 24 * 31);
            }
            if (empty($_POST['limb'])) { setcookie('limb_error', '1', time() + 24 * 60 * 60); $errors = TRUE; }
            else
            {
                if ($_POST['limb'] != 3 && $_POST['limb'] != 4 && $_POST['limb'] != 5)
                {
                    setcookie('limb_error', '2', time() + 24 * 60 * 60);
                    $errors = TRUE;
                }
                else setcookie('limb_value', $_POST['limb'], time() + 60 * 60 * 24 * 31);
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
                setcookie('name_error', '', time() + 24 * 60 * 60);
                setcookie('email_error', '', time() + 24 * 60 * 60);
                setcookie('date_error', '', time() + 24 * 60 * 60);
                setcookie('gender_error', '', time() + 24 * 60 * 60);
                setcookie('limb_error', '', time() + 24 * 60 * 60);
                setcookie('Superpowers_error', '', time() + 24 * 60 * 60);
                setcookie('bio_error', '', time() + 24 * 60 * 60);
                setcookie('contract_error', '', time() + 24 * 60 * 60);
            }

            $user = 'u52860';
            $password = '5556290';
            $database = new PDO('mysql:host=localhost;dbname=u52860', $user, $password, [PDO::ATTR_PERSISTENT => true, PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);

            if (!empty($_COOKIE[session_name()]) && session_start() && !empty($_SESSION['login']))
            {
                $ID_Record = $_SESSION['uid'];
                $statement = $database -> prepare("UPdate Person SET name = ?, email = ?, date = ?, gender = ?, limb = ?, bio = ?, contract = ? WHERE person_id = ?");
                $statement -> execute([$_POST['name'], $_POST['email'], $_POST['date'], $_POST['gender'], $_POST['limb'], $_POST['bio'], $_POST['contract'], $_SESSION['uid']]);
                $statement_sup = $database -> prepare("INSERT INTO Connection SET person_id = ?, ability_id = ?");
                foreach($_POST['Superpowers'] as $superpowers)
                    $statement_sup -> execute([$_SESSION['uid'], $superpowers]);
            }

            else
            {
                $user_login = uniqid('', true);
                $user_password = rand(10, 1000);
                setcookie('login', $user_login);
                setcookie('password', $user_password);

                $statement = $database -> prepare("INSERT INTO Person (name, email, date, gender, limb, bio, contract) VALUES (:name, :email, :date, :gender, :limb, :bio, :contract)");
                $statement -> execute(['name' => $_POST['name'], 'email' => $_POST['email'], 'date' => $_POST['date'], 'gender' => $_POST['gender'], 'limb' => $_POST['limb'], 'bio' => $_POST['bio'], 'contract' => $_POST['contract']]);
                $id_connection = $database -> lastInsertId();
                $statement = $database -> prepare("INSERT INTO Connection (person_id, ability_id) VALUES (:person_id, :ability_id)");
                foreach ($_POST['Superpowers'] as $superpowers)
                {
                    if ($superpowers != false)
                    {
                        $statement -> execute(['person_id' => $id_connection, 'ability_id' => $superpowers]);
                    }                   
                }
                $statement = $database -> prepare("INSERT INTO User_Information SET ID_User = ?, User_Login = ?, User_Password = ?");
                $statement -> execute([$id_connection, $user_login, md5($user_password)]);
                      
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