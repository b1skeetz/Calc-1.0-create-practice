using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Class1 func = new Class1();
        char sym = ' '; // сам символ действия
        double equals = 0; // конечное значение
        bool isPoint = false; // разделитель для точки 
        int newSize = 4;
        int chet = 0;
        char[] arr_sym = new char[4];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void main_button_Click(object sender, EventArgs e)
        {
            
        }



        private void one_Click(object sender, EventArgs e)
        {
            func.WriteText(one, textBox1);
            sym = ' ';
        }

        private void two_Click(object sender, EventArgs e)
        {
            func.WriteText(two, textBox1);
            sym = ' ';
        }

        private void three_Click(object sender, EventArgs e)
        {
            func.WriteText(three, textBox1);
            sym = ' ';
        }

        private void four_Click(object sender, EventArgs e)
        {
            func.WriteText(four, textBox1);
            sym = ' ';
        }

        private void five_Click(object sender, EventArgs e)
        {
            func.WriteText(five, textBox1);
            sym = ' ';
        }

        private void six_Click(object sender, EventArgs e)
        {
            func.WriteText(six, textBox1);
            sym = ' ';
        }

        private void seven_Click(object sender, EventArgs e)
        {
            func.WriteText(seven, textBox1);
            sym = ' ';
        }

        private void eight_Click(object sender, EventArgs e)
        {
            func.WriteText(eight, textBox1);
            sym = ' ';
        }

        private void nine_Click(object sender, EventArgs e)
        {
            func.WriteText(nine, textBox1);
            sym = ' ';
        }

        private void zero_Click(object sender, EventArgs e)
        {
            func.WriteText(zero, textBox1);
            sym = ' ';
        }

////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void plus_Click(object sender, EventArgs e)
        {
            if(sym != Convert.ToChar(plus.Text))
            {
                sym = func.replase_sym(sym, textBox1, plus, isPoint, '+'); // запись нового 
                    arr_sym[chet] = sym;
                    chet++;
                
            }
        }
//--------------------------------------------------------------------------------------------------------
        private void mines_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(mines.Text))
            {
                sym = func.replase_sym(sym, textBox1, mines, isPoint, '-'); // запись нового символа
                arr_sym[chet] = sym;
                chet++;
            }
        }

        private void multy_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(multy.Text))
            {
                sym = func.replase_sym(sym, textBox1, multy, isPoint, '*'); // запись нового символа
                arr_sym[chet] = sym;
                chet++;
            }
        }   

        private void delit_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(delit.Text))
            {
                sym = func.replase_sym(sym, textBox1, delit, isPoint, '/'); // запись нового символа
                arr_sym[chet] = sym;
                chet++;
            }
        }

        private void equal_Click(object sender, EventArgs e)
        {
            double[] numbers = func.mySplit(textBox1.Text);
            MessageBox.Show(numbers[0].ToString(), numbers[1].ToString());
            //string[] temp_number = new string[4];
            //Stack<int> all_expression = new Stack<int>();
            //for (int i = 0; i < 4; i++)
            //{
            //    //Convert.ToString(textBox1.Text.Split(arr_sym[i]));
            //    temp_number[i] = Convert.ToString(textBox1.Text.Split(arr_sym[i]));
            //    all_expression.Push(Convert.ToInt32(temp_number[i]));
            //}
            //for (int i = 0; i < newSize; i++)
            //{
            //    while (all_expression.Any())
            //    {
            //        char temp = arr_sym[i];
            //        switch (temp)
            //        {
            //            case '+':
            //                int local_temp = 0;
            //                local_temp = all_expression.Pop();
            //                equals = local_temp + all_expression.Peek();

            //                break;
            //            case '-':

            //                break;
            //            case '*':

            //                break;
            //            case '/':

            //                break;
            //            case '^':

            //                break;
            //        }
            //    }

            //}

            /*for (int j = 0; j < arr_sym.Length; j++)
            {
                sym = arr_sym[j];
                switch (sym)
                {
                    case '+':
                        string[] arr_plus = textBox1.Text.Split(sym);
                        for (int i = 0; i < arr_plus.Length; i++)
                        {
                            equals += Convert.ToDouble(arr_plus[i]);
                        }
                        break;
                    case '-':
                        string[] arr_minus = textBox1.Text.Split(sym);
                        equals = Convert.ToDouble(arr_minus[0]) - Convert.ToDouble(arr_minus[1]);
                        break;
                    case '*':
                        string[] arr_multy = textBox1.Text.Split(sym);
                        equals = Convert.ToDouble(arr_multy[0]) * Convert.ToDouble(arr_multy[1]);

                        break;
                    case '/':
                        string[] arr_delit = textBox1.Text.Split(sym);
                        equals = Convert.ToDouble(arr_delit[0]) / Convert.ToDouble(arr_delit[1]);
                        break;
                    case '^':
                        string[] arr_step = textBox1.Text.Split(sym);
                        equals = func.my_pow(Convert.ToDouble(arr_step[0]), Convert.ToInt32(arr_step[1]));
                        break;
                }
            }*/
            func.WriteText(equal, textBox1); // добавление знака равно
            textBox_answer.Text += Math.Round(equals, 3).ToString(); // округление до 3 знаков после запятой
            sym = ' '; // очистка символа действия
        }

        private void bClear_Click(object sender, EventArgs e)
        {
            sym = ' '; // очистка всех символов
            equals = 0;
            textBox1.Text = "";
            isPoint = false;
            textBox_answer.Text = "";
        }

        private void bFact_Click(object sender, EventArgs e)
        {
            int res = 1;
            int fact = int.Parse(textBox1.Text);
            for(int i = 1; i <= fact; i++)
            {
                res *= i;
            }
            textBox1.Text = res.ToString();
        }

        private void bSqrt_Click(object sender, EventArgs e)
        {
            int sqrt = int.Parse(textBox1.Text);
            double res = Math.Sqrt(sqrt);
            textBox1.Text = res.ToString();
        }

        private void bPow_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(bPow.Text))
            {
                sym = func.replase_sym(sym, textBox1, bPow, isPoint, '^'); // запись нового символа 
            }
        }

        private void bDot_Click(object sender, EventArgs e)
        {
            if (isPoint == false)
            {
                func.WriteText(bDot, textBox1); //запись точки в тексбокс
                isPoint = true;
            }
        }

        private void label_answer_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
