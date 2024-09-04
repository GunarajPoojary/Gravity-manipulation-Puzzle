using GravityManipulationPuzzle.InputActions;
using UnityEngine;

namespace GravityManipulationPuzzle
{
    /// <summary>
    /// Manages player input actions and provides access to input events.
    /// </summary>
    [DefaultExecutionOrder(-1)]
    public class PlayerInputs : MonoBehaviour
    {
        public PlayerInputActions InputActions { get; private set; }

        public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

        private void Awake()
        {
            InputActions = new PlayerInputActions();
            PlayerActions = InputActions.Player;
        }

        private void OnEnable() => InputActions.Enable();

        private void OnDisable() => InputActions.Disable();
    }
}