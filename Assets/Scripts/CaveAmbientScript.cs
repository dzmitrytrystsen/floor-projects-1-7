using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveAmbientScript : MonoBehaviour
{
    [SerializeField] private AudioClip[] _horrorSounds;

    [Header("Sounds Settings")]
    [SerializeField] private float minTime = 10f;
    [SerializeField] private float maxTime = 30f;

    private AudioSource _audioSource;
    private bool _ifReadyToPlay = false;

    private float _nextTimeForSound { get => Random.Range(minTime, maxTime); }


    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlaySoundAfter(_nextTimeForSound));
    }

    private void FixedUpdate()
    {
        if (_ifReadyToPlay)
        {
            PlayRandomHorrorSound();
        }
    }
    private void PlayRandomHorrorSound()
    {
        AudioClip randomHorrorSound = _horrorSounds[Random.Range(0, _horrorSounds.Length)];
        _audioSource.PlayOneShot(randomHorrorSound);

        StartCoroutine(PlaySoundAfter(_nextTimeForSound));
        _ifReadyToPlay = false;
    }
    private IEnumerator PlaySoundAfter(float timeForHorrorSound)
    {
        yield return new WaitForSeconds(timeForHorrorSound);

        Debug.Log("Ready to play sound!");
        _ifReadyToPlay = true;
    }
}
