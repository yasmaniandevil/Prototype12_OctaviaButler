using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Serialization;

public class Die : MonoBehaviour
{
    public float timer = 0f;
    public float shrinkTime = 6f;
    public float minSize = .2f;
    public bool isMinSize = false;

    private Vector3 mousePosOffset;

    // Start is called before the first frame update
    void Start()
    {
        if (isMinSize == false)
        {
            StartCoroutine(Shrink());
        }
    }


    private IEnumerator Shrink()
    {
        //current scale of the object
        Vector2 startScale = transform.localScale;
        Vector2 minScale = new Vector2(this.minSize, this.minSize);

        timer = 0f;

        //do this while timer is less than grow time
        do
        {
            //we want to grow the object
            transform.localScale = Vector3.Lerp(startScale, minScale, timer / shrinkTime);
            //make our timer incremental
            timer += Time.deltaTime;
            //yield
            yield return null;

        } while (timer < shrinkTime);

        isMinSize = true;
        SwapSprite();
    }

    private void SwapSprite()
    {

        var spriteRender = GetComponent<SpriteRenderer>();

        if (spriteRender != null)
        {
            spriteRender.color = Color.gray;
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
