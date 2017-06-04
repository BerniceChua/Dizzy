using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    [SerializeField] TimeElapsed m_timeElapsed;
    //[SerializeField] GameObject m_splashScreen;

    //private int floorMask = LayerMask.GetMask("Floor");

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
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        StartTheGame();
    }

    public void GoToMainMenu() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

}