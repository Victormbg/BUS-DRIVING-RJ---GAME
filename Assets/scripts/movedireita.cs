using UnityEngine;
using System.Collections;

public class movedireita : MonoBehaviour
{
    public float vel;

    void Update()
    {
        transform.Translate(vel * Time.deltaTime, 0, 0);
    }
}