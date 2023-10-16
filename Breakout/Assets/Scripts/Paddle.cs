using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Paddle : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float speed;
    public GameObject ballPrefab;
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
    private void OnCollisionEnter(Collision other)
    {
       
            Item item = other.gameObject.GetComponent<Item>();
            if (item != null)
            {
                if (GameManager.Instance.isPlaying)
            {
                if (item.currType == Item.Item_Type.Life)
                {
                    GameManager.Instance.ChangeLives(1);
                }
                else if (item.currType == Item.Item_Type.Multi)
                {
                    for (int i = 0; i < item.MultiNumber; i++)
                    {
                        GameObject ball = Instantiate(ballPrefab);
                        Vector3 pos = transform.position;
                        pos.y = Ball.Reset_Y;
                        ball.transform.position = pos;
                        ball.GetComponent<Ball>().StarMove();
                    }
                }
                }
                Destroy(other.gameObject);
            }
        

    }
}
