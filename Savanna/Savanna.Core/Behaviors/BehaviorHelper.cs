using Savanna.Core.Models;

namespace Savanna.Core.Behaviors;

internal static class BehaviorHelper
{
    public static int Distance(Position first , Position second)
    {
        return Math.Max(Math.Abs(first.X - second.X) , Math.Abs(first.Y - second.Y));
    }

    public static List<Position> GetAvailableNeighbours(Animal animal , SavannaState state)
    {
        var positions = new List<Position>();

        for (var x = -1; x <= 1; x++)
        {
            for (var y = -1; y <= 1; y++)
            {
                if (x == 0 && y == 0)
                {
                    continue;
                }

                var position = new Position(animal.Position.X + x , animal.Position.Y + y);

                var isInsideField = position.X >= 0 && position.X < state.Width && position.Y >= 0 && position.Y < state.Height;

                var isOccupied = state.Animals.Any(other => other != animal && other.Position == position);

                if (isInsideField && !isOccupied)
                {
                    positions.Add(position);
                }
            }
        }

        return positions;
    }
}
