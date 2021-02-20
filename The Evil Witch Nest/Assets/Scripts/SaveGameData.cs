using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveGameData
{
    public int level;
    public int health;
    public float[] playerPosition;

    public SaveGameData(int level, int health, Vector3 position)
    {
        this.level = level;
        this.health = health;
        this.playerPosition = new float[] { position.x, position.y, position.y };
    }
}
