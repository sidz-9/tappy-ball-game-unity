using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnner : MonoBehaviour
{
    public float maxYpos;
    public float spawnTime;
    public GameObject pipes;


    // Start is called before the first frame update
    void Start()
    {
        StartSpawnningPipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartSpawnningPipes() {
        InvokeRepeating("SpawnPipe", 0.2f, spawnTime);
    }
    public void StopSpawnningPipes() {
        CancelInvoke("SpawnPipe");
    }
    void SpawnPipe() {
        Instantiate(pipes, new Vector3(transform.position.x, Random.Range(-maxYpos, maxYpos), 0), Quaternion.identity);
    }
}
