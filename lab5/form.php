<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style.css">
    <title>Домашка 5</title>
</head>
<body>
    <?php

    if (!empty($messages)) {
    print('<div id="messages">');
    foreach ($messages as $message) {
        print($message);
    }
    print('</div>');
    }
    ?>
    <div class = "signup-form">
        <form action = "" method = "POST">
            <h1>Форма</h1>
            <input name = "name" type = "text" placeholder = "Имя" <?php if ($errors['name']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['name']; ?>">
            <input name = "email" type = "text" placeholder = "Почта" <?php if ($errors['email']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['email']; ?>">
            <input name = "date" type = "date" <?php if ($errors['date']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['date']; ?>">
            <div <?php if ($errors['gender']) {print 'class = "txtb_error"';} else {print 'class = "txtb"';} ?>><label>Пол</br><input name = "gender" type = "radio" value = "Male" <?php if ($values['gender'] == 'Male') {print 'checked = "checked"';}?>>Мужской</label>
            <label><input name = "gender" type = "radio" value = "Female" <?php if ($values['gender'] == 'Female') {print 'checked = "checked"';}?>>Женский</label></div>
            <div <?php if ($errors['limb']) {print 'class = "txtb_error"';} else {print 'class = "txtb"';} ?>><label></br>Количествово конечностей</br><input name = "limb" type = "radio" value = 3 <?php if ($values['limb'] == 3) {print 'checked = "checked"';}?>>2</label>
            <label><input name = "limb" type = "radio" value = 4 <?php if ($values['limb'] == 4) {print 'checked = "checked"';}?>>3</label>
            <label><input name = "limb" type = "radio" value = 5 <?php if ($values['limb'] == 5) {print 'checked = "checked"';}?>>4</label></div>
            <select name = "Superpowers[]" multiple = "multiple" <?php if ($errors['Superpowers']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?>>
                <option value = 1 <?php if (isset($_COOKIE["1"])) if ($_COOKIE["1"] == true) echo "selected" ?>>Телекинез</option>
                <option value = 2 <?php if (isset($_COOKIE["2"])) if ($_COOKIE["2"] == true) echo "selected" ?>>Невидимость</option>
                <option value = 3 <?php if (isset($_COOKIE["3"])) if ($_COOKIE["3"] == true) echo "selected" ?>>Бессмертие</option>
            </select>
            <textarea name = "bio" placeholder = "Биография" <?php if ($errors['bio']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?>><?php print $values['bio']; ?></textarea>
            <div <?php if ($errors['contract']) {print 'class = "txtb_error"';} else {print 'class = "txtb"';} ?>><label><input name = "contract" value = "Checked" type = "checkbox" <?php if ($values['contract'] == 'Checked') {print 'checked="checked"';} ?>>С контрактом ознакомлен(а)</label></div>
            </br>
            <input type = "submit" value = "Отправить данные" class = "signup-btn sf_input">
        </form>
    </div>
    <a href = "login.php">Авторизоваться</a>
</body>
</html>