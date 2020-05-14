using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMount : MonoBehaviour
{

    public GameObject mountedRocket1;
    public GameObject mountedRocket2;

    public GameObject rocketPrefab;

    private bool rocket1Fired = false;
    private bool empty = false;

    private void Awake() 
    {
        
    }

    void Update()
    {
        
    }

    public void FireRocket() 
    {
        if (!rocket1Fired) {
            mountedRocket1.SetActive(false);
            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            rocket1Fired = true;
        } else if (!empty) {
            mountedRocket2.SetActive(false);
            GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
            empty = true;
            this.gameObject.SetActive(false);
        }
    }
}
