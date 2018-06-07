using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParameterCalculations
{
    //求转换参数的类
   public class PramSCals
    {
       
        //求坐标方位角
        private static double FWJ(Point2d p1, Point2d p2)
        {
            Double dx, dy;
            dx = p2.X - p1.X;
            dy = p2.Y - p1.Y;
            return Math.PI - Math.Sign(dy) - Math.Atan(dx / dy);
        }
        //两点之间的距离公式
        private static double Dist(Point2d p1, Point2d p2)
        {
            double d;
            d = Math.Sqrt(Math.Pow((p2.X - p1.X), 2) + Math.Pow((p2.Y - p1.Y), 2));
            return d;
        }
        //
        /// <summary>
        /// 两点法求四参数
        ///   /// </summary>
        /// <param name="p1旧坐标"></param>
        /// <param name="p2新坐标"></param>
        /// <param name="rota旋转参数"></param>
        /// <param name="scale比例"></param>
        /// <param name="dx x的平移"></param>
        /// <param name="dy y的平移"></param>
        public static void Canshu4(Point2d[] p1, Point2d[] p2, ref double rota, ref double scale, ref double dx, ref double dy)
        {
            rota = FWJ(p2[0], p2[1]) - FWJ(p1[0], p1[1]);
            scale = Dist(p2[0], p2[1]) / Dist(p1[0], p1[1]);
            dx = p2[0].X - scale * Math.Cos(rota) * p1[0].X + scale * Math.Sin(rota) * p1[0].Y;
            dy = p2[0].Y - scale * Math.Sin(rota) * p1[0].X - scale * Math.Cos(rota) * p1[0].Y;
        }
        /// <summary>
        ///三个以上的点计算四参数
        /// </summary>
        /// <param name="p1旧坐标"></param>
        /// <param name="p2新坐标"></param>
        /// <param name="PointCount转换点的个数"></param>
        /// <param name="rota旋转参数"></param>
        /// <param name="scale比例"></param>
        /// <param name="dx x的平移"></param>
        /// <param name="dy y的平移"></param>
        public static void Canshu4(Point2d[] p1, Point2d[] p2, int PointCount, ref double rota, ref double scale, ref double dx, ref double dy)
        {
            double u = 1.0, v = 0, Dx = 0.0, Dy = 0.0;

            int intCount = PointCount;
            //Matrix dx1 ;//误差方程改正数
            Matrix B;//误差方程系数矩阵
                     // Matrix W ;//误差方程常数项
            double[,] dx1 = new double[4, 1];
            double[,] B1 = new double[2 * intCount, 4];
            double[,] W1 = new double[2 * intCount, 1];
            // Matrix BT, N, InvN, BTW;
            double[,] BT = new double[4, 2 * intCount];
            double[,] N = new double[4, 4];
            double[,] InvN = new double[4, 4];
            double[,] BTW = new double[4, 1];
            for (int i = 0; i < intCount; i++)
            {
                //计算误差方程系数
                B1[2 * i, 0] = 1;
                B1[2 * i, 1] = 0;
                B1[2 * i, 2] = p1[i].X;
                B1[2 * i, 3] = -p1[i].Y;


                B1[2 * i + 1, 0] = 0;
                B1[2 * i + 1, 1] = 1;
                B1[2 * i + 1, 2] = p1[i].Y;
                B1[2 * i + 1, 3] = p1[i].X;
            }
            B = new Matrix(B1);
            for (int i = 0; i < intCount; i++)
            {
                //计算误差方程系常数
                W1[2 * i, 0] = p2[i].X - u * p1[i].X + v * p1[i].Y - Dx;
                W1[2 * i + 1, 0] = p2[i].Y - u * p1[i].Y - v * p1[i].X - Dy;

            }
            //最小二乘求解
            B.MatrixInver(B1, ref BT);//转置
            B.MatrixMultiply(BT, B1, ref N);
            InvN = B.MatrixOpp(N);
            B.MatrixMultiply(BT, W1, ref BTW);
            B.MatrixMultiply(InvN, BTW, ref dx1);
            Dx = Dx + dx1[0, 0];
            Dy = Dy + dx1[1, 0];
            u = u + dx1[2, 0];
            v = v + dx1[3, 0];
            dx = Dx;
            dy = Dy;
            rota = Math.Atan(v / u);
            scale = u / Math.Cos(rota);
            dx = Math.Round(dx, 6);
            dy = Math.Round(dy, 6);
            rota = Math.Round(rota, 6);
            scale = Math.Round(scale, 6);
        }
        /// <summary>
        /// 求七参数
        /// </summary>
        /// <param name="p1 旧坐标"></param>
        /// <param name="p2 新坐标"></param>
        /// <param name="PointCount 坐标点数"></param>
        /// <param name="rotax x的旋转量"></param>
        /// <param name="rotay y的旋转量"></param>
        /// <param name="rotaz z的旋转量"></param>
        /// <param name="scale 比例"></param>
        /// <param name="dx x的平移量"></param>
        /// <param name="dy y的平移量"></param>
        /// <param name="dz z的平移量"></param>
        public static void Canshu7(Point3d[] p1, Point3d[] p2, int PointCount, ref double rotax, ref double rotay, ref double rotaz, ref double scale, ref double dx, ref double dy, ref double dz)
        {
            double[,] B1 = new double[PointCount * 3, 7];
            Matrix B = new Matrix(B1);
            double[,] dx1 = new double[7, 1];//V=B*X-L
            double[,] L = new double[PointCount * 3, 1];
            double[,] BT = new double[7, PointCount * 3];
            double[,] N = new double[7, 7];
            double[,] InvN = new double[7, 7];
            double[,] BTL = new double[7, 1];
            //初始化L矩阵
            for(int i=0;i<PointCount*3;i++)
            {
                if(i%3==0)
                {
                    L[i, 0] = p2[i / 3].X;
                }
                else if(i%3==1)
                {
                    L[i, 0] = p2[i / 3].Y;
                }
                else if (i % 3 == 2)
                {
                    L[i, 0] = p2[i / 3].Z;
                }
            }
            //初始化B矩阵
            for (int i = 0; i < PointCount * 3; i++)
            {
                if(i%3==0)
                {
                    B1[i, 0] = 1;
                    B1[i, 1] = 0;
                    B1[i, 2] = 0;
                    B1[i, 3] = p1[i/3].X;
                    B1[i, 4] = 0;
                    B1[i, 5] = -p1[i/3].Z;
                    B1[i, 6] = p1[i/3].Y;

                }
                else if(i%3==1)
                {
                    B1[i, 0] = 0;
                    B1[i, 1] = 1;
                    B1[i, 2] = 0;
                    B1[i, 3] = p1[i / 3].Y;
                    B1[i, 4] = p1[i/3].Z;
                    B1[i, 5] = 0;
                    B1[i, 6] = -p1[i / 3].X;
                }
                else if (i % 3 == 2)
                {
                    B1[i, 0] = 0;
                    B1[i, 1] = 0;
                    B1[i, 2] = 1;
                    B1[i, 3] = p1[i / 3].Z;
                    B1[i, 4] = -p1[i / 3].Y;
                    B1[i, 5] = p1[i/3].X;
                    B1[i, 6] = 0;
                }

            }
            //转置
            B.MatrixInver(B1,ref BT);
            //法方程矩阵
            //N=BT*B
            B.MatrixMultiply(BT,B1,ref N);
            //求逆
            InvN=B.MatrixOpp(N);
            //BTL=BT*L
            B.MatrixMultiply(BT,L,ref BTL);
            //dx1=invN*BTL;
            B.MatrixMultiply(InvN,BTL,ref dx1);
            //
            dx = Math.Round(dx1[0, 0], 6);
            dy = Math.Round(dx1[1, 0], 6);
            dz = Math.Round(dx1[2, 0], 6);
            scale = Math.Round(dx1[3, 0], 6);
            rotax = Math.Round(dx1[4, 0] / dx1[3, 0], 6);
            rotay = Math.Round(dx1[5, 0] / dx1[3, 0], 6);
            rotaz = Math.Round(dx1[6, 0] / dx1[3, 0], 6);
        }
    }
}
