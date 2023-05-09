using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;
using Range = Microsoft.Office.Interop.Word.Range;

/*namespace kukuha
{
    public partial class kukuha
    {
        static private void ImageToDocx(List<string> Images, string source)
        {
            Application wordApp = new Application();
            Document wordDoc = wordApp.Documents.Add();
            Range docRange = wordDoc.Range();

            string imagePath = "/logs/kart.png";         

            // Create an InlineShape in the InlineShapes collection where the picture should be added later
            // It is used to get automatically scaled sizes.
            InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
            float scaledWidth = autoScaledInlineShape.Width;
            float scaledHeight = autoScaledInlineShape.Height;
            autoScaledInlineShape.Delete();

            // Create a new Shape and fill it with the picture
            Shape newShape = wordDoc.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
            newShape.Fill.UserPicture(imagePath);

            // Convert the Shape to an InlineShape and optional disable Border
            InlineShape finalInlineShape = newShape.ConvertToInlineShape();    
            // Cut the range of the InlineShape to clipboard
            finalInlineShape.Range.Cut();

            // And paste it to the target Range
            docRange.Paste();
          
            wordDoc.SaveAs2(source);
            // Закрываем документ
            wordDoc.Close();
            wordDoc = null;
            wordApp.Quit();
        }
        static void Main()
        {
            string filename = "/logs/qxc.doc";
            List<string>Images = new List<string>();
            //Images.Add("/logs/kart.png");
            ImageToDocx(Images,filename);
        }
    }
}*/

