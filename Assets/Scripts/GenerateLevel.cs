using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 100;
    public bool creatingSection = false;
    public int index;

    void Update()
    {
        if(creatingSection == false && PlayerController.gameIsRunning)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
    }

    IEnumerator GenerateSection()
    {
        // Valitaan numero 0 ja 3 v‰lill‰
        index = Random.Range(0, 4);
        // Asetetaan uusi alusta
        Instantiate(section[index], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 50;
        // Odotetaan pari sekuntia ennenkuin lis‰t‰‰n uusi alusta
        yield return new WaitForSeconds(2);
        creatingSection = false;
    }
}
