using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTime : MonoBehaviour {
    bool m_isNewScoreHigher = false;

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    public float ShowCurrentHighScore(string scoreName) {
        return PlayerPrefs.GetFloat(scoreName);
    }

    public void FindHigherScore(string scoreName, float oldScore, float newScore) {
        if (oldScore >= newScore)
            return;

        m_isNewScoreHigher = true;
        PlayerPrefs.SetFloat(scoreName, newScore);
    }

    public bool IsNewScoreHigher() {
        return m_isNewScoreHigher;
    }

}