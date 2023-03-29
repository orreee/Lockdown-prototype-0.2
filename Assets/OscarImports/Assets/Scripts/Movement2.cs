using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    [SerializeField] GameObject followingObject;

    private void Start()
    {
        
    }

    void Update()
    {
        transform.position = followingObject.transform.position;
    }
}
