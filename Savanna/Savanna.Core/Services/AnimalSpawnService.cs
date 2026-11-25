using Savanna.Core.Enums;
using Savanna.Core.Interfaces;
using Savanna.Core.Models;

namespace Savanna.Core.Services;

public class AnimalSpawnService : IAnimalSpawnService
{
    private const int AntelopeVisionRange = 3;
    private const int LionVisionRange = 4;

    private const int AntelopeSpeed = 2;
    private const int LionSpeed = 2;

    public Animal Spawn(AnimalType animalType , SavannaState state)
    {
        ArgumentNullException.ThrowIfNull(state);

        var availablePositions = new List<Position>();

        for (var x = 0; x < state.Width; x++)
        {
            for (var y = 0; y < state.Height; y++)
            {
                var position = new Position(x , y);

                var isOccupied = state.Animals.Any(animal => animal.Position == position);

                if (!isOccupied)
                {
                    availablePositions.Add(position);
                }
            }
        }

        if (availablePositions.Count == 0)
        {
            throw new InvalidOperationException("There are no available positions in the savanna.");
        }

        var (visionRange , speed) = animalType switch
        {
            AnimalType.Antelope => (AntelopeVisionRange , AntelopeSpeed),
            AnimalType.Lion => (LionVisionRange , LionSpeed),
            _ => throw new ArgumentOutOfRangeException(nameof(animalType))
        };

        var randomIndex = Random.Shared.Next(availablePositions.Count);

        var animal = new Animal(animalType ,availablePositions[randomIndex] ,visionRange ,speed);

        state.Animals.Add(animal);

        return animal;
    }
}
