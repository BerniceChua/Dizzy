using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] TimeElapsed m_timeElapsed;
    //[SerializeField] GameObject m_splashScreen;
    [SerializeField] Text m_timeElapsedText;

    //private int floorMask = LayerMask.GetMask("Floor");

    bool m_gameOver = false;

    public static GameManager control;
    //void Awake() {
    //    if (control == null)
    //    {
    //        DontDestroyOnLoad(gameObject);
    //        control = this;
    //    }
    //    else if (control != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    // Use this for initialization
    void Start () {
        //if (control == null)
        //{
        //    DontDestroyOnLoad(gameObject);
        //    control = this;
        //}
        //else if (control != this)
        //{
        //    Destroy(gameObject);
        //}
    }
	
	// Update is called once per frame
	void Update () {
        if (m_gameOver)
            return;

#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
            StartTheGame();
#else
        if (Input.touchCount == 2)
            StartTheGame();
#endif
    }

    void StartTheGame() {
        //m_splashScreen.gameObject.SetActive(false);

        m_timeElapsed.gameObject.SetActive(true);
        m_timeElapsed.Timer();
    }

    public void ResetGame() {
        StartTheGame();
        m_timeElapsedText.color = Color.white;
    }

    public void GoToMainMenu() {
        //SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void PauseGame()
    {
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        //Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Time.timeScale = 1;
    }

    public void GameOver() {

    }

}