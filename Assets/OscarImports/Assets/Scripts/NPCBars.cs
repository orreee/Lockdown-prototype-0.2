using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCBars : MonoBehaviour
{
    public SanityBar sanityBar;
    public HungerBar hungerBar;
    public HealthBar healthBar;

    public float maxSanity = 100f;
    public float currentSanity;

    public float maxHunger = 100f;
    public float currentHunger;

    public float maxHealth = 100f;
    public float currentHealth;

    private const float coef = 1f;
    
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        sanityBar.SetMaxSanity(maxSanity);

        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        currentSanity -= coef * Time.deltaTime;
        sanityBar.SetSanity(currentSanity);
        
        currentHunger -= 0.5f * coef * Time.deltaTime;
        hungerBar.SetHunger(currentHunger);
        
        currentHealth -= 0.2f * coef * Time.deltaTime;
        healthBar.SetHealth(currentHealth);
    }
}
