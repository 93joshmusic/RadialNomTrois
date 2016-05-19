using UnityEngine;
using System.Collections;

public class leftSpawnScript : MonoBehaviour {

	public float timer;
	public float timer2;

    public GameManager Manager;
	public GameObject brawler;
	public GameObject floater;
	// Use this for initialization
	void Start () {
	
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Manager.Status == GameManager.GameState.InGame)
        {
            //spawn a brawler ever 4 seconds
            timer += Time.deltaTime;
			timer2 += Time.deltaTime;

            if (timer > 5)
            {
                Instantiate(brawler, transform.position, Quaternion.identity);
                timer = 0;
            }
			if(timer2 >7)
			{
				Instantiate(floater, transform.position, Quaternion.identity);
				timer2 = 0;
			}
        }
	}
}
