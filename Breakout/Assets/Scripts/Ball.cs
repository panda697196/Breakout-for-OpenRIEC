using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public Transform paddle;
    private const float Reset_Y = -5.05f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //When the mouse is pressed, let the ball fly out
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isPlaying)
        {
            Vector3 speedNormalized = new Vector3(1f, 1f, 0).normalized;
            rb.velocity = speedNormalized * speed;
            GameManager.Instance.isPlaying = true;
        }
        if (!GameManager.Instance.isPlaying)
        {
            Vector3 pos = transform.position; 
            pos.x = paddle.position.x;
            pos.y = Reset_Y;
            transform.position = pos;
        }
        //Test Only
        if (Input.GetKey(KeyCode.Keypad0))
        {
            Vector3 pos = paddle.position;
            pos.x = transform.position.x;
            paddle.position = pos;
        }
    }
    
}
