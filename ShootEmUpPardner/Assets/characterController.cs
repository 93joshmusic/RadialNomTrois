using UnityEngine;
using System.Collections;

public class characterController : MonoBehaviour {
	//how fast player moves
	public float speed;

	//how high he jumps
	public float jumpHeight;

	//stops him going too fast
	public float maxVelocity;

	//the bullet prefab
	public GameObject bullet;

	//how fast the bullets travel is changed here
	public float bulletSpeed = 5.0f;

    public GameManager Manager;
    

	public bool knockBack;

	public float health;

    public int Score;

	public GameObject ray;
	
	// Use this for initialization
	void Start () {

		ray = GameObject.FindGameObjectWithTag ("Ray");


		health = 10;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Manager.Status == GameManager.GameState.InGame)
        {
            //this kills the player
            if (health < 0)
            {
                Manager.Status = GameManager.GameState.GameOver;
            }

            //makes all the players functions pause for 0.5s when hit by the enemy


            //right
            if ((Input.GetKey(KeyCode.D)) && (GetComponent<Rigidbody2D>().velocity.x < 5))
            {

                if (transform.rotation.y == 0)
                {
                    transform.rotation = new Quaternion(0, 180, 0, 0);
                }
                GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 0, 0) * speed);



            }



            //left
            if ((Input.GetKey(KeyCode.A)) && (GetComponent<Rigidbody2D>().velocity.x > -5))
            {
                if (transform.rotation.y == 1)
                {
                    transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                GetComponent<Rigidbody2D>().AddForce(new Vector3(-1, 0, 0) * speed);

            }

            //jump
            if (Input.GetKeyDown(KeyCode.W))
            {


                Vector2 rayPos = new Vector2(transform.position.x, transform.position.y );

                RaycastHit2D rayCastHit = Physics2D.Raycast(ray.transform.position, -Vector2.up, 0.5f);



                //makes the player only jump once
                if (rayCastHit.collider != null)
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1, 0) * jumpHeight);
                }





            }

            //makes the bullet shoot towards mouse position

            if (Input.GetMouseButtonDown(0))
            {
                Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
                Vector2 direction = target - myPos;
                direction.Normalize();
                GameObject projectile = (GameObject)Instantiate(bullet, myPos, Quaternion.identity);
                projectile.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
            }


        }
		
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == ("BrawlerAttack")||other.gameObject.tag == ("EnemyBullet")) 
		{
		




			health--;

		
					
		}
	}

}
