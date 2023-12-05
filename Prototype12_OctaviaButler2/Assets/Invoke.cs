using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Invoke : MonoBehaviour
{

    /*public float interval = 2f;
    public float spawnDuration = 100f;
    
    private void Start()
    {
        //InvokeRepeating("SpawnSprite", 0f, interval);
        StartCoroutine(SpawnSpritesCoroutine());
    }

    private IEnumerator SpawnSpritesCoroutine()
    {
        float startTime = Time.time;

        while (Time.time - startTime < spawnDuration)
        {
            Instantiate(this.gameObject, GetRandomPos(), Quaternion.identity);
            yield return new WaitForSeconds(interval);
        }
    }

    Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0);
    }*/

    private Vector3 mousePosOffset;

    public float interval = 4f;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("ToggleSpriteVisibility", 0f, interval);
    }

    void ToggleSpriteVisibility()
    {
        if (_spriteRenderer != null)
        {
            _spriteRenderer.enabled = !_spriteRenderer.enabled;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position = GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePosOffset;
    }

}
