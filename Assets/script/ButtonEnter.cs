using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEnter : MonoBehaviour, IPointerEnterHandler
{
    AudioManager AM;

     void Start()
     {
        AM = FindObjectOfType<AudioManager>();
     }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        AM.Play("Enter"); ;
    }
}
