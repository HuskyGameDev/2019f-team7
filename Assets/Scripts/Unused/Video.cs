﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
    }
}
