using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionAfterGameOver : MonoBehaviour {
    [SerializeField] TimeElapsed m_timeElapsed;
    [SerializeField] GameObject m_gamePiece;

    private Vector3 m_initialPosition;
    private Quaternion m_initialRotation;

    // Use this for initialization
    void Start () {
        m_initialRotation = m_gamePiece.transform.rotation;
        m_initialPosition = new Vector3(0, -5, 44.77f);
    }

    // Update is called once per frame
    void Update () {
        //if (m_timeElapsed.m_gameOver) {
        //    m_gamePiece.SetActive(false);
        //    m_gamePiece.transform.position.Set(0, -5, 44.77f);
        //}
    }

    public void ResetPosition() {
        //if (m_timeElapsed.m_gameOver) {
        //m_gamePiece.transform.position.Set(0, -5, 44.77f);
        m_gamePiece.transform.position = m_initialPosition;
        m_gamePiece.transform.rotation = m_initialRotation;
        m_gamePiece.SetActive(false);
    //}
    }

    public void ReEnable() {
        m_gamePiece.SetActive(true);
    }
}