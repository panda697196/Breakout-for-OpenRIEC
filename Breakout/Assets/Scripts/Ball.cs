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
        if (!GameManager.Instance.isPlaying)
        {
            Vector3 pos = transform.position;
            pos.x = paddle.position.x;
            pos.y = Reset_Y;
            transform.position = pos;
        }
        if (GameManager.Instance.isPassedLevel)
        {
            return;
        }
        //When the mouse is pressed, let the ball fly out
        if (Input.GetMouseButtonDown(0) && !GameManager.Instance.isPlaying)
        {
            Vector3 speedNormalized = new Vector3(1f, 1f, 0).normalized;
            rb.velocity = speedNormalized * speed;
            GameManager.Instance.isPlaying = true;
        }
      
        //Test Only
        if (Input.GetKey(KeyCode.Keypad0))
        {
            Vector3 pos = paddle.position;
            pos.x = transform.position.x;
            paddle.position = pos;
        }
    }

    //reset speed
    void OnCollisionExit(Collision other)
    {
        if (GameManager.Instance.isPlaying) {
            Vector3 sp = rb.velocity.normalized;

            float angle = Mathf.Asin(sp.y / 1) * Mathf.Rad2Deg;

            //angle >0 
            if (angle >= 0 && angle < 10)
            {
                if (sp.x > 0)
                {
                    float yy = Mathf.Tan(10 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(1f, yy, 0).normalized;
                    sp = newVelpcity;
                } else {
                    float yy = Mathf.Tan(10 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(-1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
            } else if (angle > 80 && angle <= 90)
            {
                if(sp.x > 0)
                {
                    float yy = Mathf.Tan(80 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(1f, yy, 0).normalized;
                    sp = newVelpcity;
                } else
                {
                    float yy = Mathf.Tan(80 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(-1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
            }else if (angle < 0 && angle > -10)
            {
                if (sp.x > 0)
                {
                    float yy = Mathf.Tan(-10 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
                else
                {
                    float yy = Mathf.Tan(-10 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(-1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
            }
            else if (angle <- 80 && angle >= -90)
            {
                if (sp.x > 0)
                {
                    float yy = Mathf.Tan(-80 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
                else
                {
                    float yy = Mathf.Tan(-80 * Mathf.Deg2Rad);
                    Vector3 newVelpcity = new Vector3(-1f, yy, 0).normalized;
                    sp = newVelpcity;
                }
            }


            rb.velocity = sp * speed;
        }
        
    }

}
