using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Interface_Segregation_Principle_NotIdeal;


/*   
 
 Burada şöyle bir durum söz konusu, ilk olarak bir Iprinter interfaceimiz var bu interface sayeside 
    Print Scan gibi methodları kalıtım olarak contract olan bütün classlara aktarmak istiyoruz.
            


Şimdi 
    
 
 */




interface IPrinter
{
    void Print();
    void Scan();
    void Fax();
    void PrintDuplex();
}


/*
 Şimdi burada HPPrinter 'isimli classı incelediğimiz zaman kalıtım olarak aldığı bütün classları kullanıyor hiçbir problem yok burada ,

 */

class HPPrinter : IPrinter
{
    public void Fax()
    {
        //... Fax işlemleri ...
    }

    public void Print()
    {
        //... Print işlemleri ...
    }

    public void PrintDuplex()
    {
        //... Print Duplex işlemleri ...
    }

    public void Scan()
    {
        //... Scan işlemleri ...
    }
}

/*
Burada ise SamsungPrinter'ı incelediğimizde 
    Buranın PrintDuplex ve Scan  methodunu kullanmadığını bunları desteklemediğini görüyoruz ignore etmek için notImplemented yada NotSupportedException 
        gibi hatalar ile işin içinden çıktığını görüyoruz.
    

        Aynı durum Lexmark içinde geçerli .


        Şimdi bu şekilde bir ilerleme bizim prensipimiz için doğru değil burada ekstradan bir maliyet söz konusu bunu engellemek için
               bu prensip ortaya çıkmıştır .
        
        Şöyle düşünelim yarın öbürgün bir şey oldu ve Scan methodunun içine bir parametre eklenmek istedi.
            Şimdi biz scan işlemini kullanmayan Classlar içindede kullanıyoruz burada şöyle bir durum söz konusu 
                MECBUREN HER İMPLEMENT EDİLEN YERDE BU KOD TEKRARDAN GÜNCELLEMEK GEREKECEK
        
        eee ama biz bunu kullanmadığımız yerde de güncelleyeceğiz buda ekstra bir maliyete sebep olacak .
            

        Şimdi ilk olarak , burada nasıl bir yöntem izlemeliyiz ona geçiş yapalım

            ======> Ideal.cs dosyamıza geçiş yapalım.
 
 */


class SamsungPrinter : IPrinter
{
    public void Fax()
    {
        //... Fax işlemleri ...
    }

    public void Print()
    {
        //... Print işlemleri ...
    }

    public void PrintDuplex()
        => throw new NotSupportedException();

    public void Scan()
        => throw new NotSupportedException();
}
class LexmarkPrinter : IPrinter
{
    public void Fax()
    {
        //... Fax işlemleri ...
    }

    public void Print()
    {
        //... Print işlemleri ...
    }

    public void PrintDuplex()
        => throw new NotSupportedException();

    public void Scan()
    {
        //... Scan işlemleri ...
    }
}