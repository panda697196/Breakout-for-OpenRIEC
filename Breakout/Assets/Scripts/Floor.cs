using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        Item item = other.gameObject.GetComponent<Item>();
        if (item != null)
        {
            Destroy(item.gameObject);
        }
        else
        {
            if(GameManager.Instance.IsLastBall) {
                GameManager.Instance.GameOver();
            }
            else
            {
                Destroy(other.gameObject);
            }
            
        }

   }
}
