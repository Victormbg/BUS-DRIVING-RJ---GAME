using UnityEngine;
using System.Collections;

public class PlatformUpDown : MonoBehaviour
{
	public float vel;
	
	void Update () 
	{
		transform.position += new Vector3(0, vel*Time.deltaTime, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "INVERT_VELOCITY")
        {
            vel *= -1;
        }
    }
}
