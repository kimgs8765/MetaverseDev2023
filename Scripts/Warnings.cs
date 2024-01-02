using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warnings : MonoBehaviour
{
    [SerializeField]  GameObject Warning;
    [SerializeField] GameObject Lane;

    private void OnTriggerStay(Collider other)
    {   
        if (other.tag == "Sidewalk")
        {
            Debug.LogWarning(Warning.tag);
            Warning.SetActive(true);
        }

        if (other.tag == "1st2ndLane")
        {
            Lane.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sidewalk")
        {
            Warning.SetActive(false);
        }

        if (other.tag == "1st2ndLane")
        {
            Lane.SetActive(false);
        }

    }
}
