using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testangle : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Debug.Log("Right up Little");
            rb.velocity = new Vector3(1f, 0.1f, 0).normalized;
            float angle = Mathf.Asin (rb.velocity.y/1)*Mathf.Rad2Deg;
            Debug.Log (angle);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Debug.Log("Right up Big");
            rb.velocity = new Vector3(0.1f, 1f, 0).normalized;
            float angle = Mathf.Asin(rb.velocity.y / 1) * Mathf.Rad2Deg;
            Debug.Log(angle);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Debug.Log("Left up little");
            rb.velocity = new Vector3(0.1f, 1f, 0).normalized;
            float angle = Mathf.Asin(rb.velocity.y / 1) * Mathf.Rad2Deg;
            Debug.Log(angle);
        }
    }
}
