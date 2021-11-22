﻿// See https://aka.ms/new-console-template for more information
using RetirementCalculator;

Console.WriteLine("Retirement Calculator");

decimal startingBalance = 0;
decimal currentSalary = 0;
decimal contributionRate = 0;
decimal avgRaise = 0;
int yearsTillRetire = 0;
decimal estimateMarketGrowth = 0;
int numberOfPaychecks = 0;
decimal inflation = 0;
while(true)
{
    try
    {
        Console.WriteLine("Enter Current retirement balance: (ex: 40000)");
        string? startingBalanceString = Console.ReadLine();
        startingBalance = Convert.ToDecimal(startingBalanceString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Enter Current Salary: (ex: 100000)");
        string? currentSalaryString = Console.ReadLine();
        currentSalary = Convert.ToDecimal(currentSalaryString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Enter % contribution (for 15% enter: 0.15):");
        string? contributionRateString = Console.ReadLine();
        contributionRate = Convert.ToDecimal(contributionRateString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Estimate percent average raises: (for 3.5%, enter: 0.035)");
        string? avgRaiseString = Console.ReadLine();
        avgRaise = Convert.ToDecimal(avgRaiseString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Years until Retirement: (ex: 30)");
        string? yearsTillRetireString = Console.ReadLine();
        yearsTillRetire = Convert.ToInt32(yearsTillRetireString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Estimate market growth rate / yr: (for 8%, enter: 0.08)");
        string? estimateMarketGrowthString = Console.ReadLine();
        estimateMarketGrowth = Convert.ToDecimal(estimateMarketGrowthString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}


while (true)
{
    try
    {
        Console.WriteLine("Number of Paychecks / yr (ex: 26)");
        string? numberOfPaychecksString = Console.ReadLine();
        numberOfPaychecks = Convert.ToInt32(numberOfPaychecksString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

while (true)
{
    try
    {
        Console.WriteLine("Estimate inflation: (for 2%, enter: 0.02)");
        string? inflationString = Console.ReadLine();
        inflation = Convert.ToDecimal(inflationString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine("An error occurred. Please try again.");
//        continue;
//    }
//}

decimal currentValue = startingBalance;
decimal ratePerPeriod = estimateMarketGrowth / numberOfPaychecks;
decimal salary = currentSalary;


for (int i = 0; i < yearsTillRetire; i++)
{
    decimal contributionPerPeriod = (salary * contributionRate) / numberOfPaychecks;
    currentValue = FutureValue.Calculate(currentValue, contributionPerPeriod, ratePerPeriod, numberOfPaychecks);
    Console.WriteLine($"Salary: {salary.ToString("c")} ||| FV in {i + 1} years: {currentValue.ToString("c")}");
    salary = salary * (1 + avgRaise);

}

Console.WriteLine("********");
Console.WriteLine($"Estimated Retirement: {currentValue.ToString("c")}");
var presentValue = PresentValue.Calculate(inflation, currentValue, yearsTillRetire);
Console.WriteLine($"Retirement amount in today's dollars: {presentValue.ToString("c")}");