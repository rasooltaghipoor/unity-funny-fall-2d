using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConrtoller : MonoBehaviour
{
    public static float WorldScreenHeight { get; private set; }
    public static float WorldScreenWidth { get; private set; }
    public static GameState GameState;

    void Awake()
    {
        WorldScreenHeight = Camera.main.orthographicSize * 2;
        WorldScreenWidth = WorldScreenHeight / Screen.height * Screen.width;
        GameState = GameState.STARTING;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public enum GameState
{
    STARTING,
    RUNNING,
    PAUSE,
    RESUME,
}
