using UnityEngine.Events;
using UnityEngine;

public class NPCEvent : MonoBehaviour
{
    public UnityEvent whatToDo;
    public GameObject DeactivateParent;
    public void Deactivate()
    {
        transform.SetParent(DeactivateParent.transform);
    }
}
