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
    private Animator animator;//动画组件
    private void Awake()
    {
        animator = GetComponent<Animator>();//不要把获取组件放到start中，这样会报空错，没有获取该组件
    }

    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    /// <summary>
    /// 控制位移
    /// </summary>
    public void Move()
    {
       
        transform.Translate(direction * speed * Time.deltaTime);
        
        
        AnimateMovement(direction);
        

    }

    /// <summary>
    /// 角色行走的动画控制，脸朝正确方向
    /// </summary>
    /// <param name="direction">依靠传入的方向获取x，y的值</param>
    public void AnimateMovement(Vector2 direction)
    {
        if (animator == null)
        {
            Debug.Log("animator组件没获取");
        }
        if (direction.x != 0 || direction.y != 0)//行动时
        {
            animator.SetLayerWeight(1, 1);//将walklayer层设置称权重1，主要播放行走动画
            
        }
        else//不动时
        {
            animator.SetLayerWeight(1, 0);//不动时，x，y为0，将idlelayer层设置成权重1，主要播放静止动画
            

        }

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);


    }

}
