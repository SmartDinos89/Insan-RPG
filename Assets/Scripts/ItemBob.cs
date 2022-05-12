using UnityEngine;
using System.Collections;

public class ItemBob : MonoBehaviour
{
    public AnimationCurve myCurve;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, myCurve.Evaluate((Time.time % myCurve.length)), transform.position.z);
    }
}
