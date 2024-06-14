public class MiniGame
{
    public static void Main(string[] args)
    {
        Random random= new Random();
        int choose;
        int number;

        choose = int.Parse(args[0]);
        number = random.Next(1, 10);


        while (choose != number)
        {
            Console.WriteLine("Choose your number");
            if (choose > number)
            {
                Console.WriteLine("Hit");
            }
            
        }
    }
}