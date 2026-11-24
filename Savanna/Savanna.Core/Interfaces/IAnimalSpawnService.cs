using Savanna.Core.Models;
using Savanna.Core.Enums;

namespace Savanna.Core.Interfaces;

public interface IAnimalSpawnService
{
    Animal Spawn(AnimalType animalType , SavannaState state);
}