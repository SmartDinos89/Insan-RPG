using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]private HealthManager player;
    [SerializeField]bool doesHeal;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            player = other.GetComponent<HealthManager>();

            if(player.currentHealth < player.maxHealth){
               player.Heal(1);
               Destroy(gameObject);
            }
            
        }
    }
}
