﻿
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace TeorVerC_Sharp
{
    public partial class TeorVerC_Sharp
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
                    v1.RemoveRange(r,1);
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
        static void var1(int i, ref List<string> all_key, string filename)
        {
            all_key.Clear();
            string a, b, c, d, key, otv;
            string k = i.ToString();
            List<string> Images = new List<string>();
            Images.Add("C:/logs/kart.png");
            using (StreamWriter f = new StreamWriter(filename))
            {
                f.WriteLine("Вариант №" + k +
                    "\n1. Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11. Тогда значение варианты x7 равно\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                f.WriteLine(otv + "\n" +
                    "2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n");
                f.Close();
                ImageToDocx(Images, filename);//List<string> Images, string filename C:\logs


                f.WriteLine("3. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "4. Из генеральной совокупности извлечена выборка объема n  = 100: \n Тогда относительная частота варианты xi = 5 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:" +
                    "\n Тогда статистическое распределение выборки задается : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
                    "Тогда несмещенная оценка математического ожидания равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "8. Из генеральной совокупности извлечена выборка объема n  = 500, гистограмма частот которой имеет вид:\n Тогда значение a равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
                    "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "13. Дан доверительный интервал (5,26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
                    "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "17. Основная гипотеза имеет вид H0: 2 = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -3, 6 + 4, 2x. Тогда выборочный коэффициент корреляции" +
                    "может быть равен:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
                    "квадратические отклонения x = 2, 6, y = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

            }
        }

        static void var2(int i, ref List<string> all_key, string filename)
        {
            all_key.Clear();
            string a, b, c, d, key, otv;
            string k = i.ToString();
            List<string> Images = new List<string>();
            Images.Add("C:/logs/kart.png");
            using (StreamWriter f = new StreamWriter(filename))
            {
                f.WriteLine("Вариант №" + k +
                    "\n1. Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11. Тогда значение варианты x7 равно\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                f.WriteLine(otv + "\n" +
                    "2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n");
                ImageToDocx(Images, filename);//List<string> Images, string filename C:\logs


                f.WriteLine("3. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "4. Из генеральной совокупности извлечена выборка объема n  = 100: \n Тогда относительная частота варианты xi = 5 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:" +
                    "\n Тогда статистическое распределение выборки задается : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
                    "Тогда несмещенная оценка математического ожидания равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "8. Из генеральной совокупности извлечена выборка объема n  = 500, гистограмма частот которой имеет вид:\n Тогда значение a равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
                    "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "13. Дан доверительный интервал (5,26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
                    "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "17. Основная гипотеза имеет вид H0: 2 = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -3, 6 + 4, 2x. Тогда выборочный коэффициент корреляции" +
                    "может быть равен:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
                    "квадратические отклонения x = 2, 6, y = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
            }
        }
        static void var3(int i, ref List<string> all_key, string filename)
        {
            all_key.Clear();
            string a, b, c, d, key, otv;
            string k = i.ToString();
            List<string> Images = new List<string>();
            Images.Add("C:/logs/kart.png");
            using (StreamWriter f = new StreamWriter(filename))
            {
                f.WriteLine("Вариант №" + k +
                    "\n1. Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11. Тогда значение варианты x7 равно\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                f.WriteLine(otv + "\n" +
                    "2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n");
                ImageToDocx(Images, filename);//List<string> Images, string filename C:\logs


                f.WriteLine("3. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "4. Из генеральной совокупности извлечена выборка объема n  = 100: \n Тогда относительная частота варианты xi = 5 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:" +
                    "\n Тогда статистическое распределение выборки задается : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
                    "Тогда несмещенная оценка математического ожидания равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "8. Из генеральной совокупности извлечена выборка объема n  = 500, гистограмма частот которой имеет вид:\n Тогда значение a равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
                    "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "13. Дан доверительный интервал (5,26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
                    "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "17. Основная гипотеза имеет вид H0: 2 = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -3, 6 + 4, 2x. Тогда выборочный коэффициент корреляции" +
                    "может быть равен:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
                    "квадратические отклонения x = 2, 6, y = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
            }
        }
        static void var4(int i, ref List<string> all_key, string filename)
        {
            all_key.Clear();
            string a, b, c, d, key, otv;
            string k = i.ToString();
            List<string> Images = new List<string>();
            Images.Add("C:/logs/kart.png");
            using (StreamWriter f = new StreamWriter(filename))
            {
                f.WriteLine("Вариант №" + k +
                    "\n1. Медиана вариационного ряда 2, 3, 5, 6, 7, 8, x7, 15, 18, 19, 22, 24  равна 11. Тогда значение варианты x7 равно\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);

                f.WriteLine(otv + "\n" +
                    "2. Мода вариационного ряда 2, 4, 4, 5, 5, 5, 3, 3, 6 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n");
                ImageToDocx(Images, filename);//List<string> Images, string filename C:\logs


                f.WriteLine("3. Из генеральной совокупности извлечена выборка объема n  = 81:\n Тогда значение n2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "4. Из генеральной совокупности извлечена выборка объема n  = 100: \n Тогда относительная частота варианты xi = 5 равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "5. Из генеральной совокупности извлечена выборка объема n = 50, полигон относительных частот которой имеет вид:" +
                    "\n Тогда статистическое распределение выборки задается : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "6. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 5, 5; 6, 2; 7, 1; 8, 8; 9, 3." +
                    "Тогда несмещенная оценка математического ожидания равна:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "7. По выборке объема n = 10 найдена выборочная дисперсия DB  = 8, 1. Тогда исправленное среднее квадратическое отклонение равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "8. Из генеральной совокупности извлечена выборка объема n  = 500, гистограмма частот которой имеет вид:\n Тогда значение a равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "9. Проведено пять измерений (без систематических ошибок) некоторой случайной величины(в мм) : 2, 1; x2; 2, 4; 2, 7; 2, 9." +
                    "Если несмещенная оценка математического ожидания равна 2, 48, то x2 равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "10. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочная дисперсия DB:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "11. Если все варианты xi исходного вариационного ряда увеличить в три раза, то выборочное среднее\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "12. Построен доверительный интервал для оценки математического ожидания нормально распределенного количественного признака при известном среднем квадратическом" +
                    "отклонении генеральной совокупности.Тогда при уменьшении объема выборки в четыре раза значение точности этой оценки:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "13. Дан доверительный интервал (5,26; 10,49) для оценки среднего квадратического отклонения нормально распределенного количественного признака." +
                    "Тогда при увеличении надежности(доверительной вероятности) оценки доверительный интервал может принять вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "14. Точечная оценка вероятности биномиально распределенного количественного признака равна 0, 24. Тогда его интервальная оценка может иметь вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "15. Соотношением вида P(K >2,49) = 0,05 можно определить:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "16. Правосторонняя критическая область может определяться из соотношения:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "17. Основная гипотеза имеет вид H0: 2 = 4,2. Тогда конкурирующей может являться гипотеза\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "18. Выборочное уравнение прямой линии регрессии Y на X имеет вид . Тогда выборочное среднее признака X равно:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "19. Выборочное уравнение прямой линии регрессии Y на X имеет вид  y =  -3, 6 + 4, 2x. Тогда выборочный коэффициент корреляции" +
                    "может быть равен:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "20. При построении выборочного уравнения прямой линии регрессии X на Y вычислены выборочный коэффициент регрессии xy" +
                    " = 3, 8 и выборочные средние и. Тогда уравнение регрессиипримет вид:\n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
                f.WriteLine(otv + "\n" +

                    "21. При построении выборочного уравнения парной регрессии вычислены выборочный коэффициент корреляции rB = – 0, 56 выборочные средние" +
                    "квадратические отклонения x = 2, 6, y = 1, 3. Тогда выборочный коэффициент регрессии X на Y равен : \n");
                a = "100"; b = "101"; c = "102"; d = "103"; key = b;
                otv = otvet(a, b, c, d, ref key);
                all_key.Add(key);
            }
        }

        static void Main()
        {           
            Console.WriteLine("Введи количество вариантов");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("введите имя файла");
            string filename = Console.ReadLine();
            filename += ".doc";

           
            //string path = "/logs/" + filename;
            List<string> all_key = new List<string>();
            List<List<string>> all_all_key = new List<List<string>>();
            //string s = String.Empty;
            int kol = 0;
            for (int i = 1; i <= n; i++)
            {
                if (i - (4 * kol) == 1)
                {
                    var1(i, ref all_key, filename);
                    all_all_key.Add(all_key);

                }
                if (i - (4 * kol) == 2)
                {
                    var2(i, ref all_key, filename);
                    all_all_key.Add(all_key);

                }
                if (i - (4 * kol) == 3)
                {
                    var3(i, ref all_key, filename);
                    all_all_key.Add(all_key);
                }
                if (i - (4 * kol) == 4)
                {
                    var4(i, ref all_key, filename);
                    all_all_key.Add(all_key);
                    kol++;
                }             
            }
            using (StreamWriter f = new StreamWriter(filename))
            {
                string nom;
                for (int i = 0; i < n; i++)
                {
                    f.Write("Вариант" + (i + 1) + "\n");

                    for (int j = 0; j < 21; j++)
                    {
                        nom = (j + 1).ToString();
                        f.Write("№" + nom + " " + all_all_key[i][j] + "\n");
                    }
                }
                f.Close();
            }
        }

        static private void ImageToDocx(List<string> Images, string filename)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document wordDoc = wordApp.Documents.Add();
            Word.Range docRange = wordDoc.Range();

            float mHeight = 0;
            for (int i = 0; i <= Images.Count - 1; i++)
            {
                // Create an InlineShape in the InlineShapes collection where the picture should be added later
                // It is used to get automatically scaled sizes.
                InlineShape autoScaledInlineShape = docRange.InlineShapes.AddPicture(Images[i]);
                float scaledWidth = autoScaledInlineShape.Width;
                float scaledHeight = autoScaledInlineShape.Height;
                mHeight += scaledHeight;
                autoScaledInlineShape.Delete();

                // Create a new Shape and fill it with the picture
                Shape newShape = wordDoc.Shapes.AddShape(1, 0, 0, scaledWidth, mHeight);
                newShape.Fill.UserPicture(Images[i]);

                // Convert the Shape to an InlineShape and optional disable Border
                InlineShape finalInlineShape = newShape.ConvertToInlineShape();
                //finalInlineShape.Line.Visible = MsoTriState.msoFalse;

                // Cut the range of the InlineShape to clipboard
                finalInlineShape.Range.Cut();

                // And paste it to the target Range
                docRange.Paste();
            }
            wordDoc.SaveAs2(@filename);
            wordApp.Quit();
        }
    }
}