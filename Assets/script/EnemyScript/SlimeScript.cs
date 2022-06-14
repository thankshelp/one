using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeScript : MonoBehaviour
{
    
    public Vector3 positionSlime;
    public float SlimeHealth = 30f;
    public float SlimeDamage = 10f;
    //public SwordScript sword;

    public bool attaked = false;
    public bool death = false;

    // Start is called before the first frame update
    void Start()
    {
       //sword = GameObject.FindGameObjectWithTag("Sword").transform;
        positionSlime = this.transform.position;
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Sword")
        {
            SwordScript sword = collider.gameObject.GetComponent<SwordScript>();
            Hit(sword.weapon.Damage);
        }
    }

    public void Hit(float damage)
    {
        SlimeHealth -= damage;
        attaked = true;

        FindObjectOfType<AudioManager>().Play("SlimeHit");

        //Debug.Log(SlimeHealth);

        if (SlimeHealth <= 0 && death == false)
        {
            death = true;
            GlobalStatistic.EnemyCount--;
            
        }
    }

    public void crit(float damage)
    {
        SlimeHealth -= (damage + damage / 2);
        attaked = true;

        FindObjectOfType<AudioManager>().Play("SlimeHit");

        //Debug.Log(SlimeHealth);

        if (SlimeHealth <= 0 && death == false)
        {
            death = true;
            GlobalStatistic.EnemyCount--;
        }
    }


}
