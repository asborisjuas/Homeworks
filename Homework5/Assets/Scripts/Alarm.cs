using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private float _volumeStep = 0.2f;

    private Coroutine _coroutine;

    public float MinVolume => 0f;
    public float MaxVolume => 1f;

    public void Play(float finalVolume)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(nameof(ChangeVolume), finalVolume);
    }

    private IEnumerator ChangeVolume(float finalVolume)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        while (Mathf.Approximately(audioSource.volume, finalVolume) == false)
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, finalVolume, _volumeStep * Time.deltaTime);
            yield return null;
        }
    }
}