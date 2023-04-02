using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class npcProximityScript : MonoBehaviour
{
    [SerializeField] private float Distance;
    [SerializeField] private int aboveInt;
    [SerializeField] private Transform player;
    [SerializeField] private TextMeshProUGUI textNPC;
    public bool npcInRange;
    // Start is called before the first frame update
    void Start()
    {
        npcInRange = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 npcToPlayerVector = player.position - transform.position;
        if (npcToPlayerVector.magnitude <= Distance)
        {
            npcInRange = true;
        }
        else
        {
            npcInRange = false;
        }
        if (npcInRange)
        {
            //popupObject.Transform.Y = 7;
            textNPC.transform.position = transform.position + Vector3.up * aboveInt;
            //textNPC.text = "Fuck you";
        }
        else
        {
            //popupObject.Transform.Y = -7;
            textNPC.transform.position = transform.position + Vector3.down * aboveInt;
            //textNPC.text = "Fuck you";
        }
    }
}
