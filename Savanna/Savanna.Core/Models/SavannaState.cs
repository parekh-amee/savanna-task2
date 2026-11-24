namespace Savanna.Core.Models;

public class SavannaState
{
    public int Width { get; }
    public int Height { get; }
    public List<Animal> Animals { get; }

    public SavannaState(int width , int height)
    {
        if (width <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width));
        }

        if (height <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height));
        }

        Width = width;
        Height = height;
        Animals = new List<Animal>();
    }
}
