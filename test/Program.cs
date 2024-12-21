namespace test;

class Program
{
    static void Main(string[] args)
    {
        string hello = "Hello World!!";

        foreach (var c in hello)
        {
            //Converitng each letter to its integer value
            Console.WriteLine((int)c);
        }

        int letter = 32;

        Console.WriteLine((char)letter);
        
    }
}
