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
    public partial class Form1 : Form
    {
        Class1 func = new Class1();
        char sym = ' '; // сам символ действия
        double equals = 0; // конечное значение
        bool isPoint = false; // разделитель для точки 
        int newSize = 4;
        int chet = 0;
        static int sizeArr = 0;
        char[] arr_sym = new char[sizeArr];
        double[] numbers = new double[0];
        Stack<double> stackForNumbers = new Stack<double>();
        Stack<char> stackForOperations = new Stack<char>();
        Test_form form = new Test_form();

        public Form1()
        {
            InitializeComponent();
            this.Region = new Region(func.RoundedRect(new Rectangle(0, 0, this.Width, this.Height), 10));
        }

        private void Form1_Load(object sender, EventArgs e)
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
//------------------------------------------------------------------------------------//
        private void plus_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(plus.Text))
            {
                sym = func.replase_sym(sym, textBox1, plus, isPoint, '+'); // запись нового 
                arr_sym = func.reSize(arr_sym, sym);
            }
        }
        
        private void mines_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(mines.Text))
            {
                sym = func.replase_sym(sym, textBox1, mines, isPoint, '-'); // запись нового символа
                arr_sym = func.reSize(arr_sym, sym);
            }
        }

        private void multy_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(multy.Text))
            {
                sym = func.replase_sym(sym, textBox1, multy, isPoint, '*'); // запись нового символа
                arr_sym = func.reSize(arr_sym, sym);
            }
        }

        private void delit_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(delit.Text))
            {
                sym = func.replase_sym(sym, textBox1, delit, isPoint, '/'); // запись нового символа
                arr_sym = func.reSize(arr_sym, sym);
            }
        }
//------------------------------------------------------------------------------------//
        private void equal_Click(object sender, EventArgs e)
        {
            numbers = func.mySplit(textBox1.Text);
            /*func.stackInitNum(stackForNumbers, numbers);
            for (int i = 0; i < arr_sym.Length; i++) // очистка стека от лишних нулей
            {
                stackForNumbers.Pop();
            }
            func.stackInitSym(stackForOperations, arr_sym);*/
            for (int i = 0; i < arr_sym.Length; i++)
            {
                numbers[i + 1] = func.counting(numbers[i], numbers[i + 1], arr_sym[i]);
            }
            equals = numbers[arr_sym.Length];

           // equals = func.solving(stackForNumbers, stackForOperations);
            
            

            func.WriteText(equal, textBox1); // добавление знака равно
            textBox_answer.Text += Math.Round(equals, 2).ToString(); // округление до 3 знаков после запятой
            sym = ' '; // очистка символа действия
        }
//------------------------------------------------------------------------------------//

        private void bClear_Click(object sender, EventArgs e)
        {
            sym = ' '; // очистка всех символов
            equals = 0;
            textBox1.Text = "";
            isPoint = false;
            textBox_answer.Text = "";
            arr_sym = new char[0];
            numbers = new double[0];
            stackForNumbers.Clear();
            stackForOperations.Clear();
        }

        private void bFact_Click(object sender, EventArgs e)
        {
            int res = 1;
            int fact = int.Parse(textBox1.Text);
            for (int i = 1; i <= fact; i++)
            {
                res *= i;
            }
            textBox_answer.Text = res.ToString();
        }

        private void bSqrt_Click(object sender, EventArgs e)
        {
            int sqrt = int.Parse(textBox1.Text);
            double res = Math.Sqrt(sqrt);
            textBox_answer.Text = Math.Round(res, 2).ToString(); ;
        }

        private void bPow_Click(object sender, EventArgs e)
        {
            if (sym != Convert.ToChar(bPow.Text))
            {
                sym = func.replase_sym(sym, textBox1, bPow, isPoint, '^'); // запись нового символа 
                arr_sym = func.reSize(arr_sym, sym);
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

        private void seven_MouseEnter(object sender, EventArgs e)
        {
            seven.BackColor = Color.FromArgb(227, 25, 183);
        }

        private void seven_MouseLeave(object sender, EventArgs e)
        {
            seven.BackColor = Color.Orange;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.BackColor = Color.LightGreen;
            
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.BackColor = Color.Orange;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.BackColor = Color.LightGreen;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.BackColor = Color.Orange;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.BackColor = Color.LightGreen;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.Orange;
        }

        private void textBox_answer_TextChanged(object sender, EventArgs e)
        {
            if (textBox_answer.Text == "123")
            {
                this.Hide();
                form.ShowDialog();
            }
        }
    }
}
