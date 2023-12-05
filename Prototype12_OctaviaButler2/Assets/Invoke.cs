using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Invoke : MonoBehaviour
{

    public float interval = 1f;
    public int maxSprite = 10;
    private int spriteCount = 0;

    private void Start()
    {
        InvokeRepeating("SpawnSprite", 0f, interval);
    }

    void SpawnSprite()
    {
        if (spriteCount >= maxSprite)
        {
            CancelInvoke("SpawnSprite");
            return;
        }
        
        Instantiate(this.gameObject, GetRandomPos(), Quaternion.identity);
        spriteCount++;
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
    }
}
