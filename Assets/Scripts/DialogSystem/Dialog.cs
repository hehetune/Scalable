using System;
using System.Collections.Generic;
using GameCore;
using UnityEngine;

namespace DialogSystem
{
    public class Dialog : MonoBehaviour
    {
        private Transform _playerTransform;

        public List<DialogText> dialogs = new();

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
            
        }
        
        private void OnTriggerEnter(Collider other)
        {
            Interact();
        }

        private void Interact()
        {
            
        }
    }
}