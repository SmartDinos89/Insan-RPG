using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUi : MonoBehaviour
{
    [SerializeField]private GameObject dialogueBox;
    [SerializeField]private TMP_Text nameText;
    [SerializeField]private TMP_Text text;

    public bool isOpen {get; private set;}

    
    private ResponseHandler responseHandler;
    private TypewritterEffect typewritterEffect;
    private void Start()
    {
        responseHandler = GetComponent<ResponseHandler>();
        typewritterEffect = GetComponent<TypewritterEffect>();
        CloseDialogueBox();

    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        isOpen = true;
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){
        nameText.text = dialogueObject.NPC_Name;
        
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return typewritterEffect.Run(dialogue, text);

            if(i == dialogueObject.Dialogue.Length -1 && dialogueObject.HasResponses) break;

            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        }

        if(dialogueObject.HasResponses){
            responseHandler.ShowResponses(dialogueObject.Responses);
        }
        else
        {
            CloseDialogueBox();
        }
    }

    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        text.text = string.Empty;
    }

}
