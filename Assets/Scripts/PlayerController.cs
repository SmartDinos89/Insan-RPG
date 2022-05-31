using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour , IDataPersistance
{

    [SerializeField] private DialogueUi dialogueUi;
    private HealthManager healthManager;

    private AudioSource audioPlayer;

    public DialogueUi DialogueUi => dialogueUi;

    public IInteractable Interactable { get; set; }
    public long coins;
    public TMP_Text coinText;

    public WeaponObject weapon;
    public Image weaponImage;

    Rigidbody2D body;
    Animator animator;
    float horizontal;
    float vertical;

    public float exp;
    public int level;
    [SerializeField]private RectTransform expBar;
    [SerializeField]private TMP_Text levelCounter;
    
    [HideInInspector]public bool canMove;

    Vector2 move;

    [Header("Params")]
    public float runSpeed = 20.0f;
    public float knockBackStrength = 1f;
    void Start()
    {
        GetWeapon(weapon);
        healthManager = GetComponent<HealthManager>();
        audioPlayer = GetComponent<AudioSource>();
        canMove = true;
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        if(exp == 0) {addXP(1f);} else {addXP(0f);}
        coinText.text = coins.ToString();
    }

    public void LoadData(GameData data)
    {
        this.coins = data.coinCount;
        this.transform.position = data.playerpos;
        this.exp = data.exp;
        this.level = data.level;
        if(data.weapon != null)
        {
            this.weapon = data.weapon;
        }
    }
    public void SaveData(ref GameData data)
    {
        data.coinCount = this.coins;
        data.playerpos = this.transform.position;
        data.exp = this.exp;
        data.level = this.level;
        data.weapon = this.weapon;
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
        if(canMove && move != Vector2.zero){
            body.velocity = move * runSpeed;


            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("vertical", vertical);
            animator.SetBool("moving", true);
        }else
        {
            body.velocity = Vector2.zero;
            animator.SetBool("moving", false);
        }
        
    }

    private IEnumerator Attack(){
        canMove = false;
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(.2f);
        animator.SetBool("attack", false);
        canMove = true;
    }

    public void PlaySound(AudioClip clip)
    {
        audioPlayer.clip = clip;
        audioPlayer.Play();
    }

    public void GetWeapon(WeaponObject wpn)
    {
        weapon = wpn;
        weaponImage.sprite = wpn.weaponSprite;

    }
    public void addCoins(long value){
        coins += value;
        if(coins <= 0){coins = 0;}
        if(coins >= 1000000001){coins = 1000000001;}

        if(coins >= 1000000000)
        {
            coinText.text = "\u221E";
        }
        else
        {
            coinText.text = coins.ToString();
        }
        
    }

    public void addXP(float experience){
        exp += experience;
        level = (int)Mathf.Pow(exp, 0.4f);
        levelCounter.text = "Lvl: " + level;
        float expForNextLevel = Mathf.Pow((level + 1f), 2.5f) - Mathf.Pow((level), 2.5f);
        float expToNextLevel = exp - Mathf.Pow((level), 2.5f);
        expBar.localScale = new Vector3(expToNextLevel/expForNextLevel, transform.localScale.y, transform.localScale.z);
    }
}
