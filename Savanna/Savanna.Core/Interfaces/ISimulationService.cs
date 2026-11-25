using Savanna.Core.Models;

namespace Savanna.Core.Interfaces;

public interface ISimulationService
{
    void RunRound(SavannaState state);
}