using Savanna.Core.Interfaces;
using Savanna.Core.Models;

namespace Savanna.Core.Services;

public class MovementService : IMovementService
{
    public void Move(Animal animal , Position destination , SavannaState state)
    {
        ArgumentNullException.ThrowIfNull(animal);
        ArgumentNullException.ThrowIfNull(destination);
        ArgumentNullException.ThrowIfNull(state);

        if (!state.Animals.Contains(animal))
        {
            throw new InvalidOperationException("The animal does not belong to this savanna.");
        }

        var isInsideField = destination.X >= 0 && destination.X < state.Width && destination.Y >= 0 && destination.Y < state.Height;

        if (!isInsideField)
        {
            throw new ArgumentOutOfRangeException(nameof(destination) , "The destination is outside the savanna.");
        }

        var isOccupied = state.Animals.Any(other => other != animal && other.Position == destination);

        if (isOccupied)
        {
            throw new InvalidOperationException("The destination is already occupied.");
        }

        animal.MoveTo(destination);
    }
}
