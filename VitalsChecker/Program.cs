using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsChecker
{
    public class VitalsCollection
    {
        public Vitals[] allVitals;
        public VitalsCollection(int n_vitals)
        {
            allVitals = new Vitals[n_vitals];
        }
        public void Initialize()
        {
            for (int i = 0; i < allVitals.Length; i++)
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
            Vitals one_vital = new Vitals();
            one_vital.setName("Test1");
            one_vital.setValue(30);
            one_vital.setLower(25);
            one_vital.setUpper(50);
            v_collection.Initialize();
            v_collection.UpdateVitals();
            VitalsMonitor v_monitor = new VitalsMonitor();
            AlertInSMS alertSMS = new AlertInSMS();
            AlertInIntercom alertIntercom = new AlertInIntercom();


            //Testing VitalsAreNormal()
            Checker.ExpectTrue(v_monitor.VitalsAreNormal(alertSMS, v_collection));
            v_collection.UpdateVitals();
            Checker.ExpectFalse(v_monitor.VitalsAreNormal(alertIntercom, v_collection));
            v_collection.UpdateVitals();
            Checker.ExpectFalse(v_monitor.VitalsAreNormal(alertIntercom, v_collection));

            //Testing VitalIsNormal()
            Checker.ExpectTrue(v_monitor.VitalIsNormal(one_vital));
            one_vital.setValue(20);
            Checker.ExpectFalse(v_monitor.VitalIsNormal(one_vital));
            one_vital.setValue(56);
            Checker.ExpectFalse(v_monitor.VitalIsNormal(one_vital));
            Console.WriteLine("All ok");
        }
    }
}
