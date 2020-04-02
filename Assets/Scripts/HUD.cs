using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text coins;

    void Update()
    {
        GameObject gameManagerObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerObject.GetComponent<GameManager>();
        coins.text = "$ " + gameManager.coinCount;
    }
}
