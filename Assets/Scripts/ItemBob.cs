using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBob : MonoBehaviour
{
float originalY;

public float floatStrength = 1;

void Start ()
{
    floatStrength = 1;
    this.originalY = this.transform.position.y;
}

void Update () {
    transform.position = new Vector2(transform.position.x, 
        originalY + (Mathf.Sin(Time.time) * floatStrength/2.25f));

}
}
