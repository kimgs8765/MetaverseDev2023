using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Humans : MonoBehaviour
{
    [SerializeField] GameObject Scooter;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other == Scooter.GetComponent<Collider>())
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
