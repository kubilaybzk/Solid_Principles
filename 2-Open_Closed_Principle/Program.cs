using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/* 
  
Burada asıl ilkemiz şu 
Bir sınıf ya da fonksiyon var olan özellikleri korumalı yani davranışını değiştirmiyor olmalı ve yeni özellikler kazanabilmelidir.

Yani kodumuz genişletilmeli fakat değiştirilmemli.

Genişletilmeli derken ne demek istiyoruz .
    => Kodumuzun yeni gereksinimlere göre   gelecek olan davranışlara koda eklenmesi.
        
Şimdi 3 tane class düşünelim  A,B ve C bu 3 class'ı biz banka olarak ele alalım şimdi A bankası için bir sınıf geliştirdiğimizi düşünelim.

---------------
  
    A
   
---------------

Yukarıdaki sınıfı uzun bir süre kullandık bu sınıf içinde A bankasıyla ilgili ödeme vs gibi  işlemler yapıyor.
    Zamanı geldi banka ile anlaşmazlık yaşadık ve biz B bankasına geçmeye karar verdik ne oldu bu durumda . 
        daha önce var olan kodları sildik daha sonra B aynı kodları tekrar yazdık. 

---------------
  
    A  B
   
---------------

Burada belki büyük bir sınıf yazdık ve içerisinde daha kullanılmayacak A ile ilgili fonksiyonlar kalmış oldu vs vs gibi sorunları ile karşılaştık
    
    B ile bir sorun yaşadık C bankasıa geçtik bu sefer'de A,B 'den parçalar kalmış olabilir kodlar tekrar yazılacak vs vs bir çok işlem söz konusu oldu.


Gördüğünüz gibi bir çook problem ile karşı karşıya kaldık işte bu gibi bir durumda bu prensipin değerini daha iyi anlıyoruz.
       Şimdi bunu canlı bir örnek ile inceleyelim.

. 

            


 */




#region Ideal olmayan prensipe aykırı olan durum 






/* Burada yapılan sınıfları inceleyelim 
       
    Garanti bankası  => Hesap numarasını Obje oluştururken alıyor ve PAra Gönderirken tutar isteyen bir fonksiyon ile para gönderiyor.
    Halk    bankası  => Hesap numarasını Fonksiyon'dan alıyor ve PAra Gönderirken tutar isteyen bir fonksiyon ile para gönderiyor.

    İki fonksiyon arasında bir tutarsızlık söz konusu , 

ParaGonderici class'ı içinde , 

        işte bu gibi bir durumda öncelikle bizim Garanti ile para gönderdiğimizi düşünürsek yapmamız gereken işlem. 
        
        Garanti garanti = new();
        garanti.HesapNo = "3123124";
        garanti.ParaGonder(tutar);

        şeklinde olacak diyelim ki garanti ile işimiz bozuldu Halkban'a geçiş yaptık burada ise 

ParaGonderici class'ımızı güncellememiz gerekecek .

        Halkban halkban = new();
        halkban.GonderilecekHesapNo("123");
        halkban.Gonder(tutar);

İki kod arasında tutarsızlığı ve neden maliyete sebep olduğunu açıkca ortada .
    

    PEKİ BU PROBLEMDEN NASIL KURTULURUZ
    
*/


class ParaGonderici
{
    public void Gonder(int tutar)
    {
        //Garanti garanti = new();
        //garanti.HesapNo = "...";
        //garanti.ParaGonder(tutar);
        Halkban halkban = new();
        halkban.GonderilecekHesapNo("123");
        halkban.Gonder(tutar);
    }
}
class Garanti
{
    public string HesapNo { get; set; }
    public void ParaGonder(int tutar)
    {
        //...
    }
}
class Halkban
{
    string _hesapNo;
    public void GonderilecekHesapNo(string hesapNo)
    {
        //...
    }
    public void Gonder(int tutar)
    {
        //...
    }
}


#endregion



/* 
  Genel olarak yaptığımız geliştirmede biz bir adet banka tutar ve iban üzerinden işlem yapıyoruz değil mi bir ınterface geliştirelim..
        Ve bu interface bu değerleri alan bir method'a sahip olsun.
            Bütün bankalarımız bu interface üzerinden türesin, 
                Bu sayede bütün bankalarımız bu fonksiyona sahip olmuş olsun.

  Daha sonra ParaGonder class'ımız içinde bu Interface'den türeyen obje için bu fonksiyonu çağırmış olalım bu sayede,
        ParaGonder classımız için kod değiştirme kısmında kurtulmuş oluruz sadece kodun gelişmesini sağlayabiliriz.
                İlerleyen süreçte para çek ekleyebiliriz gibi gibi 



 */



#region İdeal olarak kod tasarımı 


class IdealParaGonderici
{
    public void Gonder(IBanka banka, int tutar, string hesapNo)
    {
        banka.ParaTransferi(tutar, hesapNo);
    }
}

interface IBanka
{
    bool ParaTransferi(int tutar, string hesapNo);
}
class IdealGaranti : IBanka
{
    public string HesapNo { get; set; }
    public void ParaGonder(int tutar)
    {
        //...
    }

    public bool ParaTransferi(int tutar, string hesapNo)
    {
        try
        {

            HesapNo = hesapNo;
            ParaGonder(tutar);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
class IdealHalkbank : IBanka
{
    string _hesapNo;
    public void GonderilecekHesapNo(string hesapNo)
    {
        //...
    }
    public void Gonder(int tutar)
    {
        //...
    }

    public bool ParaTransferi(int tutar, string hesapNo)
    {
        try
        {
            GonderilecekHesapNo(hesapNo);
            Gonder(tutar);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

//Yarın öbürgün yeni bir banka eklemek istediğimiz aman bu kadar kolay bir şekilde ekleme yapabileceğiz.

class AhmetBank : IBanka
{
    public bool ParaTransferi(int tutar, string hesapNo)
    {
        throw new NotImplementedException();
    }
}

#endregion



#region Not Ideal Code

//ParaGonderici V1 = new();
//V1.Gonder(123412);



#endregion

#region Ideal Code

// paraGonderici = new();
// paraGonderici.Gonder(new.AhmetBank(), 100, "asd");

#endregion