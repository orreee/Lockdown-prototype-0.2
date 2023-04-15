using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Timer Timer;
    public Text dayText;

    public void GameOver()
    {
        gameObject.SetActive(true);
        dayText.text = "You Lost On Day " + Timer.day;
    }
}
