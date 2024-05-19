using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] 
    private GameObject _cubePrefab;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            var cube = Instantiate(_cubePrefab);
            cube.transform.position = new Vector3(Random.Range(-12, 13), 10, 0);
        }
    }
}
