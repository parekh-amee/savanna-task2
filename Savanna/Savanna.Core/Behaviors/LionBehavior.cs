using Savanna.Core.Enums;
using Savanna.Core.Interfaces;
using Savanna.Core.Models;

namespace Savanna.Core.Behaviors;

public class LionBehavior : IAnimalBehavior
{
    public AnimalType AnimalType => AnimalType.Lion;

    public Position GetNextPosition(Animal animal , SavannaState state)
    {
        var availablePositions = BehaviorHelper.GetAvailableNeighbours(animal , state);

        if (availablePositions.Count == 0)
        {
            return animal.Position;
        }

        var visibleAntelopes = state.Animals.Where(other => other.Type == AnimalType.Antelope).Where(antelope => BehaviorHelper.Distance(animal.Position , antelope.Position) <= animal.VisionRange).ToList();

        if (visibleAntelopes.Count == 0)
        {
            return availablePositions[0];
        }

        var nearestAntelope = visibleAntelopes.OrderBy(antelope => BehaviorHelper.Distance(animal.Position , antelope.Position)).First();

        if (BehaviorHelper.Distance(animal.Position , nearestAntelope.Position) <= 1)
        {
            return animal.Position;
        }

        return availablePositions.OrderBy(position => BehaviorHelper.Distance(position , nearestAntelope.Position)).First();
    }

    public void PerformAction(Animal animal , SavannaState state)
    {
        var antelope = state.Animals.Where(other => other.Type == AnimalType.Antelope).Where(other => BehaviorHelper.Distance(animal.Position , other.Position) <= 1).OrderBy(other => BehaviorHelper.Distance(animal.Position , other.Position)).FirstOrDefault();

        if (antelope != null)
        {
            state.Animals.Remove(antelope);
        }
    }
}
