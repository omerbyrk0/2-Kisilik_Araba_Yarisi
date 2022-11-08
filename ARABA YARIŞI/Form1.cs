using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARABA_YARIŞI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int kazanılanpuan = 0;
        int yolhızı = 30;
        int arabahızı = 20; //benim arabamın hızı

        bool solyon = false;
        bool sagyon = false;
        bool asagı = false;
        bool yukarı = false;

        bool solyon2 = false;
        bool sagyon2 = false;
        bool yukarı2 = false;
        bool asagı2 = false;

        Random rnd = new Random();//ilerde araba değişikliği için kullanılacak.


        public void Oyunubaslat()
        {
            btn_basla.Enabled = false;//oyun başladıktan sonra tuşa bir daha basılmaması gerek.
            carpma.Visible = false;//çarpma efektini çalıştıma 
            carpma2.Visible = false;
            kazanılanpuan = 0;//oyun her başladığında kazanılan puan sıfırlansın.


            lbl_yuksekskor.Text = Settings1.Default.yuksekSkor.ToString();

            //araba koordinatları
            bizimaraba.Left = 500;//sol tarafa uzaklığı
            bizimaraba.Top = 300;//üstten uzaklığı

            bizimaraba2.Left = 160;
            bizimaraba2.Top = 300;

            araba1.Left = 70;
            araba1.Top = 50;

            araba2.Left = 280;
            araba2.Top = 50;

            araba3.Left = 400;
            araba3.Top = 50;

            araba4.Left = 600;
            araba4.Top = 50;

            //oyun her başladığında harektesiz kalıcak
            solyon = false;
            sagyon = false;
            asagı = false;
            yukarı = false;

            solyon2 = false;
            sagyon2 = false;
            yukarı2 = false;
            asagı2 = false;
           
            carpma.Left = 165;
            carpma.Top = 294;

            timer1.Start();//timer başla

        }

        private void btn_basla_Click(object sender, EventArgs e)
        {
            Oyunubaslat();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Oyunubaslat();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            kazanılanpuan++;
            lbl_puan.Text = kazanılanpuan.ToString();

            yol.Top += yolhızı;//yolun top aını yol hızı kadar arttır.ve aşağıya götür

            if (yol.Top > 100)
            {
                yol.Top = -100;
            }

            if (solyon)//sola basılmıssa
            {
                bizimaraba.Left -= arabahızı;//arabanın leftını araba hızı kadar azalt ve sola git
            }
            if (sagyon)
            {
                bizimaraba.Left += arabahızı;//arabanın leftını araba hızı kadar arttır ve sağa gıt
            }
            if (bizimaraba.Left < 170) 
            {
                solyon = false;
            }
            else if (bizimaraba.Left + bizimaraba.Width > 650)//arabanın lefti ve uzunluğunun toplamı
            {
                sagyon = false;
            }
            if(asagı)
            {
                bizimaraba.Top += arabahızı;
            }
            if(yukarı)
            {
                bizimaraba.Top -= arabahızı;
            }
            if(bizimaraba.Top<1)
            {
                yukarı = false;
            }
            if(bizimaraba.Top>350)
            {
                asagı = false;
            }
            if (solyon2)
            {
                bizimaraba2.Left -= arabahızı;
            }
            if (sagyon2)
            {
                bizimaraba2.Left += arabahızı;
            }
            if (bizimaraba2.Left < 1)
            {
                solyon2 = false;
            }
            else if (bizimaraba2.Left + bizimaraba2.Width > 200)
            {
                sagyon2 = false;
            }
            if (asagı2)
            {
                bizimaraba2.Top += arabahızı;
            }
            if (yukarı2)
            {
                bizimaraba2.Top -= arabahızı;
            }
            if (bizimaraba2.Top < 1)
            {
                yukarı2 = false;
            }
            if (bizimaraba2.Top > 350)
            {
                asagı2 = false;
            }


            araba1.Top += arabahızı;
            araba2.Top += arabahızı;
            araba3.Top += arabahızı;
            araba4.Top += arabahızı;

            if (araba1.Top > panel1.Height) //arabanın topa uzaklığı panele uzaklığı geçerse
            {
                araba1degıstır();
                araba1.Left = rnd.Next(20, 150);
                araba1.Top = rnd.Next(40, 140) * -1; //kadrajın dısından gelecek araba
            }
            if (araba2.Top > panel1.Height)
            {
                araba2degıstır();
                araba2.Left = rnd.Next(170, 300);
                araba2.Top = rnd.Next(40, 140) * -1;
            }

            if (araba3.Top >panel1.Height)
            {
                araba3degıstır();
                araba3.Left = rnd.Next(320, 450);
                araba3.Top = rnd.Next(40, 140) * -1;
            }

            if (araba4.Top > panel1.Height)
            {
                araba4degıstır();
                araba4.Left = rnd.Next(470, 600);
                araba4.Top = rnd.Next(40, 140) * -1;
            }

            if ((bizimaraba2.Bounds.IntersectsWith(araba1.Bounds) || (bizimaraba2.Bounds.IntersectsWith(araba2.Bounds)))) //bzim arabamızın koordinatı araba1 ın koordınatıyla çakışırsa
            {
                oyunbıttı2();
            }
            if ((bizimaraba.Bounds.IntersectsWith(araba3.Bounds) || (bizimaraba.Bounds.IntersectsWith(araba4.Bounds)))) //bzim arabamızın koordinatı araba1 ın koordınatıyla çakışırsa
            {
                oyunbıttı();
            }

        }

        private void araba1degıstır()
        {
            int sira = rnd.Next(1,7);

            switch (sira)
            {
                case 1:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 2:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 3:
                    araba1.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba1.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba1.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba1.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba1.Image = Properties.Resources.araba7;
                    break;

                default:
                    break;



            }
        }
        private void araba2degıstır()
        {
            int sira = rnd.Next(1, 7);

            switch (sira)
            {
                case 1:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 2:
                    araba2.Image = Properties.Resources.araba3;
                    break;
                case 3:
                    araba2.Image = Properties.Resources.araba3;
                    break;
                case 4:
                    araba2.Image = Properties.Resources.araba4;
                    break;
                case 5:
                    araba2.Image = Properties.Resources.araba5;
                    break;
                case 6:
                    araba2.Image = Properties.Resources.araba6;
                    break;
                case 7:
                    araba2.Image = Properties.Resources.araba7;
                    break;

                default:
                    break;



            }





        }
        private void araba3degıstır()
        {
            
                int sira = rnd.Next(1,7);

                switch (sira)
                {
                    case 1:
                        araba3.Image = Properties.Resources.araba4;
                        break;
                    case 2:
                        araba3.Image = Properties.Resources.araba6;
                        break;
                    case 3:
                        araba3.Image = Properties.Resources.araba7;
                        break;
                    case 4:
                        araba3.Image = Properties.Resources.araba4;
                        break;
                    case 5:
                        araba3.Image = Properties.Resources.araba5;
                        break;
                    case 6:
                        araba3.Image = Properties.Resources.araba7;
                        break;
                    case 7:
                        araba3.Image = Properties.Resources.araba8;
                        break;

                    default:
                        break;



                }

            
        }
        private void araba4degıstır()
        {
            
                int sira = rnd.Next(1,7);

                switch (sira)
                {
                    case 1:
                        araba4.Image = Properties.Resources.araba4;
                        break;
                    case 2:
                        araba4.Image = Properties.Resources.araba3;
                        break;
                    case 3:
                        araba4.Image = Properties.Resources.araba3;
                        break;
                    case 4:
                        araba4.Image = Properties.Resources.araba4;
                        break;
                    case 5:
                        araba4.Image = Properties.Resources.araba5;
                        break;
                    case 6:
                        araba4.Image = Properties.Resources.araba6;
                        break;
                    case 7:
                        araba4.Image = Properties.Resources.araba7;
                        break;

                    default:
                        break;



                }


            
        }

        private void oyunbıttı()
        {
            timer1.Stop();

            if (Convert.ToInt32(lbl_puan.Text)>Convert.ToInt32(Settings1.Default.yuksekSkor.ToString()))
            {
                Settings1.Default.yuksekSkor = lbl_puan.Text;
            }

            btn_basla.Enabled = true;
            carpma.Visible = true;

            bizimaraba.Controls.Add(carpma);
            carpma.Location = new Point(7, -5);

            carpma.BringToFront();//efekti öne alma metotu
            carpma.BackColor = Color.Transparent;//arka planını saydam yap
            MessageBox.Show("KAZANDIĞINIZ PUAN : " + lbl_puan.Text, "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void oyunbıttı2()
        {
            timer1.Stop();

            if (Convert.ToInt32(lbl_puan.Text) > Convert.ToInt32(Settings1.Default.yuksekSkor.ToString()))
            {
                Settings1.Default.yuksekSkor = lbl_puan.Text;
            }

            btn_basla.Enabled = true;
            carpma2.Visible = true;

            bizimaraba2.Controls.Add(carpma2);
            carpma2.Location = new Point(7, -5);

            carpma.BringToFront();//efekti öne alma metotu
            carpma.BackColor = Color.Transparent;//arka planını saydam yap
            MessageBox.Show("KAZANDIĞINIZ PUAN : " + lbl_puan.Text, "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && bizimaraba.Left>0)//bastığımız tuş sol yöne eşit ise
            {
                solyon = true;
            }
            if (e.KeyCode == Keys.Right && bizimaraba.Left + bizimaraba.Width < panel1.Width)
            {
                sagyon = true;
            }
            if (e.KeyCode == Keys.Up&&bizimaraba.Top>0)
            {
                yukarı = true;
            }
            if(e.KeyCode==Keys.Down&&bizimaraba.Top + bizimaraba.Height < panel1.Height)
            {
                asagı = true;
            }
            if (e.KeyCode == Keys.A && bizimaraba2.Left > 0)
            {
                solyon2 = true;
            }
            if (e.KeyCode == Keys.D && bizimaraba2.Left > 0)
            {
                sagyon2 = true;
            }
            if (e.KeyCode == Keys.W && bizimaraba2.Top > 0)
            {
                yukarı2 = true;
            }
            if (e.KeyCode == Keys.S && bizimaraba2.Top + bizimaraba2.Height < panel1.Height)
            {
                asagı2 = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                solyon = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                sagyon=false;
            }
            if(e.KeyCode==Keys.Up)
            {
                yukarı=false;
            }
            if(e.KeyCode==Keys.Down)
            {
                asagı=false;
            }
            if(e.KeyCode==Keys.A)
            {
                solyon2=false;
            }
            if (e.KeyCode == Keys.D)
            {
                sagyon2 = false;
            }
            if (e.KeyCode == Keys.W)
            {
                yukarı2 = false;
            }
            if (e.KeyCode == Keys.S)
            {
                asagı2 = false;
            }
        }

        private void yol_Click(object sender, EventArgs e)
        {

        }

        private void carpma2_Click(object sender, EventArgs e)
        {

        }
    }
}