namespace kukuha
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
            string otv = "а)" + v[0] + "     " + "б)" + v[1] + "     " + "в)" + v[2] + "     " + "г)" + v[3];
            return otv;
        }
             
        
        static private void var1(int i, ref List<string> all_key, Application winword, Document document)
        {
            /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
            object missing = System.Reflection.Missing.Value;


            all_key.Clear();
            string a, b, c, d, key, otv;

            //document.Content.SetRange(0, 0);
            document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно" + Environment.NewLine);
            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
            otv = otvet(a, b, c, d, ref key);
            all_key.Add(key);
            document.Content.InsertAfter(otv + 
                "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
            otv = otvet(a, b, c, d, ref key);
            all_key.Add(key);
            document.Content.InsertAfter(otv +
                "\n. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
            //Добавление текста со стилем Заголовок 1

            Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            /*object styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Исходники по языку программирования CSharp";*/
            para1.Range.InsertParagraphAfter();


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
                        cell.Range.Font.Size = 10;
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
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
            }

            //document.Content.SetRange(0, 0); ///////////HZ
            document.Content.InsertAfter("PPAPAPAPAPAPAPA");

            document.Content.Paragraphs.Add(ref missing);
            /*styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Исходники по языку программирования CSharp";*/
            para1.Range.InsertParagraphAfter();


            para1 = document.Content.Paragraphs.Add(ref missing);
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
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
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
            }


            document.Content.InsertAfter("\nPPAPAPAPAPAPAPA2222");

            /*document.Content.Text += "\n";  //2
            rng = document.Content;
            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
            document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/



            string imagePath = "/logs/kart.png";  ///////3
            string imagePath2 = "/logs/kart2.png";
            document.Content.InsertAfter("\n");  //2
            Microsoft.Office.Interop.Word.Range rng = document.Content;
            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
            document.InlineShapes.AddPicture(imagePath, true, true, rng);

            //Сохранение документа
            /*object filename = "/logs/temp1.docx";
            document.SaveAs(ref filename);
            //Закрытие текущего документа
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            //Закрытие приложения Word
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;*/
            
            /*Range docRange = document.Range(); ////1
            // Create an InlineShape in the InlineShapes collection where the picture should be added later
            // It is used to get automatically scaled sizes.
            InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
            float scaledWidth = autoScaledInlineShape.Width;
            float scaledHeight = autoScaledInlineShape.Height;
            autoScaledInlineShape.Delete();

            // Create a new Shape and fill it with the picture
            Shape newShape = document.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
            newShape.Fill.UserPicture(imagePath);

            // Convert the Shape to an InlineShape and optional disable Border
            InlineShape finalInlineShape = newShape.ConvertToInlineShape();
            // Cut the range of the InlineShape to clipboard
            finalInlineShape.Range.Cut();
            // And paste it to the target Range
            docRange.Paste();
            */





        }

        static private void var2(int i, ref List<string> all_key, Application winword, Document document)
        {
            /*Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);*/
            object missing = System.Reflection.Missing.Value;

            all_key.Clear();
            string a, b, c, d, key, otv;

            //document.Content.SetRange(0, 0);
            document.Content.InsertAfter("1.Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11.Тогда значение варианты x7 равно" + Environment.NewLine);
            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
            otv = otvet(a, b, c, d, ref key);
            all_key.Add(key);
            document.Content.InsertAfter(otv +
                "\n2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
            a = "100"; b = "101"; c = "102"; d = "103"; key = b;
            otv = otvet(a, b, c, d, ref key);
            all_key.Add(key);
            document.Content.InsertAfter(otv +
                "\n. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
            //Добавление текста со стилем Заголовок 1

            Microsoft.Office.Interop.Word.Paragraph para1 = document.Content.Paragraphs.Add(ref missing);
            /*object styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Исходники по языку программирования CSharp";*/
            para1.Range.InsertParagraphAfter();


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
                        cell.Range.Font.Size = 10;
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
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
            }

            //document.Content.SetRange(0, 0); ///////////HZ
            document.Content.InsertAfter("PPAPAPAPAPAPAPA");

            document.Content.Paragraphs.Add(ref missing);
            /*styleHeading1 = "Заголовок 1";
            para1.Range.set_Style(styleHeading1);
            para1.Range.Text = "Исходники по языку программирования CSharp";*/
            para1.Range.InsertParagraphAfter();


            para1 = document.Content.Paragraphs.Add(ref missing);
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
                        cell.Shading.BackgroundPatternColor = WdColor.wdColorGray25;
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
            }


            document.Content.InsertAfter("\nPPAPAPAPAPAPAPA2222");

            /*document.Content.Text += "\n";  //2
            rng = document.Content;
            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
            document.InlineShapes.AddPicture(imagePath2, true, true, rng);*/



            string imagePath = "/logs/kart.png";  ///////3
            string imagePath2 = "/logs/kart2.png";
            document.Content.InsertAfter("\n");  //2
            Microsoft.Office.Interop.Word.Range rng = document.Content;
            rng.Collapse(Microsoft.Office.Interop.Word.WdCollapseDirection.wdCollapseEnd);
            document.InlineShapes.AddPicture(imagePath, true, true, rng);

            //Сохранение документа
            /*object filename = "/logs/temp1.docx";
            document.SaveAs(ref filename);
            //Закрытие текущего документа
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            //Закрытие приложения Word
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;*/

            /*Range docRange = document.Range(); ////1
            // Create an InlineShape in the InlineShapes collection where the picture should be added later
            // It is used to get automatically scaled sizes.
            InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(imagePath);
            float scaledWidth = autoScaledInlineShape.Width;
            float scaledHeight = autoScaledInlineShape.Height;
            autoScaledInlineShape.Delete();

            // Create a new Shape and fill it with the picture
            Shape newShape = document.Shapes.AddShape(1, 0, 0, scaledWidth, scaledHeight);
            newShape.Fill.UserPicture(imagePath);

            // Convert the Shape to an InlineShape and optional disable Border
            InlineShape finalInlineShape = newShape.ConvertToInlineShape();
            // Cut the range of the InlineShape to clipboard
            finalInlineShape.Range.Cut();
            // And paste it to the target Range
            docRange.Paste();
            */





        }
        static void Main()
        {
            int i = 1;
            List<string> all_key = new List<string>();
            List<List<string>> all_all_key = new List<List<string>>();

            Microsoft.Office.Interop.Word.Application winword = new Microsoft.Office.Interop.Word.Application();
            object missing = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            document.Content.SetRange(0, 0);




            var1(i, ref all_key, winword, document);
            var2(i, ref all_key, winword, document);


            //Сохранение документа
            object filename = "/logs/temp1.docx";
            document.SaveAs(ref filename);
            //Закрытие текущего документа
            document.Close(ref missing, ref missing, ref missing);
            document = null;
            //Закрытие приложения Word
            winword.Quit(ref missing, ref missing, ref missing);
            winword = null;
            //string filename = "/logs/qxc.doc";
            //List<string> Images = new List<string>();
            //Images.Add("/logs/kart.png");
            //ImageToDocx(filename);
        }
    }
}