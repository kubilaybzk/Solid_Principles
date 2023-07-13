using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Interface_Segregation_Principle_IdealCode;


/*
 şimdi burada ilk olarak yapmamız gereken çok iyi bir mimari kullanarak bütün projenin analizini yapmak hangi class ne kullanacak 
    
HP => Scan Fax Duplex ve Print kullanacak.
Samsung => Print ve Fax kullanacak
Lexmark => Fax Print ve Scan kullanacak


Hmm burada nasıl bir çözüm bulabiliriz ? 

    Bizim prensipimiz bize ne diyordu .
           
        HER SINIFIN YAPMASI GEREKEN HER FARKLI  DAVRANIŞI O DAVRANIŞA YADA O DAVRANIŞLARA ODAKLANMIŞ OLAN ÖZEL İNTERFACELER İLE EŞLEŞMESİ GEREKİR.
    
   Burada nasıl bir çözüm elde ederiz  ?

    1-İnterfaceleri gruplayarak? 
    2-İnterfaceleri tekrar tekrar farklı şekilde Oluşturarark ? 
    
    Aslında hepsi mantıklı geliyor kulağa değil mi ? 

    Yarın öbürgün yeni markalarında ekleneceğini düşünelim belki onlar sadece Fax yapacak belki sadece Scan işlemi yapacak
        En mantıklı çözüm  bütün fonksiyonlar methodlar yada propslar için farklı farklı interfaceler ortaya çıkarmak olacaktır. 


    Hmm peki bu fazla dosyaya sebep olmayacak mı diye düşünebiliriz ...
        Bırak olsun en azından daha temiz ve daha düzenli SOLİD prensiplerine uygun kodlara sahip olmuş oluruz.
            

 */

interface IPrint
{
    void Print();
}
interface IScan
{
    void Scan();
}
interface IFax
{
    void Fax();
}
interface IPrintDuplex
{
    void PrintDuplex();
}
class HPPrinter : IPrint, IScan, IFax, IPrintDuplex
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
class SamsungPrinter : IPrint, IFax
{
    public void Fax()
    {
        //... Fax işlemleri ...
    }

    public void Print()
    {
        //... Print işlemleri ...
    }
}
class LexmarkPrinter : IFax, IPrint, IScan
{
    public void Fax()
    {
        //... Fax işlemleri ...
    }

    public void Print()
    {
        //... Print işlemleri ...
    }

    public void Scan()
    {
        //... Scan işlemleri ...
    }
}
