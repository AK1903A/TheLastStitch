
using UnityEngine;
[CreateAssetMenu(fileName = "SpawnerAsset", menuName = "Spawners/Spawner")]

public class SpawnerData : ScriptableObject 
{
    public GameObject itemToSpawn;
    public int minSpawn;
    public int maxSpawn;
}
