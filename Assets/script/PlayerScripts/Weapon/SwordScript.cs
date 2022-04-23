using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public Weapon weapon;
    private Animator anim;

 

    public
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("State", 1);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetInteger("State", 2);
        }
        else if (Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetInteger("State", 0);
        }

        if (GetComponent<playerMove>().jump)
        {
            anim.SetInteger("State", 3);
        }
        else 
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetInteger("State", 4);
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetInteger("State", 0);
        }
       
        
    }
}
