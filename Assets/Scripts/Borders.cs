using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _leftBorders;
    [SerializeField]
    private GameObject[] _rightBorders;
    private float _lastYPos;
    private int _currentIndex;
    private float _borderWidth;
    private float _borderHeight;
    private float _xOffset;
    // Start is called before the first frame update
    void Start()
    {
        _lastYPos = 0;
        _currentIndex = 0;
        SpriteRenderer sr = _leftBorders[0].GetComponent<SpriteRenderer>();
        _borderWidth = sr.sprite.bounds.size.x * _leftBorders[0].transform.localScale.x;
        _borderHeight = sr.sprite.bounds.size.y * _leftBorders[0].transform.localScale.y;
        _xOffset = GameConrtoller.WorldScreenWidth / 2;

        for (int i = 0; i < _leftBorders.Length; i++)
        {
            _leftBorders[i].transform.position = new Vector3(-_xOffset, _lastYPos, 0);
            _rightBorders[i].transform.position = new Vector3(_xOffset, _lastYPos, 0);
            _lastYPos -= _borderHeight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_leftBorders[_currentIndex].transform.position.y - Camera.main.transform.position.y > _borderHeight * 1.2f)
        {
            _leftBorders[_currentIndex].transform.position = new Vector3(-_xOffset, _lastYPos, 0);
            _rightBorders[_currentIndex].transform.position = new Vector3(_xOffset, _lastYPos, 0);
            _lastYPos -= _borderHeight;
            _currentIndex = (_currentIndex + 1) % _leftBorders.Length;
        }
    }
}
