using UnityEngine;
using System.Collections;

public class brawlerAttackScript : MonoBehaviour {

	public GameObject player;

	public float force;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
	

	}
	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject, 1);
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{


			Vector3 dir = transform.position - player.transform.position;

			player.GetComponent<Rigidbody2D>().AddForce(-dir.normalized*force*Time.deltaTime);

		}
	}


}
