using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    private int coins = 0;
    public void addCoin(int coinValue)
    {
        if (coinValue > 0)
            coins += coinValue;
    }
}
