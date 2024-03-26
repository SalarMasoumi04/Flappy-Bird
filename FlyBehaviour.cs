using System;
using System.Collections;
using UnityEngine;      

public class FlyBehaviour : MonoBehaviour
{
    [SerializeField] private float _velocity = 1.5f;
    [SerializeField] private float _rotationspeed = 10f;

    public static event Action Died;
    public static event Action ScoreAdded;
    
    private Rigidbody2D _rigidbody;
    
    private void OnCollisionEnter2D() => Died?.Invoke();

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ScoreCounter());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = Vector2.up * _velocity;
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, _rigidbody.velocity.y * _rotationspeed);
    }

    private IEnumerator ScoreCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ScoreAdded?.Invoke();
        }
    }
}
