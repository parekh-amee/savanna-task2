using Savanna.Core.Enums;
using Savanna.Core.Models;

namespace Savanna.Core.Interfaces;

public interface IAnimalBehavior
{
    AnimalType AnimalType { get; }
    Position GetNextPosition(Animal animal , SavannaState state);
    void PerformAction(Animal animal , SavannaState state);
}
