using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -0.5f;
    public float maxHeight = 1.5f;

    private void OnEnable() {

        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {

        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {

        GameObject laser = Instantiate(prefab, transform.position, Quaternion.identity);
        laser.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
