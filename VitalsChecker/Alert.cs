using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsChecker
{
    interface IAlert
    {
        void sendAlert(string message);
    }
    class AlertInSMS : IAlert
    {
        public void  sendAlert(string message)
        {
            Console.WriteLine(message);
        }
    }
    class AlertInIntercom : IAlert
    {
        public void sendAlert(string message)
        {
            Console.WriteLine(message);
        }
    }
}
