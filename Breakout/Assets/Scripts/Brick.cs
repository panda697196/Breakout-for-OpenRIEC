using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public enum Brick_Type
    {
        Normal,
        NoBreak,
        Prop_Life,
        Prop_Multi
    }
    public GameObject ItemPrefab;
    public Brick_Type currType;
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
        if (currType == Brick_Type.NoBreak)
        {
            return;
        } else if (currType == Brick_Type.Prop_Life || currType == Brick_Type.Prop_Multi)
        {
            GameObject item = Instantiate(ItemPrefab);
            Vector3 pos = transform.position;
            pos.z -= 0.5f;
            item.transform.position = pos;
        }
        this.enabled = false;
        Destroy(gameObject);
        GameManager.Instance.CheckLevelPassed();

    }
}
