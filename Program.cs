namespace CA221003
{
    internal class Program
    {
        static Random rnd = new();
        static string[] fishes = { "harcsa", "ponty", "keszeg", "kárász", "aranyhal", "kráken" };
        static List<Fish> fishList = new();
        static void Main()
        {
            ListaFeltoltese();
            //ListaKiirasas();
            //Feladatok();
            Emulacio(500);
            Console.WriteLine($"ragadozók száma a tóban: {fishList.Count(f => f.Predator)}");
            Console.WriteLine($"halak száma a tóban: {fishList.Count}");



            Console.ReadKey(true);
        }

        private static void Emulacio(int iteraciokSzama)
        {
            using StreamWriter sw = new(@"..\..\..\src\emu.log");

            for (int k = 0; k < iteraciokSzama; k++)
            {
                sw.WriteLine($"{k + 1}. iteráció:");

                int x = -1;
                int y = -1;
                while (x == y)
                {
                    x = rnd.Next(fishList.Count);
                    y = rnd.Next(fishList.Count);
                }

                if (fishList[x].Predator == fishList[y].Predator)
                {
                    sw.WriteLine("\ta két hal életmódja megegyezik:");
                    sw.WriteLine($"\t{GetFishInfo(fishList[x])}");
                    sw.WriteLine($"\t{GetFishInfo(fishList[y])}");
                }
                else
                {
                    Fish pFish = fishList[x].Predator ? fishList[x] : fishList[y];
                    Fish hFish = !fishList[x].Predator ? fishList[x] : fishList[y];
                    sw.WriteLine("\t=============táplálkozási szándék:=============");
                    sw.WriteLine("\tragadozó:");
                    sw.WriteLine($"\t{GetFishInfo(pFish)}");
                    sw.WriteLine("\tnövényevő:");
                    sw.WriteLine($"\t{GetFishInfo(hFish)}");

                    if (pFish.SwimTop <= hFish.SwimBottom && pFish.SwimBottom >= hFish.SwimTop)
                    {
                        fishList.Remove(hFish);
                        sw.WriteLine("\ta növényevő hal elpusztult");
                        if (pFish.Weight * 1.09f <= 40)
                        {
                            pFish.Weight *= 1.09f;
                            sw.WriteLine($"\ta ragadozó {pFish.Weight}Kg-ra hízott");
                        }
                        else
                        {
                            pFish.Weight = 40f;
                            sw.WriteLine($"\ta ragadozó súlya nem növelhető tovább (jelenleg {pFish.Weight}Kg");
                        }
                    }
                    else
                    {
                        sw.WriteLine("\ta két hal nem tud beúszni egymás zónájába");
                    }
                }
            }
        }

        static string GetFishInfo(Fish fish)
        {
            return
                $"{fish.Species,-8} " +
                $"{(fish.Predator ? "ragadozó" : "növényevő"),9} " +
                $"{fish.Weight,5:0.00}Kg " +
                $"[{fish.SwimTop,3}-{(fish.SwimTop + fish.SwimDepth),3}] cm";
        }

        static void Feladatok()
        {
            Console.WriteLine($"ragadozók száma: {fishList.Count(f => f.Predator)} db");
            Console.WriteLine($"legnagyobb súlyú hal súlya: {fishList.Max(f => f.Weight):0.00Kg}");
            Console.WriteLine($"halak száma 1.1m-en: {fishList.Count(f => f.SwimTop <= 110 && f.SwimTop + f.SwimDepth >= 110)} db");

        }
        static void ListaFeltoltese()
        {
            for (int i = 0; i < 100; i++)
            {
                fishList.Add(new Fish(
                    weight: rnd.Next(1, 81) / 2f,
                    predator: rnd.Next(100) >= 90,
                    swimTop: rnd.Next(401),
                    swimDepth: rnd.Next(10, 401),
                    species: fishes[rnd.Next(fishes.Length)]));
            }
        }
        static void ListaKiirasas()
        {
            Console.WriteLine("| fajta | életmód |  súly | úszási sáv |");
            Console.WriteLine("---------------------------------------");
            foreach (var fish in fishList)
            {
                Console.ForegroundColor = fish.Predator 
                    ? ConsoleColor.Red
                    : ConsoleColor.Green;

                //if (fish.SwimTop <= 110 && fish.SwimTop + fish.SwimDepth >= 110)
                //    Console.ForegroundColor = ConsoleColor.Blue;

                Console.WriteLine(GetFishInfo(fish));

                Console.ResetColor();
            }
        }
        static void Tesztek()
        {
            #region tesztelgetés
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
                $"\tSúly: {fish.Weight} Kg\n" +
                $"\tÉletforma: {(fish.Predator ? "ragadozó" : "növényevő")}");


            //fish.Predator = true;
            #endregion
            #region "Elvis operator"
            //<condition> ? <value if condition is True> : <value if condition is False>
            string predatorString = fish.Predator ? "ragadozó" : "növényevő";

            //ua. mint ez:
            if (fish.Predator == true)
            {
                predatorString = "ragadozó";
            }
            else
            {
                predatorString = "növényevő";
            }
            #endregion

        }
    }
}