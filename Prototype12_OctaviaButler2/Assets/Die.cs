using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Die : MonoBehaviour
{
    public float timer = 0f;
    [FormerlySerializedAs("growTime")] public float shrinkTime = 6f;
    public float minSize = .2f;
    public bool isMinSize = false;

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
}
