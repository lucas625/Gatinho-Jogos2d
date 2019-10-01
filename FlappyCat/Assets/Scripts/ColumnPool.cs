﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    public GameObject ColumnPrefab;
    private Vector2 ObjectPoolPosition = new Vector2(-15f, -25f);
    public int ColumnPoolSize = 10;
    private GameObject[] Columns;

    public float SpawnRate = 4f;
    private float TimeSinceLastSpawned; // used to move the columns

    // values for the column position
    private float SpamnXPosition = 22f;
    public float ColumnMin = -2.5f;
    public float ColumnMax = 2.5f;
    private int CurrentColumn = 0;


    // Start is called before the first frame update
    void Start()
    {
        Columns = new GameObject[ColumnPoolSize];
        for (int i = 0; i < ColumnPoolSize; i++)
        {
            Columns[i] = (GameObject)Instantiate(ColumnPrefab, ObjectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameController.instance.IsStarted() && (!GameController.instance.IsPaused())) 
        {
            TimeSinceLastSpawned += Time.deltaTime;
            if ((!GameController.instance.GameOver) && TimeSinceLastSpawned >= (int)SpawnRate)
            {
                SpawnRate = 2f +(Random.Range(0, 6) / (-1f * GameController.instance.ScrollSpeed));
                TimeSinceLastSpawned = 0;
                float SpamnYPosition = Random.Range(ColumnMin, ColumnMax);
                Columns[CurrentColumn].transform.position = new Vector2(SpamnXPosition, SpamnYPosition);
                CurrentColumn = (CurrentColumn + 1) % ColumnPoolSize;
            }
        }
        

    }
}
