using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const float Velocity = 5f;
    private const float DestinationX = 11.5f;
    
    private Transform _transform;
    private Vector2 _destination;
    
    private void Awake()
    {
        _transform = transform;
        _destination = new(DestinationX, _transform.position.y);
    }

    private void Update()
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
