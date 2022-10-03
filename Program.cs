namespace CA221003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Fish fish = new(
                weight: 25F,
                predator: false,
                swimTop: 0,
                swimDepth: 0,
                species: null);

            Console.WriteLine(
                "A hal adatai:\n" +
                $"\tSúly: {fish.Weight} Kg");

            fish.Weight -= 2.5F;


            Console.WriteLine(
                "A hal adatai:\n" +
                $"\tSúly: {fish.Weight} Kg");
        }
    }
}