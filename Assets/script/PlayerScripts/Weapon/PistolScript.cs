using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PistolScript : MonoBehaviour
{
    public Weapon pistol;
    public Camera cam;
    public TextMeshProUGUI ammo;

    Animator anim;

    public float range = 1000f;
    public float fireRate = 0.1f;
    public float nextShot = 0f;

    public int currentAmmo;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentAmmo = pistol.BaseAmmo;
        ammo.text = currentAmmo + "/" + pistol.BaseAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if((anim.GetInteger("State") == 4) && (Time.time >= nextShot) && (currentAmmo > 0))
        {
            nextShot = Time.time + 1 / fireRate;
            currentAmmo--;
            ammo.text = currentAmmo + "/" + pistol.BaseAmmo;
            Shoot();
        }

        if(currentAmmo != pistol.BaseAmmo && anim.GetInteger("State") == 5)
        {
            currentAmmo = pistol.BaseAmmo;
            ammo.text = currentAmmo + "/" + pistol.BaseAmmo;
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.tag);

            if(hit.transform.tag == "Slime")
            {
                SlimeScript slime = hit.transform.GetComponent<SlimeScript>();
                
                slime.Hit(pistol.Damage);
            }
            else if (hit.transform.tag == "SlimeHead")
            {
                SlimeScript slime = hit.transform.gameObject.GetComponentInParent<SlimeScript>();
                             
                slime.crit(pistol.Damage);
            }
            
        }
    }
}
