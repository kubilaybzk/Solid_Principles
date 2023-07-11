using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Liskov_Substitution_Principle_NotIdeal;
/* 
 
 Burada bir adet Cloud adında bir abstract classımız var  bu classımız'da referans alırken Translate ve MachineLearning gibi iki adet fonksiyonumuz var bu fonksiyonlarımızı
      mutlaka ama mutlaka kullanmaz zorunda kullanmak istemez ise notimplemented gibi hatalar çıkarabiliriz karşımıza lakin burada şöyle bir durum söz konusu 
          

Cloud cloud = new AWS();
cloud.MachineLearning();
cloud.Translate();

cloud = new Google();
cloud.MachineLearning();
cloud.Translate();

cloud = new Azure();
cloud.MachineLearning();
if (cloud is not Azure)
{
    cloud.Translate();
}

şimdi burada gerekli düzenlemeleri yaparken ilk olarak karşımıza çıkacak olan problemi bir if koşulu ile biz kendi kendimize çözdük implement kısmı kolay olduğun için 
    ama bunu başka bir sınıf içinde başka bir şekilde kullanmış olduğumuzu göz önüne alırsak mutlaka burada bir hata ile karşı karşıya kalacağız.
        Yani biz cloud olarak AWS yada  Google yerine Azure kullanmış olsak ve Transalte fonksiyonunu kullanmak istesek burada biz bir hata alacağız.
            İşte bahsettiğimiz durum bu prensipe aykırı bir durum.
            

        
    Burada öyle bir design kullanmamız gerekiyor ki ilerleyen aşamada en ufak bir güncelleme yapılacağı zaman kodlarımızda hata olmasını istemeyiz bunun için Ideal.cs dosyamıza geçiş yapalım.


 */
abstract class Cloud
{
    public abstract void Translate();
    public abstract void MachineLearning();
}
class AWS : Cloud
{
    override public void Translate()
        => Console.WriteLine("AWS Translate");
    override public void MachineLearning()
        => Console.WriteLine("AWS Machine Learning");
}

class Azure : Cloud
{
    override public void Translate()
        => throw new NotImplementedException();

    override public void MachineLearning()
        => Console.WriteLine("Azure Machine Learning");
}

class Google : Cloud
{
    override public void Translate()
        => Console.WriteLine("Google Translate");

    override public void MachineLearning()
        => Console.WriteLine("Google Machine Learning");
}