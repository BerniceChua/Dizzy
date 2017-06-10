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

    //public void FindHigherScore(string scoreName, float oldScore, float newScore) {
    public void FindHigherScore(string scoreName, float newScore) {
        //if (PlayerPrefs.GetFloat("Best Time") < newScore)
        Debug.Log(IsNewScoreHigher(newScore));
        if (IsNewScoreHigher(newScore)) {
        //if (IsNewScoreHigher()) {
            PlayerPrefs.SetFloat(scoreName, newScore);
            m_isNewScoreHigher = true;
        } else {
            m_isNewScoreHigher = false;
        }

        //PlayerPrefs.SetFloat(scoreName, newScore);
        return;
    }

    public bool IsNewScoreHigher(float newScore) {
        //public bool IsNewScoreHigher() {
        //return m_isNewScoreHigher;
        //Debug.Log("PlayerPrefs.GetFloat('Best Time') < newScore) = " + (PlayerPrefs.GetFloat("Best Time") < newScore) );
        Debug.Log(PlayerPrefs.GetFloat("Best Time"));
        Debug.Log(newScore);
        return (PlayerPrefs.GetFloat("Best Time") < newScore);
    }

}