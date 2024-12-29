using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqCode
{
    public class SimpleTestClass
    {
        public void Run1()
        {
            SampleClass sampleClass = new SampleClass();

            byte? test = (byte?)sampleClass.FleetEventType;
        }

        public void Run2() 
        {
            SampleClass simpleClass = new SampleClass
            { 
                StartDateTime = DateTime.Now,
                CustomDate = DateTime.Now.ToString(),
            };

            string json = JsonConvert.SerializeObject(simpleClass);
        }
    }
}
