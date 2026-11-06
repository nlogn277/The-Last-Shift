using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform spawnPoint;
    public CameraFollow cameraFollow;

    public GameObject startButton;

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        cameraFollow.player = player.transform;
        Movement movement = player.GetComponent<Movement>();
        movement.SetCamera(Camera.main.transform);

        //Hide start game Button.
        startButton.SetActive(false);
    }

    
}
