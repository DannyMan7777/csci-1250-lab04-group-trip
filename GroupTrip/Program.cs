/*
 ==============================================================================
 * Name: Daniel McKinney
 * Course: CSCI 1250, Section 002
 * Assignment: Lab 02, Trip Calculator
 * Date: September 22, 2026
 * Description: Calculates the fuel, food, and work hours behind one road trip.
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

System.Console.WriteLine("\n===== Part 1: The Trip =====");

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

/*
System.Console.WriteLine("\n  === FINAL RESULTS ===");
System.Console.WriteLine("Total trip cost: " + tripTotalCost.ToString("C"));
System.Console.WriteLine("Trip cost per person: " + tripIndividualCost.ToString("C"));
System.Console.WriteLine("Your hourly net pay: " + netHourlyPay.ToString("C"));
System.Console.WriteLine("Time you must work this week to cover your share (hh:mm): " + hoursNeededFormatted.ToString(@"hh\:mm"));
*/

//Methods

static double FuelCost(double tripMileage, double gasMileage, double gasPrice)
{
    double gallons = tripMileage / gasMileage;
    return gallons * gasPrice;
}

static double TakeHomePay(double hours, double hourlyRate, double taxRate)
{
    double grossPay = hours * hourlyRate;
    double taxWithheld = grossPay * TAX_RATE;
    return grossPay - taxWithheld;
}

static double HoursToCover(double individualCost, double netHourlyRate)
{
    return individualCost / netHourlyRate;
}

/*
Alternatively, to make HoursToCover look nicer:
static TimeSpan HoursToCover(double individualCost, double netHourlyRate)
{
    double unformattedHoursToCover = individualCost / netHourlyRate;
    TimeSpan hoursToCover = TimeSpan.FromHours(unformattedHoursToCover);
    return hoursToCover;
}
*/