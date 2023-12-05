using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePosOffset;
    public GameObject spriteToAppear;
    public AudioSource audio;

    public void Start()
    {
        audio.gameObject.SetActive(false);
    }

    private void Update()
    {
        /*if (this.gameObject == false)
        {
            GetComponent<AudioSource>().gameObject.SetActive(true);
        }*/
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        mousePosOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePosOffset;
    }

    private void OnMouseUp()
    {
        Debug.Log("mouse up");
        this.gameObject.SetActive(false);
        Instantiate(spriteToAppear, transform.position, Quaternion.identity);
        //GetComponent<AudioSource>().gameObject.SetActive(true);
        audio.gameObject.SetActive(true);
    }
}
