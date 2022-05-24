using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBob : MonoBehaviour
{
float originalY;

[SerializeField]private float period = 3.0f;
[SerializeField]private float amp = .3f;

[SerializeField]private float phaseShift = .55f;

void Start ()
{
    this.originalY = this.transform.position.y;
}

void Update () {
    transform.position = new Vector2(transform.position.x, 
        originalY + ((amp * Mathf.Sin(Time.time * period)) + phaseShift));

}


private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(new Vector3(transform.position.x, this.originalY, transform.position.z), .5f);
    Gizmos.color = Color.blue;
    Gizmos.DrawWireSphere(transform.position, .5f);
}
}
