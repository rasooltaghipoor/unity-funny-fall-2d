using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConrtoller : MonoBehaviour
{
    public static float WorldScreenHeight { get; private set; }
    public static float WorldScreenWidth { get; private set; }
    public static GameState CurrentGameState;
    private Vector2 firstMousePosition;
    private Vector2 lastMousePosition;
    private bool isStartLine;
    [SerializeField]
    private Transform barrier;

    void Awake()
    {
        WorldScreenHeight = Camera.main.orthographicSize * 2;
        WorldScreenWidth = WorldScreenHeight / Screen.height * Screen.width;
        CurrentGameState = GameState.STARTING;
        isStartLine = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isStartLine)
        {
            isStartLine = false;
            firstMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lastMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(lastMousePosition, firstMousePosition) > 0.1f)
            {
                // Debug.Log("Distance: " + Vector2.Distance(lastMousePosition, firstMousePosition));
                Vector3 direction = lastMousePosition - firstMousePosition;
                barrier.position = new Vector3(lastMousePosition.x, lastMousePosition.y, 0);
                var angle = Mathf.Atan2(lastMousePosition.y - firstMousePosition.y, lastMousePosition.x - firstMousePosition.x) * 180 / Mathf.PI;
                // float angle2 = Vector2.SignedAngle(lastMousePosition - firstMousePosition, Vector2.right);
                barrier.eulerAngles = new Vector3(0, 0, angle);
            }
            isStartLine = true;
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