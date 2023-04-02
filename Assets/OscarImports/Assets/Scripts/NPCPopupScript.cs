using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//public class NPCPopupScript : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {

//    }

//    // Update is called once per frame
//    void Update()
//    {

//    }
//}
public class NPCPopupScript : MonoBehaviour
{
    [SerializeField] private GameObject popupObject;
    [SerializeField] private string popupText;
    [SerializeField] private Sprite popupImage;
    [SerializeField] private float popupHeight = 2.0f;

    [SerializeField] private bool playerInRange = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UpdatePopup();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            ResetPopup();
        }
    }

    //void UpdatePopup()
    //{
    //    // Set the position of the popup object to be in front of the camera
    //    popupObject.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;

    //    // Update the text or image component with the desired content
    //    Text popupTextComponent = popupObject.GetComponentInChildren<Text>();
    //    if (popupTextComponent != null)
    //    {
    //        popupTextComponent.text = popupText;
    //    }
    //    Image popupImageComponent = popupObject.GetComponentInChildren<Image>();
    //    if (popupImageComponent != null)
    //    {
    //        popupImageComponent.sprite = popupImage;
    //    }
    //}
    void UpdatePopup()
    {
        // Set the position of the popup object to float above the NPC
        Vector3 popupPosition = transform.position + Vector3.up * popupHeight;
        popupObject.transform.position = popupPosition;

        // Update the text or image component with the desired content
        Text popupTextComponent = popupObject.GetComponentInChildren<Text>();
        if (popupTextComponent != null)
        {
            popupTextComponent.text = popupText;
        }
        Image popupImageComponent = popupObject.GetComponentInChildren<Image>();
        if (popupImageComponent != null)
        {
            popupImageComponent.sprite = popupImage;
        }
    }

    void ResetPopup()
    {
        // Set the position of the popup object to be off-screen
        popupObject.transform.position = new Vector3(-1000, -1000, -1000);
    }
}
