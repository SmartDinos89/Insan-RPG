using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private GameObject player;
    public enum ItemType{
        healing,
        coin
    }
    [SerializeField]private ItemType itemType;
    [Range(0, 10)][SerializeField]private float HealAmount;
    [Range(0, 9999)]public int value;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        HealthManager healthManager = player.GetComponent<HealthManager>();    
        PlayerController playerController = player.GetComponent<PlayerController>();
        value = playerController.level * Random.Range(1,15);
        if(other.CompareTag("Player")){

            switch(itemType){
                case ItemType.healing:

                    if(healthManager.currentHealth < healthManager.maxHealth){
                        if(healthManager.maxHealth - healthManager.currentHealth < HealAmount)
                        {
                            healthManager.Heal(healthManager.maxHealth - healthManager.currentHealth);
                            Destroy(gameObject);
                        }
                        healthManager.Heal(HealAmount);
                        Destroy(gameObject);
                    }
                break;
                case ItemType.coin:
                    playerController.addCoins(value);
                    Destroy(gameObject);
                break;
                default:
                return;
            }
        }
    }
}
