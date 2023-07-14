/*
 Şimdi burada genelde internetten baktığımız kaynaklarda çok düzensiz ve kalıp bir anlatım söz konusu biz bunu istemiyoruz.
    Daha akılda kalıcı  bir şekilde anlatmak istiyorum bu konuyu  

        Öncelikle bizim key cümlemizi aktarayım.


                ====> BAĞIMLILIKLARI TERSİNE ÇEVİR <====


------------------------------------------------------------------------------------------------------------------------------

        Bir adet komutan  düşünelim,
                    
              Bu komutanın emrinde sadece 1 asker olsun.

        Komutan askeri yanına çağırsın , ve emir versin olum git sigaraları temizle desin.

             Asker sigaraları temizlemeye gitsin.

        Birkaç dakika sonra bir kez daha askeri çağırsın,

            Asker hemen gelmez değil mi şuan bir iş ile meşgul sigara topluyor

        Asker komutanın yanına gelince komutan -> olum neredesin sen beni bir yere götürmen lazımdı desin
           
            Asker ne diye cevap verir emrinizi yerine getiriyordum der değil mi mantıken  ? 
        
        Burada nasıl bir problem söz konusu
                
            Komutan emirlerini yerine getirmesi için tek bir askere bağlı bundan dolayı.
                    

------------------------------------------------------------------------------------------------------------------------------

        Peki bunu nasıl çözebiliriz ??
            
                Eğer bu komutan birden fazla askere sahip olursa ne olur ? 

                Sigara toplaması için 1.askeri görevlendirir.
                    
                Bir yere gitmek için başka bir askeri görevlendirir.

                Başak bir görev için 3.askeri vs vs 

        
       İlk durumda neydi komutan görevlerini yapması için bir askere bağlıydı değil mi  ? 
            Şimdi ne oldu askerler komutana bağlı oldu .
    
    

------------------------------------------------------------------------------------------------------------------------------


Başka bir örnek verelim . 

        Bir insan sıvı ihtiyacını durmadan kola ile karşılıyor olsun .
                Yani bu insan kola dışında başka bir şey içemesin.
        
        Bir yere gittiğinde masada ne olursa olsun kola içsin , kola yoksa başı ağırsın keyfi kaçsın ..

        Burada insan neye bağlı Kolaya değil mi ? 

        Şimdi bu durumun tam tersi nasıl olur ? 

            Adamın burada bağımlı olduğu şey ne ? Kola 
                Bunun tam tersi nasıl olur ? 
                    Kola adama bağlı olursa değil mi .


------------------------------------------------------------------------------------------------------------------------------


    Şimdi yazılımsal bir örnek verelim 
       Öncelikle NotIdeal.cs classımıza geçelim

 */



#region Not Ideal Code
//using _5_Dependency_Inversion_Principle_NotIdealCode;
//MailService mailService = new();
//mailService.SendMail(new Gmail());

/* Bahsettiğimiz gibi burada sadece Gmail kullanıyoruz Gmail dışında başka bir şey kullanamıyoruz */

#endregion
#region Ideal Code
using _5_Dependency_Inversion_Principle_Ideal;
MailService mailService = new();
mailService.SendMail(new Gmail(), "...", "...");
mailService.SendMail(new Hotmail(), "...", "...");
#endregion