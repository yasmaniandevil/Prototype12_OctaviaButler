using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    
    public float timer = 0f;
    public float growTime = 6f;
    public float maxSize = 2f;
    public bool isMaxSize = false;

    //public float delay = 5f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ActivateObjectDelayed());
        Debug.Log("ActivateGameObj");
        
        if (isMaxSize == false)
        {
            StartCoroutine(Grow());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator Grow()
    {
        //current scale of the object
        Vector2 startScale = transform.localScale;
        Vector2 maxScale = new Vector2(this.maxSize, this.maxSize);

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
    
    /*IEnumerator ActivateObjectDelayed()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);
        Debug.Log("Delay" + delay);

        // Activate the GameObject
        gameObject.SetActive(true);
    }*/
}
