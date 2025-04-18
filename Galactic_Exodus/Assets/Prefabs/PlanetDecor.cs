using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetDecor : MonoBehaviour
{
    public float speed = 5f;
    public float lifeTime = 7f;

    void Start()
    {
        Destroy(this.gameObject,lifeTime);
    }
    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime;
    }
}
