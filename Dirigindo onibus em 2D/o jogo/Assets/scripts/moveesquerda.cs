using UnityEngine;
using System.Collections;

public class moveesquerda : MonoBehaviour
{
    public float vel;

    void Update()
    {
        transform.Translate(-vel * Time.deltaTime, 0, 0);
    }
}

