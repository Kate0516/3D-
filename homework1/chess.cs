using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chess : MonoBehaviour
{

    private int turn = 1;   //轮流落子，1是玩家O的回合，-1是玩家X的回合
    private int[,] chessdata = new int[3, 3];    //记录棋盘每格的落子情况，0代表空，1代表O，2代表X
    // Use this for initialization
    void Start()
    {
        reset();
    }
    //初始化棋局，玩家1先手，所有格为空
    void reset()
    {
        turn = 1;
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                chessdata[i, j] = 0;
            }
        }
    }
    //设置UI界面
    void OnGUI()
    {
        
        GUIStyle font = new GUIStyle();//设置字体样式
        font.fontSize = 25;
        font.normal.textColor = new Color(255, 255, 255);


        if (GUI.Button(new Rect(350, 370, 100, 50), "reset"))
            reset();
        int res = endstate();//检查棋局是否结束，返回值为1时O胜利，2时X胜利，0时棋局未结束
        if (res == 1)
        {
            GUI.Label(new Rect(350, 50, 100, 50), "O wins", font);
        }
        else if (res == 2)
        {
            GUI.Label(new Rect(350, 50, 100, 50), "X wins", font);
        }
        //每一帧都重新生成棋盘格，根据数组存储
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                if (chessdata[i, j] == 1)
                    GUI.Button(new Rect(280 + i * 80, 120 + j * 80, 80, 80), "O");
                if (chessdata[i, j] == 2)
                    GUI.Button(new Rect(280 + i * 80, 120 + j * 80, 80, 80), "X");
                if (GUI.Button(new Rect(280 + i * 80, 120 + j * 80, 80, 80), ""))//创建空按钮，被点击时返回true
                {
                    if (res == 0)
                    {
                        if (turn == 1)
                            chessdata[i, j] = 1;
                        else
                            chessdata[i, j] = 2;
                        turn = -turn;//轮换
                    }
                }
            }
        }
    }
    

    //检查游戏是否结束
    int endstate()
    {
        // 检查横排
        for (int i = 0; i < 3; ++i)
        {
            if (chessdata[i, 0] != 0 && chessdata[i, 0] == chessdata[i, 1] && chessdata[i, 1] == chessdata[i, 2])
            {
                return chessdata[i, 0];
            }
        }
        //检查竖排
        for (int j = 0; j < 3; ++j)
        {
            if (chessdata[0, j] != 0 && chessdata[0, j] == chessdata[1, j] && chessdata[1, j] == chessdata[2, j])
            {
                return chessdata[0, j];
            }
        }
        //检查斜线
        if (chessdata[1, 1] != 0 && chessdata[0, 0] == chessdata[1, 1] && chessdata[1, 1] == chessdata[2, 2] 
            || chessdata[0, 2] == chessdata[1, 1] && chessdata[1, 1] == chessdata[2, 0])
        {
            return chessdata[1, 1];
        }
        return 0;
    }
}
