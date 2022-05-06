using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")){
            EnemyController enemyController = other.GetComponent<EnemyController>();
            enemyController.TakeDamage(1);
        }
    }
}
