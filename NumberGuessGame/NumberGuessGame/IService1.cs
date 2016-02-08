using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberGuessGame
{
  
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "generateSecretNumber/{lower}/{upper}")]
        int SecretNumber(string lower, string upper);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "checkSecretNumber/{userNum}/{secretNum}")]
        string checkNumber(string userNum, string secretNum);
    }


}
