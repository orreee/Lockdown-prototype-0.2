using SojaExiles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerLogic : MonoBehaviour
{
    public Timer time;

    [SerializeField] private float Distance;

    public Text Money;
    public float money = 0;
    public bool usingComputer = false;

    [SerializeField] private Transform player;
    void Awake()
    {
        player = FindObjectOfType<Movement>().transform.transform;
    }

    void Update()
    {
        Vector3 computerToPlayerVector = player.position - transform.position;

        if (computerToPlayerVector.magnitude <= Distance && Input.GetKeyDown(KeyCode.E) && !usingComputer)
        {
            usingComputer = true;
        }
        else if (computerToPlayerVector.magnitude <= Distance && Input.GetKeyDown(KeyCode.E) && usingComputer)
            usingComputer = false;

        if (usingComputer)
        {
            time.speed = 10;
            money += 3.5f * Time.deltaTime;
            Money.text = "Money: " + (int)money + " €";
        }
        else
        {
            time.speed = 1;
        }

        if (computerToPlayerVector.magnitude >= Distance && usingComputer)
            usingComputer = false;
    }
}

