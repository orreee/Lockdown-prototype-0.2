using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedLogic : MonoBehaviour
{
    public Timer time;

    [SerializeField] private float Distance;
    [SerializeField] private Transform player;
    [SerializeField] private Text dayText;

    void Awake()
    {
        player = FindObjectOfType<Movement>().transform.transform;
    }

    void Update()
    {
        Vector3 bedToPlayerVector = player.position - transform.position;

        if (bedToPlayerVector.magnitude <= Distance && Input.GetKeyDown(KeyCode.E) && time.currentSeconds >= 1200)
        {
            time.currentSeconds = 360;
            time.day++;
            dayText.text = "Day: " + time.day;
        }
    }
}
