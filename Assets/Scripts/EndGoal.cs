using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    [SerializeField]
    StartGoal nextGoal;
    [SerializeField]
    private ParticleSystem ps;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            StartCoroutine(Spawn(other));
        }
    }

    private IEnumerator Spawn(Collider other)
    {

        ParticleSystem cloneEnd = Instantiate(ps);
        cloneEnd.transform.position = other.transform.position;
        other.GetComponentInChildren<MeshRenderer>().enabled = false;

        float t = 0;
        ParticleSystem cloneStart = null;
        while (t < 2)
        {
            other.transform.position = cloneEnd.transform.position;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;//we can abstract all this and have the goals determine velocity on spawn but later...
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            t += Time.deltaTime;
            if(t > 1)
                other.transform.position = nextGoal.transform.position;
            if (t > 1.7)
            {
                if (cloneStart == null)
                {
                    cloneStart = Instantiate(ps);
                    cloneStart.transform.position = nextGoal.transform.position;
                }
            }
            yield return null;
        }
        other.GetComponentInChildren<MeshRenderer>().enabled = true;
        Destroy(cloneStart.gameObject);
        Destroy(cloneEnd.gameObject);

    }
}
