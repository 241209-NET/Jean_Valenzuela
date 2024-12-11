using System.Text.RegularExpressions;

namespace mini_project;
class Program
{
    static void Main(string[] args)
    {
        Account account = new Account(40000);
        bool keep = true;
        String pattern = "[^0-9]";

        Regex regex= new Regex(pattern);

        while (keep)
        {
            Console.WriteLine("\nWelcome to Revature's ATM......\n"
                                + "1) Withdraw Revature Coins.\n"
                                + "2) Deposit Revature Coins.\n"
                                + "3) Check Balance.\n"
                                + "4) Exit ATM.\n"
                                + "Enter a number:");

            String number = Console.ReadLine()!;

            switch (number)
            {
                case "1":
                    Console.WriteLine("How many coins would you like to withdraw:");
                    string withdraw = Console.ReadLine()!;
                    if (regex.IsMatch(withdraw)){
                        Console.WriteLine($"{withdraw} is not a valid amount");
                        break;
                    } else {
                        account.Withdraw(Convert.ToInt64(withdraw));
                        break;
                    }
                case "2":
                    Console.WriteLine("How many coins would you like to Deposit:");
                    string deposit = Console.ReadLine()!;
                    if (regex.IsMatch(deposit)){
                        Console.WriteLine($"{deposit} is not a valid amount");
                        break;
                    } else {
                        account.Deposit(Convert.ToInt64(deposit));
                        break;
                    }
                case "3":
                    Console.WriteLine($"You currently have {account.getBalance()} coins\n\n");
                    break;
                case "4":
                    Console.WriteLine("Have a good day");
                    keep = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option try Again\n\n");
                    break;
            }
        }
    }
}
