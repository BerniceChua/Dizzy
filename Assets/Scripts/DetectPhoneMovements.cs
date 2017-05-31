using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPhoneMovements : MonoBehaviour {

    //Rigidbody rb { get { return GetComponent<Rigidbody>(); } set { rb = value; } }
       [SerializeField] float speed = 10.0f;

    Vector3 m_lastPosition = Vector3.zero;

    //   //public float m_Horizontal { get { return Input.gyro.rotationRateUnbiased.x; } /*set { m_Horizontal = value; }*/ }
    //   public float m_Horizontal { get { return Input.compass.trueHeading; } /*set { m_Horizontal = value; }*/ }


    // Use this for initialization
    void Awake()
    {
        /// This enables Compass.trueHeading property to contain a valid value, you must also enable location updates
        //Input.location.Start();
        //Input.compass.enabled = true;

        //speed = m_Horizontal;
    }

    //// Update is called once per frame
    //void Update () {

    //   //}

    //       //void FixedUpdate()
    //       //{
    //       //Input.gyro.enabled = true;
    //       //float initialOrientationX = Input.gyro.userAcceleration.x;
    //       //float initialOrientationY = Input.gyro.userAcceleration.y;
    //       //rb.AddForce(initialOrientationY * speed, 0.0f, -initialOrientationX * speed);
    //       //float initialOrientationX = Input.gyro.attitude.x;
    //       //float initialOrientationY = Input.gyro.attitude.y;




    //       transform.position = new Vector3(CalcChangeInHeading(), 0, 0);

    //   }

    //   float CalcChangeInHeading()
    //   {
    //       Input.location.Start();
    //       Input.compass.enabled = true;
    //       float horizontalMove1 = Input.compass.trueHeading;
    //       float horizontalMove2 = Input.compass.trueHeading;

    //       return (horizontalMove2 - horizontalMove1)/Time.time;
    //   }

    //   void CalcChangeInTime()
    //   {

    //   }
    void Update()
    {
        Vector2 dir = Vector2.zero;
        //dir.x = -Input.acceleration.y;
        //dir.z = Input.acceleration.x;


        dir.x = Input.acceleration.x * Time.deltaTime;
        //dir.x = transform.position.x;
        //dir.z = Input.acceleration.x;

        //if (dir.sqrMagnitude > 1)
        //    dir.Normalize();

        //dir *= Time.deltaTime;
        transform.Translate(dir * speed);
    }

    float GetSpeed()
    {
        float speed = (transform.position - m_lastPosition).magnitude / Time.deltaTime;

        m_lastPosition = transform.position;

        return speed;
    }

}