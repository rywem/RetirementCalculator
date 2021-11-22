using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementCalculator
{
    public static class PresentValue
    {
        public static decimal Calculate(decimal inflationRate, decimal futureValue, int years)
        {
            //decimal currentValue = (decimal)futureValue / (double)Math.Pow((double)(1+inflationRate)), (double)years);
            return (decimal)futureValue /(decimal)Math.Pow((double)(1 + inflationRate), (double)years);
        }
    }
}
