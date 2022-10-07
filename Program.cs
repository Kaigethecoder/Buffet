public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, welcome to our buffet!");
        int people = 0;
        bool buffet = true;
        while (buffet)
        {
            List<Guest> guests = new List<Guest>();
            bool validParty = false;
            while (validParty == false)
            {


                Console.WriteLine();
                Console.WriteLine("How many people are eating today?  (1-6)");
                string response = Console.ReadLine();
                try
                {
                    people = Int32.Parse(response);
                    if (people > 0 && people < 7)
                    {
                        validParty = true;
                        Console.WriteLine();
                        Console.WriteLine($"Great!  I'll take you {people} right this way.");
                    }
                    else
                    {
                        validParty = false;
                        Console.WriteLine();
                        Console.WriteLine("Sorry, we can only serve 1-6 people per party.");
                    }
                }
                catch (Exception ex)
                {
                    validParty = false;
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, I think I misunderstood your answer.");
                }

            }
            //Now we ask each guest their name and drink order
            for (int i = 0; i < people; i++)
            {
                var newGuest = new Guest();
                newGuest = newGuest.TakeOrder();
                guests.Add(newGuest);
            }
            bool validCheck = false;
            while (validCheck == false)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to split the check or altogether?");
                Console.WriteLine("Enter y for split or n for together.");
                string split = Console.ReadLine().ToUpper();
                if (split == "Y")
                {
                    validCheck = true;
                    guests[0].SplitCheck(guests);
                }
                else if (split == "N")
                {
                    validCheck = true;
                    Console.WriteLine();
                    Console.WriteLine($"The total is {guests[0].GetTotalBill(guests)}.");
                }
                else
                {
                    validCheck = false;
                    Console.WriteLine();
                    Console.WriteLine("Sorry, I didn't catch that.");
                }
            }
            bool validResponse = false;
            while (validResponse == false)
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to go again?");
                string eatAgain = Console.ReadLine().ToUpper();
                if (eatAgain == "Y")
                {
                    buffet = true;
                    validResponse = true;
                    Console.WriteLine();
                    Console.WriteLine("Great!");
                }
                else if (eatAgain == "N")
                {
                    buffet = false;
                    validResponse = true;
                    Console.WriteLine();
                    Console.WriteLine("Have a nice day!");
                }
                else
                {
                    validResponse = false;
                    Console.WriteLine();
                    Console.WriteLine("I'm sorry, I didn't catch that.");
                }
            }
        }
    }
    public class Guest
    {
        public string Name { get; set; }
        public string drinkChoice { get; set; }
        public decimal totalCost { get; set; }

        public Guest(string newName, string newDrinkChoice, decimal newTotalCost)
        {
            Name = newName;
            drinkChoice = newDrinkChoice;
            totalCost = newTotalCost;
        }
        public Guest()
        {

        }
        public void SplitCheck(List<Guest> guests)
        {
            Console.WriteLine();
            foreach(Guest guest in guests)
            {
                Console.WriteLine($"{guest.Name} owes {guest.totalCost}.");
            }
        }
        public decimal GetTotalBill(List<Guest> guests)
        {
            decimal totalBill = 0;
            foreach(Guest guest in guests)
            {
                totalBill += guest.totalCost;
            }
            return totalBill;
        }
        public decimal GetTotalCostOfGuest(string drink)
        {
            decimal totalCost = 0;
            if (drink.Equals("water", StringComparison.CurrentCultureIgnoreCase))
            {
                totalCost = 9.99M;
            }
            else if (drink.Equals("coffee", StringComparison.CurrentCultureIgnoreCase))
            {
                totalCost = 11.99M;
            }
            else
            {
                totalCost = 10.49M;
            }
            return totalCost;
        }
        public Guest TakeOrder() //maybe build on this and ask age. Kids eat free or for 3.99
        {
            bool validName = false;
            bool validDrink = false;
            var newGuest = new Guest();
            string guestName = "";
            string drinkChoice = "";
            while(validName == false)
            {
                Console.WriteLine();
                Console.WriteLine("What is your name?");
                guestName = Console.ReadLine();
                if (guestName == "")
                {
                    validName = false;
                    Console.WriteLine();
                    Console.WriteLine("Sorry, I didn't catch that.");
                }
                else
                {
                    validName = true;
                    newGuest.Name = guestName;
                }
            }
            if (validName == true)
            {
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("What would you like to drink?");
                    drinkChoice = Console.ReadLine();

                    if (drinkChoice.Equals("water", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine();
                        Console.WriteLine($"Okay {newGuest.Name}, one {newGuest.drinkChoice.ToLower()} for you.");
                    }
                    else if (drinkChoice.Equals("coffee", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine();
                        Console.WriteLine($"Okay {newGuest.Name}, one {newGuest.drinkChoice.ToLower()} for you.");
                    }
                    else if (drinkChoice.Equals("soda", StringComparison.CurrentCultureIgnoreCase))
                    {
                        validDrink = true;
                        newGuest.drinkChoice = drinkChoice;
                        Console.WriteLine();
                        Console.WriteLine($"Okay {newGuest.Name}, one {newGuest.drinkChoice.ToLower()} for you.");
                    }
                    else
                    {
                        validDrink = false;
                        Console.WriteLine();
                        Console.WriteLine("Sorry, we don't have that.  Your choices are water, coffee or self serve soda.");            
                    }
                    
                } while (validDrink == false);
            }
            newGuest.totalCost = newGuest.GetTotalCostOfGuest(newGuest.drinkChoice);
            return newGuest;
        }

    }
}