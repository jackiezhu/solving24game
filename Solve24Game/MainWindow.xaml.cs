using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Solve24Game
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Any bug or advice, please contact me via www.scolarart.com \n  纯属娱乐，版权不究");
        }

        private void RandomInputGenerate(object sender, RoutedEventArgs e)
        {
            Random rand = new Random();
            number1.Text = Convert.ToString(rand.Next() % 13 + 1);
            number2.Text = Convert.ToString(rand.Next() % 13 + 1);
            number3.Text = Convert.ToString(rand.Next() % 13 + 1);
            number4.Text = Convert.ToString(rand.Next() % 13 + 1);
        }

        private bool NumberInRange(int n) 
        {
            return n >= 1 && n <= 13;
        }

        private bool NumberInRange()
        {
            int num1 = Convert.ToInt32(number1.Text.Trim());
            int num2 = Convert.ToInt32(number2.Text.Trim());
            int num3 = Convert.ToInt32(number3.Text.Trim());
            int num4 = Convert.ToInt32(number4.Text.Trim());
            return NumberInRange(num1) && NumberInRange(num2) && NumberInRange(num3) && NumberInRange(num4);
        }

        private bool ValidInput()
        {
            string pattern = @"^\d+$";
            if (Regex.IsMatch(number1.Text.Trim(), pattern) && Regex.IsMatch(number2.Text.Trim(), pattern)
                && Regex.IsMatch(number3.Text.Trim(), pattern) && Regex.IsMatch(number4.Text.Trim(), pattern))
            {
                return NumberInRange();
            }
            return false;
        }

        private void GenerateAnwser(object sender, RoutedEventArgs e)
        {
            if (!ValidInput())
            {
                MessageBox.Show("请输入1-13之间的整数");
                return;
            }

            List<int> input = new List<int>();
            input.Add(Convert.ToInt32(number1.Text.Trim()));
            input.Add(Convert.ToInt32(number2.Text.Trim()));
            input.Add(Convert.ToInt32(number3.Text.Trim()));
            input.Add(Convert.ToInt32(number4.Text.Trim()));
            Solving24 solving24Instance = new Solving24(input);
            List<String> result = solving24Instance.CalculateResult(); 
            dgList.ItemsSource = result;
        }

    }
}
