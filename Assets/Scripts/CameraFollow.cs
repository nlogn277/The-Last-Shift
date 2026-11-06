using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 5, -7);

    public float Speed = 5f;

    void LateUpdate()
    {
        if (player == null)
            return;

        Vector3 desiredPosition = player.position + offset;

        transform.position = Vector3.Lerp(
            transform.position, desiredPosition, Speed * Time.deltaTime);

        transform.LookAt(player);
    }

}