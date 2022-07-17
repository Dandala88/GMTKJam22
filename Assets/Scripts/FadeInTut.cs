using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInTut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(FadeTut()); 
    }

    private IEnumerator FadeTut()
    {
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }
}
