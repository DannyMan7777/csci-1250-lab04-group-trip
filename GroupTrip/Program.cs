/*
 ==============================================================================
 * Name: Daniel McKinney
 * Course: CSCI 1250, Section 002
 * Assignment: Lab 02, Trip Calculator
 * Date: September 22, 2026
 * Description: Rebuilds the trip calculator with methods and arrays so it
 *              reports on a whole group instead of one person.
 ==============================================================================
 */

//Constants

const double TAX_RATE = 0.18;

const double PIZZA_SLICES = 8.0;

//Arrays

string[] names = { "Ada", "Grace", "Alan", "Katherine" };
double[] hoursWorked = { 22, 15, 30, 18 };
double[] hourlyRates = { 13.50, 16.00, 11.20, 14.80 };

//Part 1: The Trip

System.Console.WriteLine("  ============ Lab 4: Trip Calculator ============");

Console.Write("Enter the round trip mileage (no nondecimal values): ");
double tripMileage = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the vehicle's gas mileage (no nondecimal values): ");
double gasMileage = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the price of gas (no nondecimal values): ");
double gasPrice = Convert.ToDouble(Console.ReadLine());

Console.Write("Enter the number of pizzas to purchase (no nondecimal values): ");
int numberPizzas = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the price per pizza (no nondecimal values): ");
double pizzaPrice = Convert.ToDouble(Console.ReadLine());

System.Console.WriteLine("\n ===== Part 1: The Trip =====");

double fuelCost = FuelCost(tripMileage, gasMileage, gasPrice);

System.Console.WriteLine("Fuel Cost: " + $"{fuelCost:C}");

double numberSlices = numberPizzas * PIZZA_SLICES;
double slicesPerPerson = numberSlices / names.Length;
double pizzaCost = numberPizzas * pizzaPrice;

double tripCost = fuelCost + pizzaCost;
double individualCost = (fuelCost + pizzaCost) / names.Length;

System.Console.WriteLine("Pizza cost: " + $"{pizzaCost:C}");

System.Console.WriteLine("Trip total: " + $"{tripCost:C}");

//Part 2: The Group

System.Console.WriteLine("\n  ===== Part 2: The Group =====");

System.Console.WriteLine("People going: " + names.Length.ToString());
System.Console.WriteLine("Slices each: " + slicesPerPerson.ToString());
System.Console.WriteLine("Cost per person: " + (individualCost).ToString("C"));

//Part 3: The Report

double totalHours = 0;
double totalNetPay = 0;
double longestHoursToWork = 0;

System.Console.WriteLine("\n ===== Part 3: Who Works How Long =====");

for (int i = 0; i < names.Length; i++)
{
    double netPay = TakeHomePay(hoursWorked[i], hourlyRates[i], TAX_RATE);
    double netHourlyRate = netPay / hoursWorked[i];
    double hoursToWork = HoursToCover(individualCost, netHourlyRate);
    hoursToWork = Math.Round(hoursToWork, 2);
    Console.WriteLine($"{names[i]} takes home {netPay:C} for {hoursWorked[i]} hours of work, makes {netHourlyRate:C} hourly, and must work {hoursToWork} hours to cover their share.");
    totalHours += hoursWorked[i];
    totalNetPay += netPay;
    longestHoursToWork = Math.Max(longestHoursToWork, hoursToWork);
}
System.Console.WriteLine($"\nTotal hours worked: {totalHours}");
System.Console.WriteLine($"Total take home pay: {totalNetPay:C}");
System.Console.WriteLine($"Longest anyone must work: {longestHoursToWork}");

//Methods

static double FuelCost(double tripMileage, double gasMileage, double gasPrice)
{
    double gallons = tripMileage / gasMileage;
    return gallons * gasPrice;
}

static double TakeHomePay(double hoursWorked, double hourlyRate, double taxRate)
{
    double grossPay = hoursWorked * hourlyRate;
    double taxWithheld = grossPay * TAX_RATE;
    return grossPay - taxWithheld;
}

static double HoursToCover(double individualCost, double netHourlyRate)
{
    return individualCost / netHourlyRate;
}

/*
This is where I would show you how I would declare a TimeSpan for hoursToWork, what modifications I would make to which lines,
and how much nicer and more practical the result would be. However, it's late and I'm lazy. Hate to disappoint. Next time.
*/