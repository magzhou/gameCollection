﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cookieJar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        cookieController.curSpeltWord += GetComponent<TextMeshPro>().text;
        Debug.Log(cookieController.curSpeltWord);
        GetComponent<TextMeshPro>().enabled = !GetComponent<TextMeshPro>().enabled;
    }
}
