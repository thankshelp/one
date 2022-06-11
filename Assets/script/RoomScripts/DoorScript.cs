using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : DoorLock
{
    float distanse = 2.0f;
    // Update is called once per frame
    void Update()
    {
        if (GlobalStatistic.EnemyCount > 0)
        {
            isLock = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanse) && hit.transform.tag == "Door")
            {
                if (!isLock)
                {
                    //анимация двери

                }
            }
        }
    }
}
