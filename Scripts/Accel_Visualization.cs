using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accel_Visualization : MonoBehaviour
{
    Vector3 curr_rot; 

    void Start()
    {
        curr_rot = transform.localEulerAngles;
    }

    // Update is called once per frame    void Update()
    void Update()
    {
        float accel_Input = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
        float prev_rot = Mathf.Clamp(transform.localEulerAngles.x, 0, 40);

        if (accel_Input < 0 & prev_rot > curr_rot.x - 40 )
        {
            float x_change = Mathf.Lerp(0, prev_rot, 0.5f);
            Debug.Log(x_change);
            transform.Rotate(-x_change, 0, 0);
        }

        else if (accel_Input == 0 & prev_rot < curr_rot.x )
        {
            float x_change = Mathf.Lerp(prev_rot, 40, 0.5f);
            transform.Rotate(x_change, 0, 0);
        }
    }
}
