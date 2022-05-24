using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour
{
    private PlayerController player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    public void BuyWeapon(WeaponObject weapon){
        if(player.coins >= weapon.value){
            player.GetWeapon(weapon);
        player.addCoins(-1 * weapon.value);
        } 
    }
    public void BuyMagic(int value){
        if(player.coins >= value){
            
        } 
    }
}
