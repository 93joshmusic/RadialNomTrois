using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloaterScript : MonoBehaviour {

	public float speed;
	public float health;

	public GameObject player;

	public int moveDirection;
	public Quaternion correctRot;

	public Slider SliderForHealth;

	public Vector3 xDirection;

	public bool attacking;

	public float distance;

	public GameObject bullet;

	public float bulletSpeed;

	public float timer;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

		if (transform.position.x > 11) {
			moveDirection = -1;
			correctRot = new Quaternion (0, 0,0,0);
		} else {
			moveDirection = 1;
			correctRot = new Quaternion (0, 180,0,0);

			attacking = false;
		}

	
	}
	
	// Update is called once per frame
	void Update () {

		GameObject Manager = GameObject.Find("GameManager");
		GameManager Man = (GameManager)Manager.GetComponent("GameManager");
		if (Man.Status == GameManager.GameState.InGame) {
			//SliderForHealth.value = health;//Shows health on slider
			
			//works out whether the player is behind or in front of the brawler
			xDirection = transform.position - player.transform.position;
			
			if (health < 0) {
				Destroy (gameObject);
			}


			
			RaycastHit2D rayCastHit = Physics2D.Raycast (transform.position, -xDirection, 5f);
			
			if ((rayCastHit.collider != null)&&(rayCastHit.collider.name == "Player"))
			{
				timer += Time.deltaTime;
				
					if (timer >0.5f)
					{
						GameObject projectile = (GameObject)Instantiate(bullet, new Vector3(transform.position.x,transform.position.y+0.5f,transform.position.z), Quaternion.identity);
						projectile.GetComponent<Rigidbody2D>().velocity = -xDirection * bulletSpeed;

						timer = 0;
					}


			}

			else if ((rayCastHit.collider == null)||(rayCastHit.collider.name != "Player"))
			{

			

				transform.rotation = correctRot;
				transform.Translate(new Vector3(moveDirection, 0, 0) * speed * Time.deltaTime, Space.World);
				correctRot = transform.rotation;



			}
			
		}
	
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		//change direction if wall or other brawler
		if((col.gameObject.tag == "Wall")||(col.gameObject.tag == "Brawler"))
		{
			speed = -speed;
			
			transform.Rotate (new Vector3(0,180,0));
			
			correctRot = transform.rotation;
			
			
		}
		
		
		
		
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Bullet")
		{
			health --;
		}
	}
	
	void OnDestroy()
	{
		characterController Chr = (characterController)player.GetComponent("characterController");
		Chr.Score += 10;
	}

}
