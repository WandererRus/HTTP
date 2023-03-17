using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace HTTP
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string site = textBox1.Text;
            HttpClient client= new HttpClient();
            HttpResponseMessage response = client.GetAsync(site).Result;
            HttpContent content = response.Content;
            Stream stream = content.ReadAsStream();
            StreamReader reader = new StreamReader(stream);
            richTextBox1.Text = reader.ReadToEnd();

            MailMessage post = new MailMessage("iluxailuxa@gmail.com", "mysterylucky@yandex.ru");
            post.Subject = "Test message";
            post.HeadersEncoding = Encoding.Unicode;
            post.Body = "post message";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            smtp.Credentials = new NetworkCredential("iluxailuxa@gmail.com", "password");
            smtp.Send(post);
            
        }
    }
}