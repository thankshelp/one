using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Look : MonoBehaviour
{
    public static bool cursorLock = true;
    //public GameObject menu;

    public Transform player;
    public Transform cam;

    [Range(50f, 200f)]
    public float xSens = 70f;
    [Range(50f, 200f)]
    public float ySens = 70f;
    //public float maxAngle;
    public Slider sensSlider;
    

    Quaternion Center;
    // Start is called before the first frame update
    void Start()
    {
        Center = cam.localRotation;
        xSens = ySens = FindObjectOfType<MusicManager>().s * 150 + 50;
        sensSlider.value = FindObjectOfType<MusicManager>().s;
    }

    // Update is called once per frame
    void Update()
    {
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    cursorLock = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //if (Input.GetKeyDown(KeyCode.Escape))
            //    cursorLock = true;
        }

        setY();
        setX();

    }

    public void sensChenged()
    {
        xSens = sensSlider.value * 150 + 50;
        ySens = sensSlider.value * 150 + 50;

        FindObjectOfType<MusicManager>().s = sensSlider.value;
    }

    void setY()
    {
        float mouseY = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion yRot = cam.localRotation * Quaternion.AngleAxis(mouseY, -Vector3.right);

        if (Quaternion.Angle(Center, yRot) < 90f)
        {
            cam.localRotation = yRot;
        }

    }

    void setX()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSens * Time.deltaTime;
        Quaternion xRot = player.localRotation * Quaternion.AngleAxis(mouseX, Vector3.up);

        player.localRotation = xRot;
    }

    
}
