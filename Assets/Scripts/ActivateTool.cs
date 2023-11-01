using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTool : MonoBehaviour
{
    public GameObject drawTool;
    public GameObject eraseTool;
    public GameObject flySwatter;
    public GameObject pong;
    public GameObject duck;


    public GameObject[] tools;
    public void actDraw()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        drawTool.SetActive(true);
    }
    public void actErase()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        eraseTool.SetActive(true);
    }
    public void actFly()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        flySwatter.SetActive(true);
    }
    public void actPong()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        pong.SetActive(true);
    }
    public void actDuck()
    {
        foreach (GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        duck.SetActive(true);
    }
}
