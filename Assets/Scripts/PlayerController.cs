using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private DialogueUi dialogueUi;
    private HealthManager healthManager;

    public DialogueUi DialogueUi => dialogueUi;

    public IInteractable Interactable { get; set; }

    public WeaponObject weapon;
    public Image weaponImage;

    Rigidbody2D body;
    Animator animator;
    float horizontal;
    float vertical;
    
    [HideInInspector]public bool canMove;

    Vector2 move;

    public float runSpeed = 20.0f;

    void Start()
    {
        GetWeapon(weapon);
        healthManager = GetComponent<HealthManager>();
        canMove = true;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down
        
        
        move = new Vector2(horizontal, vertical).normalized;

        if(dialogueUi.isOpen || !canMove)
        {
            move = Vector2.zero;
        }

        if(Input.GetButtonDown("Submit") && dialogueUi.isOpen == false)
        {
            Interactable?.Interact(this);
        }

        if(Input.GetButtonDown("Attack"))
        {
            StartCoroutine(Attack());
        }

    }

    void FixedUpdate()
    {
        body.velocity = move * runSpeed;

        if(move != Vector2.zero)
        {
            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);
            animator.SetBool("moving", true);
        }else
        {
            animator.SetBool("moving", false);
        }
    }

    private IEnumerator Attack(){
        canMove = false;
        animator.SetTrigger("attack");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        canMove = true;
    }

    public void GetWeapon(WeaponObject wpn)
    {
        weapon = wpn;
        weaponImage.sprite = wpn.weaponSprite;

    }
}
