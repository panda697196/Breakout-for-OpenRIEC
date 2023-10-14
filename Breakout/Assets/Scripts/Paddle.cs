using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isPassedLevel){
            return;
        }

        //Get horizontal movement displacement
        float xx = Input.GetAxisRaw("Horizontal");
        if (xx != 0) {
            Vector3 pos = transform.position;
            pos.x += xx * Time.deltaTime * speed;
            //Restricted to a certain range
            pos.x = Mathf.Clamp(pos.x,xMin,xMax);
            transform.position = pos;
        }

    }
}
