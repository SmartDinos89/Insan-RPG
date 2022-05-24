using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField] private RectTransform HealthBar;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    public ParticleSystem explosion;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        currentHealth = maxHealth;
    }


    public IEnumerator TakeDamage(float damage)
    {
            if(currentHealth > damage)
            {
                currentHealth -= damage;
                HealthBar.localScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
                sr.material = matWhite;
                Instantiate(explosion, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(.1f);
                sr.material = matDefault;
            } else
            {
                currentHealth = 0;
                HealthBar.localScale = new Vector3(currentHealth/maxHealth, transform.localScale.y, transform.localScale.z);
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
