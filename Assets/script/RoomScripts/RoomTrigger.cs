using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour
{
    public GameObject enemy;

    int countTrigger=0;

    int waveCont = 3;
    int currWave;

    public float startTime;
    private float spawnTime;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (countTrigger == 0)
        {
            if (this.GetComponentInParent<Room>().doorU != null)
            {
                this.GetComponentInParent<Room>().doorU.GetComponent<Animator>().SetInteger("state", 2);
            }
            if (this.GetComponentInParent<Room>().doorD != null)
            {
                this.GetComponentInParent<Room>().doorD.GetComponent<Animator>().SetInteger("state", 2);
            }
            if (this.GetComponentInParent<Room>().doorL != null)
            {
                this.GetComponentInParent<Room>().doorL.GetComponent<Animator>().SetInteger("state", 2);
            }
            if (this.GetComponentInParent<Room>().doorR != null)
            {
                this.GetComponentInParent<Room>().doorR.GetComponent<Animator>().SetInteger("state", 2);
            }
            spawnTime = startTime = 10f;
             

            //if (FindObjectOfType<roomPlacer>().floor)
            //{
            //    for (int spawnPoint = 0; spawnPoint < 3; spawnPoint++)
            //    {
            //        Vector3 pos;
            //        pos.x = this.transform.position.x + Random.Range(-4, 4);
            //        pos.y = this.transform.position.y;
            //        pos.z = this.transform.position.z + Random.Range(-4, 4);

            //        Instantiate(enemy, pos, Quaternion.identity);

            //        GlobalStatistic.EnemyCount++;
            //    }
            //    currWave++;
            //}
        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        if (FindObjectOfType<roomPlacer>().floor)
        {
            
            if (spawnTime >= startTime && currWave < 3)
            {
                
                for (int spawnPoint = 0; spawnPoint < 3; spawnPoint++)
                {
                    Vector3 pos;
                    pos.x = this.transform.position.x + Random.Range(-4, 4);
                    pos.y = this.transform.position.y;
                    pos.z = this.transform.position.z + Random.Range(-4, 4);

                    Instantiate(enemy, pos, Quaternion.identity);

                    GlobalStatistic.EnemyCount++;
                   
                }
                currWave++;
                spawnTime = 0f;
            }
            else if (currWave < 3)
            {
                spawnTime += Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        countTrigger++;
        currWave = 0;
    }
}
