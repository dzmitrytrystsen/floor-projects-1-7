using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzingLight : MonoBehaviour
{
    [Header("Buzzing Settings")]
    [SerializeField] private float minBuzzTime = 0f;
    [SerializeField] private float maxBuzzTime = 0.5f;

    private AudioSource _audioSource;
    private Light _light;

    private bool _isSwitched = false;
    private int _signal = 0;
    private float _nextTimeForGlitch { get => Random.Range(minBuzzTime, maxBuzzTime); }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _light = GetComponent<Light>();
    }

    private void Update()
    {
        if (!_isSwitched)
        {
            if (_signal == 0)
            {
                _audioSource.Play();
                _light.enabled = true;
                StartCoroutine(BuzzingEfffect(_nextTimeForGlitch));
                _signal = 1;
            }

        }
        else
        {
            if (_signal == 1)
            {
                _audioSource.Stop();
                _light.enabled = false;
                StartCoroutine(BuzzingEfffect(_nextTimeForGlitch));
                _signal = 0;
            }
        }
    }

    private IEnumerator BuzzingEfffect(float timeForGlitch)
    {
        yield return new WaitForSeconds(timeForGlitch);

        _isSwitched = !_isSwitched;
    }
}
