using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignScript : MonoBehaviour
{
    [SerializeField] String TextToDisplay;
    [SerializeField] private GameObject TextboxHandler;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            TextboxHandler.GetComponent<TextboxController>()?.UpdateText(TextToDisplay);
        }
    }
}
