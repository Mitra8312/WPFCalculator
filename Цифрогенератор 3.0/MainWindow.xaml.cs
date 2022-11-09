using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Цифрогенератор_3._0
{
    public partial class MainWindow : Window
    {
        public static double result; // переменная для вычисления результата
        public static string p; // переменная для определения знака опереции
        public static double s; // переменная для мат операций
        public static double l; // переменная для отчистки после равно
        public static int k; // переменная для удаления последнего символа
        public static bool OchNado; // переиенная для корректной работы деления единицы на икс. Без этих штук будут дублироваться запятые(
        public static bool OchNado2; // переменная для корректной работы нахождения процента
        public static double c; // переменная для корректной работы нахождения процента
        public static double x; // переменная для счета деления на единицы на икс
        public static double pOm = 0; // переменная, чтобы плюс на минкс менять
        public static double sqr = 0;
        public static double sqrt = 0;
        public static bool TNometry = false;
        public static bool Second = false;
        public static bool Inzh = false;
        public static bool Prog = false;
        public static bool Common = true; // эти переменные для смены режимов калькулятора
        public static int bracket = 0; // переменная для работы со скобками 

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in Gridik.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }

            foreach (UIElement el in GrIn.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }

            foreach (UIElement el in Progra.Children)
            {
                if (el is Button)
                {
                    ((Button)el).Click += Button_Click;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string interesting = (string)((Button)e.OriginalSource).Content;


                if (Common == true)
                {
                    switch (interesting)
                    {
                        case "C":
                            MainT.Text = "";
                            KidT.Text = "";
                            result = 0;
                            s = 0;
                            l = 0;
                            c = 0;
                            break;

                        case "CE":
                            MainT.Text = "";
                            break;

                        case "Sqr(x)":
                            if (MainT.Text == "")
                            {
                                MainT.Text = "";
                            }
                            else
                            {
                                sqr = Convert.ToDouble(MainT.Text);
                                sqr = sqr * sqr;
                                MainT.Text = sqr.ToString();
                            }
                            break;

                        case "Sqrt(x)":
                            if (MainT.Text == "")
                            {
                                MainT.Text = "";
                            }
                            else
                            {
                                sqrt = Convert.ToDouble(MainT.Text);
                                MainT.Text = Math.Sqrt(sqrt).ToString();
                            }
                            break;

                        case ",":
                            if (MainT.Text.Contains(","))
                            {
                                MainT.Text = MainT.Text;
                            }
                            else if (MainT.Text == "")
                            {
                                MainT.Text += "0,";
                            }
                            else MainT.Text += interesting;
                            break;

                        case "/":
                            if (p == "/")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s / Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                l = 1;
                                p = "";
                            }
                            else if (p == "-" || p == "+" || p == "*")
                            {
                                k = KidT.Text.Length - 1;
                                KidT.Text = KidT.Text.Remove(k, 1);
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "/";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "/";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "/";
                                    MainT.Text += interesting;
                                }
                                p = "/";
                                MainT.Text = "";
                                l = 0;
                            }
                            else
                            {
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "/";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "/";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "/";
                                    MainT.Text += interesting;
                                }
                                p = "/";
                                MainT.Text = "";
                                l = 0;
                            }
                            break;

                        case "+/-":
                            if (MainT.Text == "")
                            {
                                MainT.Text = "";
                            }
                            else
                            {
                                pOm = Convert.ToDouble(MainT.Text);
                                pOm *= -1;
                                MainT.Text = pOm.ToString();
                            }
                            break;

                        case "%":
                            if (MainT.Text == "")
                            {
                                MainT.Text = MainT.Text;
                            }
                            else
                            {
                                c = Convert.ToDouble(MainT.Text);
                                c = c / 100;
                                MainT.Text = c.ToString();
                                if (OchNado2 == true)
                                {
                                    KidT.Text = "";
                                    OchNado2 = false;
                                }
                                KidT.Text = MainT.Text;
                            }
                            p = "";
                            l = 1;
                            OchNado2 = true;
                            break;

                        case "1/x":
                            if (MainT.Text == "")
                            {
                                MainT.Text = MainT.Text;
                            }
                            else
                            {
                                if (KidT.Text != "")
                                {
                                    if (p != "")
                                    {
                                        x = Convert.ToDouble(MainT.Text);
                                        x = 1 / x;
                                        MainT.Text = x.ToString();
                                    }
                                }
                                else
                                {
                                    x = Convert.ToDouble(MainT.Text);
                                    x = 1 / x;
                                    MainT.Text = x.ToString();
                                    if (OchNado == true)
                                    {
                                        KidT.Text = "";
                                        OchNado = false;
                                    }
                                    KidT.Text = MainT.Text;
                                }
                            }
                            OchNado = true;
                            l = 1;
                            break;

                        case "Z":
                            if (MainT.Text.Length > 1)
                            {
                                k = MainT.Text.Length - 1;
                                MainT.Text = MainT.Text.Remove(k, 1);
                            }
                            else if (MainT.Text.Length == 1)
                            {
                                MainT.Text = "";
                            }
                            break;

                        case "+":
                            if (p == "+")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s + Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                l = 1;
                                p = "";
                            }
                            else if (p == "-" || p == "/" || p == "*")
                            {
                                k = KidT.Text.Length - 1;
                                KidT.Text = KidT.Text.Remove(k, 1);
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "+";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "+";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "+";
                                    MainT.Text += interesting;
                                }
                                p = "+";
                                MainT.Text = "";
                                l = 0;
                            }
                            else
                            {
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "+";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "+";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "+";
                                    MainT.Text += interesting;
                                }
                                p = "+";
                                MainT.Text = "";
                                l = 0;
                            }
                            break;

                        case "-":
                            if (p == "-")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s - Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                l = 1;
                                p = "";
                            }
                            else if (p == "+" || p == "/" || p == "*")
                            {
                                k = KidT.Text.Length - 1;
                                KidT.Text = KidT.Text.Remove(k, 1);
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "-";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "-";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "-";
                                    MainT.Text += interesting;
                                }
                                p = "-";
                                MainT.Text = "";
                                l = 0;
                            }
                            else
                            {
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "-";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "-";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "-";
                                    MainT.Text += interesting;
                                }
                                p = "-";
                                MainT.Text = "";
                                l = 0;
                            }
                            break;

                        case "=":
                            if (p == "+")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s + Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                            }
                            else if (p == "-")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s - Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                            }
                            else if (p == "/")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s / Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                            }
                            else if (p == "*")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s * Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                            }
                            l = 1;
                            p = "";
                            c = 0;
                            break;

                        case "*":
                            if (p == "*")
                            {
                                if (MainT.Text == "")
                                {
                                    result = s;
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                else
                                {
                                    result = s * Convert.ToDouble(MainT.Text);
                                    MainT.Text = result.ToString();
                                    KidT.Text = MainT.Text;
                                    s = result;
                                }
                                l = 1;
                                p = "";
                            }
                            else if (p == "-" || p == "/" || p == "+")
                            {
                                k = KidT.Text.Length - 1;
                                KidT.Text = KidT.Text.Remove(k, 1);
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "*";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "*";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "*";
                                    MainT.Text += interesting;
                                }
                                p = "*";
                                MainT.Text = "";
                                l = 0;
                            }
                            else
                            {
                                if (l == 1)
                                {
                                    KidT.Text = "";
                                }
                                if (KidT.Text == "" && MainT.Text == "")
                                {
                                    s = 0;
                                    KidT.Text = "0";
                                    KidT.Text += "*";
                                }
                                else if (KidT.Text != "")
                                {
                                    s = Convert.ToDouble(KidT.Text);
                                    KidT.Text += "*";
                                }
                                else
                                {
                                    s = Convert.ToDouble(MainT.Text);
                                    KidT.Text = s.ToString();
                                    KidT.Text += "*";
                                    MainT.Text += interesting;
                                }
                                p = "*";
                                MainT.Text = "";
                                l = 0;
                            }
                            break; // Конец обычного калькулятора, получается

                        default:
                            if (l == 1)
                            {
                                MainT.Text = "";
                                KidT.Text = "";
                                l = 0;
                            }
                            MainT.Text += interesting;
                            break;
                    }
                }
                else if (Inzh == true)
                {
                    switch (interesting)
                    {
                        case "Second":
                            //заглушка просто
                            break;

                        case "Тригонометрия":
                            //снова заглушка для функциональной клавиши
                            break;

                        case "Pi":
                            TMI.Text = "3,1415926";
                            l = 1;
                            break;

                        case "e":
                            TMI.Text = "2,7182818";
                            l = 1;
                            break;

                        case "C":
                            TMI.Text = "";
                            TKI.Text = "";
                            result = 0;
                            s = 0;
                            l = 0;
                            c = 0;
                            break;

                        case "CE":
                            TMI.Text = "";
                            break;

                        case "Sqr(x)":
                            if (TMI.Text == "")
                            {
                                TMI.Text = "";
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                sqr = Convert.ToDouble(TMI.Text);
                                sqr = sqr * sqr;
                                TMI.Text = sqr.ToString();
                            }
                            break;

                        case "Sqrt(x)":
                            if (TMI.Text == "")
                            {
                                TMI.Text = "";
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                sqrt = Convert.ToDouble(TMI.Text);
                                TMI.Text = Math.Sqrt(sqrt).ToString();
                            }
                            break;

                        case ",":
                            if (TMI.Text.Contains(","))
                            {
                                TMI.Text = TMI.Text;
                            }
                            else if (TMI.Text == "")
                            {
                                TMI.Text += "0,";
                                TKI.Text += TMI.Text;
                            }
                            else
                            {
                                TMI.Text += interesting;
                                TKI.Text += ",";
                            }
                            break;

                        case "+/-":
                            if (TMI.Text == "")
                            {
                                TMI.Text = "";
                            }
                            else
                            {
                                pOm = Convert.ToDouble(TMI.Text);
                                pOm *= -1;
                                TMI.Text = pOm.ToString();
                            }
                            break;

                        case ")":
                            if (TKI.Text.Contains("(") == false)
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                TMI.Text += ")";
                                bracket -= 1;
                            }
                            break;

                        case "(":
                            if ((TKI.Text.EndsWith("√") == false || TKI.Text.EndsWith("^") == false || TKI.Text.EndsWith("+") == false || TKI.Text.EndsWith("%") == false || TKI.Text.EndsWith("\\") == false || TKI.Text.EndsWith("*") == false || TKI.Text.EndsWith("-") == false) && TMI.Text != "" && TMI.Text.EndsWith("(") != true)
                            {
                                TMI.Text += "*";
                            }
                            TMI.Text += "(";
                            bracket += 1;
                            break;

                        case "|x|":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                if (x < 0) x *= -1;
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "1/x":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = 1 / x;
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "Z":
                            if (TMI.Text.Length > 1)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            else if (TMI.Text.Length == 1)
                            {
                                TMI.Text = "";
                            }
                            break;

                        case "mod":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "%";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "+":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "+";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "-":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "-";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "*":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "*";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "/":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "/";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "x^y":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text.EndsWith(")"))
                            {
                                TKI.Text += TMI.Text;
                                string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                TKI.Text = "";

                                TMI.Text = esult;
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "^";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "y√x":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text.EndsWith(")"))
                            {
                                TKI.Text += TMI.Text;
                                string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                TKI.Text = "";

                                TMI.Text = esult;
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "√";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "log":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Log(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "n!":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                if (TMI.Text.EndsWith("("))
                                {
                                    TMI.Text = "";
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Factor(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "exp":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                if (TMI.Text.EndsWith("("))
                                {
                                    TMI.Text = "";
                                }
                                x = Convert.ToDouble(TMI.Text);

                                TMI.Text = x.ToString() + ",e+0";
                                l = 0;
                            }
                            break;

                        case "10^x":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                if (TMI.Text.EndsWith("("))
                                {
                                    TMI.Text = "";
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Pow(10, x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "ln":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Log(1 - x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "sin":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Sin(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "cos":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Cos(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "tg":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Tan(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "ctg":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = 1.0 / Math.Tan(x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "x^3":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Pow(x, 3);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "2^x":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Pow(2, x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "∛x":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Pow(x, 1.0 / 3.0);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "log(y,x)":
                            if (TMI.Text.EndsWith("(") == true)
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            if (TMI.Text.EndsWith(")"))
                            {
                                TKI.Text += TMI.Text;
                                string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                TKI.Text = "";

                                TMI.Text = esult;
                            }
                            if (TMI.Text == "")
                            {
                                TMI.Text = "0";
                            }
                            if ((TKI.Text.EndsWith("√") == true || TKI.Text.EndsWith("^") == true || TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("%") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                            }
                            TKI.Text += TMI.Text;
                            TKI.Text += "l";
                            TMI.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "e^x":
                            if (TMI.Text == "")
                            {
                                TMI.Text = TMI.Text;
                            }
                            else
                            {
                                if (TMI.Text.EndsWith(")"))
                                {
                                    TKI.Text += TMI.Text;
                                    string esult = new DataTable().Compute(TKI.Text, null).ToString();
                                    TMI.Text = esult;
                                }
                                if (TMI.Text.Contains("("))
                                {
                                    TKI.Text += "(";
                                    TMI.Text = TMI.Text.Replace("(", "");
                                }
                                x = Convert.ToDouble(TMI.Text);
                                x = Math.Pow(2.7182818, x);
                                TMI.Text = x.ToString();
                            }
                            l = 1;
                            break;

                        case "=":
                            if (TKI.Text.Contains("√"))
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                                result = Math.Pow(Convert.ToDouble(TMI.Text), 1 / Convert.ToDouble(TKI.Text));
                                TMI.Text = "";
                                TKI.Text = "";
                                TMI.Text = result.ToString();
                            }
                            if (TKI.Text.Contains("l"))
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                                result = Math.Log(Convert.ToDouble(TKI.Text), Convert.ToDouble(TMI.Text));
                                TMI.Text = "";
                                TKI.Text = "";
                                TMI.Text = result.ToString();
                            }
                            if (TKI.Text.Contains("^"))
                            {
                                k = TKI.Text.Length - 1;
                                TKI.Text = TKI.Text.Remove(k, 1);
                                result = Math.Pow(Convert.ToDouble(TKI.Text), Convert.ToDouble(TMI.Text));
                                TMI.Text = result.ToString();
                            }
                            else
                            {
                                TKI.Text += TMI.Text;
                                TKI.Text = TKI.Text.Replace(",", ".");
                                if (bracket > 0)
                                {
                                    if (TKI.Text.EndsWith("("))
                                    {
                                        TKI.Text += "0";
                                    }
                                    for (int i = 0; i < bracket; i++)
                                    {
                                        TKI.Text += ")";
                                    }
                                }
                                if ((TKI.Text.EndsWith("+") == true || TKI.Text.EndsWith("\\") == true || TKI.Text.EndsWith("*") == true || TKI.Text.EndsWith("-") == true) && TMI.Text == "")
                                {
                                    TKI.Text += "0";
                                }
                                if (TKI.Text.EndsWith("."))
                                {
                                    k = TKI.Text.Length - 1;
                                    TKI.Text = TKI.Text.Remove(k, 1);
                                }
                                string res = new DataTable().Compute(TKI.Text, null).ToString();
                                TMI.Text = res;
                            }
                            l = 1;
                            c = 0;
                            TKI.Text = "";
                            bracket = 0;
                            break;

                        default:
                            if (l == 1)
                            {
                                TMI.Text = "";
                                TKI.Text = "";
                                l = 0;
                            }
                            if (TMI.Text.Contains(",e"))
                            {
                                k = TMI.Text.Length - 1;
                                TMI.Text = TMI.Text.Remove(k, 1);
                            }
                            TMI.Text += interesting;
                            break;
                    }
                }

                else if (Prog == true)
                {
                    switch (interesting)
                    {
                        case "Bin":
                            break;

                        case "Hex":
                            break;

                        case "Oct":
                            break;

                        case "Dec":
                            break;

                        case "CE":
                            TMP.Text = "";
                            TKP.Text = "";
                            thex.Text = "";
                            tdec.Text = "";
                            toct.Text = "";
                            tbin.Text = "";
                            l = 0;
                            break;

                        case "Z":
                            if (TMP.Text.Length > 1)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            else if (TMP.Text.Length == 1)
                            {
                                TMP.Text = "";
                            }
                            if (TMP.Text.Contains("A") || TMP.Text.Contains("B") || TMP.Text.Contains("C") || TMP.Text.Contains("D") || TMP.Text.Contains("E") || TMP.Text.Contains("F"))
                            {
                                thex.Text = TMP.Text;
                                int x = Convert.ToInt32(TMP.Text, 16);
                                tdec.Text = x.ToString();
                                long i = Convert.ToInt64(tdec.Text);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            else
                            {
                                long i = Convert.ToInt64(TMP.Text);
                                thex.Text = Convert.ToString(i, 16);
                                tdec.Text = Convert.ToString(i, 10);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            break;

                        case "+":
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            if (TMP.Text == "")
                            {
                                TMP.Text = "0";
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("%") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }
                            TKP.Text = tdec.Text;
                            TKP.Text += "+";
                            TMP.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "-":
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            if (TMP.Text == "")
                            {
                                TMP.Text = "0";
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("%") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }
                            TKP.Text = tdec.Text;
                            TKP.Text += "-";
                            TMP.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "*":
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            if (TMP.Text == "")
                            {
                                TMP.Text = "0";
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("%") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            TKP.Text = tdec.Text;
                            TKP.Text += "*";
                            TMP.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "/":
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            if (TMP.Text == "")
                            {
                                TMP.Text = "0";
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("%") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }
                            TKP.Text = tdec.Text;
                            TKP.Text += "/";
                            TMP.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "%":
                            if (TMP.Text.EndsWith("(") == true)
                            {
                                k = TMP.Text.Length - 1;
                                TMP.Text = TMP.Text.Remove(k, 1);
                            }
                            if (TMP.Text == "")
                            {
                                TMP.Text = "0";
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("%") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }
                            TKP.Text = tdec.Text;
                            TKP.Text += "%";
                            TMP.Text = "";
                            if (l == 1)
                            {
                                l = 0;
                            }
                            break;

                        case "=":
                            TKP.Text += tdec.Text;
                            TKP.Text = TKP.Text.Replace(",", ".");
                            if (bracket > 0)
                            {
                                if (TKP.Text.EndsWith("("))
                                {
                                    TKP.Text += "0";
                                }
                                for (int i = 0; i < bracket; i++)
                                {
                                    TKP.Text += ")";
                                }
                            }
                            if ((TKP.Text.EndsWith("+") == true || TKP.Text.EndsWith("\\") == true || TKP.Text.EndsWith("*") == true || TKP.Text.EndsWith("-") == true) && TMP.Text == "")
                            {
                                TKP.Text += "0";
                            }
                            if (TKP.Text.EndsWith("."))
                            {
                                k = TKP.Text.Length - 1;
                                TKP.Text = TKP.Text.Remove(k, 1);
                            }

                            string res = new DataTable().Compute(TKP.Text, null).ToString();
                            if (res.Contains(","))
                            {
                                double g = Convert.ToDouble(res);
                                res = Math.Round(g).ToString();

                            }
                            TMP.Text = res;

                            if (TMP.Text.Contains("A") || TMP.Text.Contains("B") || TMP.Text.Contains("C") || TMP.Text.Contains("D") || TMP.Text.Contains("E") || TMP.Text.Contains("F"))
                            {
                                thex.Text = TMP.Text;
                                int x = Convert.ToInt32(TMP.Text, 16);
                                tdec.Text = x.ToString();
                                long i = Convert.ToInt64(tdec.Text);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            else
                            {
                                long i = Convert.ToInt64(TMP.Text);
                                thex.Text = Convert.ToString(i, 16);
                                tdec.Text = Convert.ToString(i, 10);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            l = 1;
                            c = 0;
                            TKP.Text = "";
                            bracket = 0;
                            break;

                        case "":
                            MessageBox.Show("Тут ничего нет, просто для красоты", "Nothing");
                            break;

                        case ",":
                            MessageBox.Show("В калькуляторе от шиндовс она не работает вообще", "Ого");
                            break;

                        case "+/-":
                            if (TMP.Text == "")
                            {
                                TMP.Text = "";
                            }
                            else
                            {
                                pOm = Convert.ToDouble(TMP.Text);
                                pOm *= -1;
                                TMP.Text = pOm.ToString();
                                long i = Convert.ToInt64(TMP.Text);
                                thex.Text = Convert.ToString(i, 16);
                                tdec.Text = Convert.ToString(i, 10);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            break;

                        case ")":
                            if (TKP.Text.Contains("(") == false)
                            {
                                TMP.Text = TMP.Text;
                            }
                            else
                            {
                                TKP.Text += ")";
                                bracket -= 1;
                            }
                            break;

                        case "(":
                            if ((TKP.Text.EndsWith("+") == false || TKP.Text.EndsWith("%") == false || TKP.Text.EndsWith("\\") == false || TKP.Text.EndsWith("*") == false || TKP.Text.EndsWith("-") == false) && TMP.Text != "" && TMP.Text.EndsWith("(") != true)
                            {
                                TKP.Text += TMP.Text;
                                TKP.Text += "*";
                                TMP.Text = "";
                            }
                            TKP.Text += "(";
                            bracket += 1;
                            break;

                        default:
                            if (l == 1)
                            {
                                TKP.Text = "";
                                TMP.Text = "";
                            }
                            TMP.Text += interesting;
                            if (TMP.Text.Contains("A") || TMP.Text.Contains("B") || TMP.Text.Contains("C") || TMP.Text.Contains("D") || TMP.Text.Contains("E") || TMP.Text.Contains("F"))
                            {
                                thex.Text = TMP.Text;
                                int x = Convert.ToInt32(TMP.Text, 16);
                                tdec.Text = x.ToString();
                                long i = Convert.ToInt64(tdec.Text);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            else
                            {
                                long i = Convert.ToInt64(TMP.Text);
                                thex.Text = Convert.ToString(i, 16);
                                tdec.Text = Convert.ToString(i, 10);
                                toct.Text = Convert.ToString(i, 8);
                                tbin.Text = Convert.ToString(i, 2);
                            }
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                TMI.Text = "";
                TKI.Text = "";
                TMP.Text = "";
                TKP.Text = "";
                KidT.Text = "";
                MainT.Text = "";
                MessageBox.Show("Ошибочка вышла, нельзя так писать!", "У вас проблемы.");
            }
            catch (OverflowException)
            {
                TMI.Text = "";
                TKI.Text = "";
                TMP.Text = "";
                TKP.Text = "";
                KidT.Text = "";
                MainT.Text = "";
                MessageBox.Show("Ошибочка вышла, нельзя так писать!", "У вас проблемы.");
            }
            catch (EvaluateException)
            {
                TMI.Text = "";
                TKI.Text = "";
                TMP.Text = "";
                TKP.Text = "";
                KidT.Text = "";
                MainT.Text = "";
                MessageBox.Show("Ошибочка вышла, нельзя так писать!", "У вас проблемы.");
            }
            catch (SyntaxErrorException)
            {
                TMI.Text = "";
                TKI.Text = "";
                TMP.Text = "";
                TKP.Text = "";
                KidT.Text = "";
                MainT.Text = "";
                MessageBox.Show("Ошибочка вышла, нельзя так писать!", "У вас проблемы.");
            }
        }
        private void Rectangle_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (this.WindowState != WindowState.Minimized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else this.WindowState = WindowState.Maximized;
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void Nometry_Click(object sender, RoutedEventArgs e)
        {
            if (TNometry == false)
            {
                TNometry = true;
            }
            else
            {
                TNometry = false;
            }
            if (TNometry == true)
            {
                sin.Content = "sin";
                cos.Content = "cos";
                tg.Content = "tg";
                ctg.Content = "ctg";
            }
            else
            {
                sin.Content = "";
                cos.Content = "";
                tg.Content = "";
                ctg.Content = "";
            }
        }
        private void Sec_Click(object sender, RoutedEventArgs e)
        {
            if (Second == false)
            {
                Second = true;
            }
            else
            {
                Second = false;
            }
            if (Second == true)
            {
                s1.Content = "x^3";
                s2.Content = "∛x";
                s3.Content = "y√x";
                s4.Content = "2^x";
                s5.Content = "log(y,x)";
                s6.Content = "e^x";
            }
            else
            {
                s1.Content = "Sqr(x)";
                s2.Content = "Sqrt(x)";
                s3.Content = "x^y";
                s4.Content = "10^x";
                s5.Content = "log";
                s6.Content = "ln";
            }
        }
        private void Inzhe_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Inzh = true;
            Prog = false;
            Common = false;
        }
        private void Com_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Prog = false;
            Inzh = false;
            Common = true;
        }
        static double Factor(double a)
        {
            if (a > 0)
            {
                return a * Factor(a - 1);
            }
            else return 1;
        }
        private void hex_Click(object sender, RoutedEventArgs e)
        {
            A16.IsEnabled = true;
            B16.IsEnabled = true;
            C16.IsEnabled = true;
            D16.IsEnabled = true;
            E16.IsEnabled = true;
            F16.IsEnabled = true;
            B0.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            B4.IsEnabled = true;
            B5.IsEnabled = true;
            B6.IsEnabled = true;
            B7.IsEnabled = true;
            B8.IsEnabled = true;
            B9.IsEnabled = true;
        }
        private void dec_Click(object sender, RoutedEventArgs e)
        {
            A16.IsEnabled = false;
            B16.IsEnabled = false;
            C16.IsEnabled = false;
            D16.IsEnabled = false;
            E16.IsEnabled = false;
            F16.IsEnabled = false;
            B0.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            B4.IsEnabled = true;
            B5.IsEnabled = true;
            B6.IsEnabled = true;
            B7.IsEnabled = true;
            B8.IsEnabled = true;
            B9.IsEnabled = true;
        }
        private void oct_Click(object sender, RoutedEventArgs e)
        {
            A16.IsEnabled = false;
            B16.IsEnabled = false;
            C16.IsEnabled = false;
            D16.IsEnabled = false;
            E16.IsEnabled = false;
            F16.IsEnabled = false;
            B0.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = true;
            B3.IsEnabled = true;
            B4.IsEnabled = true;
            B5.IsEnabled = true;
            B6.IsEnabled = true;
            B7.IsEnabled = true;
            B8.IsEnabled = false;
            B9.IsEnabled = false;
        }
        private void bin_Click(object sender, RoutedEventArgs e)
        {
            A16.IsEnabled = false;
            B16.IsEnabled = false;
            C16.IsEnabled = false;
            D16.IsEnabled = false;
            E16.IsEnabled = false;
            F16.IsEnabled = false;
            B0.IsEnabled = true;
            B1.IsEnabled = true;
            B2.IsEnabled = false;
            B3.IsEnabled = false;
            B4.IsEnabled = false;
            B5.IsEnabled = false;
            B6.IsEnabled = false;
            B7.IsEnabled = false;
            B8.IsEnabled = false;
            B9.IsEnabled = false;
        }
        private void Progr_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Prog = true;
            Inzh = false;
            Common = false;
        }
    }
}