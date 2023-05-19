using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Word.Range;
using WordApp = Microsoft.Office.Interop.Word.Application;
using Оконное_приложение.kukuha2;
using System.Xml.Schema;

namespace Оконное_приложение
{
    public partial class Form1 : Form
    {
        int var_count;
        //string name = "VarTest";
        //bool complited = false;

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
        }
        //Выбор варианта
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var_count = int.Parse(textBox1.Text);
            Console.WriteLine(var_count);
            butActivator();
        }
        private void butActivator()
        {
            if (textBox1.Text.Length != 0)
                button1.Enabled = true;
        }
        public void button1_Click(object sender, EventArgs e)
        {

            SaveFileDialog sfg = new SaveFileDialog();
            sfg.InitialDirectory = @"C:\";
            sfg.RestoreDirectory = true;
            sfg.FileName = ".docx";
            sfg.DefaultExt = "docx";
            sfg.Filter = "docx files (*.docx) | *.docx";
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                kukuha.Gener(var_count, sfg);
                //Stream fileStream = sfg.OpenFile();
                //StreamWriter sw = new StreamWriter(fileStream);
            }
            Console.WriteLine("Button");
            DialogResult res = MessageBox.Show("Контрольная создана", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void saveFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }


        //public partial class kukuha
        //{
        //    static List<string> sort(string a, string b, string c, string d, ref string key)
        //    {
        //        List<string> v1 = new List<string>();
        //        List<string> v2 = new List<string>();
        //        v1.Add(a);
        //        v1.Add(b);
        //        v1.Add(c);
        //        v1.Add(d);

        //        string otv;
        //        int kol = 4;
        //        Random rand = new Random();
        //        for (int i = 0; i < 4; i++)
        //        {

        //            int r = rand.Next() % kol;
        //            //cout << r << endl;
        //            kol--;
        //            v2.Add(v1[r]);

        //            if (v2[i] == key)
        //                key = i.ToString();
        //            if (v1.Count != 0)
        //            {
        //                v1.RemoveRange(r, 1);
        //            }
        //        }
        //        if (key == "0")
        //            key = "а";
        //        if (key == "1")
        //            key = "б";
        //        if (key == "2")
        //            key = "в";
        //        if (key == "3")
        //            key = "г";
        //        return v2;
        //    }
        //    static string otvet(string a, string b, string c, string d, ref string key)
        //    {
        //        List<string> v = sort(a, b, c, d, ref key);
        //        string otv = "а)" + v[0] + "     " + "б)" + v[1] + "     " + "в)" + v[2] + "     " + "г)" + v[3];
        //        return otv;
        //    }

        //    static private void var1(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
        //    {
        //        /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
        //        object missing = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
        //        object missing = System.Reflection.Missing.Value;

        //        all_key.Clear();
        //        string a, b, c, d, key, otv;

        //        //document.Content.SetRange(0, 0);
        //        document.Content.InsertAfter("\n                                                                      Вариант " + i +
        //            "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно:" + Environment.NewLine);
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n3. Из генеральной совокупности извлечена выборка объема n  = 81:\n");
        //        //Добавление текста со стилем Заголовок 1

        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
        //        /*object styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        //Создание таблицы 5х5
        //        Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 6;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }
        //        //document.Content.SetRange(0, 0); ///////////HZ
        //        document.Content.InsertAfter("Тогда значение n2 равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n4. Из генеральной совокупности извлечена выборка объема n  = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

        //        document.Content.Paragraphs.Add(ref missing);
        //        /*styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        para1 = document.Content.Paragraphs.Add(ref missing);
        //        //para1.Range.InsertParagraphAfter();
        //        Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        secondTable.Borders.Enable = 1;
        //        foreach (Row row in secondTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }

        //        document.Content.InsertAfter("Тогда относительная частота варианты xi = 5 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

        //        /*document.Content.Text += "\n";  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/


        //        string imagePath = "/logs/kart.png";  ///////3

        //        document.Content.InsertAfter("\n");  //2
        //        Microsoft.Office.Interop.Word.Range rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);

        //        document.Content.InsertAfter("\nТогда статистическое распределение выборки задается: \n");
        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        string imagePath2 = "/logs/kart2.png";
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);


        //        document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
        //                "Тогда несмещенная оценка математического ожидания равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n8.Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");


        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);


        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter("\n Тогда значение a равно:\n" + otv +
        //            "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
        //                "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
        //                "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n13. Дан доверительный интервал(5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
        //                "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
        //        a = "P(K < -2,8) = 0,06"; b = "P(K > 2,8) = 0,06"; c = "P(-2,8 < K < 2,8) = 0,06"; d = "P(K < -2,8) + P(K > 2,8)"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n17. Основная гипотеза имеет вид H0: σ^2 = 4,2. Тогда конкурирующей может являться гипотеза\n");
        //        a = "H1: σ^2 < 4,2"; b = "H1: σ^2 <= 4,2"; c = "H1: σ^2 >= 4,2"; d = "H1: σ^2 > 4,0"; key = a;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
        //        a = "2,14"; b = "-2,14"; c = "2,5"; d = "-2,5"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -3,6 + 4,2x. Тогда выборочный коэффициент корреляции" +
        //                "может быть равен:\n");
        //        a = "2,4"; b = "-0,25"; c = "0,25"; d = "-2,4"; key = c;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
        //                " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
        //                "квадратические отклонения σx = 2, 6, σy = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
        //        a = "-1,12"; b = "1,3"; c = "0,33"; d = "-0,28"; key = d;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv + "\n");


        //        //Сохранение документа
        //        /*object filename = "/logs/temp1.docx";
        //        document.SaveAs(ref filename);
        //        //Закрытие текущего документа
        //        document.Close(ref missing, ref missing, ref missing);
        //        document = null;
        //        //Закрытие приложения Word
        //        winword.Quit(ref missing, ref missing, ref missing);
        //        winword = null;*/

        //        /*Range docRange = document.Range(); ////1
        //        // Create an InlineShape in the InlineShapes collection where the picture should be added later
        //        // It is used to get automatically scaled sizes.
        //        InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
        //        float scaledWidth = autoScaledInlineShape.Width;
        //        float scaledHeight = autoScaledInlineShape.Height;
        //        autoScaledInlineShape.Delete();

        //        // Create a new Shape and fill it with the picture
        //        Shape newShape = document.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
        //        newShape.Fill.UserPicture(imagePath);

        //        // Convert the Shape to an InlineShape and optional disable Border
        //        InlineShape finalInlineShape = newShape.ConvertToInlineShape();
        //        // Cut the range of the InlineShape to clipboard
        //        finalInlineShape.Range.Cut();
        //        // And paste it to the target Range
        //        docRange.Paste();
        //        */


        //    }

        //    static private void var2(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
        //    {
        //        /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
        //        object missing = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
        //        object missing = System.Reflection.Missing.Value;

        //        all_key.Clear();
        //        string a, b, c, d, key, otv;

        //        //document.Content.SetRange(0, 0);
        //        document.Content.InsertAfter("\n Вариант " + i +
        //            "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно:" + Environment.NewLine);
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n3. Из генеральной совокупности извлечена выборка объема n  = 81:\n");
        //        //Добавление текста со стилем Заголовок 1

        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
        //        /*object styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        //Создание таблицы 5х5
        //        Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 6;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }
        //        //document.Content.SetRange(0, 0); ///////////HZ
        //        document.Content.InsertAfter("Тогда значение n2 равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n4. Из генеральной совокупности извлечена выборка объема n  = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

        //        document.Content.Paragraphs.Add(ref missing);
        //        /*styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        para1 = document.Content.Paragraphs.Add(ref missing);
        //        //para1.Range.InsertParagraphAfter();
        //        Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        secondTable.Borders.Enable = 1;
        //        foreach (Row row in secondTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }

        //        document.Content.InsertAfter("Тогда относительная частота варианты xi = 5 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

        //        /*document.Content.Text += "\n";  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/


        //        string imagePath = "/logs/kart.png";  ///////3

        //        document.Content.InsertAfter("\n");  //2
        //        Microsoft.Office.Interop.Word.Range rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);

        //        document.Content.InsertAfter("\nТогда статистическое распределение выборки задается: \n");
        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        string imagePath2 = "/logs/kart2.png";
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);


        //        document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
        //                "Тогда несмещенная оценка математического ожидания равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n8.Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");


        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);


        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter("\n Тогда значение a равно:\n" + otv +
        //            "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
        //                "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
        //                "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n13. Дан доверительный интервал(5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
        //                "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
        //        a = "P(K < -2,2) = 0,05"; b = "P(K > 2,2) = 0,05"; c = "P(-2,2 < K < 2,2) = 0,05"; d = "P(K < -2,2) + P(K > 2,2) = 0,05"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n17. Основная гипотеза имеет вид H0: σ^2 = 5. Тогда конкурирующей может являться гипотеза\n");
        //        a = "H1: σ^2 < 5"; b = "H1: σ^2 < 6"; c = "H1: σ^2 > 5"; d = "H1: σ^2 > 4"; key = c;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -1,8 + 2x. Тогда выборочный коэффициент корреляции" +
        //                "может быть равен:\n");
        //        a = "-3,6"; b = "3,6"; c = "0,5"; d = "-0,5"; key = c;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
        //                " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0,28 выборочные средние" +
        //                "квадратические отклонения σx = 0,2 , σy = 2,3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
        //        a = "1,12"; b = "-0,27"; c = "1,33"; d = "-3,22"; key = d;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv + "\n");
        //    }

        //    static private void var3(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
        //    {
        //        /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
        //        object missing = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
        //        object missing = System.Reflection.Missing.Value;

        //        all_key.Clear();
        //        string a, b, c, d, key, otv;

        //        //document.Content.SetRange(0, 0);
        //        document.Content.InsertAfter("\n Вариант " + i +
        //            "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно:" + Environment.NewLine);
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n3. Из генеральной совокупности извлечена выборка объема n  = 81:\n");
        //        //Добавление текста со стилем Заголовок 1

        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
        //        /*object styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        //Создание таблицы 5х5
        //        Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 6;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }
        //        //document.Content.SetRange(0, 0); ///////////HZ
        //        document.Content.InsertAfter("Тогда значение n2 равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n4. Из генеральной совокупности извлечена выборка объема n  = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

        //        document.Content.Paragraphs.Add(ref missing);
        //        /*styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        para1 = document.Content.Paragraphs.Add(ref missing);
        //        //para1.Range.InsertParagraphAfter();
        //        Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        secondTable.Borders.Enable = 1;
        //        foreach (Row row in secondTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }

        //        document.Content.InsertAfter("Тогда относительная частота варианты xi = 5 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

        //        /*document.Content.Text += "\n";  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/


        //        string imagePath = "/logs/kart.png";  ///////3

        //        document.Content.InsertAfter("\n");  //2
        //        Microsoft.Office.Interop.Word.Range rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);

        //        document.Content.InsertAfter("\nТогда статистическое распределение выборки задается: \n");
        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        string imagePath2 = "/logs/kart2.png";
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);


        //        document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
        //                "Тогда несмещенная оценка математического ожидания равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n8.Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");


        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);


        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter("\n Тогда значение a равно:\n" + otv +
        //            "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
        //                "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
        //                "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n13. Дан доверительный интервал(5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
        //                "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
        //        a = "P(K < -3,15) = 0,2"; b = "P(K > 3,15) = 0,2"; c = "P(-3,15 < K < 3,15) = 0,2"; d = "P(K < -3,15) + P(K > 3,15) = 0,2"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n17. Основная гипотеза имеет вид H0: σ^2 = 4 Тогда конкурирующей может являться гипотеза\n");
        //        a = "H1: σ^2 > 3"; b = "H1: σ^2 <= 4"; c = "H1: σ^2 > 4"; d = "H1: σ^2 >= 4"; key = c;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид X`. Тогда выборочное среднее признака X равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -1,2 - 2,4x. Тогда выборочный коэффициент корреляции" +
        //                "может быть равен:\n");
        //        a = "0,75"; b = "-2"; c = "2"; d = "-0,75"; key = d;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
        //                " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
        //                "квадратические отклонения σx = 0,3, σy = 1,5. Тогда выборочный коэффициент регрессии X на Y равен : \n");
        //        a = "-0,2"; b = "1,15"; c = "3,77"; d = "-4,85"; key = d;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv + "\n");
        //    }

        //    static private void var4(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
        //    {
        //        /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
        //        object missing = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
        //        object missing = System.Reflection.Missing.Value;

        //        all_key.Clear();
        //        string a, b, c, d, key, otv;

        //        //document.Content.SetRange(0, 0);
        //        document.Content.InsertAfter("\n Вариант " + i +
        //            "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно:" + Environment.NewLine);
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n3. Из генеральной совокупности извлечена выборка объема n  = 81:\n");
        //        //Добавление текста со стилем Заголовок 1

        //        Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
        //        /*object styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        //Создание таблицы 5х5
        //        Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        firstTable.Borders.Enable = 1;
        //        foreach (Row row in firstTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 6;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }
        //        //document.Content.SetRange(0, 0); ///////////HZ
        //        document.Content.InsertAfter("Тогда значение n2 равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n4. Из генеральной совокупности извлечена выборка объема n  = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

        //        document.Content.Paragraphs.Add(ref missing);
        //        /*styleHeading1 = "Заголовок 1";
        //        para1.Range.set_Style(styleHeading1);
        //        para1.Range.Text = "Исходники по языку программирования CSharp";*/
        //        para1.Range.InsertParagraphAfter();


        //        para1 = document.Content.Paragraphs.Add(ref missing);
        //        //para1.Range.InsertParagraphAfter();
        //        Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
        //        secondTable.Borders.Enable = 1;
        //        foreach (Row row in secondTable.Rows)
        //        {
        //            foreach (Cell cell in row.Cells)
        //            {
        //                //Заголовок таблицы
        //                if (cell.RowIndex == 1)
        //                {
        //                    cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
        //                    cell.Range.Font.Bold = 1;
        //                    //Задаем шрифт и размер текста
        //                    cell.Range.Font.Name = "verdana";
        //                    cell.Range.Font.Size = 10;
        //                    //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
        //                    //Выравнивание текста в заголовках столбцов по центру
        //                    cell.VerticalAlignment =
        //                         WdCellVerticalAlignment.wdCellAlignVerticalCenter;
        //                    cell.Range.ParagraphFormat.Alignment =
        //                         WdParagraphAlignment.wdAlignParagraphCenter;
        //                }
        //                //Значения ячеек
        //                else
        //                {
        //                    cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
        //                }
        //            }
        //        }

        //        document.Content.InsertAfter("Тогда относительная частота варианты xi = 5 равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

        //        /*document.Content.Text += "\n";  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/


        //        string imagePath = "/logs/kart.png";  ///////3

        //        document.Content.InsertAfter("\n");  //2
        //        Microsoft.Office.Interop.Word.Range rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);

        //        document.Content.InsertAfter("\nТогда статистическое распределение выборки задается: \n");
        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        string imagePath2 = "/logs/kart2.png";
        //        document.InlineShapes.AddPicture(imagePath2, true, true, rng);


        //        document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
        //                "Тогда несмещенная оценка математического ожидания равна:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n8.Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");


        //        document.Content.InsertAfter("\n");  //2
        //        rng = document.Content;
        //        rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
        //        document.InlineShapes.AddPicture(imagePath, true, true, rng);


        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter("\n Тогда значение a равно:\n" + otv +
        //            "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
        //                "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
        //                "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n13. Дан доверительный интервал(5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
        //                "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
        //        a = "P(K < -0,11) = 0,8"; b = "P(K > 0,11) = 0,8"; c = "P(-0,11 < K < 0,11) = 0,8"; d = "P(K < -0,11) + P(K > 0,11) = 0,8"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n17. Основная гипотеза имеет вид H0: σ^2 = 0,6. Тогда конкурирующей может являться гипотеза\n");
        //        a = "H1: σ^2 < 0,6"; b = "H1: σ^2 <= 0,6"; c = "H1: σ^2 > 0,6"; d = "H1: σ^2 >= 0,6"; key = a;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  3,3 - 1,5x. Тогда выборочный коэффициент корреляции" +
        //                "может быть равен:\n");
        //        a = "-3"; b = "0,61"; c = "-0,61"; d = "3"; key = c;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
        //                " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
        //        a = "100"; b = "101"; c = "102"; d = "103"; key = b;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv +
        //            "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = 0,54 выборочные средние" +
        //                "квадратические отклонения σx = 1,6 , σy = 3,2. Тогда выборочный коэффициент регрессии X на Y равен : \n");
        //        a = "1,08"; b = "0,27"; c = "-0,27"; d = "-1,08"; key = a;
        //        otv = otvet(a, b, c, d, ref key);
        //        all_key.Add(key);
        //        document.Content.InsertAfter(otv + "\n");
        //    }

        //    public static void Gener(int var_count)
        //    {
        //        List<string> all_key = new List<string>();
        //        List<List<string>> all_all_key = new List<List<string>>();

        //        Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
        //        object missing = System.Reflection.Missing.Value;
        //        Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
        //        document.Content.SetRange(0, 0);


        //        Console.WriteLine("Введи количество вариантов");
        //        int n = var_count;


        //        int kol = 0;
        //        for (int i = 1; i <= n; i++)
        //        {
        //            if (i - (4 * kol) == 1)
        //            {
        //                var1(i, ref all_key, winword, document);
        //                all_all_key.Add(all_key);

        //            }
        //            if (i - (4 * kol) == 2)
        //            {
        //                var2(i, ref all_key, winword, document);
        //                all_all_key.Add(all_key);

        //            }
        //            if (i - (4 * kol) == 3)
        //            {
        //                var3(i, ref all_key, winword, document);
        //                all_all_key.Add(all_key);
        //            }
        //            if (i - (4 * kol) == 4)
        //            {
        //                var4(i, ref all_key, winword, document);
        //                all_all_key.Add(all_key);
        //                kol++;
        //            }
        //        }
        //        //Сохранение документа
        //        object filename = "/logs/temp1.docx";
        //        document.SaveAs(ref filename);
        //        //Закрытие текущего документа
        //        document.Close(ref missing, ref missing, ref missing);
        //        document = null;
        //        //Закрытие приложения Word
        //        winword.Quit(ref missing, ref missing, ref missing);
        //        winword = null;
        //        //string filename = "/logs/qxc.doc";
        //        //List<string> Images = new List<string>();
        //        //Images.Add("/logs/kart.png");
        //        //ImageToDocx(filename);

        //    }
    }

  
    //@"C: \Users\Isusi\OneDrive\Рабочий стол\qwerty\kukuha\logs"
    //namespace kukuha2
    //{
    //    public partial class kukuha
    //    {
    //        static List<string> sort(string a, string b, string c, string d, ref string key)
    //        {
    //            List<string> v1 = new List<string>();
    //            List<string> v2 = new List<string>();
    //            v1.Add(a);
    //            v1.Add(b);
    //            v1.Add(c);
    //            v1.Add(d);

    //            string otv;
    //            int kol = 4;
    //            Random rand = new Random();
    //            for (int i = 0; i < 4; i++)
    //            {

    //                int r = rand.Next() % kol;
    //                //cout << r << endl;
    //                kol--;
    //                v2.Add(v1[r]);

    //                if (v2[i] == key)
    //                    key = i.ToString();
    //                if (v1.Count != 0)
    //                {
    //                    v1.RemoveRange(r, 1);
    //                }
    //            }
    //            if (key == "0")
    //                key = "а";
    //            if (key == "1")
    //                key = "б";
    //            if (key == "2")
    //                key = "в";
    //            if (key == "3")
    //                key = "г";
    //            return v2;
    //        }
    //        static string otvet(string a, string b, string c, string d, ref string key)
    //        {
    //            List<string> v = sort(a, b, c, d, ref key);
    //            string otv = "а) " + v[0] + "                                     " + "б) " + v[1] + "\n" + "в) " + v[2] + "                                     " + "г) " + v[3];
    //            return otv;
    //        }
    //        static private void var1(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
    //        {
    //            /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
    //            object missing = System.Reflection.Missing.Value;
    //            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
    //            object missing = System.Reflection.Missing.Value;

    //            all_key.Clear();
    //            string a, b, c, d, key, otv;

    //            //document.Content.SetRange(0, 0);
    //            document.Content.InsertAfter("                                                             Тест 2. Вариант " + i +
    //                "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 11. Тогда значение варианты x7 равно:" + Environment.NewLine);
    //            a = "13"; b = "12"; c = "14"; d = "10"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
    //            a = "6"; b = "5"; c = "9"; d = "4"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n3. Из генеральной совокупности извлечена выборка объема n = 81:");
    //            //Добавление текста со стилем Заголовок 1

    //            //Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
    //            /*object styleHeading1 = "Заголовок 1";
    //            para1.Range.set_Style(styleHeading1);
    //            para1.Range.Text = "Исходники по языку программирования CSharp";*/
    //            //para1.Range.InsertParagraphAfter();

    //            document.Content.InsertAfter("\n");  //2
    //            Microsoft.Office.Interop.Word.Range rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            //string imagePath = @"\Users\Isusi\OneDrive\Рабочий стол\qwerty\kukuha\logs\kart.png";        
    //            string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
    //            document.InlineShapes.AddPicture(imagePath3, true, true, rng);

    //            /*
    //            //Создание таблицы 5х5
    //            Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
    //            firstTable.Borders.Enable = 1;
    //            foreach (Row row in firstTable.Rows)
    //            {
    //                foreach (Cell cell in row.Cells)
    //                {
    //                    //Заголовок таблицы
    //                    if (cell.RowIndex == 1)
    //                    {
    //                        cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
    //                        cell.Range.Font.Bold = 1;
    //                        //Задаем шрифт и размер текста
    //                        cell.Range.Font.Name = "verdana";
    //                        cell.Range.Font.Size = 6;
    //                        //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
    //                        //Выравнивание текста в заголовках столбцов по центру
    //                        cell.VerticalAlignment =
    //                             WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                        cell.Range.ParagraphFormat.Alignment =
    //                             WdParagraphAlignment.wdAlignParagraphCenter;
    //                    }
    //                    //Значения ячеек
    //                    else
    //                    {
    //                        cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
    //                    }
    //                }
    //            }*/
    //            //document.Content.SetRange(0, 0); ///////////HZ
    //            document.Content.InsertAfter("\nТогда значение n2 равно:\n");
    //            a = "14"; b = "22"; c = "15"; d = "16"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n4. Из генеральной совокупности извлечена выборка объема n = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

    //            string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath4, true, true, rng);

    //            //document.Content.Paragraphs.Add(ref missing);
    //            /*styleHeading1 = "Заголовок 1";
    //            para1.Range.set_Style(styleHeading1);
    //            para1.Range.Text = "Исходники по языку программирования CSharp";*/
    //            //para1.Range.InsertParagraphAfter();

    //            /*para1 = document.Content.Paragraphs.Add(ref missing);
    //            //para1.Range.InsertParagraphAfter();
    //            Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
    //            secondTable.Borders.Enable = 1;
    //            foreach (Row row in secondTable.Rows)
    //            {
    //                foreach (Cell cell in row.Cells)
    //                {
    //                    //Заголовок таблицы
    //                    if (cell.RowIndex == 1)
    //                    {
    //                        cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
    //                        cell.Range.Font.Bold = 1;
    //                        //Задаем шрифт и размер текста
    //                        cell.Range.Font.Name = "verdana";
    //                        cell.Range.Font.Size = 10;
    //                        //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
    //                        //Выравнивание текста в заголовках столбцов по центру
    //                        cell.VerticalAlignment =
    //                             WdCellVerticalAlignment.wdCellAlignVerticalCenter;
    //                        cell.Range.ParagraphFormat.Alignment =
    //                             WdParagraphAlignment.wdAlignParagraphCenter;
    //                    }
    //                    //Значения ячеек
    //                    else
    //                    {
    //                        cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
    //                    }
    //                }
    //            }*/
    //            document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
    //            a = "0,4"; b = "0,35"; c = "0,45"; d = "0,75"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");
    //            /*document.Content.Text += "\n";  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/
    //            string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var1.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath5, true, true, rng);

    //            document.Content.InsertAfter("\nТогда статистическое распределение выборки задается:");
    //            key = "а";
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
    //            document.InlineShapes.AddPicture(imagePath2, true, true, rng);

    //            document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 5,5; 6,2; 7,1; 8,8; 9,3." +
    //                    " Тогда несмещенная оценка математического ожидания равна:\n");
    //            a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 8,1. Тогда исправленное среднее квадратическое отклонение равно:\n");

    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

    //            string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var1.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath8, true, true, rng);

    //            a = "28"; b = "27"; c = "26"; d = "29"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n\n\n\nТогда значение a равно:\n" + otv +
    //                "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,1; x2; 2,4; 2,7; 2,9. " +
    //                    "Если несмещенная оценка математического ожидания равна 2, 48, то x₂ равно:\n");

    //            a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
    //            a = "увеличится в 3 раза"; b = "не изменится"; c = "увеличится в 9 раз"; d = "увеличится на 9 единиц"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
    //            a = "увеличится на 3 единицы"; b = "увеличится в 3 раза"; c = "не изменится"; d = "увеличится в 9 раз"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
    //                    "отклонении генеральной совокупности. Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
    //            a = "увеличится в 2 раза"; b = "увеличится в 8 раз"; c = "уменьшится в 2 раза"; d = "уменьшится в 8 раз"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n13. Дан доверительный интервал (5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
    //                    "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n\n\n\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
    //            a = "P(K < -2,8) = 0,06"; b = "P(K > 2,8) = 0,06"; c = "P(-2,8 < K < 2,8) = 0,06"; d = "P(K < -2,8) + P(K > 2,8)"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n17. Основная гипотеза имеет вид H0: σ² = 4,2. Тогда конкурирующей может являться гипотеза\n");
    //            a = "H1: σ² < 4,2"; b = "H1: σ² <= 4,2"; c = "H1: σ² >= 4,2"; d = "H1: σ² > 4,0"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид. Тогда выборочное среднее признака X равно:\n");
    //            a = "2,14"; b = "-2,14"; c = "2,5"; d = "-2,5"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -3,6 + 4,2x. Тогда выборочный коэффициент корреляции " +
    //                        "может быть равен:\n");
    //            a = "2,4"; b = "-0,25"; c = "0,25"; d = "-2,4"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
    //                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессии примет вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние " +
    //                        "квадратические отклонения σₓ = 2, 6, σᵧ = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен:\n");
    //            a = "-1,12"; b = "1,3"; c = "0,33"; d = "-0,28"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv + "\n\n\n\n");

    //            //Сохранение документа
    //            /*object filename = "/logs/temp1.docx";
    //            document.SaveAs(ref filename);
    //            //Закрытие текущего документа
    //            document.Close(ref missing, ref missing, ref missing);
    //            document = null;
    //            //Закрытие приложения Word
    //            winword.Quit(ref missing, ref missing, ref missing);
    //            winword = null;*/

    //            /*Range docRange = document.Range(); ////1
    //            // Create an InlineShape in the InlineShapes collection where the picture should be added later
    //            // It is used to get automatically scaled sizes.
    //            InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
    //            float scaledWidth = autoScaledInlineShape.Width;
    //            float scaledHeight = autoScaledInlineShape.Height;
    //            autoScaledInlineShape.Delete();

    //            // Create a new Shape and fill it with the picture
    //            Shape newShape = document.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
    //            newShape.Fill.UserPicture(imagePath);

    //            // Convert the Shape to an InlineShape and optional disable Border
    //            InlineShape finalInlineShape = newShape.ConvertToInlineShape();
    //            // Cut the range of the InlineShape to clipboard
    //            finalInlineShape.Range.Cut();
    //            // And paste it to the target Range
    //            docRange.Paste();
    //            */
    //        }

    //        static private void var2(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
    //        {
    //            object missing = System.Reflection.Missing.Value;

    //            all_key.Clear();
    //            string a, b, c, d, key, otv;
    //            document.Content.InsertAfter("                                                             Тест 2. Вариант " + i +
    //                 "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 10. Тогда значение варианты x7 равно:" + Environment.NewLine);
    //            a = "13"; b = "12"; c = "14"; d = "10"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n2. Мода вариационного ряда 2, 4, 4, 4, 5, 5, 3, 3, 6 равна:\n");
    //            a = "6"; b = "5"; c = "9"; d = "4"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n3. Из генеральной совокупности извлечена выборка объема n = 89:");

    //            document.Content.InsertAfter("\n");  //2
    //            Microsoft.Office.Interop.Word.Range rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
    //            string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
    //            document.InlineShapes.AddPicture(imagePath3, true, true, rng);

    //            document.Content.InsertAfter("\nТогда значение n2 равно:\n");
    //            a = "14"; b = "22"; c = "15"; d = "16"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n4. Из генеральной совокупности извлечена выборка объема n = 110:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

    //            string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath4, true, true, rng);

    //            document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
    //            a = "0,04"; b = "0,35"; c = "0,45"; d = "0,5"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

    //            string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var2.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath5, true, true, rng);

    //            document.Content.InsertAfter("\nТогда статистическое распределение выборки задается:");
    //            key = "б";
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);

    //            document.InlineShapes.AddPicture(imagePath2, true, true, rng);
    //            document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; 4,5; 5,1; 5,8; 9,3." +
    //                    " Тогда несмещенная оценка математического ожидания равна:\n");
    //            a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 8,1. Тогда исправленное среднее квадратическое отклонение равно:\n");

    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

    //            string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var2.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath8, true, true, rng);

    //            a = "15"; b = "16"; c = "17"; d = "14"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n\n\n\nТогда значение a равно:\n" + otv +
    //                "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; x₂; 2,6; 2,7; 2,9. " +
    //                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

    //            a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n10. Если все варианты xi исходного вариационного ряда увеличить в четыре раза, то выборочная дисперсия DB:\n");
    //            a = "увеличится в 16 раз"; b = "не изменится"; c = "увеличится в 9 раз"; d = "увеличится на 4 единицы"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в четыре раза, то выборочное среднее\n");
    //            a = "увеличится на 4 единицы"; b = "увеличится в 4 раза"; c = "не изменится"; d = "увеличится в 16 раз"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
    //                    "отклонении генеральной совокупности. Тогда при уменьшении объема выборки в девять раз значение точности этой оценки:\n");
    //            a = "увеличится в 3 раза"; b = "увеличится в 9 раз"; c = "уменьшится в 3 раза"; d = "уменьшится в 9 раз"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n13. Дан доверительный интервал (5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
    //                    "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n\n\n\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
    //            a = "P(K < -2,2) = 0,05"; b = "P(K > 2,2) = 0,05"; c = "P(-2,2 < K < 2,2) = 0,05"; d = "P(K < -2,2) + P(K > 2,2) = 0,05"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n17. Основная гипотеза имеет вид H0: σ² = 4,2. Тогда конкурирующей может являться гипотеза\n");
    //            a = "H1: σ² < 4,2"; b = "H1: σ² <= 4,2"; c = "H1: σ² >= 4,2"; d = "H1: σ² > 4,0"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид σₓ σᵢ. Тогда выборочное среднее признака X равно:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -1,8 + 2x. Тогда выборочный коэффициент корреляции " +
    //                    "может быть равен:\n");
    //            a = "-3,6"; b = "3,6"; c = "0,5"; d = "-0,5"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
    //                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессии примет вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние " +
    //                        "квадратические отклонения σₓ = 2, 6, σᵧ = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен:\n");
    //            a = "-1,12"; b = "1,3"; c = "0,33"; d = "-0,28"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv + "\n\n\n\n");
    //        }

    //        static private void var3(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
    //        {
    //            object missing = System.Reflection.Missing.Value;
    //            all_key.Clear();
    //            string a, b, c, d, key, otv;

    //            document.Content.InsertAfter("                                                             Тест 2. Вариант " + i +
    //                 "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 9. Тогда значение варианты x7 равно:" + Environment.NewLine);
    //            a = "13"; b = "12"; c = "14"; d = "10"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 3, 6, 6, 6 равна:\n");
    //            a = "6"; b = "5"; c = "9"; d = "4"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n3. Из генеральной совокупности извлечена выборка объема n = 82:");

    //            document.Content.InsertAfter("\n");  //2
    //            Microsoft.Office.Interop.Word.Range rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
    //            string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
    //            document.InlineShapes.AddPicture(imagePath3, true, true, rng);

    //            document.Content.InsertAfter("\nТогда значение n2 равно:\n");
    //            a = "14"; b = "22"; c = "15"; d = "16"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n4. Из генеральной совокупности извлечена выборка объема n = 125:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

    //            string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath4, true, true, rng);

    //            document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
    //            a = "0,35"; b = "0,16"; c = "0,75"; d = "0,56"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

    //            string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var3.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath5, true, true, rng);

    //            document.Content.InsertAfter("\nТогда статистическое распределение выборки задается:");
    //            key = "в";
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);

    //            document.InlineShapes.AddPicture(imagePath2, true, true, rng);

    //            document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 5,2; 5,5; 6,1; 9,3; 10,8." +
    //                    " Тогда несмещенная оценка математического ожидания равна:\n");
    //            a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 8,1. Тогда исправленное среднее квадратическое отклонение равно:\n");

    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

    //            string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var3.png");
    //            document.Content.InsertAfter("\n");  //2
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath8, true, true, rng);

    //            a = "7"; b = "8"; c = "9"; d = "6"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n\n\n\nТогда значение a равно:\n" + otv +
    //                "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,1; x₂; 2,4; 2,7; 2,9. " +
    //                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

    //            a = "2,4"; b = "2,5"; c = "2,3"; d = "2,2"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n10. Если все варианты xi исходного вариационного ряда увеличить в пять раз, то выборочная дисперсия DB:\n");
    //            a = "увеличится в 25 раз"; b = "не изменится"; c = "увеличится в 10 раз"; d = "увеличится на 25 единиц"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n11. Если все варианты xᵢ исходного вариационного ряда уменшить в три раза, то выборочное среднее\n");
    //            a = "уменьшится на 3 единицы"; b = "уменьшится в 3 раза"; c = "не изменится"; d = "увеличится в 9 раз"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
    //                    "отклонении генеральной совокупности. Тогда при увеличении объема выборки в четыре раза значение точности этой оценки:\n");
    //            a = "увеличится в 2 раза"; b = "увеличится в 8 раз"; c = "уменьшится в 2 раза"; d = "уменьшится в 8 раз"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n13. Дан доверительный интервал (5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
    //                    "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n\n\n\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
    //            a = "P(K < -3,15) = 0,2"; b = "P(K > 3,15) = 0,2"; c = "P(-3,15 < K < 3,15) = 0,2"; d = "P(K < -3,15) + P(K > 3,15) = 0,2"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n17. Основная гипотеза имеет вид H0: σ² = 4 Тогда конкурирующей может являться гипотеза\n");
    //            a = "H1: σ² > 3"; b = "H1: σ² <= 4"; c = "H1: σ² > 4"; d = "H1: σ² >= 4"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид. Тогда выборочное среднее признака X равно:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -1,2 - 2,4x. Тогда выборочный коэффициент корреляции " +
    //                    "может быть равен:\n");
    //            a = "0,75"; b = "-2"; c = "2"; d = "-0,75"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
    //                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессии примет вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние " +
    //                        "квадратические отклонения σₓ = 0,3, σᵧ = 1,5. Тогда выборочный коэффициент регрессии X на Y равен:\n");
    //            a = "-0,2"; b = "1,15"; c = "3,77"; d = "-4,85"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv + "\n\n\n\n");
    //        }

    //        static private void var4(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
    //        {
    //            object missing = System.Reflection.Missing.Value;
    //            all_key.Clear();
    //            string a, b, c, d, key, otv;
    //            document.Content.InsertAfter("                                                             Тест 2. Вариант " + i +
    //                 "\n1.Медиана вариационного ряда 2, 3, 5, 6, 7, 9, x₇, 16, 18, 19, 22, 24 равна 13. Тогда значение варианты x7 равно:" + Environment.NewLine);
    //            a = "13"; b = "12"; c = "14"; d = "10"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n2. Мода вариационного ряда 2, 4, 5, 5, 6, 6, 9, 9, 9 равна:\n");
    //            a = "6"; b = "5"; c = "9"; d = "4"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n3. Из генеральной совокупности извлечена выборка объема n = 83");

    //            document.Content.InsertAfter("\n");
    //            Microsoft.Office.Interop.Word.Range rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
    //            string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
    //            document.InlineShapes.AddPicture(imagePath3, true, true, rng);
    //            document.Content.InsertAfter("\nТогда значение n2 равно:\n");
    //            a = "14"; b = "22"; c = "15"; d = "16"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n4. Из генеральной совокупности извлечена выборка объема n = 200:");

    //            string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
    //            document.Content.InsertAfter("\n");
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath4, true, true, rng);

    //            document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
    //            a = "0,55"; b = "0,4"; c = "0,825"; d = "0,725"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

    //            string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var4.png");
    //            document.Content.InsertAfter("\n");
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath5, true, true, rng);

    //            document.Content.InsertAfter("\nТогда статистическое распределение выборки задается:");
    //            key = "г";
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n");
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath2, true, true, rng);

    //            document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 4,5; 5,2; 6,1; 7,8; 8,3." +
    //                    " Тогда несмещенная оценка математического ожидания равна:\n");
    //            a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = d;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 8,1. Тогда исправленное среднее квадратическое отклонение равно:\n");

    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

    //            string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var4.png");
    //            document.Content.InsertAfter("\n");
    //            rng = document.Content;
    //            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
    //            document.InlineShapes.AddPicture(imagePath8, true, true, rng);

    //            a = "26"; b = "27"; c = "28"; d = "25"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter("\n\n\n\nТогда значение a равно:\n" + otv +
    //                "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; x₂; 2,6; 2,7; 2,9. " +
    //                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

    //            a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n10. Если все варианты xi исходного вариационного ряда увеличить в два раза, то выборочная дисперсия DB:\n");
    //            a = "увеличится в 4 раза"; b = "не изменится"; c = "увеличится в 8 раз"; d = "увеличится на 2 единицы"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в пять раз, то выборочное среднее\n");
    //            a = "увеличится на 5 единиц"; b = "увеличится в 5 раз"; c = "не изменится"; d = "увеличится в 25 раз"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
    //                    "отклонении генеральной совокупности. Тогда при увеличении объема выборки в девять раз значение точности этой оценки:\n");
    //            a = "увеличится в 3 раза"; b = "увеличится в 9 раз"; c = "уменьшится в 3 раза"; d = "уменьшится в 9 раз"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n13. Дан доверительный интервал (5, 26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
    //                    "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n\n\n\n15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
    //            a = "P(K < -0,11) = 0,8"; b = "P(K > 0,11) = 0,8"; c = "P(-0,11 < K < 0,11) = 0,8"; d = "P(K < -0,11) + P(K > 0,11) = 0,8"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n17. Основная гипотеза имеет вид H0: σ² = 0,6. Тогда конкурирующей может являться гипотеза\n");
    //            a = "H1: σ² < 0,6"; b = "H1: σ² <= 0,6"; c = "H1: σ² > 0,6"; d = "H1: σ² >= 0,6"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид. Тогда выборочное среднее признака X равно:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = 3,3 - 1,5x. Тогда выборочный коэффициент корреляции " +
    //                    "может быть равен:\n");
    //            a = "-3"; b = "0,61"; c = "-0,61"; d = "3"; key = c;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
    //                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессии примет вид:\n");
    //            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv +
    //                "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = 0,54 выборочные средние " +
    //                        "квадратические отклонения σₓ = 1,6 , σᵧ = 3,2. Тогда выборочный коэффициент регрессии X на Y равен:\n");
    //            a = "1,08"; b = "0,27"; c = "-0,27"; d = "-1,08"; key = a;
    //            otv = otvet(a, b, c, d, ref key);
    //            all_key.Add(key);
    //            document.Content.InsertAfter(otv + "\n\n\n\n");
    //        }
    //        public static void Gener(int var_count, SaveFileDialog sfg)
    //        {
    //            List<string> all_key;
    //            List<List<string>> all_all_key = new List<List<string>>();

    //            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
    //            object missing = System.Reflection.Missing.Value;
    //            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
    //            document.Content.SetRange(0, 0);

    //            Console.WriteLine("Введи количество вариантов");
    //            int n = var_count;

    //            document.Content.Font.Size = 12;
    //            int kol = 0;
    //            for (int i = 1; i <= n; i++)
    //            {
    //                if (i - (4 * kol) == 1)
    //                {
    //                    all_key = new List<string>();
    //                    var1(i, ref all_key, winword, document);

    //                    all_all_key.Add(all_key);

    //                }
    //                if (i - (4 * kol) == 2)
    //                {
    //                    all_key = new List<string>();
    //                    var2(i, ref all_key, winword, document);
    //                    all_all_key.Add(all_key);

    //                }
    //                if (i - (4 * kol) == 3)
    //                {
    //                    all_key = new List<string>();
    //                    var3(i, ref all_key, winword, document);
    //                    all_all_key.Add(all_key);
    //                }
    //                if (i - (4 * kol) == 4)
    //                {
    //                    all_key = new List<string>();
    //                    var4(i, ref all_key, winword, document);
    //                    all_all_key.Add(all_key);
    //                    kol++;
    //                }
    //            }

    //            string nom;
    //            for (int i = 0; i < n; i++)
    //            {
    //                document.Content.InsertAfter("\nВариант" + (i + 1) + "\n");
    //                for (int j = 0; j < 21; j++)
    //                {
    //                    nom = (j + 1).ToString();
    //                    document.Content.InsertAfter(nom + "." + all_all_key[i][j] + "  ");
    //                }
    //                document.Content.InsertAfter("\n");
    //            }

    //            //Сохранение документа
    //            object filename = sfg.FileName;
    //            document.SaveAs(ref filename);
    //            //Закрытие текущего документа
    //            document.Close(ref missing, ref missing, ref missing);
    //            document = null;
    //            //Закрытие приложения Word
    //            winword.Quit(ref missing, ref missing, ref missing);
    //            winword = null;
    //        }
    //    }
    //}


