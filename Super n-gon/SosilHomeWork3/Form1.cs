using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace SosilHomeWork3
{
    public partial class Form1 : Form
    {
        ThreePoint[] pointSet;
        Thread color;
        int controlSpeed;
        bool[] enemyOk;
        fourPoint[] enemySet;//장애물 세트
        fourPoint[] enemySet1;
        fourPoint[] enemySet2;
        fourPoint[] enemySet3;
        PointF[] user;//유저의 위치
        int maxCount;//최댓값
        Thread t;
        int poligonCount;
        int userRadian;//유저 움직임
        int radianVal;
        int map;
        int speed;
        double[] smalePoli;//가운데 심장

        int time = 0;
        Graphics g;

        public class fourPoint
        {
            public PointF[] point;
            public void setMeber(double x0, double y0, double x1, double y1, double x2, double y2, double x3, double y3)
            {
                point = new PointF[4];
                point[0].X = (float)x0;
                point[0].Y = (float)y0;
                point[1].X = (float)x1;
                point[1].Y = (float)y1;
                point[2].X = (float)x2;
                point[2].Y = (float)y2;
                point[3].X = (float)x3;
                point[3].Y = (float)y3;
            }
        }

        public class ThreePoint
        {
            public PointF[] point;
            public void setMeber(double x0, double y0, double x1, double y1, double x2, double y2)
            {
                point = new PointF[3];
                point[0].X = (float)x0;
                point[0].Y = (float)y0;
                point[1].X = (float)x1;
                point[1].Y = (float)y1;
                point[2].X = (float)x2;
                point[2].Y = (float)y2;
            }
        }

        public Form1()
        {
            InitializeComponent(); 
            maxCount = 512;
            poligonCount = 5;
            pointSet = new ThreePoint[maxCount*2];
            enemySet = new fourPoint[maxCount];
            enemySet1 = new fourPoint[maxCount];
            enemySet2 = new fourPoint[maxCount];
            enemySet3 = new fourPoint[maxCount];
            for (int i = 0; i < maxCount; i ++)
            {
                enemySet[i] = new fourPoint();
                enemySet1[i] = new fourPoint();
                enemySet2[i] = new fourPoint();
                enemySet3[i] = new fourPoint();

            }
            for(int i = 0; i < maxCount*2; i ++)
            {
                pointSet[i] = new ThreePoint();
            }
            radianVal = 0;
            map = 0;
            user = new PointF[3];
            userRadian = 270;
            enemyOk = new bool[4];
            for (int i = 0; i < 4; i++)
                enemyOk[i] = false;
            controlSpeed = 15;
            color = new Thread(new ThreadStart(fontHi));
            color.Start();
            speed = 0;
            smalePoli = new double[12];
            smalePoli[0] = 30.0;//심장 뛰는 주기
            smalePoli[1] = 30.0;
            smalePoli[2] = 20.0;
            smalePoli[3] = 15.0;
            smalePoli[4] = 15.0;
            smalePoli[5] = 15.0;
            smalePoli[6] = 20.0;
            smalePoli[7] = 23.0;
            smalePoli[8] = 22.0;
            smalePoli[9] = 18.0;
            smalePoli[10] = 19.0;
            smalePoli[11] = 20.0;
        }

        private void fontHi()//글자가 반짝반짝
        {
            int count =0;
            while(map==0)
            {
                Thread.Sleep(500);
                if (count % 2 == 0)
                    label3.ForeColor = Color.Red;
                else
                    label3.ForeColor = Color.Yellow;
                count++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            
            int Height = ClientSize.Height / 2;
            int Width = ClientSize.Width / 2;
            double a;//기울기
            double radian;//라디안

            double x1, y1, x2, y2;
            double c = Math.Sqrt(Height * Height + Width * Width) *2;

            for (int i = 0; i < poligonCount; i++)//폴리곤 갯수 만큼
            {
                radian = i * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180.0));
                x1 = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
                y1 = x1 * a;
                if (radian <= 270 && radian > 90)
                {
                    x1 *= -1;
                    y1 *= -1;
                }
                x1 += Width;
                y1 += Height;

                radian = (i + 1) * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180));
                x2 = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
                y2 = x2 * a;
                if (radian <= 270 && radian > 90)
                {
                    x2 *= -1;
                    y2 *= -1;
                }
                x2 += Width;
                y2 += Height;

                pointSet[i].setMeber(Width, Height, x1, y1, x2, y2);
            }
            for (int i = 0; i < poligonCount; i++)//배경그리기
            {
                if (poligonCount%2 == 0 || poligonCount ==7)
                {
                    if (i % 4 == 0)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(204, 102, 0)), pointSet[i].point);
                    else if (i % 4 == 1)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(102, 51, 0)), pointSet[i].point);
                    else if (i % 4 == 2)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(51, 25, 0)), pointSet[i].point);
                    else
                        g.FillPolygon(new SolidBrush(Color.FromArgb(153, 76, 0)), pointSet[i].point);
                }
                else
                {
                    if (i % 3 == 0)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(204, 102, 0)), pointSet[i].point);
                    else if (i % 3 == 1)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(102, 51, 0)), pointSet[i].point);
                    else if (i % 3 == 2)
                        g.FillPolygon(new SolidBrush(Color.FromArgb(51, 25, 0)), pointSet[i].point);
                }
            }


            for (int i = 0; i <4; i++)//적 만들기
            {
                if (enemyOk[i])
                {
                    if (i == 0)
                    {
                        for (int j = 0; j < poligonCount; j++)
                            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 255, 102)), enemySet[j].point);
                    }
                    else if (i == 1)
                    {
                        for (int j = 0; j < poligonCount; j++)
                            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 255, 0)), enemySet1[j].point);
                    }
                    else if (i == 2)
                    {
                        for (int j = 0; j < poligonCount; j++)
                            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 255, 204)), enemySet2[j].point);
                    }
                    else if (i == 3)
                    {
                        for (int j = 0; j < poligonCount; j++)
                            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 255, 150)), enemySet3[j].point);
                    }
                }
            }

            c = smalePoli[(time% 12)];

            for (int i = poligonCount; i < poligonCount*2; i++)
            {
                radian = (i-poligonCount) * (360.0 / poligonCount) + 0.0005 + radianVal;//0.0005를 더한건 무한대라서
                a = Math.Tan(radian * (Math.PI / 180.0));
                x1 = Math.Sqrt(Math.Abs((c *c) / ((a * a) + 1)));
                y1 = x1 * a;
                if (radian <= 270 && radian > 90)
                {
                    x1 *= -1;
                    y1 *= -1;
                }
                x1 += Width;
                y1 += Height;

                radian = ((i - poligonCount) + 1) * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180));
                x2 = Math.Sqrt(Math.Abs((c * c)/ ((a*a) + 1)));
                y2 = x2 * a;
                if (radian <= 270 && radian > 90)
                {
                    x2 *= -1;
                    y2 *= -1;
                }
                x2 += Width;
                y2 += Height;

                pointSet[i].setMeber(Width, Height, x1, y1, x2, y2);
            }
            for (int i = poligonCount; i < poligonCount * 2; i++)
            {
                g.FillPolygon(new SolidBrush(Color.FromArgb(255 , 255 , 255)), pointSet[i].point);
            }

            double x3, y3;

            radian =  (userRadian+radianVal) + 0.0005;
            a = Math.Tan(radian * (Math.PI / 180.0));

            c = 40;
            x1 = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
            y1 = x1 * a;
            if (radian <= 270 && radian > 90)
            {
                x1 *= -1;
                y1 *= -1;
            }
            x1 += Width;
            y1 += Height;

            c = 30;
            radian = (userRadian + radianVal + 15) + 0.0005;
            a = Math.Tan(radian * (Math.PI / 180));
            x2 = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
            y2 = x2 * a;
            if (radian <= 270 && radian > 90)
            {
                x2 *= -1;
                y2 *= -1;
            }
            x2 += Width;
            y2 += Height;

            c = 30;

            radian = (userRadian + radianVal - 15) + 0.0005;
            a = Math.Tan(radian * (Math.PI / 180));
            x3 = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
            y3 = x3 * a;
            if (radian <= 270 && radian > 90)
            {
                x3 *= -1;
                y3 *= -1;
            }
            x3 += Width;
            y3 += Height;

            user[0].X = (float)x1;
            user[0].Y = (float)y1;
            user[1].X = (float)x2;
            user[1].Y = (float)y2;
            user[2].X = (float)x3;
            user[2].Y = (float)y3;

            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 255, 255)), user);

        }

        private void gameStart()//게임 돌아가는 스레드
        {
            Random rnd = new Random();
            int random = rnd.Next(5, 20);
            int[] enemyRandom = new int[4];
            int[] enemyNum = new int[4];
            enemyNum[0] = 600;
            enemyNum[1] = 800;
            enemyNum[2] = 1000;
            enemyNum[3] = 1200;
            enemyRandom[0] = rnd.Next(0, poligonCount);
            enemyRandom[1] = rnd.Next(0, poligonCount);
            enemyRandom[2] = rnd.Next(0, poligonCount);
            enemyRandom[3] = rnd.Next(0, poligonCount);
            int i = 0, num = 1;
            time = 0;
            while (map == 1)
            {
                Thread.Sleep(50);
                time++;
                label4.Text = "Time : " + time;
                if (i == random)
                {
                    i = 0;
                    random = rnd.Next(5, 20);
                    num *= -1;
                }
                i++;

                radianVal += num;

                speed = time / 50;

                for (int j = 0; j < 4; j++)
                {
                    if (enemyNum[j] > 20)
                    {
                        if (enemyNum[j] < 50)
                        {
                            double left = (360.0 / poligonCount) * enemyRandom[j];
                            double right = (360.0 / poligonCount) * (enemyRandom[j] + 1);
 
                            bool die = false;

                            if (left > right)
                            {
                                if (userRadian >= right && userRadian <= left)
                                    die = true;
                            }
                            else
                            {
                                if (userRadian > right || userRadian < left)
                                    die = true;
                            }
                            
                            if (die)//죽음
                            {
                                label1.Visible = true;
                                label2.Visible = true;
                                label3.Visible = true;
                                label6.Visible = true;

                                map = 0;
                                for (int k = 0; k < 4; k++)
                                    enemyOk[k] = false;

                                MessageBox.Show("기록 : " + time, "GAME OVER");
                                color = new Thread(new ThreadStart(fontHi));
                                color.Start();
                                time = 0;
                                speed = 0;
                                Invalidate();
                                break;
                            }
                        }
                        enemy(enemyNum[j], j, enemyRandom[j]);
                        enemyNum[j] -= 4 + speed;
                    }
                    else
                    {
                        enemyNum[j] = 800 + speed * 80;
                        enemyRandom[j] = rnd.Next(0, poligonCount);
                    }
                    enemyOk[j] = true;
                }
                Invalidate();
            }
        }

        private void enemy(double c, int enemynum, int randomVal)//적을 만드는 함수, 각도랑, 번호, 입구 
        {
            double Width = ClientSize.Width/2;
            double Height = ClientSize.Height/2;
            double radian, a;
            double[] x, y;
            x = new double[4];
            y = new double[4];

            for (int i = 0; i < poligonCount; i++)
            {
                if (i == randomVal)
                {
                    for(int j= 0; j <4; j++)
                    {
                        x[j] = 0;
                        y[j] = 0;
                    }
                    if (enemynum == 0)
                        enemySet[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    else if (enemynum == 1)
                        enemySet1[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    else if (enemynum == 2)
                        enemySet2[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                    else if (enemynum == 3)
                        enemySet3[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);

                    continue;

                }
                radian = i * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180.0));
                x[0] = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
                y[0] = x[0] * a;
                if (radian <= 270 && radian > 90)
                {
                    x[0] *= -1;
                    y[0] *= -1;
                }
                x[0] += Width;
                y[0] += Height;

                radian = (i + 1) * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180));
                x[1] = Math.Sqrt(Math.Abs((c * c) / ((a * a) + 1)));
                y[1] = x[1] * a;
                if (radian <= 270 && radian > 90)
                {
                    x[1] *= -1;
                    y[1] *= -1;
                }
                x[1] += Width;
                y[1] += Height;
                    

                radian = i * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180.0));
                x[3] = Math.Sqrt(Math.Abs(((c-20) * (c - 20)) / ((a * a) + 1)));
                y[3] = x[3] * a;
                if (radian <= 270 && radian > 90)
                {
                    x[3] *= -1;
                    y[3] *= -1;
                }
                x[3] += Width;
                y[3] += Height;

                radian = (i + 1) * (360.0 / poligonCount) + 0.0005 + radianVal;
                a = Math.Tan(radian * (Math.PI / 180));
                x[2] = Math.Sqrt(Math.Abs(((c - 20) * (c - 20)) / ((a * a) + 1)));
                y[2] = x[2] * a;
                if (radian <= 270 && radian > 90)
                {
                    x[2] *= -1;
                    y[2] *= -1;
                }
                x[2] += Width;
                y[2] += Height;

                PointF[] enemyPoint =
                {
                    new PointF((float)x[0], (float)y[0]),
                    new PointF((float)x[1], (float)y[1]),
                    new PointF((float)x[2], (float)y[2]),
                    new PointF((float)x[3], (float)y[3])
                };
                    
                if(enemynum ==0)
                    enemySet[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]); 
                else if (enemynum == 1)
                    enemySet1[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                else if (enemynum == 2)
                    enemySet2[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
                else if (enemynum == 3)
                    enemySet3[i].setMeber(x[0], y[0], x[1], y[1], x[2], y[2], x[3], y[3]);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//아래 입력했을때 작동
        {
            if (map == 0)//처음 맵
            {
                if (e.KeyCode == Keys.Up)
                {
                    if (poligonCount < maxCount)
                        poligonCount++;
                    label2.Text = poligonCount + "-GON";
                    Invalidate();
                }

                else if (e.KeyCode == Keys.Down)
                {
                    if (poligonCount > 3)
                        poligonCount--;
                    label2.Text = poligonCount + "-GON";
                    Invalidate();
                }

                else if(e.KeyCode == Keys.Space)
                {
                    map = 1;
                    t = new Thread(new ThreadStart(gameStart));
                    t.Start();
                    label1.Visible = false;
                    label2.Visible = false;
                    label3.Visible = false;
                    label6.Visible = false;
                }
            }
            else if(map ==1)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    t.Abort();
                    label1.Visible = true;
                    label2.Visible = true;
                    label3.Visible = true;
                    label6.Visible = true;
                    map = 0;
                    for (int i = 0; i < 4; i++)
                        enemyOk[i] = false;
                    color = new Thread(new ThreadStart(fontHi));
                    color.Start();
                    speed = 0;
                    time = 0;
                }
            }
            if (e.KeyCode == Keys.Right)
            {
                userRadian += controlSpeed;
                if (userRadian > 360)
                    userRadian = 0;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Left)
            {
                userRadian -= controlSpeed;
                if (userRadian < 0)
                    userRadian = 360;
                Invalidate();
            }
            else if (e.KeyCode == Keys.U)
            {
                if (controlSpeed < 25)
                {
                    controlSpeed++;
                    label5.Text = "Control Speed : " + controlSpeed;
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (controlSpeed > 10)
                {
                    controlSpeed--;
                    label5.Text = "Control Speed : " + controlSpeed;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (map ==1)
                t.Abort();
            else
                color.Abort();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
