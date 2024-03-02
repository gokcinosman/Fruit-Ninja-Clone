using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits;
    public GameObject bombPrefab;
    public float bombChance = 0.1f;
    private Collider spawnArea;
    public float maxSpawnRate = 1f;
    public float minSpawnRate = 0.3f;
    public float minAngle = -15f;
    public float maxAngle = 15f;
    public float minForce = 16f;
    public float maxForce = 22f;
    public float maxLifeTime = 10f;


    private void Awake()
    {

        spawnArea = GetComponent<Collider>();
    }
    private void OnEnable()
    {

        StartCoroutine(SpawnFruits());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }
    private IEnumerator SpawnFruits()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            RandomizeFruit();
            yield return new WaitForSeconds(Random.Range(minSpawnRate, maxSpawnRate));
        }
    }

    public void RandomizeFruit()
    {
        GameObject fruit = fruits[Random.Range(0, fruits.Length)];
        if (Random.value < bombChance)
        {
            fruit = bombPrefab;
        }
        Vector3 spawnPosition = new Vector3
        {
            x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z)
        };
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));
        GameObject spawnedFruit = Instantiate(fruit, spawnPosition, spawnRotation);
        Destroy(spawnedFruit, maxLifeTime);
        float force = Random.Range(minForce, maxForce);
        spawnedFruit.GetComponent<Rigidbody>().AddForce(spawnedFruit.transform.up * force, ForceMode.Impulse);


    }



}
