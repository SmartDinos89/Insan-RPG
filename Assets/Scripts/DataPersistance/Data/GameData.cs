using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public long coinCount;
    public Vector3 playerpos;
    public float maxHealth;
    public float currentHealth;
    public WeaponObject weapon;
    public float exp;
    public int level;
    public GameData()
    {
        this.coinCount = 0;
        this.playerpos = new Vector3(-82.0f,27.0f,0.0f);
        this.maxHealth = 10.0f;
        this.currentHealth = 10.0f;
        this.exp = 0.0f;
        this.level = 0;
        this.weapon = null;
    }
}
