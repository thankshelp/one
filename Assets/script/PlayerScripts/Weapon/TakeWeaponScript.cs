using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeWeaponScript : MonoBehaviour
{
    float distanse = 3.0f; 

   
    public GameObject Sword; 

    //int WeaponCount;

    
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

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanse) && (hit.transform.tag == "Pistol"))
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

        FakePistol.transform.parent = ActiveWeapon.transform.parent;
        Rigidbody rig = FakePistol.GetComponent<Rigidbody>();
        rig.isKinematic = true;
        rig.constraints = RigidbodyConstraints.None;

        FakePistol.GetComponent<BoxCollider>().enabled = false;

        FakePistol.transform.localPosition = new Vector3(0, 0, 0);
        FakePistol.transform.localRotation = new Quaternion(0, 0, 0, 0);

        ActiveWeapon.SetActive(false);
        ActiveWeapon.gameObject.transform.parent.GetComponent<WeaponSwitch>().weaponSwitch = ActiveWeapon.gameObject.transform.parent.transform.childCount;
    }   
    
    void DropWeapon(GameObject PistolOne)
    {
        PistolOne.SetActive(true);
        PistolOne.gameObject.transform.parent = null;

        PistolOne.transform.rotation = new Quaternion(0, 0, 0, 0);
        PistolOne.transform.position = new Vector3(PistolOne.transform.position.x, 0.262f, PistolOne.transform.position.z);

        Rigidbody rig = PistolOne.GetComponent<Rigidbody>();
        rig.isKinematic = false;
        rig.constraints = RigidbodyConstraints.FreezeAll;

        PistolOne.GetComponent<BoxCollider>().enabled = true;
    }
}
