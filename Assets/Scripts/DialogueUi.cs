using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueUi : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    private TypewritterEffect typewritterEffect;
    private void Start()
    {
        typewritterEffect = GetComponent<TypewritterEffect>();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        StartCoroutine(StepThroughDialogue(dialogueObject));
    }

    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject){

        foreach (string dialogue in dialogueObject.Dialogue)
        {
            yield return typewritterEffect.Run(dialogue, text);
            yield return new WaitUntil(() => Input.GetButtonDown("Submit"));
        }

    }

}
