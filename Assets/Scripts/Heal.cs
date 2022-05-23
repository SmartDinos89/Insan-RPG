using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GameObject player = other.gameObject;
            StartCoroutine(HealPlayer(player));
        }
    }
    private IEnumerator HealPlayer(GameObject player)
    {
        player.GetComponent<PlayerController>().canMove = false;
        player.GetComponent<HealthManager>().Heal(player.GetComponent<HealthManager>().maxHealth - player.GetComponent<HealthManager>().currentHealth);
        yield return new WaitForSeconds(.2f);
        player.GetComponent<PlayerController>().canMove = true;
    }
    
}
