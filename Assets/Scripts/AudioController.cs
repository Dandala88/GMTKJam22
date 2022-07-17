using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioClip[] feltCollisions;
    public AudioClip[] cardCollisions;
    public AudioClip rollingLoop;
    public AudioSource audioSource;
    public PlayerController pc;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        float[] nums = new float[2] { -0.5f, 0.5f };
        foreach (var x in nums)
        {
            foreach (var y in nums)
            {
                foreach (var z in nums)
                {
                    var newCollider = transform.gameObject.AddComponent<SphereCollider>();
                    newCollider.center = new Vector3(x, y, z);
                    newCollider.isTrigger = true;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if (pc.getRollingStatus() && !audioSource.isPlaying)
        // {
        //     audioSource.PlayOneShot(feltCollisions[Random.Range(0, feltCollisions.Length)]);
        // }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(feltCollisions[Random.Range(0, feltCollisions.Length)]);
        }
    }
}
