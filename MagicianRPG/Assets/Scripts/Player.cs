﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        GetInput();//控制方向
        base.Update();

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
