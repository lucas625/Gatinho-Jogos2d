using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using GameAnalyticsSDK;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject GameOverText;
    public GameObject ScoreText;
    public GameObject StartText;
    public GameObject Scenery;

    public bool GameOver = false;
    private bool GameStarted = false;
    public float ScrollSpeed = 0;
    private float DefaultScroolSpeed = -1.5f;
    private int NumberOfBackgrounds; // used to dinamically set the number of backgrounds 

    private int Score = 0;

    // Awake is called before any Start
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        NumberOfBackgrounds = Scenery.transform.childCount;
    }

    void Start() {
        GameAnalytics.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GameOver)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            if (!IsStarted())
            {
                StartGame();
            }

        }
    }

    // sets default game style
    private void StartGame()
    {
        StartText.SetActive(false);
        ScoreText.SetActive(true);
        ScrollSpeed = DefaultScroolSpeed;
        GameStarted = true;
        Score = 0;
    }

    // checks if the game has started
    public bool IsStarted() {
        return GameStarted;
    }

    // controller's operations when the cat dies
    public void CatDied()
    {
        GameOverText.SetActive(true);
        GameOver = true;
    }

    // getter for number of backgroudnds
    public int GetNumberOfBackgrounds() {
        return NumberOfBackgrounds;
    }

    public void Scored()
    {
        if (GameOver) {
            return;
        }
        Score++;
        ScoreText.GetComponent<UnityEngine.UI.Text>().text = "Score: " + Score.ToString();
    }

}
