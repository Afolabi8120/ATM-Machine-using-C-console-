using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_Machine
{
    class Program
    {
        /*
                        Developed by: AFOLABI TEMIDAYO TIMOTHY
         *This is a Bank like ATM Machine
         *You need to create an account first before you can have access to the system
         *After successful registration write down your account number and pin
         *A sum of #2000 will be automatically deposited into the account
         *The account number and pin is the one you will use for logging into the system
         *The account number is generated randomly which consist of ten digits
         *Thanks :)
         * */
        static string fname, lname, yob, gender, uOption;
        static int transaction_pin, new_pin, new_pin2, new_pin3, transaction_pin2, transaction_pin3, acct_number, login_acct_number, login_acct_pin;
        static decimal acct_balance;

        static void Main(string[] args)
        {
            var reg = new Program();
            reg.Start();

            
            Console.ReadKey();
        }

        void Start()
        {
            var reg = new Program();

            Begin:
            Console.WriteLine("Welcome To ATM Machine");
            Console.WriteLine("1) Login  \n2) Register  \n3) Exit");
            Console.WriteLine("Please enter an option!");
            string userOption = Console.ReadLine();

            switch (userOption)
            {
                case "1":
                    reg.Login();
                    break;
                case "2":
                    reg.Register();

                    gotoProceed:
                    Console.WriteLine("Proceed to Login: Y or N");
                    string newOption = Console.ReadLine().ToUpper();

                    switch (newOption)
                    {
                        case "Y":
                            Console.Clear();
                            reg.Start();
                            break;
                        case "N":
                            Console.WriteLine("Please press the enter key to exit!");
                            break;
                        default:
                            Console.WriteLine("Invalid option selected!");
                            goto gotoProceed;
                            break;
                    }
                    break;
                case "3":
                    Console.WriteLine("Please press the enter key to exit!");
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("You selected an invalid option!");
                    goto Begin;
            }
        }

        // Login Page 
        void Login()
        {
            beginLogin:
            Console.WriteLine("------------LOGIN PAGE!------------");
            Console.Write("Enter Your Account No: ");
            login_acct_number = int.Parse(Console.ReadLine());
            Console.Write("Enter Your Account Pin: ");
            login_acct_pin = int.Parse(Console.ReadLine());

            if ((login_acct_number == acct_number) && (login_acct_pin == transaction_pin))
            {
                var reg = new Program();
                reg.loginMenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Details Provided!");
                Console.ResetColor();
                goto beginLogin;
            }

        }

        // Login Menu Page 
        void loginMenu()
        {
            var reg = new Program();
            Welcome:
            Console.Clear();
            Console.WriteLine("------------MAIN MENU------------");
            Console.WriteLine("Welcome {0}, {1}", lname, fname);
            Console.Write("1) View Account Balance\n2) View Account Details\n3) Change Pin\n4) Logout\n ");
            Console.WriteLine("Select an option ");
            var userOp = Console.ReadLine();

            switch (userOp)
            {
                case "1":
                    Console.Clear();
                    reg.viewAccountBalance();
                    break;
                case "2":
                    Console.Clear();
                    reg.viewAccountDetails();
                    break;
                case "3":
                    Console.Clear();
                    reg.changePin();
                    break;
                case "4":
                    Console.Clear();
                    reg.Start();
                    break;
                default:
                    Console.WriteLine("Invalid option selected!");
                    goto Welcome;
            }

        }

        // View Account Balance
        void viewAccountBalance()
        {
            var date = DateTime.Now.ToLongDateString();
            var time = DateTime.Now.ToLongTimeString();
            Console.WriteLine("------------ACCOUNT DETAILS------------");
            Console.WriteLine("Your account balance as at {0} {1} is {2}", date, time, acct_balance);
            goToMenu:
            Console.WriteLine("Press B or b to go back to Homepage");
            string goBack = Console.ReadLine().ToUpper();
            switch (goBack)
            {
                case "B":
                    var reg = new Program();
                    reg.loginMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    goto goToMenu;
            }
        }

        // View Account Details
        void viewAccountDetails()
        {
            Console.WriteLine("------------ACCOUNT DETAILS------------");
            Console.WriteLine("Surname: {0}\nFirst Name: {1}\nDOB: {2}\nGender: {3}", lname, fname, yob, gender);
            goToMenu:
            Console.WriteLine("Press B or b to go back to Homepage");
            string goBack = Console.ReadLine().ToUpper();
            switch (goBack)
            {
                case "B":
                    var reg = new Program();
                    reg.loginMenu();
                    break;
                default:
                    Console.WriteLine("Invalid Option Selected");
                    goto goToMenu;
            }
        }

        // Change Pin
        void changePin()
        {
            getPin:
            Console.WriteLine("------------CHANGE PIN------------");
            Console.Write("Enter your old pin: ");
            new_pin = int.Parse(Console.ReadLine());
            Console.Write("Enter your new pin: ");
            new_pin2 = int.Parse(Console.ReadLine());
            Console.Write("Confirm your new pin: ");
            new_pin3 = int.Parse(Console.ReadLine());

            if (new_pin != transaction_pin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Old Pin is not correct!");
                Console.ResetColor();
                goto getPin;
            }
            else if (new_pin2 != new_pin3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pin do not Match!");
                Console.ResetColor();
                goto getPin;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Pin has been changed successfully");
                Console.ResetColor();
                transaction_pin = new_pin2;
                goToMenu:
                Console.WriteLine("Press B or b to go back to Homepage");
                string goBack = Console.ReadLine().ToUpper();
                switch (goBack)
                {
                    case "B":
                        var reg = new Program();
                        reg.loginMenu();
                        break;
                    default:
                        Console.WriteLine("Invalid Option Selected");
                        goto goToMenu;
                }
            }
        }

        // Registration Page
        void Register()
        {
            Console.WriteLine("------------REGISTRATION PAGE!------------");
            Console.WriteLine("Please enter all data's correctly\n");
            Console.Write("Enter your first name: ");
            fname = Console.ReadLine();
            Console.Write("Enter your surname: ");
            lname = Console.ReadLine().ToUpper();
            Console.Write("Enter your date of birth (e.g 1990-12-22) : ");
            yob = Console.ReadLine();

            getGender:
            Console.WriteLine("Select your gender: M or F ");
            gender = Console.ReadLine().ToUpper();

            switch (gender)
            {
                case "F":
                case "M":

                    break;
                default:
                    Console.WriteLine("You selected and invalid gender!");
                    goto getGender;
                    
            }
            getPin:
            Console.WriteLine("(N:B pin should not be less than or greater than 4 digits)\nSet transaction pin: ");
            transaction_pin = int.Parse(Console.ReadLine());
            Console.WriteLine("(Confirm transaction pin: ");
            transaction_pin2 = int.Parse(Console.ReadLine());

            if (transaction_pin != transaction_pin2) 
            {
                Console.WriteLine("Transaction Pin do not match");
                goto getPin;
            }

            UserSubmit:
            Console.WriteLine("(Submit Data : Y or N");
            uOption = Console.ReadLine().ToUpper();

            Random rand = new Random();
            int myRand = rand.Next(111111111, 999999999);
            acct_number = myRand;
            acct_balance = 2000;

            switch (uOption)
            {
                case "Y":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Account has been created successfully\n");
                    Console.ResetColor();
                    Console.WriteLine("Dear {0}, Your account number is: 0{1} and #{2} has been added to your account!", lname, acct_number, acct_balance.ToString("#,000.00"));
                    break;
                case "N":
                    Console.Clear();
                    var reg = new Program();
                    reg.Start();
                    break;
                default:
                    Console.WriteLine("Invalid details selected\n");
                    goto UserSubmit;
                    break;
            }
            

        }
    }
}
