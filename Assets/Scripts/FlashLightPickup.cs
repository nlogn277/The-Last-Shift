using UnityEngine;

public class FlashlightPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FlashlightController flashlight =
                other.GetComponent<FlashlightController>();

            if (flashlight != null)
            {
                flashlight.PickUpFlashlight();
                Destroy(gameObject);
            }
        }
    }
}