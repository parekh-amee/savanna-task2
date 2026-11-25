using Savanna.Core.Models;

namespace Savanna.Core.Interfaces;

public interface IMovementService
{
    void Move(Animal animal , Position destination , SavannaState state);
}