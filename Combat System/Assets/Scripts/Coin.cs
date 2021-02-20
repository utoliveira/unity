using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Gettable
{
    public int coinValue = 10;

    public override void OnPlayerGet(GameObject player)
    {
        player.GetComponent<PlayerInventory>().addCoin(coinValue);
    }
}
