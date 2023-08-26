using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConrtoller : MonoBehaviour
{
    public static float WorldScreenHeight { get; private set; }
    public static float WorldScreenWidth { get; private set; }

    void Awake()
    {
        WorldScreenHeight = Camera.main.orthographicSize * 2;
        WorldScreenWidth = WorldScreenHeight / Screen.height * Screen.width;
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
