using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    class Class1
    {
        public void WriteText(Button b, TextBox box)
        {
            box.Text += b.Text;
        }

        public void WriteText(Button b, Label box)
        {
            box.Text += b.Text;
        }

        public double my_pow(double number, int step)
        {
            double res = number;
            for(int i = 1; i < step; i++)
            {
                res *= number;
            }
            return res;
        }

        public char replase_sym(char sym, TextBox textBox, Button b, bool point, char change_sym)
        {
            if (sym != ' ')
            {
                string temp = textBox.Text;
                textBox.Text = temp.Replace(sym, Convert.ToChar(b.Text));
                sym = change_sym;
            }
            else
            {
                WriteText(b, textBox);
                sym = change_sym;
                point = false;
            }
            return sym;
        }

        public double[] mySplit(string str)
        {
            int str_lenth = str.Length;
            string temp = "";
            double[] numbers = new double[str_lenth];
            int chetchik = 0;
            for(int i = 0; i < str_lenth; i++)
            {
                if(str[i] == '+' || str[i] == '-'|| str[i] == '*'|| str[i] == '/' || str[i] == '^')
                {
                    numbers[chetchik] = Convert.ToDouble(temp);
                    chetchik++;
                    temp = "";
                }
                else
                {
                    temp += str[i];
                  
                }
            }
            numbers[chetchik] = Convert.ToDouble(temp);
            return numbers;
        }

        public double counting(double num1, double num2, char sym)
        {
            switch (sym)
            {
                case '+':
                    return num1 + num2;
                    
                case '-':
                    return num1 - num2;
                    
                case '*':
                    return num1 * num2;
                    
                case '/':
                    return num1 / num2;
                    
                case '^':
                    return Math.Pow(num1, num2);
                    
            }
            return 0;
        }

        public char[] reSize(char[] mas, char sym)
        {
            char[] newMas = new char[mas.Length + 1];
            for(int i = 0; i < mas.Length; i++)
            {
                newMas[i] = mas[i];
            }
            newMas[newMas.Length - 1] = sym;
            return newMas;
        }
    }
}
