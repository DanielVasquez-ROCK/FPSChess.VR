using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen : MonoBehaviour
{
    public float speed = 2.0f;
    private Vector3 moveDirection =  Vector3.zero;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
        {
            Vector2 touchpadInput = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);

            moveDirection = new Vector3(touchpadInput.x, 0.0f, touchpadInput.y);
            moveDirection *= speed;
        }
        else
        {
            moveDirection = Vector3.zero;
        }
    }
}
