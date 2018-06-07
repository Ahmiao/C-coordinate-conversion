using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParameterCalculations
{
    //二维的点
    public struct Point2d
    {
        public double X;
        public double Y;
    }
    //三维的点
    public struct Point3d
    {
        public double X;
        public double Y;
        public double Z;
    }
    public partial class Form1 : Form
    {
        private int pointNum = 0;
        public Form1()
        {
            InitializeComponent();
            r4.Checked = true;//默认选择4参数
            this.MaximizeBox = false;
        }

       
       

        private void button1_Click(object sender, EventArgs e)
        {
            if (r4.Checked == true)
            {

                double rota = 0.0, sacle = 0.0, dx = 0.0, dy = 0.0;
                Point2d[] p1 = new Point2d[pointNum];
                Point2d[] p2 = new Point2d[pointNum];
                for (int i = 0; i < pointNum; i++)
                {
                    p1[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[1].Value);
                    p1[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[2].Value);
                    p2[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[3].Value);
                    p2[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[4].Value);
                }

                PramSCals.Canshu4(p1, p2, 3, ref rota, ref sacle, ref dx, ref dy);
                richTextBox1.Text = "dx=" + dx.ToString() + "\n";
                richTextBox1.Text += "dy=" + dy.ToString() + "\n";
                richTextBox1.Text += "rota=" + rota.ToString() + "\n";
                richTextBox1.Text += "sacle=" + sacle.ToString() + "\n";


            }
            else if (r77.Checked == true)
            {
                double rotax = 0.0, rotay = 0.0, rotaz = 0.0, sacle = 0.0, dx = 0.0, dy = 0.0, dz = 0.0;
                Point3d[] p1 = new Point3d[pointNum];
                Point3d[] p2 = new Point3d[pointNum];
                for (int i = 0; i < pointNum; i++)
                {
                    p1[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[1].Value);
                    p1[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[2].Value);
                    p1[i].Z = Convert.ToDouble(myDGV.Rows[i].Cells[3].Value);

                    p2[i].X = Convert.ToDouble(myDGV.Rows[i].Cells[4].Value);
                    p2[i].Y = Convert.ToDouble(myDGV.Rows[i].Cells[5].Value);
                    p2[i].Z = Convert.ToDouble(myDGV.Rows[i].Cells[6].Value);
                }

                PramSCals.Canshu7(p1, p2, 3, ref rotax, ref rotay, ref rotaz, ref sacle, ref dx, ref dy, ref dz);
                richTextBox1.Text = "dx=" + dx.ToString() + "\n";
                richTextBox1.Text += "dy=" + dy.ToString() + "\n";
                richTextBox1.Text += "dz=" + dz.ToString() + "\n";
                richTextBox1.Text += "rotax=" + rotax.ToString() + "\n";
                richTextBox1.Text += "rotay=" + rotay.ToString() + "\n";
                richTextBox1.Text += "rotaz=" + rotaz.ToString() + "\n";
                richTextBox1.Text += "sacle=" + sacle.ToString() + "\n";
            }

        }

        private DataTable Table_load2d()//初始化表格
        {
            DataTable mydt = new DataTable();
            mydt.Columns.Add("编号", Type.GetType("System.String"));
            mydt.Columns.Add("X1（m）", Type.GetType("System.Double"));
            mydt.Columns.Add("Y1（m)", Type.GetType("System.Double"));
            mydt.Columns.Add("X2（m）", Type.GetType("System.Double"));
            mydt.Columns.Add("Y2（m)", Type.GetType("System.Double"));
            return mydt;

        }
        private DataTable Table_load3d()//初始化表格
        {
            DataTable mydt = new DataTable();
            mydt.Columns.Add("编号", Type.GetType("System.String"));
            mydt.Columns.Add("X1（m）", Type.GetType("System.Double"));
            mydt.Columns.Add("Y1（m)", Type.GetType("System.Double"));
            mydt.Columns.Add("Z1（m)", Type.GetType("System.Double"));
            mydt.Columns.Add("X2（m）", Type.GetType("System.Double"));
            mydt.Columns.Add("Y2（m)", Type.GetType("System.Double"));
            mydt.Columns.Add("Z2（m)", Type.GetType("System.Double"));
            return mydt;

        }

       

        

       
        private void r4_CheckedChanged_1(object sender, EventArgs e)
        {
            if (r4.Checked == true)
            {
                myDGV.DataSource = null;
                myDGV.DataSource = Table_load2d();//加载表格
                pointNum = 0;
            }
            else
            {
                r77.Checked = false;
            }
        }

        private void saveList_Click(object sender, EventArgs e)
        {
            SaveFileDialog fs = new SaveFileDialog();
            fs.Filter = "文本文件(*.txt)|*.txt";
            fs.FileName = "文件名.txt";
            if (fs.ShowDialog() == DialogResult.OK)
            {
                this.richTextBox1.SaveFile(fs.FileName, RichTextBoxStreamType.PlainText);
            }
            MessageBox.Show("保存文件成功！");
        }

        private void r77_CheckedChanged_1(object sender, EventArgs e)
        {
            if (r77.Checked == true)
            {
                myDGV.DataSource = null;
                myDGV.DataSource = Table_load3d();//加载表格
                pointNum = 0;
            }
            else
            {
                r4.Checked = false;
            }
        }

        private void myDGV_UserAddedRow_1(object sender, DataGridViewRowEventArgs e)
        {
            //每新增一个点就会自加
            pointNum++;
        }
    }
}

