



    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Liskov_Substitution_Principle_Ideal;


/*
 
 Şimdi burada bizim Translate fonksiyonumuz , sadece  AWS ve Google tarafında kullanılıyor o zaman bunu ayrı bir interface olarak tanılmayıp sadece bu classları kalıtım olarak ilgili classlara verebiliriz.
        Bu sayede ilerleyen aşamalarda herhangi bir sorun çıkmasını engellemiş oluruz.
            
    
Cloud cloud = new AWS();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();

cloud = new Google();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();

cloud = new Azure();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();

Burada ise Tip kontrolu yaparak Translate fonksiyonunun kullanmasını sağlayacağız. İşte bu kadar kolay bu işlem ..


 */

abstract class Cloud
{
    public abstract void MachineLearning();
}
interface ITranslatable
{
    void Translate();
}
class AWS : Cloud, ITranslatable
{
    public void Translate()
       => Console.WriteLine("AWS Translate");
    override public void MachineLearning()
        => Console.WriteLine("AWS Machine Learning");
}

class Azure : Cloud
{
    override public void MachineLearning()
        => Console.WriteLine("Azure Machine Learning");
}

class Google : Cloud, ITranslatable
{
    public void Translate()
       => Console.WriteLine("Google Translate");

    override public void MachineLearning()
        => Console.WriteLine("Google Machine Learning");
}