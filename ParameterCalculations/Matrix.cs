using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParameterCalculations
{
    class Matrix
    {
        int row, column;            //矩阵的行列数 
        double [,] data;            //矩阵的数据 
        //构造函数1
        public Matrix(int rowNum,int columnNum)
        {
            row = rowNum; 
            column = columnNum; 
            data = new double[row, column];
        }     
        public Matrix(double[,] members) 
       { 
            row = members.GetUpperBound(0) + 1; 
            column = members.GetUpperBound(1) + 1; 
            data = new double[row, column]; 
            Array.Copy(members, data, row * column); 
       }
        //矩阵乘法
        public bool MatrixMultiply(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(1) != b.GetLength(0))
                return false;
            if (a.GetLength(0) != c.GetLength(0) || b.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    c[i, j] = 0;
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        c[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return true;
        }

        //  矩阵相加
        public bool MatrixAdd(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)
                || a.GetLength(0) != c.GetLength(0) || a.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] + b[i, j];
                }
            }

            return true;
        }

        //矩阵相减
        public bool MatrixSubtration(double[,] a, double[,] b, ref double[,] c)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)
                || a.GetLength(0) != c.GetLength(0) || a.GetLength(1) != c.GetLength(1))
                return false;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] - b[i, j];
                }
            }

            return true;
        }

        //// 矩阵的行列式的值 
        public double MatrixSurplus(double[,] a)
        {
            int i, j, k, p, r, m, n;
            m = a.GetLength(0);
            n = a.GetLength(1);
            double X, temp = 1, temp1 = 1, s = 0, s1 = 0;

            if (n == 2)
            {
                for (i = 0; i < m; i++)
                    for (j = 0; j < n; j++)
                        if ((i + j) % 2 > 0) temp1 *= a[i, j];
                        else temp *= a[i, j];
                X = temp - temp1;
            }
            else
            {
                for (k = 0; k < n; k++)
                {
                    for (i = 0, j = k; i < m && j < n; i++, j++)
                        temp *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - i, r = m - 1; p > 0; p--, r--)
                            temp *= a[r, p - 1];
                    }
                    s += temp;
                    temp = 1;
                }

                for (k = n - 1; k >= 0; k--)
                {
                    for (i = 0, j = k; i < m && j >= 0; i++, j--)
                        temp1 *= a[i, j];
                    if (m - i > 0)
                    {
                        for (p = m - 1, r = i; r < m; p--, r++)
                            temp1 *= a[r, p];
                    }
                    s1 += temp1;
                    temp1 = 1;
                }

                X = s - s1;
            }
            return X;
        }

        //   矩阵转置
        public bool MatrixInver(double[,] a, ref double[,] b)
        {
            if (a.GetLength(0) != b.GetLength(1) || a.GetLength(1) != b.GetLength(0))
                return false;
            for (int i = 0; i < a.GetLength(1); i++)
                for (int j = 0; j < a.GetLength(0); j++)
                    b[i, j] = a[j, i];

            return true;
        }

        //矩阵求逆
        public bool MatrixOpp(double[,] a, ref double[,] b)
        {
            double X = MatrixSurplus(a);
            if (X == 0) return false;
            X = 1 / X;

            double[,] B = new double[a.GetLength(0), a.GetLength(1)];
            double[,] SP = new double[a.GetLength(0), a.GetLength(1)];
            double[,] AB = new double[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for (int m = 0; m < a.GetLength(0); m++)
                        for (int n = 0; n < a.GetLength(1); n++)
                            B[m, n] = a[m, n];
                    {
                        for (int x = 0; x < a.GetLength(1); x++)
                            B[i, x] = 0;
                        for (int y = 0; y < a.GetLength(0); y++)
                            B[y, j] = 0;
                        B[i, j] = 1;
                        SP[i, j] = MatrixSurplus(B);
                        AB[i, j] = X * SP[i, j];
                    }
                }
            MatrixInver(AB, ref b);

            return true;
        }
        //矩阵求逆的重载，精度比较高
        public  double[,] MatrixOpp(double[,] Array)
        {
            int m = 0;
            int n = 0;
            m = Array.GetLength(0);
            n = Array.GetLength(1);
            double[,] array = new double[2 * m + 1, 2 * n + 1];
            for (int k = 0; k < 2 * m + 1; k++)  //初始化数组
            {
                for (int t = 0; t < 2 * n + 1; t++)
                {
                    array[k, t] = 0.00000000;
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = Array[i, j];
                }
            }

            for (int k = 0; k < m; k++)
            {
                for (int t = n; t <= 2 * n; t++)
                {
                    if ((t - k) == m)
                    {
                        array[k, t] = 1.0;
                    }
                    else
                    {
                        array[k, t] = 0;
                    }
                }
            }
            //得到逆矩阵
            for (int k = 0; k < m; k++)
            {
                if (array[k, k] != 1)
                {
                    double bs = array[k, k];
                    array[k, k] = 1;
                    for (int p = k + 1; p < 2 * n; p++)
                    {
                        array[k, p] /= bs;
                    }
                }
                for (int q = 0; q < m; q++)
                {
                    if (q != k)
                    {
                        double bs = array[q, k];
                        for (int p = 0; p < 2 * n; p++)
                        {
                            array[q, p] -= bs * array[k, p];
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            double[,] NI = new double[m, n];
            for (int x = 0; x < m; x++)
            {
                for (int y = n; y < 2 * n; y++)
                {
                    NI[x, y - n] = array[x, y];
                }
            }
            return NI;
        }
    }
}
