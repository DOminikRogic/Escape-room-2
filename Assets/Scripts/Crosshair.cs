using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public Texture2D Crosshairimage;


    void OnGUI()
    {
        
            float xmin = (Screen.width / 2) - (Crosshairimage.width / 2);
            float ymin = (Screen.height / 2) - (Crosshairimage.height / 2);

            GUI.DrawTexture(new Rect(xmin, ymin, Crosshairimage.width, Crosshairimage.height), Crosshairimage);
       
       


               
        
    }
}
