using Savanna.Core.Enums;
using Savanna.Core.Interfaces;
using Savanna.Core.Models;

namespace Savanna.Core.Behaviors;

public class AntelopeBehavior : IAnimalBehavior
{
    public AnimalType AnimalType => AnimalType.Antelope;

    public Position GetNextPosition(Animal animal , SavannaState state)
    {
        var availablePositions = BehaviorHelper.GetAvailableNeighbours(animal , state);

        if (availablePositions.Count == 0)
        {
            return animal.Position;
        }

        var visibleLions = state.Animals.Where(other => other.Type == AnimalType.Lion).Where(lion => BehaviorHelper.Distance(animal.Position , lion.Position) <= animal.VisionRange).ToList();

        if (visibleLions.Count == 0)
        {
            return availablePositions[0];
        }

        return availablePositions.OrderByDescending(position => visibleLions.Min(lion => BehaviorHelper.Distance(position , lion.Position))).First();
    }

    public void PerformAction(Animal animal , SavannaState state)
    {
        // Antelopes have no special action in Iteration 1.
    }
}
