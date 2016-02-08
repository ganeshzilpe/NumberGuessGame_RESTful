using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberGuess_REST
{
    
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "generateSecret/{lower}/{upper}")]
        int subSecretNumber(string lower, string upper);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, UriTemplate = "checkSecret/{userNum}/{SecretNum}")]
        string subCheckNumber(string userNum, string SecretNum);
    }

}
