using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = .5f;
    private Rigidbody2D rb2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Debug.Log("got rigid body");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, speed, 0f);
        rb2D.AddForce(movement);
        Debug.Log("moving");
    }
}
