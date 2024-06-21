using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Clickable : MonoBehaviour
{
  
    public Rigidbody rb;
    public GameObject Player;

    void Start()
    {
        var outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = Color.black;
        outline.OutlineWidth = 20f;
        GetComponent<Outline>().enabled = false;
    }

    private void OnMouseOver()
    {
        float dis = Vector3.Distance(transform.position, Player.transform.position);
        if (dis <= 6f)
        {
            GetComponent<Outline>().enabled = true;
        }
        else
        {
            GetComponent<Outline>().enabled = false;
        }
    }

    private void OnMouseExit()
    {
        GetComponent<Outline>().enabled = false;
    }



   
   
}