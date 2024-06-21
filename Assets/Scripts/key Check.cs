using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class keyCheck : MonoBehaviour
{
    public AudioSource sound;
    public Pickup_Sc co;
    public bool unlocked = false;
    public GameObject key;
    Rigidbody m_Rigidbody;
    public Material GREENLED;
    public GameObject led;


    private void Start()
    {
        m_Rigidbody = key.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Key")
        {
            //gameObject.GetComponent<Collider>().isTrigger = false;
            if (co.carried == true)
            {
                co.carried = false;

                co.CurrentObject = null;
                // other.gameObject.transform.position = new Vector3(transform.position.x+ 142.5775f, transform.position.y + 16.83471f, transform.position.z+ -1.536242f);
                m_Rigidbody.isKinematic = true;
                key.layer = 0;
                key.GetComponent<Clickable>().enabled = false;
                led.GetComponent<Renderer>().material = GREENLED;
            }
            else
            {

                other.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y+0.216f, transform.position.z );
                m_Rigidbody.isKinematic = true;
                key.layer = 0;
                key.GetComponent<Clickable>().enabled = false;
                led.GetComponent<Renderer>().material = GREENLED;
            }
            unlocked = true;
            sound.Play();
        }
    }


}
