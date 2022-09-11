using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float Velocity = 5f;
    
    private Transform _transform;
    private Vector2 _destination;
    
    private void Awake()
    {
        _transform = transform;
        _destination = new(11.5f, _transform.position.y);
    }

    void Update()
    {
        if (_transform.position.x <= _destination.x)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, _destination, Velocity * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
