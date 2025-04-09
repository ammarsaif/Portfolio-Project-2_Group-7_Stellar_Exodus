using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    public float fallSpeed = 1.5f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }
}
