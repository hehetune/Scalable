using System;
using UnityEngine;

namespace DialogSystem
{
    [Serializable]
    [CreateAssetMenu(menuName = "Dialog/Create DialogText")]
    public class DialogSO : ScriptableObject
    {
        public string speakerName;
        [TextArea(5, 10)]
        public string[] paragraphs;
    }
}