using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    private GameObject _enemyChar;
    private Transform _enemyTransform;

    private Vector3 _enemySpawnLocation;

    public float _enemySpawn_X;
    public float _enemySpawn_Z;
    public float _enemySpawn_Y;

    private Transform _platformTransform;
    private float _platformSize_X;
    private float _platformSize_Z;
    private float _platformSize_Y;

    private Transform _playerTransform;
    private const float RotationSpeed = 1.0f;



    private const float _respawnHeight = -10f;
    private const float _abovePlatformHeight = 1f;
    private const float _platformOffset = 1f;


    // public UpdatePlayerInfo UpdatePlayerInfo;
    // Start is called before the first frame update
    void Start()
    {
        _platformTransform = GameObject.Find("Platform").transform;

        _platformSize_X = _platformTransform.localScale.x / 2 - _platformOffset;
        _platformSize_Z = _platformTransform.localScale.z / 2 - _platformOffset;
        _platformSize_Y = _platformTransform.localScale.y + _abovePlatformHeight;
        InvokeRepeating("SpawnEnemy", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_cooldown)
        {
            _cooldownDelay = 1f / SpeedManager.enemySpawnScaling;
            SpawnEnemy();
            _cooldown = true;
            StartCoroutine(Cooldown());
        }
    }
    
    private bool _cooldown = false;
    private float _cooldownDelay = 1f;

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(_cooldownDelay);
        _cooldown = false;
    }

    void SpawnEnemy() {
        _enemyChar = GameObject.Instantiate(Resources.Load("Enemy"), _enemySpawnLocation, Quaternion.identity) as GameObject;
        _enemyTransform = _enemyChar.transform;

        _enemySpawn_X = _platformTransform.position[0] + Random.Range(-_platformSize_X, _platformSize_X);
        _enemySpawn_Z = _platformTransform.position[2] + Random.Range(-_platformSize_X, _platformSize_X);
        _enemySpawn_Y = _platformTransform.position[1] + _platformSize_Y;
        _enemySpawnLocation = new Vector3(_enemySpawn_X, _enemySpawn_Y, _enemySpawn_Z);
        _enemyTransform.position = _enemySpawnLocation;     
    }
}
