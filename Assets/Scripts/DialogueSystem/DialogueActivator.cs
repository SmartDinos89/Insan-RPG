using UnityEngine;
using TMPro;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private TMP_Text text;
    [SerializeField] private string interactDialogue;

    private void Awake() {
        text.text = string.Empty;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && 
        other.TryGetComponent(out PlayerController playerController)){
            playerController.Interactable = this;
            if(interactDialogue != null)
            text.text = interactDialogue;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && 
        other.TryGetComponent(out PlayerController playerController)){
            if(playerController.Interactable is DialogueActivator dialogueActivator
             && dialogueActivator == this){
                 playerController.Interactable = null;
                 if(text.text != string.Empty)
                 text.text = string.Empty;
             }
        }
    }
    public void Interact(PlayerController playerController)
    {
        playerController.DialogueUi.npc = gameObject;
        text.text = string.Empty;
        playerController.DialogueUi.ShowDialogue(dialogueObject);
    }
}

