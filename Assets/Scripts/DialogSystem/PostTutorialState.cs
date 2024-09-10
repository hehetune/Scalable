using UnityEngine;

namespace DialogSystem
{
    public class PostTutorialState : MonoBehaviour, INpcState
    {
        private Npc _npc;
        [SerializeField] private DialogSO dialogSo;
        [SerializeField] private ChatBubble _chatBubble;

        private void Awake()
        {
            _npc = GetComponent<Npc>();
        }

        public void HandleInteraction()
        {
            // Logic to show small chat box
            Debug.Log("Showing chat box above the player...");
            _chatBubble.AddMessage(this.dialogSo.paragraphs);
        }
    }
}