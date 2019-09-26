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
    public GameObject Scenery;

    public bool GameOver = false;
    private bool GameStarted = false;
    public float ScrollSpeed = 0;
    private float DefaultScroolSpeed = -1.5f;
    private int NumberOfBackgrounds; // used to dinamically set the number of backgrounds 

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
    }

    // sets default game style
    private void StartGame()
    {
        StartText.SetActive(false);
        ScoreText.SetActive(true);
        ScrollSpeed = DefaultScroolSpeed;
        GameStarted = true;
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

}
