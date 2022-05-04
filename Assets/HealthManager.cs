using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] GameObject healthContainer;
    [SerializeField]GameObject healthIcon;

    private void Start() {
        currentHealth = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Instantiate(healthIcon, transform.position, Quaternion.identity, healthContainer.transform);
        }



    }

}
