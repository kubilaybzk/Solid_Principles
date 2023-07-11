
using System;
using System.Security.Cryptography.X509Certificates;

/* 
    Single responsibility prensibi sınıflarımızın iyi tanımlanmış tek bir sorumluluğu olması gerektiğini anlatmaktadır. 
    Bir sınıf (nesne) yalnızca bir amaç uğruna değiştirilebilir,
    o amaçta o sınıfa yüklenen sorumluluktur, yani bir sınıfın yapması gereken yalnızca bir işi olması gerekir.


    Eğer geliştirdiğiniz sınıf ya da fonksiyon birden fazla amaca hizmet ediyorsa, bu kurala aykırı bir geliştirme sürecinde olduğunuz anlamına geliyor.
    Bunu farkettiğinizde amaçlara uygun olarak parçalamanız gerekmektedir.

    Gereksinimler değiştiğinde, yazılan kodda da değişmesi gereken kısımlar olacaktır. 
    Bu da yazılan sınıfların(nesnelerin) bir kısmının ya da tamamının değiştirilmesi anlamına gelir.
    Bir sınıf ne kadar fazla sorumluluk alırsa, o kadar fazla değişime uğramak zorunda kalır. 
    Böylece birçok kod parçasının değişmesine neden olurken, yeniden yazımda; değişikliklerin uygulanması da bir o kadar zorlaşır.


 */








#region  Not İdeal 




class Database
{
    public void Connect()
    {
        //...
        Console.WriteLine("Veritabanı bağlantısı sağlanmıştır.");
    }
    public void Disconnect()
    {
        //...
        Console.WriteLine("Veritabanı bağlantısı kesilmiştir.");
    }
    public string State { get; set; }
    public List<Person> GetPersons()
    {
        return new() {
            new(){ Name = "Hilmi", Surname = "Celayir" },
            new(){ Name = "Mustafa", Surname = "Yıldız" },
            new(){ Name = "Cafer", Surname = "Muiddinoğlu" }
        };
    }
}


//Burayı bir entity olarak düşünelim  (hatayı ignore etmek için eklendi.)
class Person{
    public string Name { get; set; }
    public string Surname { get; set; }

}



/* 
  Yukarıda bulunan Database classını incelediğimizde Connect,Disconnect,GetPersons adında 3 adet method olduğunu görüyoruz
    Şimdi bizim öğrendiğimiz bilgilere göre burada tek bir işten sorunlu olmayan bir class geliştirdiğimizi fark etmiş olmamız gerek değil mi
        Yani bizim kodumuz hem Veri tabanına bağlantı işlemlerini hemde Person verilerini çekip ondan işlem yapma ile sorumlu olduğunu fark ediyoruz.
            İşte bu bizim prensipimize aykırı bir durum bunu nasıl düzeltebiliriz ona bakalım.

        


 
 */


#endregion

/* 
 Prensibimiz gereği ne yapmamız gerekiyor tek bir işlemden sorumlu classlara sahip olmamız gerekiyor o zaman ilk yapmamız gereken işlem 
                ekstra yapılan işi ayırmak 
  Burada bizim GetPerson() methodumuzu ayırmamız gerekiyor bunu düzeltmek için GetPerson() methodunu yeni bir class 'a eklememiz gerekiyor.
*/


#region Ideal


class IdealDatabase
{
    public void Connect()
    {
        //...
        Console.WriteLine("Veritabanı bağlantısı sağlanmıştır.");
    }
    public void Disconnect()
    {
        //...
        Console.WriteLine("Veritabanı bağlantısı kesilmiştir.");
    }
    public string State { get; set; }
}

class PersonService
{
    public List<Person> GetPersons()
    {
        return new() {
            new(){ Name = "Hilmi", Surname = "Celayir" },
            new(){ Name = "Mustafa", Surname = "Yıldız" },
            new(){ Name = "Cafer", Surname = "Muiddinoğlu" }
        };
    }
}


#endregion
