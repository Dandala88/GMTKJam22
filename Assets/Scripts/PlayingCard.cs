using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayingCard : MonoBehaviour
{
    [SerializeField]
    List<Material> cardFaces;

    private MeshRenderer mesh;

    private void Awake()
    {
        mesh = GetComponent<MeshRenderer>();
        int randomRange = cardFaces.Count;
        int roll = Random.Range(0, randomRange);
        mesh.material = cardFaces[roll];
    }
}
