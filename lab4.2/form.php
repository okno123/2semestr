<html>
  <head>
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>Задание 4</title>
    <link rel="stylesheet" type="text/css" href="styles.css">
    <style>
/* Сообщения об ошибках и поля с ошибками выводим с красным бордюром. */

    </style>
  </head>
  <body>

<?php
if (!empty($messages)) {
  print('<div id="messages">');
  // Выводим все сообщения.
  foreach ($messages as $message) {
    print($message);
  }
  print('</div>');
}

// Далее выводим форму отмечая элементы с ошибками классом error
// и задавая начальные значения элементов ранее сохраненными.
?>

<form action="" method="POST" class="content">
        <h1 class="form_title">Форма</h1>

        <div class="form_group <?php if ($errors['Name']) {
            print 'error';
        } ?>">
            <input name="Name" class="form_input" placeholder=" " value="<?php print $values['Name']; ?>">
            <label class="form_label">Имя:</label>
        </div>

        <div class="form_group <?php if ($errors['Email']) {
            print 'error';
        } ?>">
            <input name="Email" class="form_input" placeholder=" "  value="<?php print $values['Email']; ?>" <?php if ($errors['Email']) {
                    print 'class="error"';
                } ?>>
            <label class="form_label">e-mail:</label>
        </div>
        
        <div class="group">
            <p class="text_label">Год рождения:</p>
            <input name="Date" type="date" value="<?php print $values['Date']; ?>" <?php if ($errors['Date']) {
                    print 'class="error"';
                } ?>>
        </div>

        <div class="group <?php if ($errors['Gender']) {
            print 'error';
        } ?>">
            <p class="text_label">Пол:</p>
            <input name = "Gender" type = "radio" value= Female <?php if ($values['Gender'] == 'Female') {
                    print 'checked="checked"';
                } ?>>Женский
            <input name = "Gender" type = "radio" value= Male <?php if ($values['Gender'] == 'Male') {
                    print 'checked="checked"';
                } ?>>Мужской
        </div>

        <div class="group <?php if ($errors['Limb']) {
            print 'error';
        } ?>">
            <p class="text_label">Количество конечностей:</p>
            <label class="text_label">4 </label>
            <input class="radio" name="Limb" type="radio" value=4 <?php if ($values['Limb'] == 4) {
                    print 'checked="checked"';
                } ?>>
            <label class="text_label">5 </label>
            <input class="radio" name="Limb" type="radio" value=5 <?php if ($values['Limb'] == 5 or empty($values['limb'])) {
                    print 'checked="checked"';
                } ?>>
            <label class="text_label">6 </label>
            <input class="radio" name="Limb" type="radio" value=6 <?php if ($values['Limb'] == 6) {
                    print 'checked="checked"';
                } ?>>
        </div>

        <div class = "<?php if ($errors['Superpowers']) {
            print 'error';
        } ?>">
            <label>
                Cверхспособности: <br>
                <select name="Superpowers[]" multiple="multiple">
                    <option  value = 1 <?php if (isset($_COOKIE["1"])) if ($_COOKIE["1"]=="true") echo "selected" ?> > Бессмертие </option>
                    <option  value = 2 <?php if (isset($_COOKIE["2"])) if ($_COOKIE["2"]=="true") echo "selected" ?> > Прохождение сквозь стены </option>
                    <option  value = 3 <?php if (isset($_COOKIE["3"])) if ($_COOKIE["3"]=="true") echo "selected" ?> > Левитация </option>
                </select><br>
            </label>
            <br>
        </div>

        <div class="group <?php if ($errors['bio']) {
            print ' error';
        } ?>">
            <textarea name = "bio" placeholder = "Биография" class = "form_textarea"> <?php print $values['bio']; ?> </textarea>
        </div>
        
        <div>
            <label><input name = "contract" type = "checkbox" value = 1 <?php if ($values['contract']) {
                    print 'checked="checked"';
                } ?>>С контрактом ознакомлен(а)</label>
            <br>
        </div>
        <input type = "submit" value = "Отправить данные" class = "form_btn">
    </form>
  </body>
</html>