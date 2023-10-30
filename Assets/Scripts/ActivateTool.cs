using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTool : MonoBehaviour
{
    public GameObject drawTool;
    public GameObject eraseTool;
    public GameObject flySwatter;

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
}
