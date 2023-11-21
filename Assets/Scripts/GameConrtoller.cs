using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameConrtoller : MonoBehaviour
{
    public static float WorldScreenHeight { get; private set; }
    public static float WorldScreenWidth { get; private set; }
    public static GameState CurrentGameState;
    private Vector2 _firstMousePosition;
    private Vector2 _lastMousePosition;
    private bool _isStartLine;
    private EnemySpawner _enemySpawner;
    [SerializeField]
    private Transform barrier;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Slider _healthBar;
    private Player _playerScript;
    private float _playerHealth;

    void Awake()
    {
        WorldScreenHeight = Camera.main.orthographicSize * 2;
        WorldScreenWidth = WorldScreenHeight / Screen.height * Screen.width;
        CurrentGameState = GameState.STARTING;
        _isStartLine = true;
        _enemySpawner = GetComponent<EnemySpawner>();
        _playerScript = _player.GetComponent<Player>();
        _playerHealth = _playerScript.Health;
        _healthBar.maxValue = _playerScript.Health;
        _healthBar.value = _playerScript.Health;

        // Array.ForEach(_enemySpawner.EnemyPool, enemy => enemy.OnPlayerCollision = CheckCollisionImpact);
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject enemy in GetComponent<EnemySpawner>().EnemyPool)
            enemy.GetComponent<Enemy>().OnPlayerCollision += CheckCollisionImpact;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isStartLine)
        {
            _isStartLine = false;
            _firstMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(_lastMousePosition, _firstMousePosition) > 0.1f)
            {
                // Debug.Log("Distance: " + Vector2.Distance(_lastMousePosition, _firstMousePosition));
                Vector3 direction = _lastMousePosition - _firstMousePosition;
                barrier.position = new Vector3(_lastMousePosition.x, _lastMousePosition.y, 0);
                var angle = Mathf.Atan2(_lastMousePosition.y - _firstMousePosition.y, _lastMousePosition.x - _firstMousePosition.x) * 180 / Mathf.PI;
                // float angle2 = Vector2.SignedAngle(_lastMousePosition - _firstMousePosition, Vector2.right);
                barrier.eulerAngles = new Vector3(0, 0, angle);
            }
            _isStartLine = true;
        }
    }

    private void CheckCollisionImpact(float damage)
    {
        _playerHealth -= damage;
        _healthBar.value = _playerHealth;
        Debug.Log($"Health: {_playerHealth}");
        if (_playerHealth <= 0)
        {
            // TODO: Game over! Do final actions.
            Debug.Log("Game Over!");
        }
    }

    public enum GameState
    {
        STARTING,
        RUNNING,
        PAUSE,
        RESUME,
    }
}