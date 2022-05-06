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

    private void Start() {
        currentHealth = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(Health, transform.position, Quaternion.identity, healthContainer.transform);
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.L)){TakeDamage(1);}
        if(currentHealth <= 0){SceneManager.LoadScene("Menu");}
    }

    public void TakeDamage(int damage)
    {
        for (int i = 0; i < damage; i++)
        {
            if(currentHealth >= 0)
            {
                currentHealth -= 1;
                Destroy(healthContainer.transform.GetChild(healthContainer.transform.childCount - 1).gameObject);
            } else
            {
                Debug.Log("Already Dead");
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
            else
            {
                Debug.Log("Max Health");
            }

        }


    }

}