namespace kukuha2
    {
        public partial class kukuha
        {
            static List<string> sort(string a, string b, string c, string d, ref string key)
            {
                List<string> v1 = new List<string>();
                List<string> v2 = new List<string>();
                v1.Add(a);
                v1.Add(b);
                v1.Add(c);
                v1.Add(d);

                string otv;
                int kol = 4;
                Random rand = new Random();
                for (int i = 0; i < 4; i++)
                {

                    int r = rand.Next() % kol;
                    //cout << r << endl;
                    kol--;
                    v2.Add(v1[r]);

                    if (v2[i] == key)
                        key = i.ToString();
                    if (v1.Count != 0)
                    {
                        v1.RemoveRange(r, 1);
                    }
                }
                if (key == "0")
                    key = "а";
                if (key == "1")
                    key = "б";
                if (key == "2")
                    key = "в";
                if (key == "3")
                    key = "г";
                return v2;
            }
            static string otvet(string a, string b, string c, string d, ref string key)
            {
                List<string> v = sort(a, b, c, d, ref key);
                string otv = "а) " + v[0] + "                                     " + "б) " + v[1] + "\n" + "в) " + v[2] + "                                     " + "г) " + v[3];
                return otv;
            }

            static private void var1(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
            {
                object missing = System.Reflection.Missing.Value;

                all_key.Clear();
                string a, b, c, d, key, otv;
                Microsoft.Office.Interop.Word.Paragraph para1;
                para1 = document.Content.Paragraphs.Add(ref missing);
                para1.Range.Font.Bold = 1;
                para1.Range.Text = "                                                             Тест 2. Вариант " + i;
                para1.Range.InsertParagraphAfter();

                //document.Content.SetRange(0, 0);
                document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 11. Тогда значение варианты x7 равно:" + Environment.NewLine);
                a = "13"; b = "12"; c = "14"; d = "10"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
                a = "6"; b = "5"; c = "9"; d = "4"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                
                document.Content.InsertAfter(otv +
                    "\n3. Из генеральной совокупности извлечена выборка объема n = 81:");
                //Добавление текста со стилем Заголовок 1

                //Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
                /*object styleHeading1 = "Заголовок 1";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Исходники по языку программирования CSharp";*/
                //para1.Range.InsertParagraphAfter();

                document.Content.InsertAfter("\n");  //2
                Microsoft.Office.Interop.Word.Range rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                //string imagePath = @"\Users\Isusi\OneDrive\Рабочий стол\qwerty\kukuha\logs\kart.png";        
                string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
                document.InlineShapes.AddPicture(imagePath3, true, true, rng);

                /*
                //Создание таблицы 5х5
                Table firstTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
                firstTable.Borders.Enable = 1;
                foreach (Row row in firstTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Заголовок таблицы
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 6;
                            //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                 WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                 WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        //Значения ячеек
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }*/
                //document.Content.SetRange(0, 0); ///////////HZ
                document.Content.InsertAfter("\nТогда значение n2 равно:\n");
                a = "14"; b = "22"; c = "15"; d = "16"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n4. Из генеральной совокупности извлечена выборка объема n = 100:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");
                string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath4, true, true, rng);

                //document.Content.Paragraphs.Add(ref missing);
                /*styleHeading1 = "Заголовок 1";
                para1.Range.set_Style(styleHeading1);
                para1.Range.Text = "Исходники по языку программирования CSharp";*/
                //para1.Range.InsertParagraphAfter();

                /*para1 = document.Content.Paragraphs.Add(ref missing);
                //para1.Range.InsertParagraphAfter();
                Table secondTable = document.Tables.Add(para1.Range, 2, 6, ref missing, ref missing);
                secondTable.Borders.Enable = 1;
                foreach (Row row in secondTable.Rows)
                {
                    foreach (Cell cell in row.Cells)
                    {
                        //Заголовок таблицы
                        if (cell.RowIndex == 1)
                        {
                            cell.Range.Text = "Колонка " + cell.ColumnIndex.ToString();
                            cell.Range.Font.Bold = 1;
                            //Задаем шрифт и размер текста
                            cell.Range.Font.Name = "verdana";
                            cell.Range.Font.Size = 10;
                            //cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
                            //Выравнивание текста в заголовках столбцов по центру
                            cell.VerticalAlignment =
                                 WdCellVerticalAlignment.wdCellAlignVerticalCenter;
                            cell.Range.ParagraphFormat.Alignment =
                                 WdParagraphAlignment.wdAlignParagraphCenter;
                        }
                        //Значения ячеек
                        else
                        {
                            cell.Range.Text = (cell.RowIndex - 2 + cell.ColumnIndex).ToString();
                        }
                    }
                }*/
                document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
                a = "0,4"; b = "0,35"; c = "0,45"; d = "0,75"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");
                string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var1.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath5, true, true, rng);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда статистическое распределение выборки задается:");
                key = "а";
                all_key.Add(key);
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
                document.InlineShapes.AddPicture(imagePath2, true, true, rng);

                document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 5,5; 6,2; 7,1; 8,8; 9,3." +
                        " Тогда несмещенная оценка математического ожидания равна:\n");
                a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 8,1. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "0,9"; b = "3"; c = "9"; d = "81"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

                string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var1.png");
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath8, true, true, rng);

                a = "28"; b = "27"; c = "26"; d = "29"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда значение a равно:\n" + otv +
                    "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,1; x₂; 2,4; 2,7; 2,9. " +
                        "Если несмещенная оценка математического ожидания равна 2, 48, то x₂ равно:\n");

                a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
                a = "увеличится в 3 раза"; b = "не изменится"; c = "увеличится в 9 раз"; d = "увеличится на 9 единиц"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
                a = "увеличится на 3 единицы"; b = "увеличится в 3 раза"; c = "не изменится"; d = "увеличится в 9 раз"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
                        "отклонении генеральной совокупности. Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "увеличится в 2 раза"; b = "увеличится в 8 раз"; c = "уменьшится в 2 раза"; d = "уменьшится в 8 раз"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n13. Дан доверительный интервал (4,26; 9,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
                    "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "(4,14; 9,61)"; b = "(4,26; 9,61)"; c = "(4,14; 9,49)"; d = "(4,06; 9,59)"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0,24. Тогда его интервальная оценка может иметь вид:\n");
                a = "(-0,5; 0,8)"; b = "(0,25; 0,3)"; c = "(0,14; 0,34)"; d = "(0,05; 0,25)"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("15. Соотношением вида P(K < -2,09) = 0,025 можно определить:\n");
                a = "левостороннюю критическую область"; b = "правостороннюю критическую область"; c = "двустороннюю критическую область"; d = "область принятия гипотезы"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "P(K < -2,8) = 0,06"; b = "P(K > 2,8) = 0,06"; c = "P(-2,8 < K < 2,8) = 0,06"; d = "P(K < -2,8) + P(K > 2,8)"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n17. Основная гипотеза имеет вид H0: σ² = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "H1: σ² < 4,2"; b = "H1: σ² <= 4,2"; c = "H1: σ² >= 4,2"; d = "H1: σ² > 4,0"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид \nȳₓ - 3,25 = 1,245(x+2,14). Tогда выборочное среднее признака X равно:\n");
                a = "2,14"; b = "-2,14"; c = "2,5"; d = "-2,5"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -3,6 + 4,2x. Тогда выборочный коэффициент корреляции " +
                            "может быть равен:\n");
                a = "2,4"; b = "-0,25"; c = "0,25"; d = "-2,4"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии ρₓᵧ" +
                        " = 3,8 и выборочные средние x = 13,2 и y = 22,7. Тогда уравнение регрессии примет вид:\n");
                a = "xᵧ = 3,8y + 73,06"; b = "Yₓ = 3,8y + 73,06"; c = "Xᵧ = 3,8y - 73,06"; d = "Xᵧ = 3,8y + 80,35"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rᵦ = -0, 56 выборочные средние " +
                            "квадратические отклонения \nσₓ = 2,6; σᵧ = 1,3. Тогда выборочный коэффициент регрессии X на Y равен:\n");
                a = "-1,12"; b = "1,3"; c = "0,33"; d = "-0,28"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

            }

            static private void var2(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
            {
                object missing = System.Reflection.Missing.Value;

                all_key.Clear();
                string a, b, c, d, key, otv;
                Microsoft.Office.Interop.Word.Paragraph para1;
                para1 = document.Content.Paragraphs.Add(ref missing);
                para1.Range.Font.Bold = 1;
                para1.Range.Text = "                                                             Тест 2. Вариант " + i;
                para1.Range.InsertParagraphAfter();

                document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 10. Тогда значение варианты x7 равно:" + Environment.NewLine);
                a = "13"; b = "12"; c = "14"; d = "10"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n2. Мода вариационного ряда 2, 4, 4, 4, 5, 5, 3, 3, 6 равна:\n");
                a = "6"; b = "5"; c = "9"; d = "4"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n3. Из генеральной совокупности извлечена выборка объема n = 89:");

                document.Content.InsertAfter("\n");  //2
                Microsoft.Office.Interop.Word.Range rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
                string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
                document.InlineShapes.AddPicture(imagePath3, true, true, rng);

                document.Content.InsertAfter("\nТогда значение n2 равно:\n");
                a = "14"; b = "22"; c = "15"; d = "16"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n4. Из генеральной совокупности извлечена выборка объема n = 110:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

                string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath4, true, true, rng);

                document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
                a = "0,04"; b = "0,35"; c = "0,45"; d = "0,5"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

                string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var2.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath5, true, true, rng);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда статистическое распределение выборки задается:");
                key = "б";
                all_key.Add(key);
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);

                document.InlineShapes.AddPicture(imagePath2, true, true, rng);
                document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; 4,5; 5,1; 5,8; 9,3." +
                        " Тогда несмещенная оценка математического ожидания равна:\n");
                a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 72,9. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "0,9"; b = "3"; c = "9"; d = "81"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

                string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var2.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath8, true, true, rng);

                a = "15"; b = "16"; c = "17"; d = "14"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда значение a равно:\n" + otv +
                    "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; x₂; 2,6; 2,7; 2,9. " +
                        "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

                a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n10. Если все варианты xi исходного вариационного ряда увеличить в четыре раза, то выборочная дисперсия DB:\n");
                a = "увеличится в 16 раз"; b = "не изменится"; c = "увеличится в 9 раз"; d = "увеличится на 4 единицы"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в четыре раза, то выборочное среднее\n");
                a = "увеличится на 4 единицы"; b = "увеличится в 4 раза"; c = "не изменится"; d = "увеличится в 16 раз"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
                        "отклонении генеральной совокупности. Тогда при уменьшении объема выборки в девять раз значение точности этой оценки:\n");
                a = "увеличится в 3 раза"; b = "увеличится в 9 раз"; c = "уменьшится в 3 раза"; d = "уменьшится в 9 раз"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n13. Дан доверительный интервал (25,44; 26,98) для оценки математического ожидания нормально распределенного количественного признака. " +
                        "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "(24,04; 28,38)"; b = "(25,74; 26,68)"; c = "(24,04; 26,98)"; d = "(24,14; 28,38)"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0,26. Тогда его интервальная оценка может иметь вид:\n");
                a = "(-0,5; 0,8)"; b = "(0,16; 0,36)"; c = "(0,14; 0,34)"; d = "(0,05; 0,25)"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("15. Соотношением вида P(K > 1,49) = 0,05 можно определить:\n");
                a = "левостороннюю критическую область"; b = "правостороннюю критическую область"; c = "двустороннюю критическую область"; d = "область принятия гипотезы"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "P(K < -2,2) = 0,05"; b = "P(K > 2,2) = 0,05"; c = "P(-2,2 < K < 2,2) = 0,05"; d = "P(K < -2,2) + P(K > 2,2) = 0,05"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n17. Основная гипотеза имеет вид H0: σ² = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "H1: σ² < 4,2"; b = "H1: σ² <= 4,2"; c = "H1: σ² >= 4,2"; d = "H1: σ² > 4,0"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид \nȳₓ - 2,14 = 2,113(x+1,53). Тогда выборочное среднее признака X равно:\n");
                a = "1,53"; b = "-1,53"; c = "2,2"; d = "-2,2"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -1,8 + 2x. Тогда выборочный коэффициент корреляции " +
                        "может быть равен:\n");
                a = "-3,6"; b = "3,6"; c = "0,5"; d = "-0,5"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии ρₓᵧ" +
                        " = 3,6 и выборочные средние x = 24,9 и y = 12,5. Тогда уравнение регрессии примет вид:\n");
                a = "xᵧ = 3,6y - 77,14"; b = "-xᵧ = 3,6y + 77,14"; c = "xᵧ = 3,6y - 100,14"; d = "Yₓ = 3,6x - 77,14"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rᵦ = - 0, 56 выборочные средние " +
                            "квадратические отклонения \nσₓ = 2,6; σᵧ = 1,3. Тогда выборочный коэффициент регрессии X на Y равен:\n");
                a = "-1,12"; b = "1,3"; c = "0,33"; d = "-0,28"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv);
                
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);
            }

            static private void var3(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
            {
                object missing = System.Reflection.Missing.Value;
                all_key.Clear();
                string a, b, c, d, key, otv;
                Microsoft.Office.Interop.Word.Paragraph para1;
                para1 = document.Content.Paragraphs.Add(ref missing);
                para1.Range.Font.Bold = 1;
                para1.Range.Text = "                                                             Тест 2. Вариант " + i;
                para1.Range.InsertParagraphAfter();

                document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x₇, 15, 18, 19, 22, 24 равна 9. Тогда значение варианты x7 равно:" + Environment.NewLine);
                a = "13"; b = "12"; c = "14"; d = "10"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 3, 6, 6, 6 равна:\n");
                a = "6"; b = "5"; c = "9"; d = "4"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n3. Из генеральной совокупности извлечена выборка объема n = 82:");

                document.Content.InsertAfter("\n");  //2
                Microsoft.Office.Interop.Word.Range rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
                string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
                document.InlineShapes.AddPicture(imagePath3, true, true, rng);

                document.Content.InsertAfter("\nТогда значение n2 равно:\n");
                a = "14"; b = "22"; c = "15"; d = "16"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n4. Из генеральной совокупности извлечена выборка объема n = 125:"); //\n Тогда относительная частота варианты xi = 5 равна:\n");

                string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath4, true, true, rng);

                document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
                a = "0,35"; b = "0,16"; c = "0,75"; d = "0,56"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

                string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var3.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath5, true, true, rng);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда статистическое распределение выборки задается:");
                key = "в";
                all_key.Add(key);
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);

                document.InlineShapes.AddPicture(imagePath2, true, true, rng);

                document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 5,2; 5,5; 6,1; 9,3; 10,8." +
                        " Тогда несмещенная оценка математического ожидания равна:\n");
                a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 32,4. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "0,9"; b = "3"; c = "9"; d = "6"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

                string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var3.png");
                document.Content.InsertAfter("\n");  //2
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath8, true, true, rng);

                a = "7"; b = "8"; c = "9"; d = "6"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда значение a равно:\n" + otv +
                    "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,1; x₂; 2,4; 2,7; 2,9. " +
                        "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

                a = "2,4"; b = "2,5"; c = "2,3"; d = "2,2"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n10. Если все варианты xi исходного вариационного ряда увеличить в пять раз, то выборочная дисперсия DB:\n");
                a = "увеличится в 25 раз"; b = "не изменится"; c = "увеличится в 10 раз"; d = "увеличится на 25 единиц"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n11. Если все варианты xᵢ исходного вариационного ряда уменьшить в три раза, то выборочное среднее\n");
                a = "уменьшится на 3 единицы"; b = "уменьшится в 3 раза"; c = "не изменится"; d = "увеличится в 9 раз"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
                        "отклонении генеральной совокупности. Тогда при увеличении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "увеличится в 2 раза"; b = "увеличится в 8 раз"; c = "уменьшится в 2 раза"; d = "уменьшится в 8 раз"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n13. Дан доверительный интервал (12,02; 16,28) для оценки математического ожидания нормально распределенного количественного признака. " +
                        "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "(11,71; 16,59)"; b = "(12,52; 15,78)"; c = "(12,02; 16,92)"; d = "(9,89; 16,28)"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0,28. Тогда его интервальная оценка может иметь вид:\n");
                a = "(-0,5; 0,8)"; b = "(0,25; 0,3)"; c = "(0,18; 0,38)"; d = "(0,05; 0,25)"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("15. Соотношением вида P(K < -2,78) + P(K > 2,78) = 0,01 можно определить:\n");
                a = "левостороннюю критическую область"; b = "правостороннюю критическую область"; c = "двустороннюю критическую область"; d = "область принятия гипотезы"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "P(K < -3,15) = 0,2"; b = "P(K > 3,15) = 0,2"; c = "P(-3,15 < K < 3,15) = 0,2"; d = "P(K < -3,15) + P(K > 3,15) = 0,2"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n17. Основная гипотеза имеет вид H0: σ² = 4 Тогда конкурирующей может являться гипотеза\n");
                a = "H1: σ² > 3"; b = "H1: σ² <= 4"; c = "H1: σ² > 4"; d = "H1: σ² >= 4"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид \nȳₓ - 4,8 = 0,53(x - 3,13). Тогда выборочное среднее признака X равно:\n");
                a = "3,13"; b = "-3,13"; c = "4"; d = "-4"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = -1,2 - 2,4x. Тогда выборочный коэффициент корреляции " +
                        "может быть равен:\n");
                a = "0,75"; b = "-2"; c = "2"; d = "-0,75"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии ρₓᵧ" +
                        " = -2,45 и выборочные средние x = 3,44 и y = 7,18. Тогда уравнение регрессии примет вид:\n");
                a = "xᵧ = 2,45y + 15,608"; b = "Yₓ = -2,45y + 15,608"; c = "Yₓ = -2,45y + 1,248"; d = "Yₓ = -2,45y - 15,608"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rᵦ = - 0,56 выборочные средние " +
                            "квадратические отклонения \nσₓ = 0,3; σᵧ = 1,5. Тогда выборочный коэффициент регрессии X на Y равен:\n");
                a = "-0,2"; b = "1,15"; c = "3,77"; d = "-4,85"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);
            }

            static private void var4(int i, ref List<string> all_key, Microsoft.Office.Interop.Word.Application winword, Document document)
            {
                object missing = System.Reflection.Missing.Value;
                all_key.Clear();
                string a, b, c, d, key, otv;

                Microsoft.Office.Interop.Word.Paragraph para1;
                para1 = document.Content.Paragraphs.Add(ref missing);
                para1.Range.Font.Bold = 1;
                para1.Range.Text = "                                                             Тест 2. Вариант " + i;
                para1.Range.InsertParagraphAfter();

                document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 9, x₇, 16, 18, 19, 22, 24 равна 13. Тогда значение варианты x7 равно:" + Environment.NewLine);
                a = "13"; b = "12"; c = "14"; d = "10"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n2. Мода вариационного ряда 2, 4, 5, 5, 6, 6, 9, 9, 9 равна:\n");
                a = "6"; b = "5"; c = "9"; d = "4"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n3. Из генеральной совокупности извлечена выборка объема n = 83");

                document.Content.InsertAfter("\n");
                Microsoft.Office.Interop.Word.Range rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                string imagePath2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart2.png");
                string imagePath3 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart3.png");
                document.InlineShapes.AddPicture(imagePath3, true, true, rng);
                document.Content.InsertAfter("\nТогда значение n2 равно:\n");
                a = "14"; b = "22"; c = "15"; d = "16"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n4. Из генеральной совокупности извлечена выборка объема n = 200:");

                string imagePath4 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/kart4.png");
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath4, true, true, rng);

                document.Content.InsertAfter("\nТогда относительная частота варианты xᵢ = 5 равна:\n");
                a = "0,55"; b = "0,4"; c = "0,825"; d = "0,725"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:");

                string imagePath5 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n5var4.png");
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath5, true, true, rng);
                
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда статистическое распределение выборки задается:");
                key = "г";
                all_key.Add(key);
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath2, true, true, rng);

                document.Content.InsertAfter("\n6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 4,5; 5,2; 6,1; 7,8; 8,3." +
                        " Тогда несмещенная оценка математического ожидания равна:\n");
                a = "5,38"; b = "8,38"; c = "7,38"; d = "6,38"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n7. По выборке объема n = 10 найдена выборочная дисперсия DB = 14,4. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "0,9"; b = "3"; c = "9"; d = "4"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n8. Из генеральной совокупности извлечена выборка объема n = 500, гистограмма частот которой имеет вид:");

                string imagePath8 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs/n8var4.png");
                document.Content.InsertAfter("\n");
                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                document.InlineShapes.AddPicture(imagePath8, true, true, rng);

                a = "26"; b = "27"; c = "28"; d = "25"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("Тогда значение a равно:\n" + otv +
                    "\n9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины (в мм): 2,2; x₂; 2,6; 2,7; 2,9. " +
                        "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");

                a = "2,4"; b = "2,5"; c = "2,3"; d = "2,48"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n10. Если все варианты xi исходного вариационного ряда увеличить в два раза, то выборочная дисперсия DB:\n");
                a = "увеличится в 4 раза"; b = "не изменится"; c = "увеличится в 8 раз"; d = "увеличится на 2 единицы"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n11. Если все варианты xᵢ исходного вариационного ряда увеличить в пять раз, то выборочное среднее\n");
                a = "увеличится на 5 единиц"; b = "увеличится в 5 раз"; c = "не изменится"; d = "увеличится в 25 раз"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом " +
                        "отклонении генеральной совокупности. Тогда при увеличении объема выборки в девять раз значение точности этой оценки:\n");
                a = "увеличится в 3 раза"; b = "увеличится в 9 раз"; c = "уменьшится в 3 раза"; d = "уменьшится в 9 раз"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n13. Дан доверительный интервал (5,26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака. " +
                        "Тогда при увеличении надежности (доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "(5,26; 10,61)"; b = "(5,14; 10,61)"; c = "(5,14; 10,49)"; d = "(4,14; 9,49)"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0,22. Тогда его интервальная оценка может иметь вид:\n");
                a = "(-0,5; 0,8)"; b = "(0,25; 0,3)"; c = "(0,14; 0,34)"; d = "(0,12; 0,32)"; key = d;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);

                document.Content.InsertAfter("15. Соотношением вида P(K > 2,78) = 0,05 можно определить:\n");
                a = "левостороннюю критическую область"; b = "правостороннюю критическую область"; c = "двустороннюю критическую область"; d = "область принятия гипотезы"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "P(K < -0,11) = 0,8"; b = "P(K > 0,11) = 0,8"; c = "P(-0,11 < K < 0,11) = 0,8"; d = "P(K < -0,11) + P(K > 0,11) = 0,8"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n17. Основная гипотеза имеет вид H0: σ² = 0,6. Тогда конкурирующей может являться гипотеза\n");
                a = "H1: σ² < 0,6"; b = "H1: σ² <= 0,6"; c = "H1: σ² > 0,6"; d = "H1: σ² >= 0,6"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n18. Выборочное уравнение прямой линии регрессии Y на X имеет вид \nȳₓ - 1,5 = 3,14(x - 2,41). Тогда выборочное среднее признака X равно:\n");
                a = "2,41"; b = "-2,41"; c = "3,5"; d = "-3,5"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n19. Выборочное уравнение прямой линии регрессии Y на X имеет вид y = 3,3 - 1,5x. Тогда выборочный коэффициент корреляции " +
                        "может быть равен:\n");
                a = "-3"; b = "0,61"; c = "-0,61"; d = "3"; key = c;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии ρₓᵧ" +
                        " = 1,53 и выборочные средние x = 8,9 и y = 13,7. Тогда уравнение регрессии примет вид:\n");
                a = "Xᵧ = 1,53y - 12,061"; b = "Xᵧ = - 1,53y - 12,061"; c = "Xᵧ = -1,53y + 12,061"; d = "Xᵧ = 1,53y + 15,061"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv +
                    "\n21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rᵦ = 0,54 выборочные средние " +
                            "квадратические отклонения \nσₓ = 1,6; σᵧ = 3,2. Тогда выборочный коэффициент регрессии X на Y равен:\n");
                a = "1,08"; b = "0,27"; c = "-0,27"; d = "-1,08"; key = a;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                document.Content.InsertAfter(otv);

                rng = document.Content;
                rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
                rng.InsertBreak(WdBreakType.wdPageBreak);
            }
            static public void Gener(int vat_count, SaveFileDialog svg)
            {
                List<string> all_key;// = new List<string>();
                List<List<string>> all_all_key = new List<List<string>>();

                Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
                object missing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
                document.Content.SetRange(0, 0);

                Console.WriteLine("Введи количество вариантов");
                int n = vat_count;

                /*Console.WriteLine("введите имя файла");
                string filename = Console.ReadLine();
                filename += ".docx";*/
                document.Content.Font.Size = 12;
                //string path = "/logs/" + filename;
                //string s = String.Empty;
                int kol = 0;
                for (int i = 1; i <= n; i++)
                {
                    if (i - (4 * kol) == 1)
                    {
                        all_key = new List<string>();
                        var1(i, ref all_key, winword, document);

                        all_all_key.Add(all_key);

                    }
                    if (i - (4 * kol) == 2)
                    {
                        all_key = new List<string>();
                        var2(i, ref all_key, winword, document);
                        all_all_key.Add(all_key);

                    }
                    if (i - (4 * kol) == 3)
                    {
                        all_key = new List<string>();
                        var3(i, ref all_key, winword, document);
                        all_all_key.Add(all_key);
                    }
                    if (i - (4 * kol) == 4)
                    {
                        all_key = new List<string>();
                        var4(i, ref all_key, winword, document);
                        all_all_key.Add(all_key);
                        kol++;
                    }
                }

                string nom;
                for (int i = 0; i < n; i++)
                {
                    document.Content.InsertAfter("\nВариант" + (i + 1) + "\n");
                    for (int j = 0; j < 21; j++)
                    {
                        nom = (j + 1).ToString();
                        document.Content.InsertAfter(nom + "." + all_all_key[i][j] + "     ");
                    }
                    document.Content.InsertAfter("\n");
                }

                object filename = svg.FileName;
                document.SaveAs(ref filename);
                document.Close(ref missing, ref missing, ref missing);
                document = null;
                winword.Quit(ref missing, ref missing, ref missing);
                winword = null;
            }
        }
    }

}





