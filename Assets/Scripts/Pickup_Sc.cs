using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Sc : MonoBehaviour
{

    [SerializeField] private LayerMask PickupMask;
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform pickupTarget;
    [Space]
    [SerializeField] private float pickuprange;
    public Rigidbody CurrentObject;
    public bool carried = false;
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {          
            if (CurrentObject)
            {
                carried = !carried;
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }

            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, pickuprange, PickupMask))
            {
                carried = !carried;
                CurrentObject = hitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
        }
        
    }
     void FixedUpdate()
    {
        if (CurrentObject)
        {
            Vector3 DirectionToPoint = pickupTarget.position - CurrentObject.transform.position;
            float distancetoPoint = DirectionToPoint.magnitude;
            CurrentObject.velocity = DirectionToPoint * 12f * distancetoPoint;
        }
    }
}
