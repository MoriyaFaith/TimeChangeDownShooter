﻿/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour {

    public AudioSource doorSound;
    [SerializeField] private Key.KeyType keyType;
    
    public Key.KeyType GetKeyType() {
        return keyType;
    }

    public void OpenDoor()
    {
        doorSound.Play();
        gameObject.SetActive(false);
    }
}
