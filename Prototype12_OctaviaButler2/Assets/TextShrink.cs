using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShrink : MonoBehaviour
{
    public float timer = 0f;
    public float shrinkTime = 6f;
    public float minSize = .2f;
    public bool isMinSize = false;
    public GameObject objectToShrink;

    // Start is called before the first frame update
    void Start()
    {
        
        objectToShrink.SetActive(false);

        StartCoroutine(ActiveAfterDelay());

    }

    IEnumerator ActiveAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        
        objectToShrink.SetActive(true);
        
        if (isMinSize == false)
        {
            StartCoroutine(Shrink());
        }
    }


    private IEnumerator Shrink()
    {
        //current scale of the object
        Vector2 startScale = objectToShrink.transform.localScale;
        Vector2 minScale = new Vector2(this.minSize, this.minSize);

        timer = 0f;

        //do this while timer is less than grow time
        do
        {
            //we want to grow the object
            objectToShrink.transform.localScale = Vector3.Lerp(startScale, minScale, timer / shrinkTime);
            //make our timer incremental
            timer += Time.deltaTime;
            //yield
            yield return null;

        } while (timer < shrinkTime);

        objectToShrink.SetActive(false);
        
        isMinSize = true;
    }
}
