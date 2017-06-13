using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectIfGamePieceIsOnLeftEdge : MonoBehaviour {
    [SerializeField] Transform m_target;

    [SerializeField] TimeElapsed m_timeElapsed;

    Camera m_camera { get { return GetComponent<Camera>(); } set { m_camera = value; } }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 viewPosition = m_camera.WorldToViewportPoint(m_target.position);

        if (viewPosition.x < 0.01f) {
            Debug.Log("It's game over, man; game over!");
            m_timeElapsed.GameOver();
        }

        return;
	}
}