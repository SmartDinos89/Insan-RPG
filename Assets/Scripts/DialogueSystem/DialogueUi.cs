using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class DialogueUi : MonoBehaviour
{
    [SerializeField]private GameObject dialogueBox;

    [SerializeField]private Image portraitBox;

    [SerializeField]private TMP_Text nameText;
    [SerializeField]private TMP_Text text;

    public bool isOpen {get; private set;}

    
    private TypewritterEffect typewritterEffect;
    private void Start()
    {
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
        if(dialogueObject.Portrait == null){
            portraitBox.color = new Color(0,0,0,0);
        } else {
            portraitBox.color = new Color(255,255,255,255);
        }
        nameText.text = dialogueObject.NPC_Name;
        portraitBox.sprite = dialogueObject.Portrait;
        
        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];

            yield return RunTypingEffect(dialogue);
            text.text = dialogue;

            if (i == dialogueObject.Dialogue.Length) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        }
            CloseDialogueBox();
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
