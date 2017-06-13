﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsed : MonoBehaviour {

    public Dictionary<string, float> m_ScoreTime = new Dictionary<string, float>();

    [SerializeField] Text m_timeElapsed;
    
    //float time = Time.realtimeSinceStartup;
    //int m_timer = 0;
    float m_startTime;

    public bool m_gameOver = false;

    float m_runningTime;
    float m_endingTime;
    [SerializeField] ScoreTime m_scoreTime;

    [SerializeField] GameManager m_gameManager;

    [SerializeField] DisplayGameOverScreen m_displayGameOverScreen;

    [SerializeField] GameObject m_gameOverDisplay;

    //[SerializeField] GameObject m_timerObject;
    [SerializeField] Text m_timerObject;

    [SerializeField] GameObject m_newHighScore;

    [SerializeField] GameObject m_menuAndPausePanel;

    [SerializeField] RepositionAfterGameOver m_resetGamePiece;

    [SerializeField] Orbit m_orbit;

    //void Awake()
    //{
    //    //m_timeElapsed.text = "00:00";
    //    ResetTime();
    //}

    // Use this for initialization
    void Start()
    {
        //m_timeElapsed.text = "00:00";
        m_startTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (m_gameOver) {
            GameOver();
            return;
        }

        Timer();
    }

    public void Timer()
    {
        //int minutes = Mathf.FloorToInt(m_timer / 60);
        //int seconds = Mathf.FloorToInt(m_timer % 60);

        //string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        //m_timeElapsed.text = formattedTime;



        //System.TimeSpan t = System.TimeSpan.FromSeconds(m_timer);
        //string timerFormatted = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);

        //m_timeElapsed.text = timerFormatted;

        //float m_runningTime = Time.time - m_startTime;
        m_runningTime = Time.time - m_startTime;
        m_timeElapsed.text = DisplayFormattedTime(m_runningTime);
    }

    public string DisplayFormattedTime(float unformattedTime) {
        string hours = ((int)unformattedTime / 3600).ToString("00");
        string minutes = ((int)unformattedTime / 60).ToString("00");
        //string seconds = ((int) t % 60).ToString("00");
        //string seconds = string.Format("{0:00.00}", (t % 60).ToString("00"));
        string seconds = (unformattedTime % 60).AddOneLeadingZero();

        return hours + ":" + minutes + ":" + seconds;
    }

    public void ResetTime() {
        m_gameOver = false;
        m_timeElapsed.color = Color.white;
        m_startTime = Time.time;
    }

    public void GameOver() {
        //m_ScoreTime.Add(m_timeElapsed.text, m_runningTime);

        //Debug.Log("m_scoreTime = " + m_ScoreTime);
        //Debug.Log("m_ScoreTime.Keys = " + m_ScoreTime.Keys);
        //Debug.Log("m_ScoreTime.Values = " + m_ScoreTime.Values);
        //Debug.Log("m_ScoreTime[m_timeElapsed.text] = " + m_ScoreTime[m_timeElapsed.text]);

        m_gameManager.PauseGame();
        m_endingTime = m_runningTime;
        //m_scoreTime.FindHigherScore("Best Time", m_scoreTime.ShowCurrentHighScore("Best Time"), m_runningTime);
        m_scoreTime.FindHigherScore("Best Time", m_endingTime);
        //Debug.Log(PlayerPrefs.GetFloat("Best Time"));

        //Debug.Log("m_scoreTime.IsNewScoreHigher(m_runningTime) = " + m_scoreTime.IsNewScoreHigher(m_endingTime));
        ////Debug.Log("m_scoreTime.IsNewScoreHigher() = " + m_scoreTime.IsNewScoreHigher());
        //Debug.Log("m_scoreTime.ShowCurrentHighScore('Best Time') = " + m_scoreTime.ShowCurrentHighScore("Best Time"));
        //Debug.Log("PlayerPrefs.GetFloat('Best Time') = " + PlayerPrefs.GetFloat("Best Time"));
        //Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

        //if (m_scoreTime.IsNewScoreHigher(m_runningTime)) {
        //if (m_scoreTime.IsNewScoreHigher()) {
        if (PlayerPrefs.GetFloat("Best Time") <= m_endingTime) {
            //Debug.Log("The running time of " + m_runningTime + " is bigger than ");
            //Debug.Log("PlayerPrefs.GetFloat('Best Time') = " + PlayerPrefs.GetFloat("Best Time"));
            //Debug.Log("m_scoreTime.IsNewScoreHigher(m_runningTime) = " + m_scoreTime.IsNewScoreHigher(m_runningTime));
            m_timeElapsed.color = Color.green;

            /// Add some fancy text animations.
        } else {
            //Debug.Log("The running time has not beaten the record time of ");
            //Debug.Log("PlayerPrefs.GetFloat('Best Time') = " + PlayerPrefs.GetFloat("Best Time"));
            //Debug.Log("m_scoreTime.IsNewScoreHigher(m_runningTime) = " + m_scoreTime.IsNewScoreHigher(m_runningTime));
            m_timeElapsed.color = Color.yellow;
        }

        m_orbit.enabled = false;
        m_resetGamePiece.ResetPosition();
        //m_displayGameOverScreen.DisplayGameOverMessage();
        StartCoroutine(DisplayGameOverMessage());
    }

    public IEnumerator DisplayGameOverMessage() {
        Debug.Log("Hello");
        /// Add a paused time between these 2 events.
        yield return new WaitForSecondsRealtime(2);
        Debug.Log("Hello from the other side!!!");

        /// Add some fancy text animations.
        m_timerObject.enabled = false;
        m_gameOverDisplay.SetActive(true);
        m_gameOverDisplay.GetComponentInChildren<Text>().text = DisplayFormattedTime(m_endingTime);
        m_gameOverDisplay.GetComponentInChildren<Text>().color = Color.yellow;

        if (PlayerPrefs.GetFloat("Best Time") <= m_endingTime)
        {
            m_gameOverDisplay.GetComponentInChildren<Text>().color = Color.green;
            Debug.Log("Special message should appear... in 3... 2... 1:");
            yield return new WaitForSecondsRealtime(3);
            m_newHighScore.SetActive(true);

        }

        yield return new WaitForSecondsRealtime(3);
        m_gameOverDisplay.SetActive(false);
        m_newHighScore.SetActive(false);
        m_timerObject.enabled = true;
        m_menuAndPausePanel.SetActive(true);
        //m_resetGamePiece.ReEnable();
    }
}