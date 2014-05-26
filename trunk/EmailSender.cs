using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace MyChecker
{
    class EmailSender:ISender
    {
        private String _user;
        private String _pass;
        public EmailSender()
        {
            _user = "logmeinpls@mail.ru";
            Console.WriteLine(String.Format("Введите пароль для {0}", _user));
            _pass = Console.ReadLine();
        }
        public void SendMsg(String Msg)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.mail.ru", 587);
                client.Credentials = new NetworkCredential(_user, _pass);
                client.EnableSsl = true;
                MailMessage Mail = new MailMessage(_user,_user, "Attention!",Msg);
                Mail.BodyEncoding = Encoding.GetEncoding("UTF-8");
                Mail.SubjectEncoding = Encoding.GetEncoding("UTF-8");
                client.Send(Mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
