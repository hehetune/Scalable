using System;
using GameCore;
using UnityEngine;

namespace Character
{
    [RequireComponent(typeof(CharacterController))]
    public class CharacterMovement : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public float rotationSpeed = 10f;
        public float acceleration = 5f;
        public float deceleration = 5f;
        public float jumpForce = 5f;
        public float gravity = -9.81f;
        public float fallGravityMultiply = 2f;

        private CharacterController controller;
        private Vector3 velocity;
        private Vector3 targetDirection;
        private float currentSpeed = 0f;
        private bool isGrounded;

        private Vector2 moveInput => GameInput.Instance.CharacterMovement;
        private bool jumpPressed = false; 
        
        private void OnEnable()
        {
            GameInput.Instance.OnJumpAction += OnJumpEvent;
        }

        private void OnDisable()
        {
            GameInput.Instance.OnJumpAction -= OnJumpEvent;
        }

        void Start()
        {
            controller = GetComponent<CharacterController>();
        }

        void Update()
        {
            isGrounded = controller.isGrounded;

            // Calculate target direction
            targetDirection = new Vector3(moveInput.x, 0f, moveInput.y).normalized;

            // Acceleration and Deceleration
            if (targetDirection.magnitude >= 0.1f)
            {
                currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, acceleration * Time.deltaTime);

                // Rotate towards the target direction
                float targetAngle = Mathf.Atan2(targetDirection.x, targetDirection.z) * Mathf.Rad2Deg;
                float angle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, rotationSpeed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            else
            {
                currentSpeed = Mathf.Lerp(currentSpeed, 0f, deceleration * Time.deltaTime);
            }

            // Apply movement
            Vector3 move = targetDirection * currentSpeed;
            controller.Move(move * Time.deltaTime);

            // Handle jumping
            if (isGrounded && jumpPressed)
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
                jumpPressed = false;
            }

            // Apply gravity
            velocity.y += gravity * fallGravityMultiply * Time.deltaTime;

            // Apply vertical movement
            controller.Move(velocity * Time.deltaTime);

            // Reset velocity if grounded
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f; // Slightly negative to keep the character grounded
            }
        }
        
        private void OnJumpEvent(object sender, EventArgs e)
        {
            jumpPressed = true;
        }
    }
}