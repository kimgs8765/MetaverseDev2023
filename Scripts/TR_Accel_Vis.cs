using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TR_Accel_Vis : MonoBehaviour
{
    public bool accel_Input ;
    Vector3 curr_rot;
    AudioSource scooter; 
    void Start()
    {
        curr_rot = transform.localEulerAngles;
        scooter = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame    void Update()
    void Update()
    {
        float prev_rot = Mathf.Clamp(transform.localEulerAngles.x, 0, 40);

        if (accel_Input == true & prev_rot > curr_rot.x - 40)
        {
            float x_change = Mathf.Lerp(0, prev_rot, 0.5f);
            Debug.Log(x_change);
            transform.Rotate(-x_change, 0, 0);

            if( !scooter.isPlaying) 
            {  
                scooter.Play();
                Debug.Log("Àç»ýÁß");
            }

        }

        else if (accel_Input == false & prev_rot < curr_rot.x)
        {
            float x_change = Mathf.Lerp(prev_rot, 40, 0.5f);
            transform.Rotate(x_change, 0, 0);

            if( scooter.isPlaying) { scooter.Pause(); }
            
        }

    }
}
