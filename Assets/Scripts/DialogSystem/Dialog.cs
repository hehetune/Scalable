using System;
using System.Collections.Generic;
using Input;
using UnityEngine;

namespace DialogSystem
{
    [Serializable]
    public class DialogMessages
    {
        public List<string> messages;
    }
    public abstract class Dialog : MonoBehaviour
    {
        // private const float INTERACT_DISTANCE = 5f;
        public abstract void Interact();

        private Transform _playerTransform;

        public List<DialogMessages> dialogs = new();

        private void OnEnable()
        {
            GameInput.Instance.OnJumpAction += OnContinueDialog;
        }

        private void OnDisable()
        {
            GameInput.Instance.OnJumpAction -= OnContinueDialog;
        }

        private void OnContinueDialog(object o, EventArgs e)
        {
            Interact();
        }
        
        private void OnTriggerEnter(Collider other)
        {
            
        }

        // private bool IsWithinInteractDistance()
        // {
        //     return Vector3.Distance(_playerTransform.position, transform.position) < INTERACT_DISTANCE;
        // }
    }
}