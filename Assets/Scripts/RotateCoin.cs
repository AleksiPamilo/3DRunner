using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCoin : MonoBehaviour
{
    // M��ritet��n kolikon py�rimis nopeus
    private int rotateSpeed = 1;

    void Update()
    {
        // Py�ritet��n kolikkoa m��ritetyll� nopeudella
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}
