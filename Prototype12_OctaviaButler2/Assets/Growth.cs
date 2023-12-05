using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{

    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 2f;
    public bool isMaxSize = false;

    private Vector3 mousePosOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }
    }


    public IEnumerator Grow()
    {
        //current scale of the object
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(this.maxSize, this.maxSize);

        timer = 0f;

        //do this while timer is less than grow time
        do
        {
            //we want to grow the object
            transform.localScale = Vector3.Lerp(startScale, maxScale, timer / growTime);
            //make our timer incremental
            timer += Time.deltaTime;
            //yield
            yield return null;

        } while (timer < growTime);

        isMaxSize = true;
        
    }

    public Vector3 GetMouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    public void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    public void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mousePosOffset;
    }
}
