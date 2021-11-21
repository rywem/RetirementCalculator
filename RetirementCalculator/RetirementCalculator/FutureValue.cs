using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetirementCalculator
{
    public static class FutureValue
    {
        public static decimal Calculate(decimal startingBalance, decimal monthlyInvestment, decimal monthlyInterestRate, int periods)
        {
            decimal futureValue = startingBalance;
            for (int i = 0; i < periods; i++)
            {
                futureValue = (futureValue + monthlyInvestment) * (1 + monthlyInterestRate);
            }

            return futureValue;
        }
    }
}
