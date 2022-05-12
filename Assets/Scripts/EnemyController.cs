using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public int health = 3;
    public int maxHealth = 3;
    public int damage = 1;
    public float stopRange;
    public float detectRange;
    public Transform targetPos;
    public GameObject player;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;
    private bool hurting;
    public float cooldown = 1f; //seconds
    private float lastAttackedAt = -9999f;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        player = GameObject.FindGameObjectWithTag("Player");
        targetPos = player.transform;
        health = maxHealth;
        hurting = false;
    }
    private void Update() {
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, targetPos.position) >= stopRange && Vector3.Distance(transform.position, targetPos.position) <= detectRange)
        {
            var step =  speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
        }else if(Vector3.Distance(transform.position, targetPos.position) <= stopRange && Vector3.Distance(transform.position, targetPos.position) <= detectRange){
            if (Time.time > lastAttackedAt + cooldown) {
                Attack(damage);
                lastAttackedAt = Time.time;
            }
        }
    }
    public IEnumerator TakeDamage(int damage)
    {
        hurting = true;
        health--;
        sr.material = matWhite;
        yield return new WaitForSeconds(.2f);
        sr.material = matDefault;
        if(health <= 0){
            Destroy(gameObject);
        }
        hurting = false;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, stopRange);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Hitboxes"){
            if(!hurting)
            StartCoroutine(TakeDamage(1)); 
        }
    }

    public void Attack(int damage){
        StartCoroutine(player.GetComponent<HealthManager>().TakeDamage(damage));
    }
}
