using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Grass");
        if(other.CompareTag("Player")){
            float randNum = Random.Range(0,500);

            if(randNum <= 10){
                Debug.Log("Encounter");
            }
        }
    }
}
