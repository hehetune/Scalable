using System;
using UnityCommunity.UnitySingleton;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class GameInput : MonoSingleton<GameInput>
    {
        private static bool firsttimecallInstance = true;
        public event EventHandler OnInteractAction;
        public event EventHandler OnPauseAction;

        public event EventHandler OnJumpAction;
        public Vector2 CharacterMovement => playerInputActions.GameInput.Move.ReadValue<Vector2>();
        private PlayerInputActions playerInputActions;

        private void Awake()
        {
            playerInputActions = new PlayerInputActions();
            playerInputActions.GameInput.Enable();
            playerInputActions.GameInput.Pause.performed += Pause_performed;
            playerInputActions.GameInput.Jump.performed += Jump_performed;
        }

        private void OnDestroy()
        {
            if (playerInputActions != null)
            {
                playerInputActions.GameInput.Pause.performed -= Pause_performed;
                playerInputActions.GameInput.Jump.performed -= Jump_performed;
                playerInputActions.Dispose();
            }
        }

        public void DisableGameInput()
        {
            playerInputActions.GameInput.Disable();
        }

        private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnPauseAction?.Invoke(this, EventArgs.Empty);
        }

        private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            OnJumpAction?.Invoke(this, EventArgs.Empty);
        }
    }
}