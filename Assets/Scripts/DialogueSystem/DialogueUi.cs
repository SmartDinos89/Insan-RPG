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

            yield return RunTypingEffect(dialogue);
            text.text = dialogue;

            if (i == dialogueObject.Dialogue.Length -1 && dialogueObject.HasResponses) break;

            yield return null;
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

    private IEnumerator RunTypingEffect(string dialogue)
    {
        typewritterEffect.Run(dialogue, text);
        while (typewritterEffect.isRunning)
        {
            yield return null;

            if (Input.GetButtonDown("Submit")) { typewritterEffect.Stop();  }
        }
    }



    public void CloseDialogueBox()
    {
        isOpen = false;
        dialogueBox.SetActive(false);
        text.text = string.Empty;
    }

}
