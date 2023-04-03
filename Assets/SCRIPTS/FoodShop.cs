using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodShop : MonoBehaviour
{
    [SerializeField] private float Distance;

    public ComputerLogic cl;
    public UI_Shop shop;
    public bool usingShop = false;

    private int breadAmount = 0;
    private int beerAmount = 0;
    public Text breadText;
    public Text beerText;

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

    public void BuyBread()
    {
        if(cl.money >= 30 && breadAmount < 3)
        {
            cl.money += -30;
            breadAmount++;
            cl.Money.text = "Money: " + (int)cl.money + " €";
            breadText.text = "Bread: " + breadAmount + "/3";
        }
    }

    public void buyBeer()
    {
        if(cl.money >= 40 && beerAmount < 3)
        {
            cl.money += -40;
            beerAmount++;
            cl.Money.text = "Money: " + (int)cl.money + " €";
            beerText.text = "Beer: " + beerAmount + "/3";
        }       
    }

    public void buyBandAid()
    {
        if(cl.money >= 50 && bandAidAmount < 3)
        {
            cl.money += -50;
            bandAidAmount++;
            cl.Money.text = "Money: " + (int)cl.money + " €";
            bandAidText.text = "Band-Aid: " + bandAidAmount + "/3";
        }
    }
}
