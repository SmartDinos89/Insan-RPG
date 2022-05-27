using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]private float speed = 1.0f;
    [SerializeField]private int health = 3;
    [SerializeField]private int maxHealth = 3;
    [SerializeField]private int damage = 1;
    [SerializeField]private float stopRange;
    [SerializeField]private float detectRange;
    [SerializeField]private float attackCooldown = 1f; //seconds
    [SerializeField]private GameObject reward;
    [SerializeField]private float rewardExp;
    [SerializeField]private Animator animator;
    private Transform targetPos;
    private GameObject player;

    private Rigidbody2D rb;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;
    private bool hurting;

    private float lastAttackedAt = -9999f;

    private void Start() {
        Physics2D.IgnoreLayerCollision(3,7);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        player = GameObject.FindGameObjectWithTag("Player");
        matDefault = sr.material;
        targetPos = player.transform;
        health = maxHealth;
        hurting = false;
    }
    private void FixedUpdate() {
        Vector3 dir = (player.transform.position - rb.transform.position).normalized;
        // Check if the position of the cube and sphere are approximately equal.
        if(!hurting)
        {
            if (Vector3.Distance(transform.position, targetPos.position) >= stopRange && Vector3.Distance(transform.position, targetPos.position) <= detectRange)
            {
                animator.SetFloat("xVel", rb.velocity.x);
                animator.SetFloat("yVel", rb.velocity.y);
                animator.SetBool("moving", true);
            rb.AddForce(dir * speed * Time.fixedDeltaTime);
            }
            else if(Vector3.Distance(transform.position, targetPos.position) <= stopRange && Vector3.Distance(transform.position, targetPos.position) <= detectRange)
            {
                animator.SetBool("moving", false);
                rb.velocity = Vector2.zero;
            if (Time.time > lastAttackedAt + attackCooldown)
            {
                Attack(damage);
                lastAttackedAt = Time.time;
            }
            }
            else
            {
                rb.velocity = Vector2.zero;
                animator.SetBool("moving", false);
            }
        }
    }
    private IEnumerator TakeDamage(int damage)
    {
        hurting = true;
        health -= damage;
        sr.material = matWhite;
        Vector3 direction = transform.position - targetPos.position;
        rb.AddForce(direction * player.GetComponent<PlayerController>().knockBackStrength, ForceMode2D.Impulse);
        yield return new WaitForSeconds(.09f);
        sr.material = matDefault;
        if(health <= 0){
            Instantiate(reward, transform.position, Quaternion.identity);
            player.GetComponent<PlayerController>().addXP(rewardExp * (player.GetComponent<PlayerController>().level + 1));
            Debug.Log("Player has " + player.GetComponent<PlayerController>().exp + " Exp.");
            Debug.Log("Player is Level: " + player.GetComponent<PlayerController>().level + ".");
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
            if(!hurting && player.GetComponent<PlayerController>().weapon != null)

            StartCoroutine(TakeDamage(player.GetComponent<PlayerController>().weapon.damage)); 
            
        }
    }

    public void Attack(int damage){
        StartCoroutine(player.GetComponent<HealthManager>().TakeDamage(damage));
    }
}
