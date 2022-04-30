using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SlimeScript : MonoBehaviour
{
    
    public Vector3 positionSlime;
    public float SlimeHealth = 30f;
    public float SlimeDamage = 10f;
    public SwordScript sword;

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
            sword = collider.gameObject.GetComponent<SwordScript>();
            Hit(sword.weapon.Damage);
        }
    }

    public void Hit(float damage)
    {
        SlimeHealth -= damage;
        attaked = true;

        Debug.Log(SlimeHealth);

        if (SlimeHealth <= 0)
        {
            death = true;
        }
    }

    public void crit(float damage)
    {
        SlimeHealth -= (damage + damage / 2);
        attaked = true;

        Debug.Log(SlimeHealth);

        if (SlimeHealth <= 0)
        {
            death = true;
        }
    }


}
