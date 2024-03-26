using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _width = 6f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _startSize = _spriteRenderer.size;
    }

    private void Update()
    {
        var size = _spriteRenderer.size;
        size.x += _speed * Time.deltaTime;
        
        if (size.x > _width)
        {
            size = _startSize;
        }
        
        _spriteRenderer.size = size;
    }
}