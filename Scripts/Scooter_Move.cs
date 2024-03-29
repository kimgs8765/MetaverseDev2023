using Oculus.Interaction.Samples;
using Oculus.Platform.Models;
using OculusSampleFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scooter_Move : MonoBehaviour
{
    float MaxSpeed = 20.0f; //13.0f; //6.5f;
    float MaxbrakeTorque = 4000.0f;//800.0f;
    private float totalTorque = 0;

    [SerializeField] AudioSource scooter_audio;

    [SerializeField] GameObject player; 

    [SerializeField] WheelCollider FR_wh;
    [SerializeField] WheelCollider FL_wh;
    [SerializeField] WheelCollider BR_wh;
    [SerializeField] WheelCollider BL_wh;

    [SerializeField] private GameObject L_hand;
    [SerializeField] private GameObject R_hand;
    private float MaxRotation = 60.0f; 
    private float prev_rot;
    private float curr_rot ;
    private float chagned_rot;


    [SerializeField] float CurrSpeed;
    private Rigidbody rb;


    void Start()
    {
        Scooster_Initialize();

        rb = gameObject.GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);

        prev_rot = (R_hand.transform.localEulerAngles.y + L_hand.transform.localEulerAngles.y) / 2 ;

    }



    // Update is called once per frame
    void Update()
    {
        Vector2 cont_input = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        bool brake_button = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger );
        bool Grab_L = OVRInput.Get(OVRInput.Button.PrimaryHandTrigger);
        bool Grab_R = OVRInput.Get(OVRInput.Button.SecondaryHandTrigger);

        curr_rot = R_hand.transform.localEulerAngles.y ;
        chagned_rot = Mathf.DeltaAngle(prev_rot, curr_rot);

        if ( Grab_L && Grab_R )
        {
            Get_axel(cont_input);
            Get_brake(brake_button);
            Apply_torque();
            Applyt_rotation();

        }

        else
        {
            Scooter_Stopping();
;        }

        prev_rot = curr_rot;
        Scooter_Audio_Play();

    }



    private void Get_axel( Vector2 ControllerInput )
    {
        if (ControllerInput.x < 0 && rb.velocity.magnitude > 0.0f)
        {

            totalTorque = 790 * Mathf.Abs(ControllerInput.x) - 950 * Mathf.Abs(ControllerInput.x * ControllerInput.x)
                                + 920 * Mathf.Abs(ControllerInput.x * ControllerInput.x * ControllerInput.x);

            if (rb.velocity.magnitude >= MaxSpeed)
            {
                totalTorque = -MaxbrakeTorque * Mathf.Abs(ControllerInput.x);
            }

        }

        else
        {
            if (rb.velocity.magnitude >= 0.5)
            {
                totalTorque =  -MaxbrakeTorque * Time.deltaTime;
            }

            else
            {
                rb.velocity = new Vector3(0, 0, 0);
                totalTorque = 0;
            }

        }
    }

    private void Get_brake( bool brake_button )
    {
        if ( brake_button == true ) 
        {
            if (rb.velocity.magnitude >= 0.5)
            {
                totalTorque = -MaxbrakeTorque;

            }

            else
            {
                rb.velocity = new Vector3(0, 0, 0);
                totalTorque = 0;
            }

        }

    }

    private void Apply_torque()
    {
        FR_wh.motorTorque = 1.6f * totalTorque / 4;
        FL_wh.motorTorque = 1.6f * totalTorque / 4;

        BR_wh.motorTorque = 0.4f * totalTorque / 4;
        BL_wh.motorTorque = 0.4f * totalTorque / 4;
    }
    
    private void Applyt_rotation()
    {

        float curr_angle = FR_wh.steerAngle + chagned_rot / 5;

        FR_wh.steerAngle = Mathf.Clamp(curr_angle, -MaxRotation, MaxRotation);
        FL_wh.steerAngle = Mathf.Clamp(curr_angle, -MaxRotation, MaxRotation);



    }

    private void Scooster_Initialize()
    {
        FR_wh.motorTorque = 0;
        FL_wh.motorTorque = 0;
        BR_wh.motorTorque = 0;
        BL_wh.motorTorque = 0;

        FR_wh.steerAngle = 0;
        FL_wh.steerAngle = 0;



        //Quaternion play_rotation = player.transform.rotation;
        //gameObject.transform.rotation = player.transform.rotation;
        //gameObject.transform.position = player.transform.position - new Vector3(0, player.transform.position.y, 0)  ;


        //Vector3 player_rot = player.transform.localEulerAngles;
        //gameObject.transform.position = player.transform.rotation * new Vector3(0, 0, 0.2f);



    }

    private void Scooter_Audio_Play()
    {
        scooter_audio.volume = 0.7f * (rb.velocity.magnitude / MaxSpeed ); 
        if (rb.velocity.magnitude >= 1 & !scooter_audio.isPlaying)
        {
            scooter_audio.Play();
        }

        else if (rb.velocity.magnitude < 1 & scooter_audio.isPlaying)
        { 
            scooter_audio.Stop(); 
        }
    }

    private void Scooter_Stopping()
    {
        rb.velocity = new Vector3(0, 0, 0);
        FR_wh.steerAngle = 0;
        FR_wh.steerAngle = 0;
        totalTorque = 0;

        FR_wh.motorTorque = 0;
        FL_wh.motorTorque = 0;
        BR_wh.motorTorque = 0;
        BL_wh.motorTorque = 0;
    }

}
