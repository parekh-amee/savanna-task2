using Savanna.Core.Interfaces;
using Savanna.Core.Models;

namespace Savanna.Core.Services;

public class SimulationService : ISimulationService
{
    private readonly IMovementService _movementService;
    private readonly Dictionary<Savanna.Core.Enums.AnimalType , IAnimalBehavior>
        _behaviors;

    public SimulationService(IMovementService movementService , IEnumerable<IAnimalBehavior> behaviors)
    {
        _movementService = movementService;
        _behaviors = behaviors.ToDictionary(behavior => behavior.AnimalType);
    }

    public void RunRound(SavannaState state)
    {
        ArgumentNullException.ThrowIfNull(state);

        var animals = state.Animals.ToList();

        foreach (var animal in animals)
        {
            // The animal may have been eaten earlier in this round.
            if (!state.Animals.Contains(animal))
            {
                continue;
            }

            if (!_behaviors.TryGetValue(animal.Type , out var behavior))
            {
                throw new InvalidOperationException($"No behaviour registered for {animal.Type}.");
            }

            var nextPosition = behavior.GetNextPosition(animal , state);

            _movementService.Move(animal , nextPosition , state);

            behavior.PerformAction(animal , state);
        }
    }
}
