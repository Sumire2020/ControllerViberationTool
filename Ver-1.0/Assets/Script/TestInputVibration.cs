using UnityEngine;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;

public class TestInputVibration : MonoBehaviour
{
    private Single leftVib = 0;
    private Single rightVib = 0;
    private Single dura = 0.01f;

    private float lIn;
    private string currentButton;//当前按下的按键
    private string[] words;
    //震动的方向
    XInputDotNetPure.PlayerIndex _type = XInputDotNetPure.PlayerIndex.One;

    private void Start()
    {
        Screen.fullScreen = false;
        XInputDotNetPure.GamePad.SetVibration(_type, 0, 0);
    }

    private void Update()
    {
        var values = Enum.GetValues(typeof(KeyCode));//存储所有的按键
        for (int x = 0; x < values.Length; x++)
        {
            if (Input.GetKeyDown((KeyCode)values.GetValue(x)))
            {
                currentButton = values.GetValue(x).ToString();//遍历并获取当前按下的按键
            }
        }
        string tmp;
        if(currentButton != null)
        {
            Debug.Log(currentButton);
            words = currentButton.Split('n');
            Debug.Log(words[words.Length - 1]);
            tmp = words[words.Length - 1];
        }
        else
        {
            tmp = "0";
        }
        if (tmp == "3")
        {
            XInputDotNetPure.GamePad.SetVibration(_type, 1, 1);
        }
        else if (tmp == "2")
        {
            XInputDotNetPure.GamePad.SetVibration(_type, 0.7f, 0.7f);
        }
        else if (tmp == "1")
        {
            XInputDotNetPure.GamePad.SetVibration(_type, 0.3f, 0.3f);
        }
        else if (tmp == "0")
        {
            XInputDotNetPure.GamePad.SetVibration(_type, 0, 0);
        }
    }
}