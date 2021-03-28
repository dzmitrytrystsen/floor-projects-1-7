using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDestroyer : MonoBehaviour
{
    [SerializeField] GameObject[] levelObjects;
    [SerializeField] AudioSource _caveAmbient;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;

            foreach (GameObject levelObject in levelObjects)
            {
                Destroy(levelObject);
            }

            _caveAmbient.gameObject.SetActive(true);
            _caveAmbient.Play();
            Destroy(gameObject);
        }
    }
}
