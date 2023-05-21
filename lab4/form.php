<html lang="en">
<head>
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="style.css">
    <title>Домашка 4</title>
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
            <input name = "Name" type = "text" placeholder = "Имя" <?php if ($errors['Name']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['Name']; ?>">
            <input name = "Email" type = "text" placeholder = "Почта" <?php if ($errors['Email']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['Email']; ?>">
            <input name = "Date" type = "date" <?php if ($errors['Date']) {print 'class = "txtb_error sf_input"';} else {print 'class = "txtb sf_input"';} ?> value="<?php print $values['Date']; ?>">
            <div <?php if ($errors['Gender']) {print 'class = "txtb_error"';} else {print 'class = "txtb"';} ?>><label>Пол</br><input name = "Gender" type = "radio" value = "Male" <?php if ($values['Gender'] == 'Male') {print 'checked = "checked"';}?>>Мужской</label>
            <label><input name = "Gender" type = "radio" value = "Female" <?php if ($values['Gender'] == 'Female') {print 'checked = "checked"';}?>>Женский</label></div>
            <div <?php if ($errors['Limb']) {print 'class = "txtb_error"';} else {print 'class = "txtb"';} ?>><label></br>Количествово конечностей</br><input name = "Limb" type = "radio" value = 3 <?php if ($values['Limb'] == 3) {print 'checked = "checked"';}?>>2</label>
            <label><input name = "Limb" type = "radio" value = 4 <?php if ($values['Limb'] == 4) {print 'checked = "checked"';}?>>3</label>
            <label><input name = "Limb" type = "radio" value = 5 <?php if ($values['Limb'] == 5) {print 'checked = "checked"';}?>>4</label></div>
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
</body>
</html>