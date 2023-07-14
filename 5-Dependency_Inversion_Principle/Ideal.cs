using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_Dependency_Inversion_Principle_Ideal;

/*
 Şimdi mail servisimiz çalışacağı mail göndereceği sunucuyu burada interface üzerinden seçecek.
        Bu neyi sağlayacak
            MailServisimiz bizim için artık ImailServer interface'i üzerinden üretilen ne olursa olsun Hotmail Gmail artık fark etmez onu kullanarak işlem yapacak
                Yani bağımlılık ortadan kalkacak
            
                Hem kodda bir bütünlük olacak yarın öbürgün Yandex kullanmak istersek burada içeride /(SendMail içinde)  hiçbir düzenleme yapmamız gerekmeyecek

            
 */
class MailService
{
    public void SendMail(IMailServer mailServer, string to, string body)
    {
        mailServer.Send(to, body);
    }
}

interface IMailServer
{
    void Send(string to, string body);
}
class Gmail : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
class Yandex : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
class Hotmail : IMailServer
{
    public void Send(string to, string body)
    {
        //...Send Mail...
    }
}
