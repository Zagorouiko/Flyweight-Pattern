using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Entities;

public class SpawnProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    public GameObject cube;
    public int rows;
    public int columns;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new Spawner
        {
            Prefab = conversionSystem.GetPrimaryEntity(cube),
            ECSRows = rows,
            ECSColumns = columns
        };

        dstManager.AddComponentData(entity, spawnerData);
    }

    public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
    {
        gameObjects.Add(cube);
    }
}
