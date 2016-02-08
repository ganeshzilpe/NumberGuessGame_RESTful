using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberGuessGame
{
    
    public class Service1 : IService1
    {
        public int SecretNumber(string lower, string upper)
        {
            DateTime currentDate = DateTime.Now;
            int seed = (int)currentDate.Ticks;
            Random random = new Random(seed);
            int sNumber = random.Next(Int32.Parse(lower), Int32.Parse(upper));
            return sNumber;
        }
        public string checkNumber(string userNum, string SecretNum)
        {
            if (userNum == SecretNum)
                return "correct";
            else if (Int32.Parse(userNum) > Int32.Parse(SecretNum))
                return "too big";
            else
                return "too small";
        }
    }
}
