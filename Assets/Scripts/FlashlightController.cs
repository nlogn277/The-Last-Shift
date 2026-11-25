using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightController : MonoBehaviour
{
    public GameObject flashlight;

    private bool hasFlashlight = false;

    private void Start()
    {
        flashlight.SetActive(false);
    }

    public void PickUpFlashlight()
    {
        hasFlashlight = true;
        flashlight.SetActive(false);
    }

    private void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (hasFlashlight)
            {
                flashlight.SetActive(!flashlight.activeSelf);
            }
        }
    }
}