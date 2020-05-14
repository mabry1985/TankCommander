using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMount : MonoBehaviour
{

    public GameObject mountedRocket1;
    public GameObject mountedRocket2;
    public GameObject rocketSpawnPoint;
    public GameObject rocketPrefab;

    public bool infiniteRockets = true;

    private bool rocket1Fired = false;
    private bool empty = false;

    public void FireRocket() 
    {
        if (!rocket1Fired) {
            mountedRocket1.SetActive(false);
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, transform.rotation);
            rocket1Fired = true;
        } else if (!empty) {
            mountedRocket2.SetActive(false);
            GameObject rocket = Instantiate(rocketPrefab, rocketSpawnPoint.transform.position, transform.rotation);
            empty = true;
        } else if (infiniteRockets) {
            Reload();
        } else {
            this.gameObject.SetActive(false);
        }
    }

    private void Reload()
    {
        rocket1Fired = false;
        empty = false;
        mountedRocket1.SetActive(true);
        mountedRocket2.SetActive(true);     
    }


}
