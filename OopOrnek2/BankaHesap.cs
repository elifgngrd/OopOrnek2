using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopOrnek2
{
    abstract class BankaHesap //alttaki classlarda değiştiği için abstract class olacak
    {
        public long HesapNo { get; set; }
        public int Subekodu { get; set; }
        public string IBan { get; set; }
        public Decimal Bakiye { get; set; }

        public virtual string ParaCek(decimal tutar) 
        { 
           Bakiye -= tutar;
           return "hesabınızdan "+ tutar +"Tl para çetiniz.Güncel bakiye :" + Bakiye;
           
        }

        public virtual string ParaYatir(decimal tutar)
        {
            Bakiye += tutar;
            return "hesabınızdan " + tutar + "Tl para yatırdınız.Güncel bakiye :" + Bakiye;

        }

    }
    class VadesizHesap:BankaHesap
    {
        public override string ParaCek(decimal tutar)
        {
            if (Bakiye<tutar)
            {
                return "yetersiz bakiye...";
            }
            if (tutar%5==0)
            {
                return base.ParaCek(tutar);
            }
            else
            {
                return "5 ve 5'in katlarını çekebilirsiniz.";
            }

        }

    }

    class VadeliHesap:BankaHesap
    {
        public DateTime VadeBaslangic { get; set; }
        public int VadeGunSayisi { get; set; }
        public DateTime VadeSonuTarihi 
        {
            get
            { 
             return VadeBaslangic.AddDays(VadeGunSayisi);
            }  
        }
        public override string ParaCek(decimal tutar)
        {
            if (DateTime.Today.Date!=VadeSonuTarihi.Date)
            {
                return "Vade sonu tarihini bekleyiniz.";
            }
            else if (Bakiye < tutar)
            {
                return "yetersiz bakiye";
            }
            else if (tutar%5!=0)
            {
                return "5 ve 5 in katlarını çekebilirsin";
            }
            else
            {
                return base.ParaCek(tutar);
            }
        }
        public override string ParaYatir(decimal tutar)
        {
            if (DateTime.Today.Date==VadeSonuTarihi.Date)
            {
                return base.ParaYatir(tutar);
            }
            else
            {
                return "Vade sonu tarihini bekleyiniz.";
            }

        }

    }
}
