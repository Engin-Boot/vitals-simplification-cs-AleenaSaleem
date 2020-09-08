using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsChecker
{
    public class VitalsCollection
    {
        public  Vitals[] allVitals;
        public VitalsCollection(int n_vitals)
        {
            allVitals = new Vitals[n_vitals];
        }
        public void Initialize()
        {
            for (int i = 0; i < allVitals.Length;i++)
            {
                allVitals[i] = new Vitals();
                allVitals[i].Initialize();
            }
        }
        public void UpdateVitals()
        {
            int loopCounter;
            float value;
            for (loopCounter = 0; loopCounter < this.allVitals.Length; loopCounter++)
            {
                value = Single.Parse(Console.ReadLine());
                allVitals[loopCounter].setValue(value);
            }
        }
    }
    class Vitals_Main
    {
        static void Main(string[] args)
        {
            VitalsCollection v_collection = new VitalsCollection(3);
            v_collection.Initialize();
            v_collection.UpdateVitals();
            VitalsMonitor v_monitor = new VitalsMonitor();
            AlertInSMS alertSMS = new AlertInSMS();
            AlertInIntercom alertIntercom = new AlertInIntercom();

            Checker.ExpectTrue(v_monitor.VitalsAreNormal(alertSMS,v_collection));
            v_collection.UpdateVitals();
            Checker.ExpectFalse(v_monitor.VitalsAreNormal(alertIntercom,v_collection));
            v_collection.UpdateVitals();
            Checker.ExpectFalse(v_monitor.VitalsAreNormal(alertIntercom, v_collection));
            Console.WriteLine("All ok");
        }
    }
}
