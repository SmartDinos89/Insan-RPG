using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] private DialogueUi dialogueUi;

    public DialogueUi DialogueUi => dialogueUi;

    public IInteractable Interactable { get; set; }

    Rigidbody2D body;
    Animator animator;
    float horizontal;
    float vertical;
    
    [HideInInspector]public bool canMove;

    Vector2 move;

    public float runSpeed = 20.0f;

    void Start()
    {
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

        if(dialogueUi.isOpen)
        {
            move = Vector2.zero;
        }

        if(Input.GetButtonDown("Interact"))
        {
            Interactable?.Interact(this);
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
}
