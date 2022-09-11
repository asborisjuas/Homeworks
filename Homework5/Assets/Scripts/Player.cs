using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int _speed = 2;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _transform.Translate(_speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            _transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
    }
}