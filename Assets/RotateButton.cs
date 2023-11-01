using UnityEngine;
using UnityEngine.UI;

public class RotateButton : MonoBehaviour
{
    public Button buttonToRotate;
    public float rotationSpeed = 90.0f; // Adjust the speed as needed

    private bool isRotating = false;

    private void Start()
    {
        buttonToRotate.onClick.AddListener(ToggleRotation);
    }

    private void Update()
    {
        if (isRotating)
        {
            buttonToRotate.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    private void ToggleRotation()
    {
        isRotating = !isRotating;
    }
}
