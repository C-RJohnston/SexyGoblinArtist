using UnityEngine;

public class ResetCanvas : MonoBehaviour
{
    public GameObject strokeManager;
    public void CanvasClear()
    {
        foreach (Transform child in strokeManager.transform)
        {
            Destroy(child.gameObject);
        }
    }
    

}
