using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int secondsBetweenSpawn = 2;

    [SerializeField] private Enemy _enemyOriginal;
    [SerializeField] private Transform[] _pointsTransform;

    private readonly WaitForSeconds _waitForSeconds = new(secondsBetweenSpawn);
    private int _spawnedEnemuesCount = 0;

    private void Start()
    {
        StartCoroutine(SpawnAfterWaiting());
    }

    private IEnumerator SpawnAfterWaiting()
    {
        yield return _waitForSeconds;
        Spawn();
    }

    private void Spawn()
    {
        int index = _spawnedEnemuesCount % _pointsTransform.Length;

        Instantiate(_enemyOriginal, _pointsTransform[index]);
        _spawnedEnemuesCount++;
        StartCoroutine(SpawnAfterWaiting());
    }
}
