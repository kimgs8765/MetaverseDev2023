using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brake_Visualization : MonoBehaviour
{
    Vector3 curr_rot;

    // Start is called before the first frame update
    void Start()
    {
        curr_rot = transform.localEulerAngles;
        Debug.Log("Y 값은" + curr_rot.y);   
    }

    // Update is called once per frame    void Update()
    void Update()
    {
        float brake_Input = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger);

        float prev_rot = (transform.localEulerAngles.y > 180) ? transform.localEulerAngles.y - 360 : transform.localEulerAngles.y;

        Debug.Log("현재각도" + prev_rot);
        
        if (brake_Input > 0 & curr_rot.y - 20.0f  < prev_rot )
        {
            float y_change = Mathf.Lerp(Mathf.Abs(prev_rot), 10, 0.5f ); 
            transform.Rotate(0, -y_change , 0);
        }


        else if ( brake_Input <= 0  & curr_rot.y > prev_rot)
        {
            float y_change = Mathf.Lerp( 0, Mathf.Abs(prev_rot) ,0.5f);
            transform.Rotate(0, y_change, 0); 

        }
    }
}
