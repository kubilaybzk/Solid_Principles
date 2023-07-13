

/*
 Normal şartlarda bir tasarıma başlarken öncelikle o projenin abstrack classlarını interface'lerini oluştururuz.
   Daha sonra bu interface ile beraber kalıtım yöntemi ile classlarımızı oluştururuz.
      

   Şimdi burada şöyle bir durum söz konusu biz bu şekilde contract yani imza yöntemi ile kalıtımları alırız.

    Her bir imza için o interface içinde bulunan kodları kullanmamız gereklidir. 
        İnterface mantığı aslında budur fakat, bu prensip burada şunu savunur

        Belirli bir interface'de kullanılan bütün methodlar , o interface içinde kalıtım yöntemi method props vs bunları kullanmak zorunda olamalı.
        
         ***Sınıfın yapması gereken her farklı davranışın o davraışlara odaklanmış özel interfaceler ile eşleşmesini ister.***
     
   
Şimdi Şöyle bir yapı kullanalım ve bunu daha iyi anlayalım buradan notIdeal class'ımıza geçiş yapalım.
        

 */




#region Not Ideal Code
//using _4_Interface_Segregation_Principle_NotIdeal;
//SamsungPrinter printer = new();
//printer.PrintDuplex();
#endregion
#region Ideal Code
using _4_Interface_Segregation_Principle_IdealCode;
SamsungPrinter printer = new();
printer.Fax();
#endregion