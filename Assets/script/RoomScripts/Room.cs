using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject doorU;
    public GameObject doorR;
    public GameObject doorL;
    public GameObject doorD;

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

}
