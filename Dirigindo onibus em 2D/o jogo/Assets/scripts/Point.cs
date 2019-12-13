using UnityEngine;
using System.Collections;

public class Point : MonoBehaviour 
{
	public int point;

	void OnTriggerEnter2D(Collider2D other) 
	{
		Destroy (this.gameObject);

		if(other.gameObject.tag=="Player")
		{
			other.GetComponent<Player>().point+=point;
		}
	}



}
