using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int Delay = 2;
    private const int TotalEnemiesToSpawn = 100;

    [SerializeField] private EnemyMover _prefab;
    [SerializeField] private Transform[] _pointsTransform;

    private int _spawnedEnemiesCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnAfterWaiting());
    }

    private IEnumerator SpawnAfterWaiting()
    {
        var waitForDelay = new WaitForSeconds(Delay);
        
        while (_spawnedEnemiesCount < TotalEnemiesToSpawn)
        {
            Spawn();
            yield return waitForDelay;
        }        
    }

    private void Spawn()
    {
        int index = _spawnedEnemiesCount % _pointsTransform.Length;

        Instantiate(_prefab, _pointsTransform[index]);
        _spawnedEnemiesCount++;
    }
}
