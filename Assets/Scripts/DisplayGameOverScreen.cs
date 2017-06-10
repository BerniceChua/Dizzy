using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayGameOverScreen : MonoBehaviour {
    [SerializeField] GameManager m_gameManager;
    //[SerializeField] TimeElapsed m_timeElapsed;
    [SerializeField] GameObject m_gameOverDisplay;
    [SerializeField] GameObject m_timerObject;
    [SerializeField] GameObject m_menuAndPausePanel;

	// Use this for initialization
	void Start () {
		//m_gameOverDisplay.GetComponentInChildren<>
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayGameOverMessage() {
        m_gameManager.PauseGame();

        m_timerObject.SetActive(false);
        m_gameOverDisplay.SetActive(true);

        //m_menuAndPausePanel.SetActive(true);
    }
}
