using UnityEngine;
using System;
using System.Collections;

public class BulletPattern
{
    public int NumberOfEmitters { get; private set; }
    public int NumberOfEmitterArrays{ get; private set; }

    public float BulletMovementSpeed { get; private set; }
    public float BulletAcceleration { get; private set; }
    public float EmitterDegreeOfSeparation { get; private set; }
    public float EmitterArrayDegreeOfSeparation { get; private set; }

    public BulletPattern(int id, string gameObjectName)
    {
        BulletMovementSpeed = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "BulletSpeed", "Pattern", id));

        BulletAcceleration = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "BulletAccel", "Pattern", id));

        EmitterDegreeOfSeparation = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "EmitterDegOfSep", "Pattern", id));

        EmitterArrayDegreeOfSeparation = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "EmitterArrayDegOfSep", "Pattern", id));

        NumberOfEmitters = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "EmitterCount", "Pattern", id));

        NumberOfEmitterArrays = Convert.ToInt32(DatabaseManager.ReturnQueriedData(DataQueryType.Enemies, gameObjectName, "EmitterArrayCount", "Pattern", id));
    }

    internal void Give()
    {
        Debug.Log(BulletAcceleration);
    }
}
