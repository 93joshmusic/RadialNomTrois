using UnityEngine;
using System.Collections;

public class leftSpawnScript : MonoBehaviour {

	public float timer;
    public GameManager Manager;
	public GameObject brawler;
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

            if (timer > 4)
            {
                Instantiate(brawler, transform.position, Quaternion.identity);
                timer = 0;
            }
        }
	}
}
