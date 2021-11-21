// See https://aka.ms/new-console-template for more information
using RetirementCalculator;

Console.WriteLine("Retirement Calculator");


Console.WriteLine("Enter Current retirement balance: (ex: 40000)");
string? startingBalanceString = Console.ReadLine();
decimal startingBalance = Convert.ToDecimal(startingBalanceString);

Console.WriteLine("Enter Current Salary: (ex: 100000)");
string? currentSalaryString = Console.ReadLine();
decimal currentSalary = Convert.ToDecimal(currentSalaryString);

Console.WriteLine("Enter % contribution (ex: 0.15):");
string? contributionRateString = Console.ReadLine();
decimal contributionRate = Convert.ToDecimal(contributionRateString);


Console.WriteLine("Estimate percent average raises: (ex: 0.035)");
string? avgRaiseString = Console.ReadLine();
decimal avgRaise = Convert.ToDecimal(avgRaiseString);

Console.WriteLine("Years until Retirement: (ex: 30)");
string? yearsTillRetireString = Console.ReadLine();
int yearsTillRetire = Convert.ToInt32(yearsTillRetireString);

Console.WriteLine("Estimate market growth rate / yr: (ex: 0.08)");
string? estimateMarketGrowthString = Console.ReadLine();
decimal estimateMarketGrowth = Convert.ToDecimal(estimateMarketGrowthString);

Console.WriteLine("Number of Paychecks / yr (ex: 26)");
string? numberOfPaychecksString = Console.ReadLine();
int numberOfPaychecks = Convert.ToInt32(numberOfPaychecksString);


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
