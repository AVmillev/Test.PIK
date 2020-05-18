using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test.PIK.Wcf
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Servise" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Servise.svc или Servise.svc.cs в обозревателе решений и начните отладку.
    public class Servise : IServise
    {        
        public List<string> SaveUser(string Login, string LastName, string FirstName)
        {
            List<string> res = new List<string>();
            try
            {
                var errorStr = "Ошибка. Не найден логин.";
                if (Login.Contains("pikuser") || Login.Contains("guestuser"))
                    res.Add("Успешно");
                else
                    res.AddRange(errorStr.Split(' '));
            }
            catch(Exception ex)
            {
                res.AddRange(ex.Message.Split(' '));
            }
            return res;
        }       
    }
}
