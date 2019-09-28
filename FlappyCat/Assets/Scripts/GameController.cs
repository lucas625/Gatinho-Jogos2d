using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject GameOverText;
    public GameObject ScoreText;
    public GameObject StartText;
    public GameObject TimerText;
    public GameObject Scenery;

    private float CurrentTimeS, CurrentTimeM, CurrentTimeH = 0f;

    public bool GameOver = false;
    private bool GameStarted = false;
    public float ScrollSpeed = 0;
    private float DefaultScroolSpeed = -1.5f;
    private int NumberOfBackgrounds; // used to dinamically set the number of backgrounds 

    private int Score = 0;

    private bool Paused = false;

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

        if (IsStarted() && (!Paused) && (!GameOver)) {
            AttTime();
        }

    }

    private void AttTime() {
        CurrentTimeS += Time.deltaTime;
        if (CurrentTimeS >= 60) {
            CurrentTimeS -= 60;
            CurrentTimeM += 1;
        }
        if (CurrentTimeM >= 60) {
            CurrentTimeM -= 60;
            CurrentTimeH += 1;
        }
        if (CurrentTimeH >= 1f) {
            TimerText.GetComponent<UnityEngine.UI.Text>().text = CurrentTimeH.ToString("00") + ":" + CurrentTimeM.ToString("00") + ":" + CurrentTimeS.ToString("00");
        }else {
            TimerText.GetComponent<UnityEngine.UI.Text>().text = CurrentTimeM.ToString("00") + ":" + CurrentTimeS.ToString("00");
        }
        
    }

    // sets default game style
    private void StartGame()
    {
        StartText.SetActive(false);
        ScoreText.SetActive(true);
        TimerText.SetActive(true);
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

    public bool IsPaused() {
        return Paused;
    }

    public void Pause() {
        if (IsStarted() && (!Paused) && (!GameOver)) {
            Paused = true;
            DefaultScroolSpeed = ScrollSpeed;
            ScrollSpeed = 0;
            ScoreText.SetActive(false);
            TimerText.SetActive(false);
        }
    }

    public void UnPause() {
        if (IsStarted() && Paused && (!GameOver)) {
            Paused = false;
            ScrollSpeed = DefaultScroolSpeed;
            ScoreText.SetActive(true);
            TimerText.SetActive(true);
        }
    }


}
