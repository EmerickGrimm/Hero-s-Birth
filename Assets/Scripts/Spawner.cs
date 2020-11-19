﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] baffSpawnPoints;

    [Header ("Для точек с пометкой 1")] public Transform[] bacteriumSpawnPoints1;

    [Header("Для точек с пометкой 2")] public Transform[] bacteriumSpawnPoints2;    

    public GameObject bacteriumPrefab;

    public GameObject mucusPrefab;

    public float spawnBacteriumDelay;

    public float spawnBuffsDelay;

    private float timeToSpawnBacterium;

    private float timeToSpawnBuff;

    void Start()
    {
        timeToSpawnBacterium = spawnBacteriumDelay;
        timeToSpawnBuff = spawnBuffsDelay;
    }

    private void FixedUpdate()
    {
        if (timeToSpawnBacterium > 0)
            timeToSpawnBacterium -= 0.02f;
        else
        {
            SpawnBacterium();
            timeToSpawnBacterium = spawnBacteriumDelay;
        }

        if (timeToSpawnBuff > 0)
            timeToSpawnBuff -= 0.02f;
        else
        {
            SpawnMucus();
            timeToSpawnBuff = spawnBacteriumDelay;
        }
    }

    private void SpawnBacterium()
    {
        int rand = Random.Range(0,2); // Для рандомизации точки начала движения
        if (rand == 0)
        {
            rand = Random.Range(0, bacteriumSpawnPoints1.Length);
            GameObject bact = Instantiate(bacteriumPrefab, bacteriumSpawnPoints1[rand]);
            bact.GetComponent<BacteriumController>().SetFinishTransform(bacteriumSpawnPoints2[rand]);
        }
        else
        {
            rand = Random.Range(0, bacteriumSpawnPoints1.Length);
            GameObject bact = Instantiate(bacteriumPrefab, bacteriumSpawnPoints2[rand]);
            bact.GetComponent<BacteriumController>().SetFinishTransform(bacteriumSpawnPoints1[rand]);
        }
    }

    private void SpawnMucus()
    {
        int rand = Random.Range(0, baffSpawnPoints.Length);
        GameObject mucus = Instantiate(mucusPrefab, baffSpawnPoints[rand]);
    }

}