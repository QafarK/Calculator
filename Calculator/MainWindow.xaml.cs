using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_CE(object sender, RoutedEventArgs e)
        {
            View.Content="0";
        }
        private void Button_Click_C(object sender, RoutedEventArgs e)
        {
            View.Content="0";
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
                View.Content += "7";
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            View.Content += "8";
        }
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            View.Content += "9";
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            View.Content += "4";
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            View.Content += "5";
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            View.Content += "6";
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            View.Content += "1";
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            View.Content += "2";
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            View.Content += "3";
        }
        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            View.Content += "0";
        }

        private void Button_Click_Backspace(object sender, RoutedEventArgs e)
        {
            if (View.Content.ToString().Length > 0)
                View.Content = View.Content.ToString().Remove(View.Content.ToString().Length - 1);
        }

        private void Button_Click_Divide(object sender, RoutedEventArgs e)
        {
            if (View.Content.ToString().Length > 0)
            {
                if (View.Content.ToString()[View.Content.ToString().Length - 1].Equals('*') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('-') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('+'))
                {
                    View.Content = View.Content.ToString().Remove(View.Content.ToString().Length - 1);
                    View.Content += "/";
                }
                else if (!View.Content.ToString()[View.Content.ToString().Length - 1].Equals('/'))
                    View.Content += "/";
            }
        }
        private void Button_Click_Minus(object sender, RoutedEventArgs e)
        {
            if (View.Content.ToString().Length > 0)
            {
                if (View.Content.ToString()[View.Content.ToString().Length - 1].Equals('*') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('/') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('+'))
                {
                    View.Content = View.Content.ToString().Remove(View.Content.ToString().Length - 1);
                    View.Content += "-";
                }
                else if (!View.Content.ToString()[View.Content.ToString().Length - 1].Equals('-'))
                    View.Content += "-";
            }
        }
        private void Button_Click_Plus(object sender, RoutedEventArgs e)
        {
            if (View.Content.ToString().Length > 0)
            {
                if (View.Content.ToString()[View.Content.ToString().Length - 1].Equals('*') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('-') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('/'))
                {
                    View.Content = View.Content.ToString().Remove(View.Content.ToString().Length - 1);
                    View.Content += "+";
                }
                else if (!View.Content.ToString()[View.Content.ToString().Length - 1].Equals('+'))
                    View.Content += "+";
            }
        }

        private void Button_Click_Multiply(object sender, RoutedEventArgs e)
        {
            if (View.Content.ToString().Length > 0)
            {
                if (View.Content.ToString()[View.Content.ToString().Length - 1].Equals('/') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('-') || View.Content.ToString()[View.Content.ToString().Length - 1].Equals('+'))
                {
                    View.Content = View.Content.ToString().Remove(View.Content.ToString().Length - 1);
                    View.Content += "*";
                }
                else if (!View.Content.ToString()[View.Content.ToString().Length - 1].Equals('*'))
                    View.Content += "*";
            }
        }

        private void Button_Click_Equal(object sender, RoutedEventArgs e)
        {
            string data = "";
            List<char> op = new List<char>();

            for (int i = 0; i < View.Content.ToString().Length; i++)
            {
                if (i == 0 && View.Content.ToString()[0].Equals('-'))
                {
                    data += "0 ";
                    op.Add('-');
                }
                else
                {
                    if (View.Content.ToString()[i].Equals('+') || View.Content.ToString()[i].Equals('-') || View.Content.ToString()[i].Equals('*') || View.Content.ToString()[i].Equals('/'))
                    {
                        op.Add(View.Content.ToString()[i]);
                        data += " ";
                    }
                    else
                        data += View.Content.ToString()[i];
                }
            }
            var nums = data.Split(' ');
            int result = Convert.ToInt32(nums[0]);

            int index = 0;
            for (int i = 0; i < op.Count; i++)
            {
                if (op[i].Equals('+'))
                    result = result + Convert.ToInt32(nums[index + 1]);
                else if (op[i].Equals('-'))
                    result = result - Convert.ToInt32(nums[index + 1]);
                else if (op[i].Equals('*'))
                    result = result * Convert.ToInt32(nums[index + 1]);
                else if (op[i].Equals('/'))
                    result = result / Convert.ToInt32(nums[index + 1]);
                index++;
            }
            View.Content = result.ToString();
        }
    }
}