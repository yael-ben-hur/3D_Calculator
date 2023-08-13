using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string function;
        int size = 101;
        double[,] ver;
        double[,] xtag;
        double[,] ytag;
        int[] filling;
        int[,] pxtag;
        int[,] pytag;
        double accuracy = 0.09;
        int zoom = 75;
        double alpha = Math.PI / 5;

        static BinTreeNode<string> BuildTree(String str)
        {
            BinTreeNode<string> tr = null;
            for (int i = str.Length - 1, a = 0; i > 0; i--)
            {
                if (str[i] == ')')
                    a++;
                if (str[i] == '(')
                    a--;
                if (str[i] == '-' && tr == null && a == 0)
                    return tr = new BinTreeNode<string>(BuildTree(str.Substring(0, i)), str[i].ToString(), BuildTree(str.Substring(i + 1, str.Length - i - 1)));
                else
                   if (str[i] == '+' && tr == null && a == 0)
                    return tr = new BinTreeNode<string>(BuildTree(str.Substring(0, i)), str[i].ToString(), BuildTree(str.Substring(i + 1, str.Length - i - 1)));
            }

            for (int i = str.Length - 1, a = 0; i > 0; i--)
            {
                if (str[i] == ')')
                    a++;
                if (str[i] == '(')
                    a--;
                if (str[i] == '/' && tr == null && a == 0)
                    return tr = new BinTreeNode<string>(BuildTree(str.Substring(0, i)), str[i].ToString(), BuildTree(str.Substring(i + 1, str.Length - i - 1)));
                else
                if (str[i] == '*' && tr == null && a == 0)
                    return tr = new BinTreeNode<string>(BuildTree(str.Substring(0, i)), str[i].ToString(), BuildTree(str.Substring(i + 1, str.Length - i - 1)));
            }
            for (int i = str.Length - 1, a = 0; i > 0; i--)
            {
                if (str[i] == ')')
                    a++;
                if (str[i] == '(')
                    a--;
                if (a == 0 && str[i] == 'n' && str[i - 1] == 'i')
                {
                    tr = new BinTreeNode<string>("Sin");
                    for (int k = i + 1; k < str.Length; k++)
                    {
                        if (str[k] == '(')
                            a++;
                        if (str[k] == ')')
                            a--;
                        if (a == 0)
                            tr.SetRight(BuildTree(str.Substring(i + 2, k - i - 2)));
                    }
                }
                else
                if (a == 0 && str[i] == 's')
                {
                    tr = new BinTreeNode<string>("Cos");
                    for (int k = i + 1; k < str.Length; k++)
                    {
                        if (str[k] == '(')
                            a++;
                        if (str[k] == ')')
                            a--;
                        if (a == 0)
                             tr.SetRight(BuildTree(str.Substring(i + 2, k - i - 2)));
                    }
                }
                else
                if (a == 0 && str[i] == 'n' && str[i - 1] == 'a')
                {
                    tr = new BinTreeNode<string>("Tan");
                    for (int k = i + 1; k < str.Length; k++)
                    {
                        if (str[k] == '(')
                            a++;
                        if (str[k] == ')')
                            a--;
                        if (a == 0)
                            tr.SetRight(BuildTree(str.Substring(i + 2, k - i - 2)));
                    }
                }
                if (a == 0 && str[i] == 't')
                {
                    for (int k = i + 1, p = 0; k < str.Length; k++)
                    {
                        if (str[k] == '(')
                            a++;
                        if (str[k] == ')')
                            a--;
                        if (str[k] == ',')
                            p = k;
                        if (a == 0)
                        {
                            string s = str.Substring(i + 2, k - i - 2);
                            p = p - i - 2;
                            return tr = new BinTreeNode<string>(BuildTree(s.Substring(0, p)), "Sqrt", BuildTree(s.Substring(p + 1, s.Length - p - 1)));
                        }
                    }
                }
                if (a == 0 && str[i] == 'g')
                {
                    for (int k = i + 1, p = 0; k < str.Length; k++)
                    {
                        if (str[k] == '(')
                            a++;
                        if (str[k] == ')')
                            a--;
                        if (str[k] == ',')
                            p = k;
                        if (a == 0)
                        {
                            string s = str.Substring(i + 2, k - i - 2);
                            p = p - i - 2;
                            return tr = new BinTreeNode<string>(BuildTree(s.Substring(0, p)), "Log", BuildTree(s.Substring(p + 1, s.Length - p - 1)));
                        }
                    }
                }
                if (a == 0 && str[i] == '^')
                    return tr = new BinTreeNode<string>(BuildTree(str.Substring(0, i)), str[i].ToString(), BuildTree(str.Substring(i + 1, str.Length - i - 1)));
            }
            if (str[0] == '(')
            {
                str = str.Substring(1, str.Length - 2);
                return BuildTree(str);
            }
            if (tr == null)
                tr = new BinTreeNode<string>(str);
            return tr;
        }
        double Calculate(BinTreeNode<string> t, double x, double y)
        {
            if (t != null)
            {
                string str = t.GetInfo();

                if (str == "+")
                    return Calculate(t.GetLeft(), x, y) + Calculate(t.GetRight(), x, y);
                else
                  if (str == "-")
                    return Calculate(t.GetLeft(), x, y) - Calculate(t.GetRight(), x, y);
                else
                         if (str == "*")
                    return Calculate(t.GetLeft(), x, y) * Calculate(t.GetRight(), x, y);
                else
                                 if (str == "/")
                    return Calculate(t.GetLeft(), x, y) / Calculate(t.GetRight(), x, y);
                else
                                      if (str == "Sin")
                    return Math.Sin(Calculate(t.GetRight(), x, y));
                else
                                        if (str == "Cos")
                    return Math.Cos(Calculate(t.GetRight(), x, y));
                else
                                            if (str == "Tan")
                    return Math.Tan(Calculate(t.GetRight(), x, y));
                else
                                              if (str == "Sqrt")
                    return Math.Pow(Calculate(t.GetLeft(), x, y), 1 / Calculate(t.GetRight(), x, y));
                else
                                                    if (str == "^")
                    return Math.Pow(Calculate(t.GetLeft(), x, y), Calculate(t.GetRight(), x, y));
                else if (str == "Log")
                    return Math.Log(Calculate(t.GetLeft(), x, y), Calculate(t.GetRight(), x, y));
            }
            if (t.GetInfo() == "y")
            {
                t.SetInfo(y.ToString());
                return double.Parse(t.GetInfo()) * accuracy;
            }
            if (t.GetInfo() == "x")
            {
                t.SetInfo(x.ToString());
                return double.Parse(t.GetInfo()) * accuracy;
            }
            return double.Parse(t.GetInfo());
        }
        private void Draw_Function_Click(object sender, EventArgs e)
        {
            try
            {
                ver = new double[size, size];
                xtag = new double[size, size];
                ytag = new double[size, size];
                pxtag = new int[size, size];
                pytag = new int[size, size];
                filling = new int[size * size];
                function = Insert_Function.Text;
                for (int i = 0, x = -size / 2; i < size; i++, x++)
                {

                    for (int p = 0, y = -size / 2; p < size; p++, y++)
                    {
                        ver[i, p] = Calculate(BuildTree(Insert_Function.Text), x, y);
                        xtag[i, p] = x * accuracy - y * accuracy * Math.Cos(alpha);
                        ytag[i, p] = ver[i, p] - y * accuracy * Math.Sin(alpha);
                        pxtag[i, p] = (int)(zoom * xtag[i, p]) + panel1.Width / 2;
                        pytag[i, p] = (panel1.Height / 2) - (int)(ytag[i, p] * zoom);
                    }
                }
                Graphics g = panel1.CreateGraphics();
                g.Clear(BackColor);
                for (int i = 0; i < ver.GetLength(0) - 1; i++)
                    for (int p = 0; p < ver.GetLength(1) - 1; p++)
                    {
                        if (!Double.IsNaN(xtag[i, p]) && !Double.IsNaN(ytag[i, p]) && !Double.IsNaN(xtag[i + 1, p]) && !Double.IsNaN(ytag[i + 1, p]) 
                            && !Double.IsNaN(xtag[i, p + 1]) && !Double.IsNaN(ytag[i, p + 1]) && !Double.IsNaN(xtag[i + 1, p + 1]) && !Double.IsNaN(ytag[i + 1, p + 1]) 
                            && !Double.IsInfinity(xtag[i, p]) && !Double.IsInfinity(ytag[i, p]) && !Double.IsInfinity(xtag[i + 1, p + 1]) 
                            && !Double.IsInfinity(ytag[i + 1, p + 1]) && !Double.IsInfinity(xtag[i + 1, p]) && !Double.IsInfinity(ytag[i + 1, p]) 
                            && !Double.IsInfinity(xtag[i, p + 1]) && !Double.IsInfinity(ytag[i, p + 1]))
                        {
                            g.DrawLine(Pens.Black,
                                             (float)pxtag[i, p],
                                             (float)pytag[i, p],
                                             (float)pxtag[i + 1, p],
                                             (float)pytag[i + 1, p]);
                            g.DrawLine(Pens.Black,
                                          (float)pxtag[i, p],
                                          (float)pytag[i, p],
                                          (float)pxtag[i, p + 1],
                                          (float)pytag[i, p + 1]);
                        }
                    }
            }
            catch
            {
                MessageBox.Show("Please enter a valid function");
            }
        }

        private void Color_The_Function_Click(object sender, EventArgs e)
        {
            try
            {
                ver = new double[size, size];
                xtag = new double[size, size];
                ytag = new double[size, size];
                pxtag = new int[size, size];
                pytag = new int[size, size];
                filling = new int[size * size];
                function = Insert_Function.Text;
                for (int i = 0, x = -size / 2; i < size; i++, x++)
                {

                    for (int p = 0, y = -size / 2; p < size; p++, y++)
                    {
                        ver[i, p] = Calculate(BuildTree(Insert_Function.Text), x, y);
                        xtag[i, p] = x * accuracy - y * accuracy * Math.Cos(alpha);
                        ytag[i, p] = ver[i, p] - y * accuracy * Math.Sin(alpha);
                        pxtag[i, p] = (int)(zoom * xtag[i, p]) + panel1.Width / 2;
                        pytag[i, p] = (panel1.Height / 2) - (int)(ytag[i, p] * zoom);
                    }
                }
                Graphics g = panel1.CreateGraphics();
                g.Clear(BackColor);
                double min = 0, max = 0;
                for (int i = 0; i < ver.GetLength(0); i++)
                {
                    for (int p = 0; p < ver.GetLength(0); p++)
                    {
                        if (!Double.IsNaN(ver[i, p]) && !Double.IsInfinity(ver[i, p]))
                        {
                            if (ver[i, p] < min)
                                min = ver[i, p];
                            else
                                if (ver[i, p] > max)
                                max = ver[i, p];
                        }
                    }
                }
                double d = max - min;
                double a1 = 255 / d;
                for (int i = 0; i < ver.GetLength(0) - 1; i++)
                    for (int p = 0; p < ver.GetLength(1) - 1; p++)
                    {
                        if (!Double.IsNaN(xtag[i, p]) && !Double.IsNaN(ytag[i, p]) && !Double.IsNaN(xtag[i + 1, p]) &&
                            !Double.IsNaN(ytag[i + 1, p]) && !Double.IsNaN(xtag[i, p + 1]) && !Double.IsNaN(ytag[i, p + 1]) &&
                            !Double.IsNaN(xtag[i + 1, p + 1]) && !Double.IsNaN(ytag[i + 1, p + 1]) &&
                            !Double.IsInfinity(xtag[i, p]) && !Double.IsInfinity(ytag[i, p]) &&
                            !Double.IsInfinity(xtag[i + 1, p + 1]) && !Double.IsInfinity(ytag[i + 1, p + 1]) &&
                            !Double.IsInfinity(xtag[i + 1, p]) && !Double.IsInfinity(ytag[i + 1, p]) &&
                            !Double.IsInfinity(xtag[i, p + 1]) && !Double.IsInfinity(ytag[i, p + 1]))
                        {
                            SolidBrush Brush = new SolidBrush(System.Drawing.Color.FromArgb((int)((max - ver[i, p]) * a1), 144, 200));
                            Point[] Color = new Point[4];
                            Color[0].X = pxtag[i, p];
                            Color[0].Y = pytag[i, p];
                            Color[1].X = pxtag[i + 1, p];
                            Color[1].Y = pytag[i + 1, p];
                            Color[2].X = pxtag[i + 1, p + 1];
                            Color[2].Y = pytag[i + 1, p + 1];
                            Color[3].X = pxtag[i, p + 1];
                            Color[3].Y = pytag[i, p + 1];
                            Pen myPen = new Pen(Brush.Color);
                            g.DrawPolygon(myPen, Color);
                            g.FillPolygon(Brush, Color);
                        }
                    }
            }
            catch
            {
                MessageBox.Show("Please enter a valid function");
            }
        }
    }
}
