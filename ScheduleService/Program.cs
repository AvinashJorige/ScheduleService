using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using static Entities.LogType;
using Core;

namespace ScheduleService
{
    class Program
    {
        static void Main(string[] args)
        {
            SampleService _s = new SampleService();
            var content = _s.getData();
            Console.ReadLine();
        }
    }
}
