using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("s") || Input.GetKey("down") || Input.GetKey("a") || Input.GetKey("left") || Input.GetKey("d") || Input.GetKey("right"))//checks if any of the movement input buttons are active, otherwise the character is standing still
        {
            animator.SetBool("isWalking", true);
        }
        else { animator.SetBool("isWalking", false); }
    }
}
