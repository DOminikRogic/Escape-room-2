using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

using UnityEngine;
using UnityEngine.UI;

public class Player_sc : MonoBehaviour
{
    public Vector2 turn;
    public float Senesitivity = 500f;
    public float moveSpeed = 5f;
    public float jumpAmount = 0.5f;   
    public Rigidbody Rb;
    public bool istouching = true;
    public float m_Speed = 5f;
    public GameObject ui;
    public bool see = false;
    public Slider Sens;
    public menues menues;

    
   
    void Start()
    {
        
        see = false;
        Cursor.lockState = CursorLockMode.Locked;
        turn.y = 0;
    }

    void Update()
    {
      
        if (see == false)
        {
            
            turn.y += Input.GetAxis("Mouse X") * Sens.value * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(0, turn.y, 0);

            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection -= transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += transform.right;
            }

            // Normalize the move direction to prevent faster diagonal movement.
            if (moveDirection.magnitude > 1f)
            {
                moveDirection.Normalize();
            }

            // Apply the movement using Rigidbody.MovePosition.
            Rb.MovePosition(Rb.position + moveDirection * moveSpeed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Space) && istouching)
            {
                // Apply the jump force using ForceMode.Impulse.
                Rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse);
            }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            
            if (see == false)
            {
                GetComponent<Crosshair>().enabled = false;
                ui.SetActive(true);
                see = true;
                Cursor.lockState = CursorLockMode.None;
           
            
            }
            else if (see == true) {
                if (!menues.inoptions)
                {  
                GetComponent<Crosshair>().enabled = true;
                ui.SetActive(false);
                see = false;
                Cursor.lockState = CursorLockMode.Locked;
                }

            }
        }
    } 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            istouching = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            istouching = false;
        }
    }
    
}

