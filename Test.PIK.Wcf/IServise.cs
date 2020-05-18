using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Test.PIK.Wcf
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServise" в коде и файле конфигурации.
    [ServiceContract]
    public interface IServise
    {
        
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/SaveUser/",
            BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List <string> SaveUser(string Login, string LastName , string FirstName);       
    }
     [DataContract]
        public class UserData
        {
            string login  = String.Empty;
            string lastName = String.Empty;
            string firstName = String.Empty;
            [DataMember]
            public string Login
            {
                get { return login; }
                set { login = value; }
            }

            [DataMember]
            public string LastName
            {
                get { return lastName; }
                set { lastName = value; }
            }
            [DataMember]
            public string FirstName
            {
                get { return firstName; }
                set { firstName = value; }
            }
        }
}
