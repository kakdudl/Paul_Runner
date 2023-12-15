using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;
    [SerializeField] private bool canSpawn;
    [SerializeField] private GameObject[] entitiesPrefabs;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float entitySpeed = 50;
    [SerializeField] private float xMarginLeft = -0.1f;
    [SerializeField] private float xMarginRight = 1.75f;
    [SerializeField] private float spawnTimer;
    [SerializeField] private float spawnTimerMax = 0.5f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        TrySpawn();
    }

    private void TrySpawn()
    {
        if (!canSpawn)
            return;
        
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        else
        {
            spawnTimer = spawnTimerMax;
            //spawn here
            SpawnEntity();
        }
    }

    public void StartScript()
    {
        canSpawn = true;
        spawnTimer = spawnTimerMax;
    }

    private void SpawnEntity()
    {
        GameObject entityToSpawn = entitiesPrefabs[Random.Range(0, entitiesPrefabs.Length)];
        spawnPosition.x = Random.Range(xMarginLeft, xMarginRight);

        GameObject spawnedEntity = Instantiate(entityToSpawn, spawnPosition, Quaternion.identity);
        spawnedEntity.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -entitySpeed);
    }
}
