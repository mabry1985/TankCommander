using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player;
    public GameObject[] spawnPoints;

    private void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoints");
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        int rand = Random.Range(0, spawnPoints.Length);
        GameObject spawnPoint = spawnPoints[rand];
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
    }

}
