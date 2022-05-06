using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy: Ouch! That did " + damage.ToString() + " damage.");
    }
}
