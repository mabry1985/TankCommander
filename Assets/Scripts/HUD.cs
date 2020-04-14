using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    
    private CoinManager coinManager;

    private void Start()
    {
        coinManager = GameObject.Find("CoinManager").GetComponent<CoinManager>();
        coinManager._coinCountText.text = "$" + 0;
    }
    void Update()
    {
        coinManager._coinCountText.text = "$ " + coinManager._cointCount;
    }
}
