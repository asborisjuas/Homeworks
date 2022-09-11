using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponentInChildren<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _alarm.Play(_alarm.MaxVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            _alarm.Play(_alarm.MinVolume);
        }
    }
}
