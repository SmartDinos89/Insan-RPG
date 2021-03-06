using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private string NPC_name;
    [SerializeField] private Sprite portrait;

    public string[] Dialogue => dialogue;
    public string NPC_Name => NPC_name;
    public Sprite Portrait => portrait;

}
