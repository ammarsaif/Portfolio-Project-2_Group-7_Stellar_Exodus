using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonManager : MonoBehaviour
{
    public GameObject target; // Ensure this is public
    public float speed = 10; // Ensure this is public
    public Vector3 direction = Vector3.up; // Ensure this is public

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, direction, speed * Time.deltaTime);
    }
}
