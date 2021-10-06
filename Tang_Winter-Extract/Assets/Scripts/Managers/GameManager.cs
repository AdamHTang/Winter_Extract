/*
 * Created By: Adam Tang
 * Created On : Sept 29, 2021
 * Last Edited By:
 * Last Updated: Oct 4, 2021
 * 
 * Description: Game manager to control global game behaviors.
 * 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Variables //
    #region GameManager Singleton
    static GameManager gm;
    public static GameManager GM
    {
        get { return gm; }
    }

    void CheckGameManagerIsInScene()
    {
        if(gm == null)
        {
            gm = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }
    #endregion

    public static int Score;
    public float timeRemaining = 120.0f;
    public string ScorePrefix = string.Empty;
    public TMP_Text ScoreText = null;
    public TMP_Text GameOverText = null;
    public TMP_Text HealthText = null;
    public TMP_Text AmmoText = null;
    public TMP_Text WinText = null;
    public TMP_Text TimerText = null;
    public GameObject Player = null;
    public static bool IsPlayerDead = false;
    private int currentLevelIndex;
    

    private static int minutes;
    private static float seconds;

    void Awake()
    {
        CheckGameManagerIsInScene();
        minutes = (int)(timeRemaining / 60);
        seconds = (timeRemaining % 60);
        
    } // End Awake()

    // Update is called once per frame
    void Update()
    {
        if (ScoreText != null)
        {
            ScoreText.text = ScorePrefix + Score.ToString();
        }

        if (HealthText != null && GameObject.Find("Player") != null)
        {
            HealthText.text = "+" + Player.GetComponent<Health>().getHealthPoints().ToString("F0");
        }
        else
        {
            HealthText.text = "+" + "0";
            GameOver();
        }


        if (AmmoText != null && GameObject.Find("Player") != null)
        {
            AmmoText.text = "|" + Player.GetComponent<PlayerController>().getAmmo().ToString();
        }

        if (timeRemaining <= 0)
        {
            YouWin();
        }


    } // End Update()

    void FixedUpdate()
    {
        if (timeRemaining > 0 && GameObject.Find("Player") != null) 
        {
            timeRemaining -= Time.fixedDeltaTime;
            minutes = (int)(timeRemaining / 60);
            seconds = (timeRemaining % 60);
            TimerText.text = minutes + ":" + seconds.ToString("00");
        }
    }

    public static void GameOver()
    {
        if (gm.GameOverText != null)
        {
            gm.GameOverText.gameObject.SetActive(true);
            gm.Invoke("restartLevel", 3.0f);
        }
    } // End GameOver()

    public static void YouWin()
    {
        if (gm.WinText != null)
        {
            gm.WinText.gameObject.SetActive(true);
            gm.Invoke("newLevel", 3.0f);
        }
    }

    [System.Obsolete]
    void newLevel()
    {
        if (SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("Level_2")) || SceneManager.GetActiveScene().Equals(SceneManager.GetSceneByName("You_Win")))
        {
            SceneManager.LoadScene(2);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
       
    }

    void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
