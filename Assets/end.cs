using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class end : MonoBehaviour
{
    public GameObject endvr;
    public GameObject endde;
    public GameObject Winvr;
    public GameObject Winde;
    public GameObject vrpl;
    public GameObject depl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Capsule")
        {
            Cursor.lockState = CursorLockMode.None;
            depl.SetActive(false);
            endde.SetActive(true);
            Winde.SetActive(true);
        }
        else if (other.gameObject.name == "XR Origin (XR Rig)")
        {
            vrpl.SetActive(false);   
            endvr.SetActive(true);
            Winvr.SetActive(true);
        }
    }
}
