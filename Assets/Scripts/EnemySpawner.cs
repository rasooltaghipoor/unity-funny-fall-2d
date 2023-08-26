using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _enemyPrefabs;
    private const int _enemyPoolSize = 30;
    private GameObject[] _enemyPool;
    private float _lastYPos;
    // Start is called before the first frame update
    void Start()
    {
        _enemyPool = new GameObject[_enemyPoolSize];
        spawnInitialEnemies();
        _lastYPos = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void spawnInitialEnemies()
    {
        for (int i = 0; i < _enemyPoolSize; i++)
        {
            _enemyPool[i] = Instantiate(_enemyPrefabs[Random.Range(0, _enemyPrefabs.Length)]) as GameObject;
            _lastYPos = Random.Range(_lastYPos - GameConrtoller.WorldScreenHeight / 2, _lastYPos - GameConrtoller.WorldScreenHeight * 2);
            _enemyPool[i].transform.position = new Vector3(Random.Range(-GameConrtoller.WorldScreenWidth * 0.75f, GameConrtoller.WorldScreenWidth * 0.75f), _lastYPos, 0);
        }
    }


}
