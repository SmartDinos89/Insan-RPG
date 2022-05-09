using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private string NPC_name;

    public string[] Dialogue => dialogue;
    public string NPC_Name => NPC_name;
}
