using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PistolScript : GenericGun
{
    public Weapon pistol;
    public Camera cam;

    Animator anim;

    public float range = 1000f;
    public float fireRate = 0.1f;
    public float nextShot = 0f;

    int currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
        anim = GetComponent<Animator>();
        currentAmmo = GetComponent<WeaponAnimationScript>().curAmmo = GetComponent<WeaponAnimationScript>().baseAmmo = pistol.BaseAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTaken)
        {
            if ((anim.GetInteger("State") == 4) && (Time.time >= nextShot) && (currentAmmo > 0))
            {
                nextShot = Time.time + 1 / fireRate;
                currentAmmo--;
                GetComponent<WeaponAnimationScript>().curAmmo = currentAmmo;
                Debug.Log("pew");
                Shoot();
            }
            else if (currentAmmo == 0)
            {
                GetComponent<WeaponAnimationScript>().curAmmo = currentAmmo;
            }

            if (currentAmmo != pistol.BaseAmmo && anim.GetInteger("State") == 5)
            {
                currentAmmo = pistol.BaseAmmo;
                GetComponent<WeaponAnimationScript>().curAmmo = currentAmmo;
                // ammo.text = currentAmmo + "/" + pistol.BaseAmmo;
            }
            else if (currentAmmo == pistol.BaseAmmo)
            {
                GetComponent<WeaponAnimationScript>().curAmmo = GetComponent<WeaponAnimationScript>().baseAmmo;
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
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
