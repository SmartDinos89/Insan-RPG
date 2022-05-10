using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;

    public float stopRange;
    public float detectRange;
    public Transform targetPos; 
    private void Start() {
        targetPos = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update() {
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetPos.position) >= stopRange && Vector3.Distance(transform.position, targetPos.position) <= detectRange)
        {
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
        }
    }
    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy: Ouch! That did " + damage.ToString() + " damage.");
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }
}
