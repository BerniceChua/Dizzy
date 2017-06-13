using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayPhoneMovementInput : MonoBehaviour{

    [SerializeField] GameObject m_gamePiece;
    [SerializeField] Camera m_cameraPosition;
    [SerializeField] Orbit m_orbit;

    Text m_text { get { return GetComponent<Text>(); } set { m_text = value; } }

    Vector3 m_lastPosition = Vector3.zero;
    float m_previousSpeed = 0.0f;
    [SerializeField] Camera m_cam;
    Vector3 m_whereCameraIsPointing;

    // Use this for initialization
    void Start()
    {
        m_whereCameraIsPointing = m_cam.ViewportToWorldPoint(m_cam.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        string gyroAttitude = Input.gyro.attitude.ToString();
        m_whereCameraIsPointing = m_cam.ViewportToWorldPoint(m_cam.transform.forward);

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
            //"\n Input.gyro.userAcceleration.y = " + Input.gyro.userAcceleration.y.ToString() +
            //"\n Input.gyro.rotationRate.x = " + Input.gyro.rotationRate.x.ToString() +
            //"\nAccelerometer = " + Input.acceleration.ToString() +
            "\nm_orbit.GetSpeed() = " + m_orbit.GetSpeed()/*.ToString()*/ +
            "\nm_gamePiece.GetComponent<Orbit>().enabled = " + m_gamePiece.GetComponent<Orbit>().enabled +
            "\nm_whereCameraIsPointing = " + m_whereCameraIsPointing +
            //"\n(Input.gyro.attitude.x - m_previousSpeed) = " + (Input.gyro.attitude.x - m_previousSpeed).ToString() +
            "\nm_gamePiece.transform.position = " + m_gamePiece.transform.position.ToString() +
            "\nm_gamePiece.transform.rotation = " + m_gamePiece.transform.rotation.ToString() +
            "\nm_cameraPosition.transform = " + m_cameraPosition.transform.position.ToString() +
           "\nTime.timeScale = " + Time.timeScale +
            "\nm_lastPosition = " + m_lastPosition.ToString();
    }
}