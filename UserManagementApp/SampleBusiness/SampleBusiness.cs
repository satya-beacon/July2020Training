using System;

namespace SampleBusiness
{
    public class SampleBL
    {
        public string SayHello(string name)
        {
           if(name == null)
            {
                throw new Exception("Name can't be null");
            }

           if(name == "")
            {
                return null ;
            }

            return $"Hello.. {name}";
        }
    }
}
