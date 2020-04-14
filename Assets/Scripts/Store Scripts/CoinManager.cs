using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    [SerializeField]
    public int _cointCount;
    
    public Text _coinCountText;

    void Start()
    {
        _coinCountText = transform.GetComponentInChildren<Text>();
        _coinCountText.text = "$ " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        _coinCountText.text = "$ " + _cointCount.ToString();
    }

    public void CollectCoin()
    {
        _cointCount += 1;
    }

    public void RemoveCoin(int cost)
    {
        _cointCount -= cost;
    }

}
