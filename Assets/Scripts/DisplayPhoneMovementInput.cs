using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPhoneMovementInput : MonoBehaviour
{

    Text m_text { get { return GetComponent<Text>(); } set { m_text = value; } }

    Vector3 m_lastPosition = Vector3.zero;
    float m_previousSpeed = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        string gyroAttitude = Input.gyro.attitude.ToString();

        //float speed = (Input.acceleration - m_lastPosition).magnitude / Time.deltaTime;
        //float speed = (Input.acceleration.x - m_lastPosition.x) / Time.deltaTime;
        //float speed = (Input.gyro.attitude.x - m_lastPosition.x) / Time.deltaTime;


        //m_previousSpeed = Input.acceleration.x;
        //m_lastPosition = Input.acceleration;
        m_previousSpeed = Input.gyro.attitude.x;

        //float speed = (Input.gyro.attitude.x - m_previousSpeed) / Time.deltaTime;
        //float speed = Input.gyro.attitude.x;
        float speed = Input.gyro.userAcceleration.x;

        //m_previousSpeed = Input.acceleration.x;
        //m_lastPosition = Input.acceleration;
        m_previousSpeed = Input.gyro.attitude.x;

        m_text.text = "Gyro Attitude = " + gyroAttitude +
            "\n Input.gyro.userAcceleration.x = " + Input.gyro.userAcceleration.x.ToString() +
            "\n Input.gyro.userAcceleration.y = " + Input.gyro.userAcceleration.y.ToString() +
            "\n Input.gyro.rotationRate.x = " + Input.gyro.rotationRate.x.ToString() +
            "\nAccelerometer = " + Input.acceleration.ToString() +
            "\n(Input.gyro.attitude.x - m_previousSpeed) = " + (Input.gyro.attitude.x - m_previousSpeed).ToString() +
            "\nspeed = " + speed * 200 +
           "\nm_previousSpeed = " + m_previousSpeed.ToString() +
            "\nm_lastPosition = " + m_lastPosition.ToString();
    }
}