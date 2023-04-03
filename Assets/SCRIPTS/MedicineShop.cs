using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MedicineShop : MonoBehaviour
{
    [SerializeField] private float Distance;

    public ComputerLogic cl;
    public MedicineShop_UI shop;
    public bool usingShop = false;

    private int bandAidAmount = 0;
    public Text bandAidText;

    [SerializeField] private Transform player;
    void Awake()
    {
        player = FindObjectOfType<Movement>().transform.transform;
    }

    void Update()
    {
        Vector3 shopToPlayerVector = player.position - transform.position;

        if (shopToPlayerVector.magnitude <= Distance && Input.GetKeyDown(KeyCode.E) && !usingShop)
        {
            usingShop = true;
        }
        else if (shopToPlayerVector.magnitude <= Distance && Input.GetKeyDown(KeyCode.E) && usingShop)
            usingShop = false;

        if (usingShop)
        {
            shop.Show();
        }
        else
        {
            shop.Hide();
        }

        if (shopToPlayerVector.magnitude >= Distance && usingShop)
            usingShop = false;

    }

    public void buyBandAid()
    {
        if (cl.money >= 50 && bandAidAmount < 3)
        {
            cl.money += -50;
            bandAidAmount++;
            cl.Money.text = "Money: " + (int)cl.money + " €";
            bandAidText.text = "Band-Aid: " + bandAidAmount + "/3";
        }
    }
}
