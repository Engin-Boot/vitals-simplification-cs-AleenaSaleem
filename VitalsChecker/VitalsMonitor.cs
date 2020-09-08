using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsChecker
{
    class VitalsMonitor
    {
        bool VitalIsNormal(Vitals one_vital,string message)
        {
            CultureInfo provider = new CultureInfo("en-us");
            bool status = true;
            if (one_vital.getValue()<one_vital.getLower())
            {
                message += one_vital.getName();
                message += " Very Low with value: ";
                message += one_vital.getValue().ToString(provider);
                message += "\n";
                status = false;
            }
            if(one_vital.getValue() > one_vital.getUpper())
            {
                message += one_vital.getName();
                message += " Very High with value: ";
                message += one_vital.getValue().ToString(provider);
                message += "\n";
                status = false;
            }
            return status;
        }
        void alertRequired(bool status, IAlert alertNow, string message)
        {
            if (!status)
            {
                alertNow.sendAlert(message);
            }
        }
        internal bool VitalsAreNormal(IAlert alertNow,VitalsCollection v_collection)
        {
            string message = "";
            int loopCounter = 0;
            bool status = true;
            for (loopCounter = 0; loopCounter < v_collection.allVitals.Length; loopCounter++)
            {
                bool new_status = VitalIsNormal(v_collection.allVitals[loopCounter],message);
                status = status && new_status;
            }
            alertRequired(status, alertNow, message);
            return status;
        }
        
    }
}
