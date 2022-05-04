using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypewritterEffect : MonoBehaviour
{
    [SerializeField]private float writeSpeed = 50;

    private readonly Dictionary<HashSet<char>, float> punctuations = new Dictionary<HashSet<char>, float>()
    {
        {new HashSet<char>() {'.', '!', '?' }, 0.6f },
        {new HashSet<char>() {',', ';', ':' }, 0.3f },
    };

    public bool isRunning { get; private set; }

    private Coroutine typingCoroutine;

    public void Run(string textToType, TMP_Text textLable){
       typingCoroutine =  StartCoroutine(TypeText(textToType, textLable));
    }
    
    public void Stop()
    {
        StopCoroutine(typingCoroutine);
        isRunning = false;
    }

    private IEnumerator TypeText(string textToType, TMP_Text textLable){

        isRunning = true;
        textLable.text = string.Empty;


        yield return new WaitForSeconds(.1f);
        float t = 0;
        int characterIndex = 0;

        while(characterIndex < textToType.Length){

            int lastCharIndex = characterIndex;


            t+=Time.deltaTime;
            characterIndex = Mathf.FloorToInt(t * writeSpeed);
            characterIndex = Mathf.Clamp(characterIndex, 0, textToType.Length);

            for (int i = lastCharIndex; i < characterIndex; i++)
            {
                bool isLast = i >= textToType.Length - 1;

                textLable.text = textToType.Substring(0, i + 1);


                if (isPunctuation(textToType[i], out float waitTime) && !isLast && isPunctuation(textToType[i + 1], out _))
                {
                    yield return new WaitForSeconds(waitTime);
                }
            }

            yield return null;
        }

        isRunning = false;
    }

    private bool isPunctuation(char character, out float waitTime)
    {
        foreach (KeyValuePair<HashSet<char>, float> punctuationCatagories in punctuations)
        {
            if (punctuationCatagories.Key.Contains(character))
            {
                waitTime = punctuationCatagories.Value;
                return true;
            }
        }

        waitTime = default;
        return false;
    }
}
