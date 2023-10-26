using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateTool : MonoBehaviour
{
    public GameObject toActivate;
    public GameObject[] tools;

    public void OnButtonClick()
    {
        foreach(GameObject tool in tools)
        {
            tool.SetActive(false);
        }
        toActivate.SetActive(true);
    }
}
