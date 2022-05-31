using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugController : MonoBehaviour
{
    bool consoleActive;
    public GameObject console;
    public TMP_InputField inputField;
    PlayerController player;
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        console.SetActive(false);
        consoleActive = false;
    }
    private void Update() {
        if(Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Tab))
        {
            if(consoleActive)
            {
                console.SetActive(false);
            }
            else if(!consoleActive)
            {
                console.SetActive(true);
            }
            consoleActive = !consoleActive;
        }
    }

    public void AddMoney()
    {
        player.addCoins(int.Parse(inputField.text));
        console.SetActive(false);
        consoleActive = false;
    }
    
}
