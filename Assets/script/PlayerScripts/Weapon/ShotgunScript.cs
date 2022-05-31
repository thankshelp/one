using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : GenericGun
{
    public Weapon shotgun;

    public Camera cam;
    
    Animator anim;

    int currentAmmo;
    public float min_inaccurate = -0.5f;
    public float max_inaccurate = 0.5f;

    public float range = 500f;
    public float fireRate = 0.1f;
    public float nextShot = 0f;

    public GameObject FirePoint;

    public GameObject[] lineObject;

    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false;
        anim = GetComponent<Animator>();
        currentAmmo = GetComponent<WeaponAnimationScript>().curAmmo = GetComponent<WeaponAnimationScript>().baseAmmo = shotgun.BaseAmmo;
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
                Shoot();
            }
            else if (currentAmmo == 0)
            {
                GetComponent<WeaponAnimationScript>().curAmmo = currentAmmo;
            }

            if (currentAmmo != shotgun.BaseAmmo && anim.GetInteger("State") == 5)
            {
                currentAmmo = shotgun.BaseAmmo;
                GetComponent<WeaponAnimationScript>().curAmmo = currentAmmo;
                // ammo.text = currentAmmo + "/" + pistol.BaseAmmo;
            }
            else if (currentAmmo == shotgun.BaseAmmo)
            {
                GetComponent<WeaponAnimationScript>().curAmmo = GetComponent<WeaponAnimationScript>().baseAmmo;
            }
        }
    }

    void Shoot()
    {
        for(int rey_count = 4; rey_count>= 0; rey_count--)
        {
            

            line = lineObject[rey_count].GetComponent<LineRenderer>();
            line.startWidth = 0.1f;
            line.endWidth = 0.1f;
            
            RaycastHit hit;

            FirePoint.transform.localRotation = Quaternion.identity;

            FirePoint.transform.localRotation = Quaternion.Euler(
                FirePoint.transform.localRotation.x + Random.Range(min_inaccurate, max_inaccurate), 
                FirePoint.transform.localRotation.y + Random.Range(min_inaccurate, max_inaccurate), 
                FirePoint.transform.localRotation.z + Random.Range(min_inaccurate, max_inaccurate));

            Debug.Log(FirePoint.transform.localRotation);

            Vector3 fwd = FirePoint.transform.TransformDirection(Vector3.forward);

            

            line.SetPosition(0, FirePoint.transform.position);
            line.SetPosition(1, fwd);

            //fwd.x = fwd.x + Random.Range(min_inaccurate, max_inaccurate);
            //fwd.y = fwd.y + Random.Range(min_inaccurate, max_inaccurate);
            //fwd.z = fwd.z + Random.Range(min_inaccurate, max_inaccurate);

            if (Physics.Raycast(cam.transform.position, fwd, out hit, range))
            {
                Debug.Log(hit.transform.tag);

                

                //Instantiate(point, hit.transform.position, Quaternion.identity);

                if (hit.transform.tag == "Slime")
                {
                    SlimeScript slime = hit.transform.GetComponent<SlimeScript>();

                    slime.Hit(shotgun.Damage);
                }
                else if (hit.transform.tag == "SlimeHead")
                {
                    SlimeScript slime = hit.transform.gameObject.GetComponentInParent<SlimeScript>();

                    slime.crit(shotgun.Damage);
                }

            }
        }
        
    }
}
