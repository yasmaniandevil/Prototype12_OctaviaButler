using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShrinky : MonoBehaviour
{
    public float shrinkTime = 6f;
    public float minSize = 0.2f;
    private bool isMinSize = false;
    private float timer = 0f;

    public GameObject objectToShrink; // Assign the parent object in the Inspector

    void Start()
    {
        objectToShrink.SetActive(false);

        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(5f);

        // Activate the parent object
        objectToShrink.SetActive(true);

        // Start the Shrink coroutine for the parent and its children
        if (!isMinSize)
        {
            ShrinkRecursively(objectToShrink.transform);
        }
    }

    private void ShrinkRecursively(Transform parentTransform)
    {
        foreach (Transform child in parentTransform)
        {
            // Shrink the child object
            StartCoroutine(ShrinkCoroutine(child.gameObject));

            // Recursively call the function for any children of the child
            ShrinkRecursively(child);
        }
    }

    private IEnumerator ShrinkCoroutine(GameObject obj)
    {
        // Current scale of the object
        Vector3 startScale = obj.transform.localScale;
        Vector3 minScale = new Vector3(minSize, minSize, 1.0f);

        timer = 0f;

        // Do this while timer is less than shrink time
        do
        {
            // Shrink the object
            obj.transform.localScale = Vector3.Lerp(startScale, minScale, timer / shrinkTime);
            // Increment the timer
            timer += Time.deltaTime;
            // Yield
            yield return null;

        } while (timer < shrinkTime);

        isMinSize = true;
    }
}

