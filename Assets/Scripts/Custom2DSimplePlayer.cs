using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Custom2DSimplePlayer : MonoBehaviour
{
    public float speed = 10.0f;

    //Rigidbody2D rigidbod;
    Rigidbody2D rigidbod { get { return GetComponent<Rigidbody2D>(); } set { rigidbod = value; } }
    Vector2 velocity;

    //GyroscopeLocomotion gyroMove;
    DetectPhoneMovements phoneMoves;

    // Use this for initialization
    void Start()
    {
        //rigidbod = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed;
    }

    private void FixedUpdate()
    {
        rigidbod.MovePosition(rigidbod.position + velocity * Time.fixedDeltaTime);
    }
}
