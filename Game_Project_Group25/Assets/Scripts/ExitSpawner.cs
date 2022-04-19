using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitSpawner : MonoBehaviour
{
    public GameObject ExitPrefab;
    public int SpawnTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ExitSpawn", 0f + SpawnTime, 100f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ExitSpawn()
    {
        Instantiate(ExitPrefab, GetComponent<Transform>().position, GetComponent<Transform>().rotation);
    }
}
