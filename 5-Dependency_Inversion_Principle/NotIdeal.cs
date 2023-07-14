using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Dependency_Inversion_Principle_NotIdealCode;

/*

Bir adet mail servisimiz olsun bu mail servisimiz ile gmail aracılığı ile mail yolladığımızı düşünelim.
               Yani mail servisiminiz içinde Gmail fonksiyonları çalışsın.


           Şimdi , bu durumda bizim mail servisimiz gmail e bağımlı olmuyor mu ?

               Bu istenen bir durum değil o zaman hemen bu işlemi tersine çevirelim.

               Gmail bizim mailservis imize bağımlı olsun.


*/


class MailService
{
    public void SendMail(Gmail gmail)
    {
        gmail.Send("...");
    }
}

/*
 
Şimdi yarın öbürgün bir hata ile karşılaştığımız zaman yada gmail bozulduğu zaman yada gmail dışında başka bir mail operatörü kullanmak istediğimiz zaman,
        böyle bir yöntem kullandığımız zaman gmail dışında başka bir şey kullanmak istediğimiz zaman MailService kısmını yeniden tasarlamamız gerekecek
            parametre olarak aldığı Gmail gmail değerlerini mesela Hotmail hotmail olarak değiştireceğiz .
                Bu sefer ne olmuş olacak Hotmail'e bağımlı .
            
        Hmmm. ... 

        Şimdi düşünelim ne yaparsak , 
                Bu bağımlılığı ortadan kaldırmış olabilir ? 

            Peki sizce  ...
                Bir interface kullansak tüm bu servisler bu interface aracılığıyla kalıtım 
                    yöntemi ile bir fonksiyon almak zorunda olsa bu fonksiyon sayesinde mail işlemlerini yapıyor olsa nasıl olur ?

            
            O zaman şöyle bir şey olur , 
                    Gmail Hotmail Yaho bu interface'den türeyeceği için , 
                          ve biz istediğimizi kullanabileceğimiz için hiçbir problem yaşamayız.
                          
                    Bu sayede bizim mail servisimiz Hotmail Yada Yahoo'ya bağlı olmaz onlar  mail servise bağlı olur .


              Şimdi bunu Ideal.cs dosyamızda iceleyelim

        
 */


class Gmail
{
    public void Send(string mail)
    {
        //...Send Mail...
    }
}
class Yandex
{
    public void SendMail(string mail, string to)
    {
        //...Send Mail...
    }
}
class Hotmail
{
    public void Send(string mail)
    {
        //...Send Mail...
    }
}

