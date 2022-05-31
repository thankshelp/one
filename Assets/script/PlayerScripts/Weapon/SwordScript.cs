using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordScript : GenericGun
{
    public Weapon weapon;
    private Animator anim;
   

    //public bool CanAttack = true;
    //public float AttackCD = 1.0f;

    public GameObject player;
    
    public
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player.GetComponent<playerMove>().movement != new Vector3(0.0f, 0.0f, 0.0f))
        {
            anim.SetInteger("State", 1);
            //Debug.Log(anim.GetInteger("State"));

            if (player.GetComponent<playerMove>().sprint)
            {
                anim.SetInteger("State", 2);
            }
            else if (player.GetComponent<playerMove>().sprint == false)
            {
                anim.SetInteger("State", 1);
            }
        }
        else if(player.GetComponent<playerMove>().movement == new Vector3(0.0f, 0.0f, 0.0f))
        {
            anim.SetInteger("State", 0);
        }


        if (player.GetComponent<playerMove>().jump)
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetButtonDown("Fire1"))
        {
           // if(CanAttack)
           // {
                anim.SetInteger("State", 4);
               // CanAttack = false;
               // StartCoroutine(ResetAttackCD());
            //}
            
        }
        else if(Input.GetButtonUp("Fire1"))
        {
            anim.SetInteger("State", 0);
        }

        //Debug.Log(anim.GetInteger("State"));

        //IEnumerator ResetAttackCD()
        //{
        //    yield return new WaitForSeconds(AttackCD);
        //    CanAttack = true;
        //}

    }
}
