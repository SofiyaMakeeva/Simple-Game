using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Coin _coin;

    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i);
        }

        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            Coin newCoin = Instantiate(_coin, _points[i].position, Quaternion.identity);

            yield return null;
        }
    }
}
