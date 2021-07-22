using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;
using System.Collections;
using System.Drawing.Drawing2D;

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
            for (int i = 1; i < step; i++)
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
            for (int i = 0; i < str_lenth; i++)
            {
                if (str[i] == '+' || str[i] == '-' || str[i] == '*' || str[i] == '/' || str[i] == '^')
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
            for (int i = 0; i < mas.Length; i++)
            {
                newMas[i] = mas[i];
            }
            newMas[newMas.Length - 1] = sym;
            return newMas;
        }

        public int Prior(char sym)
        {
            switch (sym)
            {
                case '+': case '-': return 1;
                case '*': return 2;
                case '/': return 3;
                case '^': return 4;
                default: break;
            }
            return 0;
        }
        public void stackInitNum(Stack<double> numSt, double[] masNum)
        {
            for (int i = 0; i < masNum.Length; i++)
            {
                numSt.Push(masNum[i]);
            }
        }

        public void stackInitSym(Stack<char> symSt, char[] masSym)
        {
            for (int i = 0; i < masSym.Length; i++)
            {
                symSt.Push(masSym[i]);
            }
        }

        public double solving(Stack<double> StackForNumbers, Stack<char> StackForOperators)
        {
            double solve = 0;
            double res;

            /*double nodeForFloat;
            Stack<double> tmpStackFloat = new Stack<double>();
            while (!StackForNumbers.Any())
            {
                nodeForFloat = StackForNumbers.Peek();
                StackForNumbers.Pop();
                tmpStackFloat.Push(nodeForFloat);
            }
            StackForNumbers = tmpStackFloat;

            char nodeForChar;
            Stack<char> tmpStackChar = new Stack<char>();
            while (!StackForOperators.Any())
            {
                nodeForChar = StackForOperators.Peek();
                StackForOperators.Pop();
                tmpStackChar.Push(nodeForChar);
            }
            StackForOperators = tmpStackChar;*/

            char buf = StackForOperators.Peek();
            while (StackForOperators.Count != 0)
            {
               
                //StackForOperators.Pop();
                if (Prior(buf) <= Prior(StackForOperators.Peek()))
                {
                    double buffer = StackForNumbers.Peek();
                    StackForNumbers.Pop();
                    //buf = StackForOperators.Peek();
                    switch (buf)
                    {
                        case '+': { res = buffer + StackForNumbers.Peek(); StackForNumbers.Pop(); StackForNumbers.Push(res); StackForOperators.Pop();
                                if (StackForOperators.Any())
                                {
                                    buf = StackForOperators.Peek();
                                }
                            } break;
                        case '-': { res = StackForNumbers.Peek() - buffer; StackForNumbers.Pop(); StackForNumbers.Push(res); StackForOperators.Pop();
                                if (StackForOperators.Any())
                                {
                                    buf = StackForOperators.Peek();
                                }
                            } break;
                        case '*': { res = buffer * StackForNumbers.Peek(); StackForNumbers.Pop(); StackForNumbers.Push(res); StackForOperators.Pop();
                                if (StackForOperators.Any())
                                {
                                    buf = StackForOperators.Peek();
                                }
                            } break;
                        case '/': { res = StackForNumbers.Peek() / buffer; StackForNumbers.Pop(); StackForNumbers.Push(res); StackForOperators.Pop();
                                if (StackForOperators.Any())
                                {
                                    buf = StackForOperators.Peek();
                                }
                            } break;
                        default: break;
                    } //switch (buffer2)
                } //if (Prior(buf) < Prior(StackForOperators.top()))
                else
                {
                    char bufForChange2 = StackForOperators.Pop();
                    StackForOperators.Push(buf);
                    StackForOperators.Push(bufForChange2);
                }
            } //if (!StackForOperators.empty()) {
            solve = StackForNumbers.Peek();
            return solve;
        }

        public GraphicsPath RoundedRect(Rectangle baseRect, int radius)
        {
            var diameter = radius * 2;
            var sz = new Size(diameter, diameter);
            var arc = new Rectangle(baseRect.Location, sz);
            var path = new GraphicsPath();

            // Верхний левый угол
            path.AddArc(arc, 180, 90);

            // Верхний правый угол
            arc.X = baseRect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Нижний правый угол
            arc.Y = baseRect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Нижний левый угол
            arc.X = baseRect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
