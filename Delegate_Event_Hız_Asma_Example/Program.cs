namespace Delegate_Event_Hız_Asma_Example
{
    public enum ArabaModel
    {
        kamyonet,
        minibus,
        otomobil,
        ticariarac

    };

    public delegate void HizHandler(object sender, HizArgs e);

    public class HizArgs
    {
        private int guncelHiz;
        public DateTime Zaman
        {
            get { return DateTime.Now; }
        }
        public int GuncelHiz
        {
            get { return guncelHiz; }
        }

        public HizArgs(int guncelHizi)
        {
            guncelHiz = guncelHizi;
        }
    }


    public class Otomobil
    {
        private int hiz;
        private ArabaModel model;
        public event HizHandler HizAsildi;

        public ArabaModel Model
        {
            get { return model; }
            set { model = value; }
        }

        public int Hiz
        {
            get { return hiz; }
            set
            {
                if (hiz >= 80 && HizAsildi != null)
                    HizAsildi(this, new HizArgs(value));
                hiz = value;

            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Otomobil arabam = new Otomobil();

            arabam.HizAsildi += new HizHandler(arabam_HizAsildi);
            arabam.HizAsildi += (object sender, HizArgs args) => { Console.WriteLine("denemeeeeeeeeeeee"+sender); }; // bu şekilde de evente method bağlayabiliyoruz.
            arabam.HizAsildi += new HizHandler(arabam_HizAsildi);
            for (int i = 70; i <= 90; i += 5)
            {
                arabam.Hiz = i;
                Console.WriteLine("Hızımız, {0} ", arabam.Hiz);
                Thread.Sleep(500);
            }
        }

        static void arabam_HizAsildi(object sender, HizArgs arg)
        {
            Console.Write("Hız sınırı aşıldı..." + arg.Zaman + ".  \n");
        }
        static void uyari(object sender, HizArgs arg)
        {
            Console.Write("Araç devre dışı bırakılacaktır. \n");
        }
    }
}