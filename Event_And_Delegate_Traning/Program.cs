namespace Event_And_Delegate_Traning
{
    internal class Program
    {
        public delegate void MyDelegate();

        static void Main(string[] args)
        {
            var mailSender = new MailSender("as@gmai.com", "Deneme Messagw");
            Console.WriteLine("Deneme");

            MyDelegate delegate1 = new(mailSender.Send);

            delegate1.Invoke();

        }

        static class Class1
        {
            public static int Topla(int sayi1, int sayi2)
            {
                return sayi1 + sayi2;
            }

            public static int Carp(int sayi1, int sayi2)
            {
                return sayi1 * sayi2;
            }
        }

        public class MailSender
        {
            public string Mail { get; set; }
            public string Message { get; set; }

            public MailSender(string mail, string Message)
            {
                this.Mail = mail;
                this.Message = Message;
            }
            public void Send()
            {
                Console.WriteLine($"{Mail}'ine {Message} iletisi yollanmıştır.");
            }
        }
    }
}