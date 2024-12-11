namespace mini_project;
class Program
{
    static void Main(string[] args)
    {
        List<Account> accounts = new List<Account>();

        while (true)
        {

            Account account = Atm_Start.StartScreen(accounts)!;

            if (account == null){
                break;
            } else {
                accounts.Add(account);
            }
            
            while (true)
            {

                bool cont = Atm_Menu.Menu(account);

                if (cont) {
                    break;
                }

            }
        }
    }
}
