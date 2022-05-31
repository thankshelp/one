using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform spawnPoint;

    public float startTime;
    private float spawnTime;

    int waveCont = 3;
    int currWave;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnTime = startTime;
        currWave = waveCont;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0 && waveCont!=0)
        {
            Instantiate(enemy, spawnPoint.transform.position, Quaternion.identity);
            spawnTime = startTime;
            currWave--;
            waveCont--;
            GlobalStatistic.EnemyCount++;

        }
        else if (waveCont != 0)
        {
            spawnTime -= Time.deltaTime;
        }
    }
}
