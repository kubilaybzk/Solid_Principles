

/*
 
 Kodlarımızda herhangi bir değişiklik yapmaya gerek duymadan alt sınıfları, türedikleri(üst) sınıfların yerine kullanabilmeliyiz.
 
 İlerleyen aşamadı , alt sınıflar birbirleri ile yer değiştirdiğinde kodda herhangi bir patlama çatlama olmamalı.
    
    Burada şart söyle olmalı kalıtım yoluyla üst kısımdan props method alan alt classlar  
            Zorunlu olarak gereksiz methodlar yada propslar içermemeli.
                Yani bu şu anlama geliyor NotImplemented vs gibi konular olmamalı.
                    


Burada hemen NotIdeal.cs dosyasına geçiş yapalım.
 */









#region Not Ideal Code
//using _3_Liskov_Substitution_Principle_NotIdeal;

//Cloud cloud = new AWS();
//cloud.MachineLearning();
//cloud.Translate();

//cloud = new Google();
//cloud.MachineLearning();
//cloud.Translate();

//cloud = new Azure();
//cloud.MachineLearning();
//if (cloud is not Azure)
//{
//    cloud.Translate();
//}
#endregion

#region Ideal Code
using _3_Liskov_Substitution_Principle_Ideal;
Cloud cloud = new AWS();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();

cloud = new Google();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();

cloud = new Azure();
cloud.MachineLearning();
(cloud as ITranslatable)?.Translate();
#endregion