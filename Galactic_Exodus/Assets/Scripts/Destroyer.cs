using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float destroyDelay = 2f; // Time before destruction

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }
}