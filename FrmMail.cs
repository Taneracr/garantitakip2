using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace garantiTakip
{
    public partial class FrmMail : Form
    {
        public FrmMail()
        {
            InitializeComponent();
        }
        stajyerEntities3 db = new stajyerEntities3();

        // taner811907 computer190781
        // qwerty1907 acar1907881



        public void MailGonder()
        {

            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("computer190781@gmail.com", "taner811907");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajım.To.Add(comboBox1.Text);
            mesajım.From = new MailAddress(comboBox1.Text);
            mesajım.Subject = "Kodla Teknoloji";
            mesajım.Body = "Doğum Gününüz Kutlu Olsun";
            istemci.Send(mesajım);

        }

        public void GarantiMailGonder()
        {

            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("computer190781@gmail.com", "taner811907");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajım.To.Add(comboBox4.Text);
            mesajım.From = new MailAddress(comboBox4.Text);
            mesajım.Subject = "Kodla Teknoloji";
            mesajım.Body = "Garantinizin Bitimine 10 Gün Kalmıştır";
            istemci.Send(mesajım);

        }




        private void button1_Click(object sender, EventArgs e)
        {
            MailGonder();
        }

        private void FrmMail_Load(object sender, EventArgs e)
        {
            //comboBox1.Items.Add("computer190781@gmail.com");

            //foreach (var item in db.tbl_Yetkili)
            //{                             
            //    comboBox1.Items.Add(item.MAIL);
            //}

            foreach (var item in db.tbl_Yetkili)
            {
                DateTime gun = Convert.ToDateTime(item.DGMTARİH);
                int guun = gun.Day;
                int ay = gun.Month;

                if (guun.ToString() == DateTime.Now.Date.Day.ToString() && ay.ToString() == DateTime.Now.Date.Month.ToString())
                {
                    comboBox2.Items.Add(item.AD + ": " + item.DGMTARİH);
                    comboBox1.Items.Add(item.MAIL);

                    //  MailGonder(comboBox1.Items[0].ToString(), comboBox1.Items[0].ToString());
                   // MailGonder(comboBox1.Items[3].ToString(), comboBox1.Items[3].ToString());
                    

                    //MailGonder(); // doğum günü Maili
                    
                }
            }



            int bugun = Convert.ToInt32(DateTime.Now.Date.Day);
            int bugunay = Convert.ToInt32(DateTime.Now.Date.Month);

            foreach (var item in db.tbl_cari)
            {
                DateTime gun = Convert.ToDateTime(item.tbl_baslangicBitisTarih.BİTİSTARİH);
                int guun = gun.Day;
                int ay = gun.Month;
                int islem = guun - bugun;

                if (bugunay == ay && islem == 10)
                {
                    comboBox3.Items.Add(item.tbl_Yetkili.AD + ": " + item.tbl_baslangicBitisTarih.BİTİSTARİH);
                    comboBox4.Items.Add(item.tbl_Yetkili.MAIL);

                }

                //comboBox4.Items.Add(db.tbl_cari.Select(x => x.tbl_Yetkili.MAIL).ToString());
                // GarantiMailGonder(); // Garanti Bitimine 10 gün kala Maili


                // comboBox3.Items.Add(item.BİTİSTARİH);
            }






        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GarantiMailGonder();
        }
    }
}
