using Savanna.Core.Enums;
using Savanna.Core.Models;

namespace Savanna.Console;

public class ConsoleRenderer
{
    public void Render(SavannaState state)
    {
        System.Console.Clear();

        System.Console.WriteLine("========== SAVANNA ==========");
        System.Console.WriteLine();

        for (var y = 0; y < state.Height; y++)
        {
            for (var x = 0; x < state.Width; x++)
            {
                var animal = state.Animals.FirstOrDefault(animal => animal.Position == new Position(x , y));

                var symbol = animal?.Type switch
                {
                    AnimalType.Antelope => 'A',
                    AnimalType.Lion => 'L',
                    _ => '.'
                };

                System.Console.Write($"{symbol} ");
            }

            System.Console.WriteLine();
        }

        System.Console.WriteLine();
        System.Console.WriteLine($"Antelopes: {state.Animals.Count(a => a.Type == AnimalType.Antelope)}");
        System.Console.WriteLine($"Lions: {state.Animals.Count(a => a.Type == AnimalType.Lion)}");
        System.Console.WriteLine();
        System.Console.WriteLine("A - Add antelope");
        System.Console.WriteLine("L - Add lion");
        System.Console.WriteLine("Enter - Run one round");
        System.Console.WriteLine("Q - Quit");
    }
}