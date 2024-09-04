using UnityEngine;

namespace GravityManipulationPuzzle
{
    public interface IGravityDirectionProvider
    {
        Vector3 GravityDirection { get; }
    }
}