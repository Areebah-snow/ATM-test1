
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM
{
    public class Account
    {

        String firstName;
        String lastName;
        int PIN;
        double balance;
        String cardNumber;


        //Generate  a constructor to instantiate your data members
        public Account(int PIN, String firstName, String lastName, double balance, String cardNumber)
        {
            this.PIN = PIN;
            this.firstName = firstName;
            this.lastName = lastName;
            this.balance = balance;
            this.cardNumber = cardNumber;
        }

        //Getters of classmembers
        public String getfirstName()
        {
            return firstName;
        }
        public String getlastName()
        {
            return lastName;
        }
        public String getcardNum()
        {
            return cardNumber;
        }
        public int getPin()
        {
            return PIN;
        }
        public double getbalance()
        {
            return balance;
        }

        //Setters of class members

        public void setPin(int newpin)
        {
            PIN = newpin;
        }
        public void setFirstName(String newfirstname)
        {
            firstName = newfirstname;
        }
        public void setLastName(String newlastname)
        {
            lastName = newlastname;
        }

        public void setcardNum(String newcardNum)
        {
            cardNumber = newcardNum;
        }

        public void setbalance(double newbalance)
        {
            balance = newbalance;
        }


        static void Main(string[] args)
        {

           
            //Create a method to print options once you are at the ATM
            void displayOptions()
            {
                
                Console.WriteLine("Please select from the following options");
                Console.WriteLine("1. Withdrawal");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Check Balanace");
                Console.WriteLine("4. Change PIN");
                Console.WriteLine("5. Exit");

            }
            //Deposit method:  adds to your existing acct
             void deposit(Account currentUser)
            {
                Console.WriteLine("Please input the amount you wish to deposit into your account");
                double deposit = double.Parse(Console.ReadLine());
                currentUser.setbalance(deposit);
                Console.WriteLine("Deposit Successful!");
                Console.WriteLine("You currently have ${0} in your account", currentUser.getbalance());
            }

            //Withdraw method : substracts from balance of your existing account
            void withdrawal(Account currentUser)
            {
                Console.WriteLine("How much would you like to withdraw?");
                double withdrawal = Double.Parse(Console.ReadLine());

                //Condition to determine if user has enough $$ in account

                if(currentUser.getbalance() < withdrawal)
                {
                    Console.WriteLine("Insufficient Balance");

                }
                else
                {
                    //Creates a variable newbalance to deduct withdrawal amount from getter balance
                    double newbalance = currentUser.getbalance() - withdrawal;

                    //sets balance to newbalance
                    currentUser.setbalance(newbalance);
                    Console.WriteLine("Withdrawal Successful");
                }

            }

            //Balance method
            void Balance(Account currentUser)
            {
                Console.WriteLine("Current Balance:" + currentUser.getbalance());
            }

            //List of existing accounts registered into the bank

           List<Account> accounts = new List<Account>();

            //To understand the sequence check line 22
            accounts.Add(new Account(1234, "Arial", "Helivet", 100.52, "0056365378"));
            accounts.Add(new Account(2367, "Geoerge", "Tuka", 450.00, "0056234565"));
            accounts.Add(new Account(8766, "John", "Doe", 150.43, "0056345634"));
            accounts.Add(new Account(0876, "Tola", "Temitayo", 200.00, "0056332457"));
            accounts.Add(new Account(9980, "Hameed", "Grinch", 50.12, "0056975432"));
            
            //Prompts user
            Console.WriteLine("Welcome to Maple bank");
            Console.WriteLine("Please input your card number");
            String debitCardNum = "";
            Account currentUser;

            
            while(true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();

                    //Checks if the number inputted exists in our list
                    currentUser = accounts.FirstOrDefault(n => n.cardNumber == debitCardNum);
                    if(currentUser != null){break;}
                    else
                    {
                        Console.WriteLine("Card not recognized! Please check number and try again");
                    }
                }
                catch
                {
                    Console.WriteLine("Card not recognized! Please check number and try again");
                }

            }

            Console.WriteLine("Please enter PIN");
            int userPin=0;
            while(true)
            {
                try
                {
                    userPin = Convert.ToInt32(Console.ReadLine()); 
                   
                    if (currentUser.getPin() == userPin){ break; }
                    else
                    {
                        Console.WriteLine("PIN Incorrect");
                    }
                }
                catch
                {
                    Console.WriteLine("PIN Incorrect");
                }

            }

            Console.WriteLine("Welcome" + currentUser.getfirstName() + " " + currentUser.getlastName());
            int options = 0;
            do
            {
                displayOptions();
                try
                {
                    options = Convert.ToInt32(Console.ReadLine());
                    
                }
                catch { }
                if (options == 1)
                {
                    withdrawal(currentUser);
                    
                 }
                else if(options == 2) { deposit(currentUser); }
                else if(options == 3) { Balance(currentUser); }
                else if(options == 4 || options == 5) { break; }
                else { options = 0; }

                
            } while (options != 5);
            Console.WriteLine("Thank you! Have a nice day.");

            
        }
    }
}