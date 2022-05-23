using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    [SerializeField] GameObject healthContainer;
    [SerializeField]GameObject Health;

    private Material matWhite;
    private Material matDefault;
    private SpriteRenderer sr;

    public ParticleSystem explosion;

    private void Start() {
        sr = GetComponent<SpriteRenderer>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material;
        matDefault = sr.material;
        currentHealth = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(Health, transform.position, Quaternion.identity, healthContainer.transform);
        }
    }


    public IEnumerator TakeDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if(currentHealth >= 0)
            {
                sr.material = matWhite;
                currentHealth--;
                 Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(healthContainer.transform.GetChild(healthContainer.transform.childCount - 1).gameObject);
                yield return new WaitForSeconds(.1f);
                sr.material = matDefault;
            } else
            {
                SceneManager.LoadScene("Outside");
            }
        
        }
        

    }

    public void Heal(int healAmount)
    {
        for (int i = 0; i < healAmount; i++)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += 1;
                Instantiate(Health, transform.position, Quaternion.identity, healthContainer.transform);
            }

        }


    }

}
