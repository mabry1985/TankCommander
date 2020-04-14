using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();

    }
    void Update()
    {
        coinManager._coinCountText.text = "$ " + coinManager._cointCount;
    }
}
