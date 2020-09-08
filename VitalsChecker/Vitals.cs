using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VitalsChecker
{
    public class Vitals
    {
		string vitalName;
		float vitalValue, lower, upper;
		internal Vitals() {
			this.vitalName = "";
			this.vitalValue = 0;
			this.lower = 0;
			this.upper = 0;
		}
		internal Vitals(string name , float lower , float upper) {
			this.vitalName =name;
			this.vitalValue = 0;
			this.lower = lower;
			this.upper = upper;
		}
		internal void setName(string name) {
			this.vitalName = name;
		}
		internal void setValue(float value) {
			this.vitalValue = value;
		}
		internal void setLower(float lower) {
			this.lower = lower;
		}
		internal void setUpper(float upper) {
			this.upper = upper;
		}
		internal string getName() {
			return this.vitalName;
		}
		internal float getValue() { 
			return this.vitalValue;
		}
		internal float getLower() {
			return this.lower;
		}
		internal float getUpper() {
			return this.upper;
		}
		internal void Initialize() {
			string name;
			name = Console.ReadLine();
			float lower = Single.Parse(Console.ReadLine());
			float upper = Single.Parse(Console.ReadLine());
			this.vitalName = name;
			this.lower = lower;
			this.upper = upper;
		}
	}
}
