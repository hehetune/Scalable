using System;
using System.Collections.Generic;
using System.Linq;
using GameCore;
using UnityCommunity.UnitySingleton;
using UnityEngine;

namespace DialogSystem
{
    public class Dialog : MonoSingleton<Dialog>
    {
        private Transform _playerTransform;

        private DialogSO _dialogSO;

        private int _currentMessageIndex = 0;

        [SerializeField] private DialogUI _dialogUI;

        private Action _onComplete;

        public void OpenDialog(DialogSO dialogSO, Action onComplete)
        {
            this._dialogSO = dialogSO;
            this._onComplete += onComplete;
            _dialogUI.OpenDialogUI(_dialogSO.speakerName);
            GameInput.Instance.OnJumpAction += OnContinueDialog;
            ShowNextMessage();
        }

        private void CloseDialog()
        {
            GameInput.Instance.OnJumpAction -= OnContinueDialog;
            _dialogUI.CloseDialogUI();
            this._onComplete = null;
        }

        private void OnContinueDialog(object o, EventArgs e)
        {
            ShowNextMessage();
        }

        private void ShowNextMessage()
        {
            if (_currentMessageIndex == _dialogSO.paragraphs.Length)
            {
                _onComplete?.Invoke();
                CloseDialog();
                return;
            }

            _currentMessageIndex++;
            _dialogUI.DisplayMessage(_dialogSO.paragraphs[_currentMessageIndex]);
        }
    }
}