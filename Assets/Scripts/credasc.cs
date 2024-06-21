using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credasc : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ploca")
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "ploca")
        {
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
