using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineShop_UI : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
