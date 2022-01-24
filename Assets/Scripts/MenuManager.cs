using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject MenuCamera;
    private bool MenuIsActive = false;

    void Start()
    {
        MenuCamera.SetActive(false);

    }

    void Update()
    {
        // Jos ESC nappia painetaan
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Ja menu ei ole aktiivinen
            if (MenuIsActive == false)
            {
                // Asetetaan MenuCamera aktiiviseksi ja MainCamera epäaktiiviseksi
                MainCamera.SetActive(false);
                MenuCamera.SetActive(true);
                Time.timeScale = 0;
                MenuIsActive = true;

                // Asetetaan kursori näkyviin
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            // Jos menu on aktiivinen
            else if (MenuIsActive == true)
            {
                // Aseta MenuCamera epäaktiiviseksi ja MainCamera aktiiviseksi
                MenuCamera.SetActive(false);
                MainCamera.SetActive(true);
                Time.timeScale = 1;
                MenuIsActive = false;

                // Asetetaan kursori pois näkyvistä
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }

    public void ResumeGame()
    {
        // Aseta MenuCamera epäaktiiviseksi ja MainCamera aktiiviseksi
        MenuCamera.SetActive(false);
        MainCamera.SetActive(true);
        Time.timeScale = 1;
        MenuIsActive = false;

        // Asetetaan kursori pois näkyvistä
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}