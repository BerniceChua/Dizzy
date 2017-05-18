using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    public Transform target;

    DetectPhoneMovements phoneMoves;

    public float speed = 10.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //speed *= phoneMoves;

        transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
    }
}