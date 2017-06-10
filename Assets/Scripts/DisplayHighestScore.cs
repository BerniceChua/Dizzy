using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighestScore : MonoBehaviour {
    [SerializeField] Text m_displayTheScore;
    [SerializeField] TimeElapsed m_timeElapsed;
    [SerializeField] ScoreTime m_scoreTime;
    
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        m_displayTheScore.text = m_timeElapsed.DisplayFormattedTime(m_scoreTime.ShowCurrentHighScore("Best Time"));
    }
}