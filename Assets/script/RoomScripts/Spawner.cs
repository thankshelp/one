using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    public float startTime;
    private float spawnTime;

    int waveCont = 3;
    int currWave;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = 0;
        currWave = waveCont;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTime != startTime && currWave != 0)
        {
            for(int spawnPoint = 0; spawnPoint < 3; spawnPoint++)
            {
                Vector3 pos;
                pos.x = this.transform.position.x + Random.Range(-4, 4);
                pos.y = this.transform.position.y;
                pos.z = this.transform.position.z + Random.Range(-4, 4);

                Instantiate(enemy, pos, Quaternion.identity);

                GlobalStatistic.EnemyCount++;

                spawnTime = 0;
            }
            currWave--;
        }
        else if (currWave != 0)
        {
            spawnTime += Time.deltaTime;
        }

        //    foreach (Transform t in spawnPoint)
        //    {
        //        Instantiate(enemy, t.transform.position, Quaternion.identity);
        //        spawnTime = 0;

        //        GlobalStatistic.EnemyCount++;
        //    }

        //    currWave--;
        //}


    }
}
