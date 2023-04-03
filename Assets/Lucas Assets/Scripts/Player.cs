using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public SanityBar sanityBar;

    public float maxSanity = 100f;
    public float currentSanity;
    private const float coef = 6f;

    
    // Start is called before the first frame update
    void Start()
    {
        currentSanity = maxSanity;
        sanityBar.SetMaxSanity(maxSanity);
    }

    // Update is called once per frame
    void Update()
    {
        currentSanity -= coef * Time.deltaTime;
        sanityBar.SetSanity(currentSanity);
        
    }
}
