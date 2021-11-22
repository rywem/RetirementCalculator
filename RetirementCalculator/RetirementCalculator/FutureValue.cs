using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementCalculator
{
    public static class FutureValue
    {
        public static decimal Calculate(decimal startingBalance, decimal periodInvestment, decimal periodInterestRate, int periods)
        {
            decimal futureValue = startingBalance;
            for (int i = 0; i < periods; i++)
            {
                futureValue = (futureValue + periodInvestment) * (1 + periodInterestRate);
            }

            return futureValue;
        }
    }
}
