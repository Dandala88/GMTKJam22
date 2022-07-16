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
            ParticleSystem clone = Instantiate(ps);
            clone.transform.position = other.transform.position;
            other.GetComponentInChildren<MeshRenderer>().enabled = false;
            StartCoroutine(Spawn(other.transform));
        }
    }

    private IEnumerator Spawn(Transform player)
    {
        float t = 0;
        while(t < 2)
        {
            t += Time.deltaTime;
            if(t > 1)
                player.position = nextGoal.transform.position;

            if (t > 1.8)
            {
                ParticleSystem clone = Instantiate(ps);
                clone.transform.position = nextGoal.transform.position;
            }
            yield return null;
        }
        player.GetComponentInChildren<MeshRenderer>().enabled = true;
    }
}
