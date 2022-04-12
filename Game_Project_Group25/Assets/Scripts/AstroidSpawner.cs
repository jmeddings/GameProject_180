using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour
{
    public GameObject AstroidPrefab;
    public int AstroidFreq;
    public int AstroidStart;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("AstroidFall", 0f + AstroidStart, 2f + AstroidFreq);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AstroidFall()
    {
        Instantiate(AstroidPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}
