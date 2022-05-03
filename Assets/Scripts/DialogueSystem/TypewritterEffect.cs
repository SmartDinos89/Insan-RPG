using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewritterEffect : MonoBehaviour
{
    [SerializeField]private float writeSpeed = 50;
    public Coroutine Run(string textToType, TMP_Text textLable){
       return StartCoroutine(TypeText(textToType, textLable));
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLable){
        textLable.text = string.Empty;


        yield return new WaitForSeconds(.1f);
        float t = 0;
        int characterIndex = 0;

        while(characterIndex < textToType.Length){
            t+=Time.deltaTime;
            characterIndex = Mathf.FloorToInt(t * writeSpeed);
            characterIndex = Mathf.Clamp(characterIndex, 0, textToType.Length);

            textLable.text = textToType.Substring(0, characterIndex);

            yield return null;
        }

        textLable.text = textToType;
    }
}
