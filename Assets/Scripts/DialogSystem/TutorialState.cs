using UnityEngine;

namespace DialogSystem
{
    public class TutorialState : MonoBehaviour, INpcState
    {
        private Npc _npc;
        [SerializeField] private DialogSO dialogSO;

        private void Awake()
        {
            _npc = GetComponent<Npc>();
        }

        public void HandleInteraction()
        {
            // Logic to show tutorial dialog
            Debug.Log("Showing tutorial dialog...");
            Dialog.Instance.OpenDialog(this.dialogSO, () => _npc.CompleteTutorial());
        }
    }
}