using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorU;
    public GameObject doorR;
    public GameObject doorL;
    public GameObject doorD;


    float distanse = 2.0f;
    public void RotateRandom()
   {
        int count = Random.Range(0,4);

        for(int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);

            GameObject tmp = doorL;
            doorL = doorD;
            doorD = doorR;
            doorR = doorU;
            doorU = tmp;
        }
   }

    void Update()
    {
        if (GlobalStatistic.EnemyCount > 0)
        {
            if(doorU != null && doorU.GetComponent<DoorLock>() != null)
            {
                doorU.GetComponent<DoorLock>().isLock = true;
            }
            if (doorD != null && doorD.GetComponent<DoorLock>() != null)
            {
                doorD.GetComponent<DoorLock>().isLock = true;
            }
            if (doorR != null && doorR.GetComponent<DoorLock>() != null)
            {
                doorR.GetComponent<DoorLock>().isLock = true;
            }
            if (doorL != null && doorL.GetComponent<DoorLock>() != null)
            {
                doorL.GetComponent<DoorLock>().isLock = true;
            }
        }
        else
        {
            if (doorU != null && doorU.GetComponent<DoorLock>() != null)
            {
                doorU.GetComponent<DoorLock>().isLock = false;
            }
            if (doorD != null && doorD.GetComponent<DoorLock>() != null)
            {
                doorD.GetComponent<DoorLock>().isLock = false;
            }
            if (doorR != null && doorR.GetComponent<DoorLock>() != null)
            {
                doorR.GetComponent<DoorLock>().isLock = false;
            }
            if (doorL != null && doorL.GetComponent<DoorLock>() != null)
            {
                doorL.GetComponent<DoorLock>().isLock = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanse))
            {

                if (hit.transform.gameObject == doorU && doorU.GetComponent<DoorLock>() != null)
                    if(!doorU.GetComponent<DoorLock>().isLock)
                    {
                        doorU.GetComponent<Animator>().SetInteger("state", 1);
                    }
                if (hit.transform.gameObject == doorD && doorD.GetComponent<DoorLock>() != null)
                    if (!doorD.GetComponent<DoorLock>().isLock)
                    {
                        doorD.GetComponent<Animator>().SetInteger("state", 1);
                    }
                if (hit.transform.gameObject == doorR && doorR.GetComponent<DoorLock>() != null)
                    if (!doorR.GetComponent<DoorLock>().isLock)
                    {
                        doorR.GetComponent<Animator>().SetInteger("state", 1);
                    }
                if (hit.transform.gameObject == doorL && doorL.GetComponent<DoorLock>() != null)
                    if (!doorL.GetComponent<DoorLock>().isLock)
                    {
                        doorL.GetComponent<Animator>().SetInteger("state", 1);
                    }
            }
        }
    }

}
