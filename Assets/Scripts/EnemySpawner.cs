using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{

    public float spawnRadius = 40f;
    public int tanksCount = 4;

    [SerializeField]
    private GameObject characterPrefab;

    private int count = 0;
    private GameObject[] tanks;

    Vector3 spawnPosition;
    NavMeshAgent agent;



    void Start()
    {
        while (tanksCount > count)
        {
            SpawnTank();
            count += 1;
        }
    }

    private void Update() 
    {
        tanks = GameObject.FindGameObjectsWithTag("Tank");
        print (tanks.Length);
        if (tanks.Length < tanksCount) 
        {
           SpawnTank();
        }    
    }

    public void SpawnTank()
    {
        spawnPosition = RandomNavSphere(transform.position, spawnRadius, -1);
        Instantiate(characterPrefab, spawnPosition, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }

}
