using UnityEngine;
using System;
using System.Collections;

public class BulletPattern
{
    float BulletMovementSpeed;

    public BulletPattern(int id, string gameObjectName)
    {
        BulletMovementSpeed = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "BulletSpeed", "Pattern", id));
    }

    internal void Give()
    {
        Debug.Log(BulletMovementSpeed);
    }
}
