﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform target;
    [SerializeField] float m_multiplier = 10.0f;
    [SerializeField] float m_slideBackwards = 1.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        //speed = GetSpeed();

        //transform.RotateAround(target.position, target.up, speed * Time.deltaTime);

        float speedOfGamePiece = GetSpeed();

        //transform.RotateAround(target.position, target.up, speedOfGamePiece);
        transform.RotateAround(target.position, Vector3.up, -m_slideBackwards + speedOfGamePiece);
    }

    public float GetSpeed()
    {
        //float speed = (Input.acceleration.x - m_previousSpeed) / Time.deltaTime;

        //m_previousSpeed = Input.acceleration.x;

        float speed = Mathf.Abs(Input.gyro.attitude.x) * m_multiplier;

        return speed;
    }
}