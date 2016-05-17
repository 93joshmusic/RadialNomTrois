using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UIBehaviour : MonoBehaviour {
    public characterController Character;
    public GameManager Manag;
    public Slider PlayerHealthBar;
    public GameObject StartingScreen;
    public GameObject GameOver;
    public Text ScoreNumber;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        PlayerHealthBar.value = Character.health;
        ScoreNumber.text = "Score: " + Character.Score;
        SetStatus();
	}
    public void StartGame()
    {
        Manag.Status = GameManager.GameState.InGame;
    }
    public void RestartGame()
    {
        Application.LoadLevel(0);
    }
    void SetStatus()
    {
        //Enable Main Screen
        if(Manag.Status == GameManager.GameState.MainMenu)
        {
            StartingScreen.SetActive(true);
        }
        else
        {
            StartingScreen.SetActive(false);
        }

        //Enable Game Over
        if (Manag.Status == GameManager.GameState.GameOver)
        {
            GameOver.SetActive(true);
        }
        else
        {
           GameOver.SetActive(false);
        }

    }
}
