using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Director : MonoBehaviour
{
    public DirectionTracker currentTracker;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        if (currentTracker != null)
        {
            currentTracker.setForward(new Vector3(transform.forward.x, 0, transform.forward.z));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            currentTracker = other.GetComponentInChildren<DirectionTracker>();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            currentTracker = null;
        }
    }
}
