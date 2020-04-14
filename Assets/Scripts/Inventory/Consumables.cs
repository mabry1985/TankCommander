using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "new Consumables", menuName = "Items/Consumables")]
public class Consumables : Item
{
    
    [SerializeField]
    private float heal = 0f;

    [SerializeField]
    public int _cost;

    public override void Use()
    {
        GameObject player = Inventory.instance.player;
        TankHealth tankHealth = player.GetComponent<TankHealth>();

        tankHealth.Heal(heal);
        Inventory.instance.Remove(this);
    }

    public override void Buy()
    {
        GameObject coinManager = Store.instance.coinManager;
        CoinManager coinManagerScript = coinManager.GetComponent<CoinManager>();

        coinManagerScript.RemoveCoin(_cost);
        Store.instance.Remove(this);



    }

}
