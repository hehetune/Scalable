using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogSystem
{
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI npcNameText;
        [SerializeField] private TextMeshProUGUI dialogText;

        public void DisplayMessage(string text)
        {
            
        }

        public void OpenDialogUI(string speakerName)
        {
            npcNameText.text = speakerName;
            gameObject.SetActive(true);
        }

        public void CloseDialogUI()
        {
            gameObject.SetActive(false);
        }

    }
}