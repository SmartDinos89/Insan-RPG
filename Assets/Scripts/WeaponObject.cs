using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScrObjs/Weapon")]
public class WeaponObject : ScriptableObject
{
    public int id;
    public string weaponName;
    public Sprite weaponSprite;
    public float damage;
    public float value;
}
