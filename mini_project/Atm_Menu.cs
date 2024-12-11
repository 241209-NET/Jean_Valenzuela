using System.Text.RegularExpressions;

class Atm_Menu
{
    public static bool Menu(Account account){

        string amountPattern= "[^0-9]";

        Regex regex = new Regex(amountPattern);

        Console.WriteLine($"\nWelcome {account.FirstName} {account.LastName} to Chase's ATM......\n"
                                + "1) Withdraw Revature Coins.\n"
                                + "2) Deposit Revature Coins.\n"
                                + "3) Check Balance.\n"
                                + "4) Exit ATM.\n");

                String choice_2 = Console.ReadLine()!;

                switch (choice_2)
                {
                    case "1":
                        Console.WriteLine("How many coins would you like to withdraw:");
                        string withdraw = Console.ReadLine()!;
                        if (regex.IsMatch(withdraw))
                        {
                            Console.WriteLine($"{withdraw} is not a valid amount");
                            return false;
                        }
                        else
                        {
                            account.Withdraw(Convert.ToInt64(withdraw));
                            return false;
                        }
                    case "2":
                        Console.WriteLine("How many coins would you like to Deposit:");
                        string deposit = Console.ReadLine()!;
                        if (regex.IsMatch(deposit))
                        {
                            Console.WriteLine($"{deposit} is not a valid amount");
                            return false;
                        }
                        else
                        {
                            account.Deposit(Convert.ToInt64(deposit));
                            return false;
                        }
                    case "3":
                        Console.WriteLine($"You currently have {account.Balance} coins\n\n");
                        return false;
                    case "4":
                        Console.WriteLine($"Have a good day {account.FirstName} {account.LastName}");
                        return true;
                    default:
                        Console.WriteLine("Invalid Option try Again\n\n");
                        return false;
                }

    }
}