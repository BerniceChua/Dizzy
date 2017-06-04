using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsed : MonoBehaviour {

    [SerializeField] Text m_timeElapsed;
    //float time = Time.realtimeSinceStartup;
    //int m_timer = 0;
    float m_startTime;

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

        float t = Time.time - m_startTime;
        string hours = ((int) t / 3600).ToString("00");
        string minutes = ((int) t / 60).ToString("00");
        string seconds = ((int) t % 60).ToString("00");

        m_timeElapsed.text = hours + ":" + minutes + ":" + seconds;
    }

    public void ResetTime() {
        m_startTime = Time.time;
    }

}