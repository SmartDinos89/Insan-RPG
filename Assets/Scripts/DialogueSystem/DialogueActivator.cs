using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInteractable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void Awake() {
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && 
        other.TryGetComponent(out PlayerController playerController)){
            playerController.Interactable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") && 
        other.TryGetComponent(out PlayerController playerController)){
            if(playerController.Interactable is DialogueActivator dialogueActivator
             && dialogueActivator == this){
                 playerController.Interactable = null;
             }
        }
    }
    public void Interact(PlayerController playerController)
    {
        playerController.DialogueUi.ShowDialogue(dialogueObject);
    }
}

