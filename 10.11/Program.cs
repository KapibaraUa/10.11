using System;

namespace GarbageCollectionHw
{
    internal class Program
    {
        static void CreateObjectsForFinalizer()
        {
            Play play = new Play("Hamlet", "William Shakespeare", "Tragedy", 1603);
            play.ShowInfo();

            Shop shop = new Shop("Silpo", "Deribasivska 1", ShopType.Grocery);
            shop.ShowInfo();
        }

        static void Main(string[] args)
        {
            try
            {
                using (Play play1 = new Play("Forest Song", "Lesya Ukrainka", "Drama-feerie", 1911))
                {
                    Console.WriteLine(play1);
                }

                Console.WriteLine();

                Shop shop1 = new Shop("Zara", "Preobrazhenska 15", ShopType.Clothing);
                shop1.ShowInfo();
                shop1.Dispose();

                Console.WriteLine();

                using (Shop shop2 = new Shop("Intertop", "Rishelievska 20", ShopType.Footwear))
                {
                    Console.WriteLine(shop2);
                }

                Console.WriteLine();

                CreateObjectsForFinalizer();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}