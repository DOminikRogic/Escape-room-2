using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera_Sc : MonoBehaviour
{
    public Vector2 turn;
    public Player_sc player;
    public bool see = false;
    public Slider sens;

    void Start()
    {
       
        turn.x = 0;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void Update()
    {
        
        if (see == false)
       {
            
            float mouseY = Input.GetAxis("Mouse Y") * sens.value * Time.deltaTime;

             // Calculate the new X-axis rotation
             float newRotationX = turn.x - mouseY;

             // Clamp the rotation to the desired range
             newRotationX = Mathf.Clamp(newRotationX, -90f, 90f);

             if (newRotationX != turn.x)
             {
                 turn.x = newRotationX;
                 transform.localRotation = Quaternion.Euler(turn.x, 0, 0);
             }
        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (see == false)
            {

               
                see = true;
                


            }
            else if (see == true)
            {

              
                see = false;
                


            }
        }
    }
}
