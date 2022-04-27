using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextboxController : MonoBehaviour
{
    private TMP_Text _text;
    // Start is called before the first frame update
    void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    /*void Update()
    {
        _text.text = "BRUH";
    }*/
    
    public void UpdateText(System.String content)
    {
        _text.text = content;
    }
    
}
