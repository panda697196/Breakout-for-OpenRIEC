using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int liveTImes = 3;
    public Text LivesText;
    public GameObject winPanel;
    //  Determine if the game is running
    public bool isPlaying = false;
    private bool _isPassedLevel = false;
    public bool isPassedLevel
    {
        set
        {
            _isPassedLevel = value;
            if (_isPassedLevel)
            {
             //   isPlaying = false;
                winPanel.SetActive(true);
                Time.timeScale = 0.3f;
                //Delayed Call Methods
                Invoke("WinStep2",0.2f);
            }
        }
        get
        {
            return _isPassedLevel;
        }

    }
    void WinStep2()
    {
        Time.timeScale = 1f;
        isPlaying = false;
    }
    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //Initialise brick colours, random
        Brick[] allBricks = GameObject.FindObjectsOfType<Brick>();
        foreach(var item in allBricks) {
            item.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        }
    }
    public void GameOver()
    {
        if (liveTImes == 0)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            // Gameover
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            ChangeLives(-1);
            isPlaying = false;
        }
    }
    //
    public void CheckLevelPassed ()
    {
        Brick[] allBricks = GameObject.FindObjectsOfType<Brick>();
        bool tempPassedLevel = true;
        foreach(var item in allBricks)
        {
            if(item.enabled == false)
            {
                continue;
            }
            tempPassedLevel = false;
        }
        isPassedLevel = tempPassedLevel;
    }
    //Lives change
    private void ChangeLives(int step)
    {
        liveTImes += step;
        LivesText.text = "Lives:" + liveTImes;
    }
    //Reset ball position
    public void ResetBall()
    {
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPassedLevel)
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }
}
