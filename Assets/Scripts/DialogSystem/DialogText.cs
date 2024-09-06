using UnityEngine;

namespace DialogSystem
{
    [CreateAssetMenu(menuName = "Dialog/Create DialogText")]
    public class DialogText : ScriptableObject
    {
        public string speakerName;
        [TextArea(5, 10)]
        public string[] paragraphs;
    }
}