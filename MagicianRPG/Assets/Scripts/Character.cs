using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用来记录一些角色的公共方法，比如移动
/// </summary>
public abstract class Character : MonoBehaviour
{
    [SerializeField]//让私有变量也能在面板里看到
    private float speed;
    protected Vector2 direction;//要走的方向

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();//控制位移
    }

    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
