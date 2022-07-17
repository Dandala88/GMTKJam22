using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{
    [SerializeField]
    private StartGoal beginningStartGoal;

    public static StartGoal currentGoal;

    private StartGoal CurrentGoal
    {
        get { return currentGoal; }
    }

    [SerializeField]
    private ParticleSystem psDeath;
    [SerializeField]
    private ParticleSystem psSpawn;
    private AudioSource a;

    private void Awake()
    {

        a = GetComponent<AudioSource>();
        currentGoal = beginningStartGoal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            a.PlayOneShot(a.clip);
            StartCoroutine(Spawn(other.gameObject));
        }
    }

    private IEnumerator Spawn(GameObject other)
    {

        ParticleSystem cloneEnd = Instantiate(psDeath);
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
            if (t > 1)
                other.transform.position = CurrentGoal.transform.position;
            if (t > 1.7)
            {
                if (cloneStart == null)
                {
                    cloneStart = Instantiate(psSpawn);
                    cloneStart.transform.position = CurrentGoal.transform.position;
                }
            }
            yield return null;
        }
        other.GetComponentInChildren<MeshRenderer>().enabled = true;
        HUD.ResetTime();
        Destroy(cloneStart.gameObject);
        Destroy(cloneEnd.gameObject);

    }

    public void ResetPlayer()
    {
        PlayerController player = FindObjectOfType<PlayerController>();

        StartCoroutine(Spawn(player.gameObject));
    }
}
