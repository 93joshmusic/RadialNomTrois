using UnityEngine;
using System.Collections;

public class leftSpawnScript : MonoBehaviour {

	public float timer;

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

            if (timer > 5)
            {
                int ran = Random.Range(0, 2);
                if(ran == 0)
                {
                    Instantiate(brawler, transform.position, Quaternion.identity);

                }
                else
                {
                    Instantiate(floater, transform.position, Quaternion.identity);

                }
                timer = 0;
            }
        }
	}
}
