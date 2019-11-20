using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    // 血量
    public float healthval = 0.0f;
    // 用来调整血条的临时变量
    private float temp;

    private Rect barpos;//血条的位置
    private Rect addpos;//加血按钮的位置
    private Rect minuspos;//减血按钮的位置

    void Start()
    {

        barpos = new Rect(30, 0, 140, 80);
        addpos = new Rect(55, 15, 45, 15);
        minuspos = new Rect(100, 15, 45, 15);
        temp = healthval;
    }

    void OnGUI()
    {
        if (GUI.Button(addpos, "+"))
        {
            temp = temp + 0.1f > 1.0f ? 1.0f : temp + 0.1f;
        }
        if (GUI.Button(minuspos, "-"))
        {
            temp = temp - 0.1f < 0.0f ? 0.0f : temp - 0.1f;
        }

        //插值计算
        healthval = Mathf.Lerp(healthval, temp, 0.05f);
        // 显示血条
        GUI.HorizontalScrollbar(barpos, 0.0f, healthval, 0.0f, 1.0f);
        
    }
}

