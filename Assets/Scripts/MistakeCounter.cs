﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MistakeCounter : MonoBehaviour
{
    public int num;
    public GameObject x;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.mistakes >= num - (3-gameManager.maxMistakes))
        {
            x.SetActive(true);
        }
    }
}
