// See https://aka.ms/new-console-template for more information
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
decimal fourPercentRule = .04m;
List<decimal> contributionRates = new List<decimal>();
decimal weightedExpense = 0.0m;
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
        bool addMore = true;
        for (int i = 0; i < yearsTillRetire; i++)
        {
            if (addMore == true)
            {
                Console.WriteLine($"Enter % contribution for year {i}. 15% enter: 0.15):");
                string? contributionRateString = Console.ReadLine();
                contributionRate = Convert.ToDecimal(contributionRateString);
                contributionRates.Add(contributionRate);

                while (true)
                {
                    try
                    {
                        Console.WriteLine("Add more years? Y/N");
                        string? response = Console.ReadLine();
                        if (response != null && response.ToLower() == "y")
                        {
                            addMore = true;
                            break;
                        }
                        else if(response != null && response.ToLower() == "n")
                        {
                            addMore = false;
                            break;
                        }
                        throw new Exception();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid response, try again");
                        continue;

                    }
                }
            }
            else
                contributionRates.Add(contributionRate);


        }        
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

while (true)
{
    try
    {
        Console.WriteLine("Enter weighted expense ratio: (ex: 0.06)");
        string? weightedExpenseString = Console.ReadLine();
        weightedExpense = Convert.ToDecimal(weightedExpenseString);
        break;
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred. Please try again.");
        continue;
    }
}


decimal currentValue = startingBalance;
decimal ratePerPeriod = estimateMarketGrowth / numberOfPaychecks;
decimal salary = currentSalary;

decimal runningExpenseTotal = 0.0m;
decimal expenseCompounded = 0.0m;
decimal currentValueWithFees = startingBalance;
for (int i = 0; i < yearsTillRetire; i++)
{
    decimal contributionPerPeriod = 0;
        
    contributionPerPeriod = (salary * contributionRates[i]) / numberOfPaychecks;
    currentValue = FutureValue.Calculate(currentValue, contributionPerPeriod, ratePerPeriod, numberOfPaychecks);


    currentValueWithFees = FutureValue.Calculate(currentValueWithFees, contributionPerPeriod, ratePerPeriod, numberOfPaychecks);
    decimal currentExpense = currentValueWithFees * (weightedExpense * 0.01m);
    currentValueWithFees -= currentExpense;


    Console.WriteLine($"Salary: {salary.ToString("c")} ||| FV in {i + 1} years: {currentValue.ToString("c")}");
    salary = salary * (1 + avgRaise);

}

Console.WriteLine("********");
Console.WriteLine($"Estimated Retirement: {currentValue.ToString("c")}");
var presentValue = PresentValue.Calculate(inflation, currentValue, yearsTillRetire);
Console.WriteLine($"Retirement amount in today's dollars: {presentValue.ToString("c")}");
Console.WriteLine($"4% rule amount: {(presentValue * fourPercentRule).ToString("c")}");


Console.WriteLine($"Estimated Retirement with Fees: {currentValueWithFees.ToString("c")}");
var presentValueWithFees = PresentValue.Calculate(inflation, currentValueWithFees, yearsTillRetire);
Console.WriteLine($"Retirement amount in today's dollars: {presentValueWithFees.ToString("c")}");
Console.WriteLine($"4% rule amount with fees: {(presentValueWithFees * fourPercentRule).ToString("c")}");

Console.WriteLine($"401k Balance Difference with fees: {(currentValue - currentValueWithFees).ToString("c")}");

Console.WriteLine("Press 'enter' key to terminate program");
Console.ReadLine();