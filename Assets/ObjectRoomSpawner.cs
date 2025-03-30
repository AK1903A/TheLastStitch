using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRoomSpawner : MonoBehaviour
    
{
    [System.Serializable]
    public struct RandomSpawner
    {
        public string name;
        public SpawnerData spawnerData;

    }
    public GridController grid;
    public RandomSpawner[] spawnerData;

    void Start()
    {
      //grid = GetComponent<GridController>();


    }
    public void InitialiseObjectSpawning()
    {
        foreach (RandomSpawner randomSpawner in spawnerData)
        {
            SpawnObject(randomSpawner);
        }
    }
    void SpawnObject(RandomSpawner data)
    {
        int randomIteration = Random.Range(data.spawnerData.minSpawn, data.spawnerData.maxSpawn + 1);
        for (int i = 0; i < randomIteration; i++)
        {
            int randomPos = Random.Range(0, grid.availablePoints.Count - 1);
            GameObject go = Instantiate(data.spawnerData.itemToSpawn, grid.availablePoints[randomPos], Quaternion.identity,transform) as GameObject;
            grid.availablePoints.RemoveAt(randomPos);
            Debug.Log("Spawned Object");
        }
    }
}
