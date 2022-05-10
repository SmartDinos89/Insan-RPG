using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/Weapon")]
public class WeaponObject : ScriptableObject
{
    [SerializeField]private string weaponName;
    [SerializeField]private Sprite weaponSprite;
    [SerializeField]private float damage;
    [SerializeField]private float value;

    private string WeaponName => weaponName;
    private Sprite WeaponSprite => weaponSprite;
    private float Damage => damage;
    private float Value => value;
}
