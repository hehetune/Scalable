using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DialogSystem
{
    public class DialogUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI npcNameText;
        [SerializeField] private TextMeshProUGUI dialogText;

        private Queue<string> paragraphs = new();
        
        public void InitializeDialog(DialogText dialogText)
        {
            paragraphs.Clear();
            foreach (var msg in dialogText.paragraphs)
            {
                paragraphs.Enqueue(msg);
            }
        }
        
        
    }
}