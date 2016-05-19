using UnityEngine;
using System.Collections;

public class enemyBulletScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject, 1);
	
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		
		//gets rid of the bullet if it hits something
		if((other.gameObject.tag == "Floor")||(other.gameObject.tag == "Wall")||(other.gameObject.tag == "Player"))
		{
			
			Destroy (gameObject);
		}
	}
}
