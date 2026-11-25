using Savanna.Core.Behaviors;
using Savanna.Core.Enums;
using Savanna.Core.Interfaces;
using Savanna.Core.Models;
using Savanna.Core.Services;

namespace Savanna.Console;

internal class Program
{
    private static void Main(string[] args)
    {
        var state = new SavannaState(10 , 10);

        IMovementService movementService = new MovementService();

        IAnimalBehavior[] behaviors =
        {
            new AntelopeBehavior(),
            new LionBehavior()
        };

        ISimulationService simulationService = new SimulationService(movementService , behaviors);

        IAnimalSpawnService spawnService = new AnimalSpawnService();

        var renderer = new ConsoleRenderer();

        var isRunning = true;

        while (isRunning)
        {
            renderer.Render(state);

            var key = System.Console.ReadKey(true).Key;

            try
            {
                switch (key)
                {
                    case ConsoleKey.A:
                        spawnService.Spawn(AnimalType.Antelope , state);
                        break;

                    case ConsoleKey.L:
                        spawnService.Spawn(AnimalType.Lion , state);
                        break;

                    case ConsoleKey.Enter:
                        simulationService.RunRound(state);
                        break;

                    case ConsoleKey.Q:
                        isRunning = false;
                        break;
                }
            }
            catch (InvalidOperationException exception)
            {
                System.Console.WriteLine(exception.Message);
                System.Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey(true);
            }
        }

        System.Console.WriteLine("Savanna simulation finished.");
    }
}
