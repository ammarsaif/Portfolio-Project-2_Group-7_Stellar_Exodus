using UnityEngine;

[CreateAssetMenu(fileName = "Spawner", menuName = "Spawner/New Spawner")]
public class Spawner : ScriptableObject
{
    public GameObject[] enemies;     // Enemy prefabs to spawn
    public float[] yPositions;       // Y positions to spawn them
}