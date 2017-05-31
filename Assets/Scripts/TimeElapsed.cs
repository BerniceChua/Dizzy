using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeElapsed : MonoBehaviour {

    [SerializeField] Text m_timeElapsed;
    //float time = Time.realtimeSinceStartup;
    int m_timer = 0;

    // Use this for initialization
    void Start () {
        m_timeElapsed.text = "00:00";
    }
	
	// Update is called once per frame
	void Update () {
        int minutes = Mathf.FloorToInt(m_timer / 60);
        int seconds = Mathf.FloorToInt(m_timer % 60);

        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        m_timeElapsed.text = formattedTime;
    }
}
