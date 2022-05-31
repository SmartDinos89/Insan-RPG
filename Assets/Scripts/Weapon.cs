using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponObject weapon;
    public GameObject DeactivateParent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            other.GetComponent<PlayerController>().GetWeapon(weapon);
            transform.SetParent(DeactivateParent.transform);
        }
    }
}
