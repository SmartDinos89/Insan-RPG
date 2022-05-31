using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour , IDataPersistance
{
    public float maxHealth = 10;
    public float currentHealth = 10;
    public RectTransform HealthBar;
    [HideInInspector]
    public Vector3 healthBarScale;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    public ParticleSystem explosion;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        Heal(0f);
    }

    public void LoadData(GameData data)
    {
        this.maxHealth = data.maxHealth;
        this.currentHealth = data.currentHealth;

    }
    public void SaveData(ref GameData data)
    {
        data.maxHealth = this.maxHealth;
        data.currentHealth = this.currentHealth;

    }

    public IEnumerator TakeDamage(float damage)
    {
            if(currentHealth > damage)
            {
                currentHealth -= damage;
                healthBarScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
                HealthBar.localScale = healthBarScale;
                sr.material = matWhite;
                Instantiate(explosion, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                sr.material = matDefault;
            } else
            {
                currentHealth = 0;
                healthBarScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
                HealthBar.localScale = healthBarScale;
                sr.material = matWhite;
                SceneManager.LoadScene("Outside");
            }
        
        

    }

    public void Heal(float healAmount)
    {
        
        if (currentHealth < maxHealth)
        {
                currentHealth += healAmount;
                HealthBar.localScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
        }

        

    }

}
