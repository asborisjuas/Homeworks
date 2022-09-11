using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    private const float MinVolume = 0f;
    private const float MaxVolume = 1f;

    [SerializeField] private float _volumeStep = 0.2f;

    private Coroutine _coroutine;

    public void IncreaceVolume()
    {
        Play(MaxVolume);
    }

    public void DecreaceVolume()
    {
        Play(MinVolume);
    }

    private void Play(float finalVolume)
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