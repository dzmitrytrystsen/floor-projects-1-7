﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsLooper : MonoBehaviour
{
    [SerializeField] private LooperType _looperType;
    [SerializeField] private GameObject _floorBlockPrefab;

    
    private static List<GameObject> _floors = new List<GameObject>();
    private Vector3 _nextFloorPosition;
    private Vector3 _verticalOffset = new Vector3(0f, 10f, 0f);
    private enum LooperType { Creator, Destroyer };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (_looperType == LooperType.Creator)
                CreateNextFloor();
            else
                DestroyPrevFloor();
        }
    }

    private void DestroyPrevFloor()
    {
        if (_floors.Count > 2)
        {
            Destroy(_floors[0]);
            _floors.RemoveAt(0);
        }
    }

    private void CreateNextFloor()
    {
        _nextFloorPosition = transform.parent.position - _verticalOffset;
        _floors.Add(Instantiate(_floorBlockPrefab, _nextFloorPosition, Quaternion.identity));
        Destroy(gameObject);
    }
}
