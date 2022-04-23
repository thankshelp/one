using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    
    public Vector3 positionSlime;
    public int SlimeHealth = 30;
    public int SlimeDamage = 10;
    public SwordScript sword;

    // Start is called before the first frame update
    void Start()
    {
        positionSlime = this.transform.position;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Sword")
        {
            sword = collision.collider.gameObject.GetComponent<SwordScript>();
            SlimeHealth -= sword.weapon.Damage;
        }
    }
}
