using System.Text.RegularExpressions;

class Atm_Start
{
    public static Account? StartScreen(List<Account> accounts)
    {
        Account? account = new();

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        string amountPattern = "[^0-9]";

        Regex amountRegex = new Regex(amountPattern);
        Regex emailRegex = new Regex(emailPattern);

        while (true)
        {
            Console.WriteLine("Welcome to Chase Create an Account or Sign In.....\n"
                                        + "1) Create an Account\n"
                                        + "2) Sign In\n"
                                        + "3) Exit\n");

            String choice_1 = Console.ReadLine()!;

            switch (choice_1)
            {
                case "1":
                    Console.WriteLine("Enter your First Name:");
                    account.FirstName = Console.ReadLine()!;

                    Console.WriteLine("Enter your Last Name:");
                    account.LastName = Console.ReadLine()!;

                    Console.WriteLine("Enter Username:");
                    account.Username = Console.ReadLine()!;

                    Console.WriteLine("Enter your Email Address:");
                    string email = Console.ReadLine()!;
                    if (emailRegex.IsMatch(email)){
                        account.EmailAddress = email;
                    }else{
                        Console.WriteLine("Invalid Email......");
                        break;
                    }

                    Console.WriteLine("Enter Money to deposit to account:");
                    string money = Console.ReadLine()!;
                    if (amountRegex.IsMatch(money)){
                        Console.WriteLine("Invalid Amount.....");
                        break;
                    }else{
                        account.Balance = Convert.ToInt64(money);
                    }

                    return account;
                case "2":
                    Console.WriteLine("Enter username:");
                    string username = Console.ReadLine()!;

                    foreach (Account account2 in accounts)
                    {
                        if (username == account2.Username)
                        {
                            return account2;
                        }
                    }
                    Console.WriteLine("Account not found");
                    break;

                case "3":
                    Console.WriteLine("Good Bye.");
                    account = null;
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            if (account == null){
                return null;
            }
        }
    }

}