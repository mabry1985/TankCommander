using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{

    [SerializeField]
    public int _coinCount = 0;
    
    public Text _coinCountText;

    void Start()
    {
        
        _coinCountText = transform.GetComponentInChildren<Text>();
        _coinCount = 0;
        _coinCountText.text = "$ " + _coinCount;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void CollectCoin()
    {
        _coinCount += 1;
        _coinCountText.text = "$ " + _coinCount.ToString();
    }

    public void RemoveCoin(int cost)
    {
        _coinCount -= cost;
        _coinCountText.text = "$ " + _coinCount.ToString();

    }

}
