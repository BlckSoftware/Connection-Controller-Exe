using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Globalization;
using System.Diagnostics;

namespace connection_controller
{
    public partial class connection_controller : Form
    {
       
        string zaman = DateTime.Now.ToString("f", CultureInfo.CreateSpecificCulture("tr-TR"));// Tarih saat formatı Türkçe ayarlandı.

        DataTable table = new DataTable();
 
        
        public connection_controller()
        { CheckForIllegalCrossThreadCalls = false;


          

              
            checkfiles();
          
            InitializeComponent();
            StartTimer();
                    
          

            table.Columns.Add("CİHAZ ADI", typeof(string));    // CIHAZ_ADI adında sütun oluşturuldu .
            table.Columns.Add("CİHAZ İP", typeof(string));     // CIHAZ_IP  adında sütun oluşturuldu .


           
            dosya_cleaner(); // log dosyasının boyutu denetleniyor belirtilen boyutu geçtiğinde text dosyası silinip yeniden oluşturuluyor.


            dataGridView1.DataSource = table;  // table adındaki tablo formda oluşturulan data grid'ine bağlandı.


            int row_count = table.Rows.Count;
            string[] liste = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt");   // Tablo için text dosyası okundu.
            string[] values;  // for için değişken tanımlandı.

            for (int i = 0; i < liste.Length; i++) // tablodaki değerler kadar for döngüsü başlatıldı.
            {


                values = liste[i].ToString().Split('|');   // tabloda "|" cihaz adı ve ipsi arasında "|" karakteri kullanıldığı için "|" karekteri öncesi ve sonrası 2 farklı data olarak ayrıldı.



                string[] row = new string[values.Length];   // sütunları okumak için for döngüsü yapıldı.
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();                  

                }
                
                    table.Rows.Add(row);  // Text deki değerler tabloya aktarıldı.         
            
            
            }
            


        }





        System.Windows.Forms.Timer t = null;
        private void StartTimer()
        {
            t = new System.Windows.Forms.Timer();
            t.Interval = 1000;
            t.Tick += new EventHandler(t_Tick);
            t.Enabled = true;
        }

        public void t_Tick(object sender, EventArgs e)
        {
            tarih_label.Text = DateTime.Now.ToString();
        }


      

