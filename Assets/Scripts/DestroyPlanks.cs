using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanks : MonoBehaviour
{
    [SerializeField] private Rigidbody[] planks;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        planks = GetComponentsInChildren<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _audioSource.Play();

            Destroy(gameObject.GetComponent<BoxCollider>());
            foreach (Rigidbody plank in planks)
            {
                plank.isKinematic = false;
                plank.gameObject.GetComponent<BoxCollider>().enabled = false;
            }

            StartCoroutine(SwitchKinematicAfterSecs());
        }
    }

    IEnumerator SwitchKinematicAfterSecs()
    {
        yield return new WaitForSeconds(0.3f);

        foreach (Rigidbody plank in planks)
        {
            plank.gameObject.GetComponent<Collider>().enabled = true;
        }

        StopAllCoroutines();
    }
}
