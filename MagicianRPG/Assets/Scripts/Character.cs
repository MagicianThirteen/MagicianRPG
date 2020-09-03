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
    private Rigidbody2D myRigidbody2D;//刚体组件，用刚体控制移动
    public bool IsMoving //判断是否移动了。
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();//不要把获取组件放到start中，这样会报空错，没有获取该组件
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start()
    {
        Debug.Log(direction.x + "X");
        Debug.Log(direction.y + "y");
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
        AnimateMovement(direction);
    }

    private void FixedUpdate()//用物理引擎做移动所以在fixedupdate中调用
    {
        Move();
    }

    /// <summary>
    /// 控制位移
    /// </summary>
    public void Move()
    {

        //用物理引擎做移动,且把方向归一化，这样当两个按键按下时，不会叠加向量数值，使其更快，都是方向都以1个单位移动
        myRigidbody2D.velocity = direction.normalized * speed;

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
        if (IsMoving)//行动时
        {
            ActivateLayer("WalkLayer");//将walklayer层设置称权重1，主要播放行走动画
            animator.SetFloat("x", direction.x);
            animator.SetFloat("y", direction.y);
            Debug.Log(direction.x + "X");
            Debug.Log(direction.y + "y");


        }
        else//不动时
        {
            ActivateLayer("IdleLayer");//不动时，x，y为0，将idlelayer层设置成权重1，主要播放静止动画
            

        }

        


    }

    /// <summary>
    /// 改变动画层方法
    /// </summary>
    /// <param name="layerName">动画层名字</param>
    public void ActivateLayer(string layerName)
    {
        //当一个动画层启动时，其它动画层的权重设置为0
        for(int i = 0; i < animator.layerCount; i++)
        {
            animator.SetLayerWeight(i, 0);
        }
        animator.SetLayerWeight(animator.GetLayerIndex(layerName), 1);
    }

}
