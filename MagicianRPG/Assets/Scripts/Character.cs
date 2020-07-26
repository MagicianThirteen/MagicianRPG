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
    protected Animator animator;//动画组件

    private void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.zero;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();//控制位移
    }

    public void Move()
    {
       
        transform.Translate(direction * speed * Time.deltaTime);
        AnimateMovement(direction);
        
    }

    public void AnimateMovement(Vector2 direction)
    {

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }

    
}
