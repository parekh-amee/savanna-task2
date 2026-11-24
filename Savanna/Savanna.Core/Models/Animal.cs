using Savanna.Core.Enums;

namespace Savanna.Core.Models;

public class Animal
{
    public AnimalType Type { get; }
    public Position Position { get; private set; }
    public int VisionRange { get; }
    public int Speed { get; }

    public Animal(AnimalType type , Position position , int visionRange , int speed)
    {
        ArgumentNullException.ThrowIfNull(position);

        if (visionRange < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(visionRange));
        }

        if (speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed));
        }

        Type = type;
        Position = position;
        VisionRange = visionRange;
        Speed = speed;
    }

    public void MoveTo(Position newPosition)
    {
        ArgumentNullException.ThrowIfNull(newPosition);
        Position = newPosition;
    }
}
