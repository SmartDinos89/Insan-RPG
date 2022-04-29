using UnityEngine;
using TMPro;

public class DialogueUi : MonoBehaviour
{
    public TMP_Text text;

    public TextAsset json;

    private void Start()
    {
        text.text = json.text;
    }

}
