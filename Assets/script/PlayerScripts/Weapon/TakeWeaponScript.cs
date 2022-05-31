using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeaponScript : MonoBehaviour
{
    float distanse = 3.0f; 

   
    public GameObject Sword;

    
    void Start()
    {
        //WeaponCount = 1;
        // FakePistol = GameObject.FindGameObjectsWithTag("Fake");
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanse) && ((hit.transform.tag == "Pistol") || (hit.transform.tag == "Shotgun")))
            {
                GameObject FakePistol = hit.transform.gameObject;
                 
                if ((Sword.gameObject.transform.parent.transform.childCount < 3) && (Sword.activeSelf))
                {
                    TakeWeapon(FakePistol, Sword);
                }
                else if (Sword.activeSelf)
                {
                    DropWeapon(Sword.gameObject.transform.parent.transform.GetChild(1).gameObject);
                    TakeWeapon(FakePistol,Sword);
                }
                else if ((Sword.gameObject.transform.parent.transform.GetChild(1).gameObject.activeSelf) && (Sword.gameObject.transform.parent.transform.childCount < 3))
                {
                    TakeWeapon(FakePistol, Sword.gameObject.transform.parent.transform.GetChild(1).gameObject);
                } 
                else if (Sword.gameObject.transform.parent.transform.GetChild(1).gameObject.activeSelf)
                {
                    DropWeapon(Sword.gameObject.transform.parent.transform.GetChild(1).gameObject);
                    TakeWeapon(FakePistol, Sword.gameObject.transform.parent.transform.GetChild(1).gameObject);
                }
                else if ((Sword.gameObject.transform.parent.transform.childCount == 3) && (Sword.gameObject.transform.parent.transform.GetChild(2).gameObject.activeSelf)) 
                {
                    TakeWeapon(FakePistol, Sword.gameObject.transform.parent.transform.GetChild(2).gameObject);
                    DropWeapon(Sword.gameObject.transform.parent.transform.GetChild(2).gameObject);
                }

            }
            
        }

    }

    void TakeWeapon(GameObject FakePistol, GameObject ActiveWeapon)
    {
        //if(FakePistol.tag == "Pistol")
        //{
        //    FakePistol.GetComponent<PistolScript>().isTaken = true;
        //}
        FakePistol.transform.parent = ActiveWeapon.transform.parent;
        Rigidbody rig = FakePistol.GetComponent<Rigidbody>();
        rig.isKinematic = true;
        rig.constraints = RigidbodyConstraints.None;

        FakePistol.GetComponent<BoxCollider>().enabled = false;

        FakePistol.transform.localPosition = new Vector3(0, 0, 0);
        FakePistol.transform.localRotation = new Quaternion(0, 0, 0, 0);

        if (FakePistol.tag == "Shotgun")
        {
            FakePistol.transform.localRotation = new Quaternion(0, -82, 0, 0);
        }

        FakePistol.GetComponent<Animator>().enabled = true;

        ActiveWeapon.SetActive(false);
        ActiveWeapon.gameObject.transform.parent.GetComponent<WeaponSwitch>().weaponSwitch = ActiveWeapon.gameObject.transform.parent.transform.childCount;
        FakePistol.GetComponent<GenericGun>().isTaken = true;
        ActiveWeapon.GetComponent<GenericGun>().isTaken = false;
    }   
    
    void DropWeapon(GameObject PistolOne)
    {
        //if (PistolOne.tag == "Pistol")
        //{
        //    PistolOne.GetComponent<PistolScript>().isTaken = false;
        //}
        PistolOne.SetActive(true);
        PistolOne.gameObject.transform.parent = null;
        
        Rigidbody rig = PistolOne.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.constraints = RigidbodyConstraints.FreezeAll;

        PistolOne.GetComponent<BoxCollider>().enabled = true;
        PistolOne.GetComponent<Animator>().enabled = false;

        PistolOne.transform.position = new Vector3(PistolOne.transform.position.x, 0.262f, PistolOne.transform.position.z);
        PistolOne.transform.localRotation = new Quaternion(0, PistolOne.transform.rotation.y, PistolOne.transform.rotation.z, PistolOne.transform.rotation.w);
        PistolOne.GetComponent<GenericGun>().isTaken = false;
    }
}
