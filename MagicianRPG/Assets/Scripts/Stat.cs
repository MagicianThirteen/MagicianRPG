using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image FillImage;
    [SerializeField]
    private float lerpspeed;
    private float currentValue=100;//当前填充值的值
    private float maxValue=100 ;//最大填充值
    private float currentFillAmount=1;//初时的填充百分比设置成1
    //在条上显示如“100/100”的数值
    [SerializeField]
    private Text statTxt;
    public float CurrentValue {

        get {

            return currentValue;
        }

        set {
            //限制填充的数值不能大于100，小于0
            if (currentValue >= maxValue)
            {
                currentValue = maxValue;
            }else if (currentValue <= 0)
            {
                currentValue = 0;
            }

            currentValue = value;

            //计算当前填充的百分比
            currentFillAmount = currentValue / maxValue;
            //给要显示的数值赋值
            statTxt.text = currentValue + " / " + maxValue;
        }
    }

    private void Awake()
    {
        FillImage = GetComponent<Image>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        //在这里不断的更新，显示比，然后为了平滑过度，用math.lerp
        if (currentFillAmount != FillImage.fillAmount)
        {
            //别忘了计算出平滑值之后还要赋值
            FillImage.fillAmount=Mathf.Lerp(FillImage.fillAmount, currentFillAmount, Time.deltaTime * lerpspeed);
            Debug.Log(FillImage.fillAmount);
        }
        
    }

    /// <summary>
    /// 初始化最大值和当前值的方法
    /// </summary>
    /// <param name="maxvalue"></param>
    /// <param name="currvalue"></param>
    public void InitValue(float maxvalue,float currvalue)
    {
        maxValue = maxvalue;
        currentValue = currvalue;
    }

}
