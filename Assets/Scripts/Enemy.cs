using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public UnityAction<float> OnPlayerCollision;

    [SerializeField]
    private float _damageValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnPlayerCollision(_damageValue);
            transform.position = new Vector3(-GameConrtoller.WorldScreenWidth, transform.position.x, 0);
        }
    }
}