        public void dosya_cleaner()
        {
            FileInfo info = new FileInfo("LOG.txt");

            var boyut = info.Length / 1000;


            if (boyut >= 200)
            {

                File.WriteAllText("LOG.txt", String.Empty);

                MessageBox.Show("Log Dosyası Boyutu:" + boyut + "KB \n Dosya silindi.");


            }


        }
        void checkfiles()
        {




            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt"))
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt").Close();
                string message = "''Cihaz_Listesi.txt BULUNAMADI !!''\n''Cihaz_Listesi'' ADINDA TEXT DOSYASI OLUŞTURULDU " + AppDomain.CurrentDomain.BaseDirectory + "\n \n README.TXT GÖZ ATIN";
                string title = "UYARI";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);

            }


            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt"))  // Log.txt yok ise .
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt").Close(); // Dosya yarat.
                string message = "''LOG.txt BULUNAMADI !!''\n''LOG.txt'' ADINDA TEXT DOSYASI OLUŞTURULDU " + AppDomain.CurrentDomain.BaseDirectory + "\n \n README.TXT GÖZ ATIN";
                string title = "UYARI";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }

        
            if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "kim.txt"))  // Log.txt yok ise .
            {
                File.Create(AppDomain.CurrentDomain.BaseDirectory + "kim.txt").Close(); // Dosya yarat.
                string message = "''kim.txt BULUNAMADI !!''\n''kim.txt'' ADINDA TEXT DOSYASI OLUŞTURULDU " + AppDomain.CurrentDomain.BaseDirectory + "\n \n README.TXT GÖZ ATIN";
                string title = "UYARI";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, title, buttons, MessageBoxIcon.Warning);
            }
        }

          
        
        void loading()
        {
            ICMP();           
            
        }
        public  void ICMP()
        {
            File.Create(AppDomain.CurrentDomain.BaseDirectory + "label.txt").Close();

            var ip_list = table.AsEnumerable().Select(s => s.Field<string>("CİHAZ İP"));



            int row_count = table.Rows.Count;
           
   
            foreach (var k in ip_list)

            {
               
                    Thread.Sleep(15);

                Ping pingSender = new Ping();


                // var numbers = new[] { File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt") };
                // var words = new[] { File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt") };
                int timeout = 5000;// Wait 5 seconds for a reply.

                // Create a buffer of 32 bytes of data to be transmitted.
                string data = " created  by huseyin karayazim  ";    //32bayt boyutunda bir veri oluşturuldu.  
                byte[] buffer = Encoding.ASCII.GetBytes(data);


                PingOptions options = new PingOptions(64, true);

                PingReply reply = pingSender.Send(k, timeout, buffer, options); // Send the request.



                if (reply.Status == IPStatus.Success)

                {                  

                    DataRow[] ad = table.Select("[CİHAZ İP] = '" + k + "'");
                    
                    foreach (DataRow row in ad)
                    {
                       
                        string cihaz = (row[0] + " | " + row[1]);


                        string logmes_bas = zaman + " | İstasyon : " + cihaz + "  Bağlantı Var. " + "\n";
                        if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt"))           // LOG.txt yok ise .
                        {
                            File.Create(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt").Close(); // Dosya yarat.
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt")) // log dosyasına mesaj yazma.
                            {
                                sw.WriteLine(logmes_bas); // içerisine logmes yaz.
                            }


                        }

                        else if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt"))
                        {
                           
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt"))
                            {
                                sw.WriteLine(logmes_bas ); // içerisine logmes yaz.

                            }

                        }


                    }
                    
                }
               


                else if (reply.Status != IPStatus.Success)

                {
                   

                    DataRow[] adı = table.Select("[CİHAZ İP] = '" + k + "'");


                    foreach (DataRow row in adı)
                    {
                        string cihaz = (row[0] + " | " + row[1]);

                        string logmes = zaman + " | İstasyon : " + cihaz + "   Bağlantı Yok !!!! " + "\n";
                        

                        if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt")    )         // LOG.txt yok ise .
                        {
                            File.Create(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt").Close(); // Dosya yarat.
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt")) // log dosyasına mesaj yazma.
                            {
                                sw.WriteLine(logmes); // içerisine logmes yaz.
                                
                            }
                           
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "label.txt")) // log dosyasına mesaj yazma.
                            {
                                
                                sw.WriteLine(logmes); // içerisine logmes yaz.
                            }


                        }

                       else if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt"))        // LOG.txt yok ise .
                        {
                          
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "LOG.txt")) // log dosyasına mesaj yazma.
                            {
                                sw.WriteLine(logmes); // içerisine logmes yaz.
                            }
                             // Dosya yarat.
                            using (StreamWriter sw = File.AppendText(AppDomain.CurrentDomain.BaseDirectory + "label.txt")) // log dosyasına mesaj yazma.
                            {
                                sw.WriteLine(logmes); // içerisine logmes yaz.
                                
                            }
                        }
                        
                    }
                    
                }
                

            }
            log_Read();
           
           send_mail();

            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "label.txt");



        }
        public void log_Read()
        {
            var log = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "label.txt");
            log_textbox.Text =log;

        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            using (wait_screen wait = new wait_screen(loading))

            {   wait.ShowDialog(this);
                MessageBox.Show("TEST TAMAMLANDI", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }


            
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
           
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "label.txt");

        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void start_button_Click(object sender, EventArgs e)
        {

            
            backgroundWorker1.RunWorkerAsync();
        }

        private void Exit_Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "label.txt");
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
           

        }
    
        public void add_Kayıt()
        {
            TextWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt");
         
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dataGridView1.Columns.Count - 2; j++)
                {
                    writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString() + "\t" + "|" + "\t"); //  İSİM KISMI YAZILIYOR
                    

                }

                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                {


                    writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString()); //  İP KISMI YAZILIYOR
                }
                writer.WriteLine("");


            }
            writer.Close();
          
        }

        private void update_button_Click(object sender, EventArgs e)
        {
            Update();


            DataTable table = new DataTable(); // table adında tablo oluşturuldu .

            
            table.Columns.Add("CİHAZ ADI", typeof(string));    // CIHAZ_ADIadında sütun oluşturuldu .
            table.Columns.Add("CİHAZ İP", typeof(string));     // CIHAZ_IP adında sütun oluşturuldu .


            var ip_list = table.AsEnumerable().Select(s => s.Field<string>("CİHAZ İP")); // ping atabilmek için CIHAZ_IP sütunundan ip adreslerini ip_list değişkenine aktarıyorum.
            var cihaz_list = table.AsEnumerable().Select(s => s.Field<string>("CİHAZ ADI")); // CIHAZ_ADI sütununu cihaz_list değişkenine aktarıyorum.

            dataGridView1.DataSource = table;  // table adındaki tablo formda oluşturulan data grid ine bağlandı.





            string[] liste = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "Cihaz_Listesi.txt");   // Tablo için text dosyası okundu.
            string[] values;  // for için değişken tanımlandı.

            for (int i = 0; i < liste.Length; i++) // tablodaki değerler kadar for döngüsü başlatıldı.
            {
                if (liste == null) { continue; }



                values = liste[i].ToString().Split('|');   // tabloda "/" ile sütunlar ayrıldı .


                string[] row = new string[values.Length];   // sütunları okumak için for döngüsü yapıldı.
                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();


                }
                table.Rows.Add(row); // Text deki değerler tabloya aktarıldı.

            }
            int row_count = table.Rows.Count;

        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CihazIP_TextBox.Text) && (string.IsNullOrEmpty(Cihazadı_TextBox.Text)) || (CihazIP_TextBox.Text == "CİHAZ IP") && (Cihazadı_TextBox.Text == "CİHAZ ADI"))

            {
                //boş bırakılmışsa
                MessageBox.Show("CİHAZ ADI VE CİHAZ IP  BOŞ BIRAKILAMAZ !!");

                Cihazadı_TextBox.Clear();
                CihazIP_TextBox.Clear();
                placeholster_conf();
            }

            else if (string.IsNullOrEmpty(Cihazadı_TextBox.Text)|| (Cihazadı_TextBox.Text == "CİHAZ ADI"))
            {//boş bırakılmışsa
                MessageBox.Show("CİHAZ ADI BOŞ BIRAKILAMAZ !!");
                Cihazadı_TextBox.Clear();
                CihazIP_TextBox.Clear();
                placeholster_conf();

            }


            else if (string.IsNullOrEmpty(CihazIP_TextBox.Text)|| (CihazIP_TextBox.Text == "CİHAZ IP"))
            {//boş bırakılmışsa
                MessageBox.Show("CİHAZ IP BOŞ BIRAKILAMAZ !!");
                Cihazadı_TextBox.Clear();
                CihazIP_TextBox.Clear();
                placeholster_conf();

            }
          


            else
            {  //boş değilse
                table.Rows.Add(Cihazadı_TextBox.Text, CihazIP_TextBox.Text);
                dataGridView1.DataSource = table;

                MessageBox.Show("TABLOYA EKLENEN CİHAZ ADI :" + Cihazadı_TextBox.Text + "\n TABLOYA EKLENEN CİHAZ IP  :" + CihazIP_TextBox.Text);


                Cihazadı_TextBox.Clear();
                CihazIP_TextBox.Clear();
                placeholster_conf();


                add_Kayıt();

                MessageBox.Show("TABLO KAYDEDİLDİ");
            }

        }

        private void save_button_Click(object sender, EventArgs e)
        {
            add_Kayıt();
            MessageBox.Show("TABLO KAYDEDİLDİ !");

        }
        private void info_button_Click(object sender, EventArgs e)
        {
            string File = (AppDomain.CurrentDomain.BaseDirectory + "README.txt");
            Process.Start(File);
        }

        private void connection_controller_Load(object sender, EventArgs e)
        {

        }
                   
        public void send_mail()
        {
           
            string alıcı = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "kim.txt"); //alıcı mail adresilerini dışarıdan ekliyor.
            var log = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "label.txt");

            if (checkBox1.Checked == true)
            {  

                    goto step1; }

            else if (checkBox1.Checked == false)
            { goto skip; }
       
           


            if (alıcı == null || alıcı == " " || alıcı == "") { goto skip; }
            else { goto step1; }
             step1:
            if (log == null || log == " " || log == "") { goto skip; }


            MailMessage error = new MailMessage();
            SmtpClient istemci = new SmtpClient();

            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            istemci.Credentials = new System.Net.NetworkCredential("gonderici_mailadresi@mailadresi.com", "mailsifresi");

            error.To.Add(alıcı);

            error.From = new MailAddress("gonderici_mailadresi@mailadresi.com");
            error.Subject = ("MAIL BASLIGI ");
            error.Body = (" \n \n DİKKAT\n\n Sayın Yetkili Aşağıdaki İstasyon / İstasyonlara Bağlantı Sağlanamamaktadır.\n\n \n " + log+" \n\n\n\n\n\n  \n \n \n Tarih : " +zaman);
            
            istemci.Send(error);
            skip:
            File.Delete(AppDomain.CurrentDomain.BaseDirectory + "mail.txt"); // mail atıldıktan sonra program kapanırken text dosyasını siliyor.

        }

        private void Cihazadı_TextBox_Leave(object sender, EventArgs e) // text box'a PlaceHolder eklendi
        {
            if (string.IsNullOrEmpty(Cihazadı_TextBox.Text))
            {
                Cihazadı_TextBox.Text = "CİHAZ ADI";
                Cihazadı_TextBox.ForeColor = Color.Silver;
                Cihazadı_TextBox.Font = new Font(Cihazadı_TextBox.Font, FontStyle.Italic | FontStyle.Bold);
            }
          
        }
        private void CihazIP_TextBox_Leave(object sender, EventArgs e) // text box'a PlaceHolder eklendi
        {
            if (string.IsNullOrEmpty(CihazIP_TextBox.Text))
            {
                CihazIP_TextBox.Text = "CİHAZ IP";
                CihazIP_TextBox.ForeColor = Color.Silver;
                CihazIP_TextBox.Font = new Font(CihazIP_TextBox.Font, FontStyle.Italic | FontStyle.Bold);
            }

          


        }

        private void Cihazadı_TextBox_Enter(object sender, EventArgs e) // text box'a PlaceHolder eklendi
        {
            if (Cihazadı_TextBox.Text == "CİHAZ ADI")

            Cihazadı_TextBox.Text = null;
            Cihazadı_TextBox.ForeColor = Color.Black;
            Cihazadı_TextBox.Font = new  Font (Cihazadı_TextBox.Font, FontStyle.Regular | FontStyle.Bold);

        }

        private void CihazIP_TextBox_Enter(object sender, EventArgs e) // text box'a PlaceHolder eklendi
        {
            if (CihazIP_TextBox.Text == "CİHAZ IP")

            CihazIP_TextBox.Text = null;
            CihazIP_TextBox.ForeColor = Color.Black;
            CihazIP_TextBox.Font = new Font(CihazIP_TextBox.Font, FontStyle.Regular | FontStyle.Bold);
        }

       
        void placeholster_conf() //placeholster tanımlandı
        {
            CihazIP_TextBox.Text = "CİHAZ IP";
            CihazIP_TextBox.ForeColor = Color.Silver;
            CihazIP_TextBox.Font = new Font(CihazIP_TextBox.Font, FontStyle.Italic | FontStyle.Bold);

            Cihazadı_TextBox.Text = "CİHAZ ADI";
            Cihazadı_TextBox.ForeColor = Color.Silver;
            Cihazadı_TextBox.Font = new Font(Cihazadı_TextBox.Font, FontStyle.Italic|FontStyle.Bold);

        }
    }
} 
