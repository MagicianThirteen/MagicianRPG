using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]//让私有变量也能在面板里看到
    private float speed;
    private Vector2 direction;//要走的方向
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();//控制方向
        Move();//控制位移
        
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void GetInput()
    {
        direction = Vector2.zero;
        if (Input.GetKey(KeyCode.W))//getkey表示一直按着键
        {
            direction += Vector2.up;//这里用direction=Vector2.up似乎也一样？
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }
    }
}
