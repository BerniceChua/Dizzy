using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform target;

    DetectPhoneMovements phoneMoves;

    public float speed = 10.0f;

    Vector3 m_lastPosition = Vector3.zero;
    float m_previousSpeed = 0.0f;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       speed = GetSpeed();

        transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
    }

    float GetSpeed()
    {
        float speed = (Input.acceleration.x - m_previousSpeed) / Time.deltaTime;

        m_previousSpeed = Input.acceleration.x;

        return speed;
    }
}