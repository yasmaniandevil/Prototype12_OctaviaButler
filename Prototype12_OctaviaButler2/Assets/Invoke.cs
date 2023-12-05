using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Invoke : MonoBehaviour
{

    public float interval = 1f;
    //private SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    /*void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        InvokeRepeating("ToggleSprite", 0f, interval);
    }

    // Update is called once per frame
    void ToggleSprite()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
        }
    }*/


    private void Start()
    {
        InvokeRepeating("SpawnSprite", 0f, interval);
    }

    void SpawnSprite()
    {
        Instantiate(this.gameObject, GetRandomPos(), Quaternion.identity);
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
    }
}
