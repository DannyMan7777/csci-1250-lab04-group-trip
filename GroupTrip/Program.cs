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

const int PIZZA_SLICES = 6;

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

int numberSlices = numberPizzas * PIZZA_SLICES;
double slicesPerPerson = numberSlices / 4;
int leftoverSlices = numberSlices % 4;
double pizzaCost = numberPizzas * pizzaPrice;

System.Console.WriteLine("Pizza cost: " + $"{pizzaCost:C}");

System.Console.WriteLine("Trip total: " + $"{(fuelCost + pizzaCost):C}");

/*
//Part 3: Paycheck

System.Console.WriteLine("\n  ============ Part 3: Paycheck ============");

System.Console.WriteLine("\n  ===== RESULTS =====");

System.Console.WriteLine("Your weekly gross pay: " + grossPay.ToString("C"));
System.Console.WriteLine("Taxes withheld weekly: " + taxWithheld.ToString("C"));
System.Console.WriteLine("Your weekly net pay: " + netPay.ToString("C"));

double individualCost = (fuelCost + pizzaCost) / names.Length;

System.Console.WriteLine("\n  === FINAL RESULTS ===");
System.Console.WriteLine("Total trip cost: " + tripTotalCost.ToString("C"));
System.Console.WriteLine("Trip cost per person: " + tripIndividualCost.ToString("C"));
System.Console.WriteLine("Your hourly net pay: " + netHourlyPay.ToString("C"));
System.Console.WriteLine("Time you must work this week to cover your share (hh:mm): " + hoursNeededFormatted.ToString(@"hh\:mm"));

//Methods
*/
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