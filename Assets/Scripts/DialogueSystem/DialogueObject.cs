using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue/Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;
    [SerializeField] private string NPC_name;

    public bool HasResponses => Responses != null && Responses.Length > 0;
    public string[] Dialogue => dialogue;
    public string NPC_Name => NPC_name;
    public Response[] Responses => responses;
}
