using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // Määritetään kolikon pyörimis nopeus
    private int rotateSpeed = 1;

    void Update()
    {
        // Pyöritetään kolikkoa määritetyllä nopeudella
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
