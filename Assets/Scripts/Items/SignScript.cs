using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignScript : MonoBehaviour
{
    [SerializeField] String TextToDisplay;
    [SerializeField] private GameObject TextboxHandler;
    [SerializeField] private GameObject VisualTextbox;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            TextboxHandler.GetComponent<TextboxController>()?.UpdateText(TextToDisplay);
            VisualTextbox.GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            TextboxHandler.GetComponent<TextboxController>()?.UpdateText("");
            VisualTextbox.GetComponent<RectTransform>().localScale = new Vector3(0,0,0);
        }
    }
}
