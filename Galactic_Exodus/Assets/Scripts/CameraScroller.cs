using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    public float scrollSpeed = 2f; // units per second

    void Update()
    {
        transform.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
    }
}
