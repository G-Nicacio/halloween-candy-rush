using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [Header("Referências")]
    [SerializeField] private GameObject candyPrefab;
    [SerializeField] private GameObject[] hazardPrefabs;

    [SerializeField] private Transform candySpawnPointsParent;
    [SerializeField] private Transform obstacleSpawnPointsParent;

    [SerializeField] private Transform candyContainer;
    [SerializeField] private Transform obstaclesContainer;

    private List<Transform> candySpawnPoints = new List<Transform>();
    private List<Transform> obstacleSpawnPoints = new List<Transform>();

    private GameObject currentCandy;
    private int lastCandySpawnIndex = -1;

    void Start()
    {
        GameController.Init();

        LoadSpawnPoints();
        SpawnNewRound();
    }

    void Update()
    {
        if (GameController.gameOver) return;

        GameController.UpdateTimers(Time.deltaTime);

        if (GameController.IsCandyTimeOver())
        {
            DestroyCurrentCandy();
            SpawnNewCandy();
            GameController.ResetCandyTimer();
        }

        if (GameController.IsGlobalTimeOver())
        {
            GameController.ProcessGlobalFee();
        }
    }

    void LoadSpawnPoints()
    {
        candySpawnPoints.Clear();
        obstacleSpawnPoints.Clear();

        foreach (Transform child in candySpawnPointsParent)
        {
            candySpawnPoints.Add(child);
        }

        foreach (Transform child in obstacleSpawnPointsParent)
        {
            obstacleSpawnPoints.Add(child);
        }
    }

    public void OnCandyCollected()
    {
        GameController.CollectCandy();
        GameController.IncreaseDifficulty();

        ClearHazards();
        DestroyCurrentCandy();

        SpawnNewRound();
    }

    void SpawnNewRound()
    {
        SpawnNewCandy();
        SpawnHazards();
        GameController.ResetCandyTimer();
    }

    void SpawnNewCandy()
    {
        if (candySpawnPoints.Count == 0 || candyPrefab == null) return;

        int randomIndex;

        if (candySpawnPoints.Count == 1)
        {
            randomIndex = 0;
        }
        else
        {
            do
            {
                randomIndex = Random.Range(0, candySpawnPoints.Count);
            }
            while (randomIndex == lastCandySpawnIndex);
        }

        lastCandySpawnIndex = randomIndex;

        Transform spawnPoint = candySpawnPoints[randomIndex];

        currentCandy = Instantiate(candyPrefab, spawnPoint.position, Quaternion.identity, candyContainer);
    }

    void DestroyCurrentCandy()
    {
        if (currentCandy != null)
        {
            Destroy(currentCandy);
            currentCandy = null;
        }
    }

    void SpawnHazards()
    {
        if (hazardPrefabs == null || hazardPrefabs.Length == 0 || obstacleSpawnPoints.Count == 0) return;

        int hazardCount = GetHazardCountByScore();

        List<int> usedIndexes = new List<int>();

        for (int i = 0; i < hazardCount; i++)
        {
            int randomIndex = Random.Range(0, obstacleSpawnPoints.Count);

            int safetyCounter = 0;
            while (usedIndexes.Contains(randomIndex) && safetyCounter < 20)
            {
                randomIndex = Random.Range(0, obstacleSpawnPoints.Count);
                safetyCounter++;
            }

            if (!usedIndexes.Contains(randomIndex))
            {
                usedIndexes.Add(randomIndex);
                Transform spawnPoint = obstacleSpawnPoints[randomIndex];

                GameObject chosenHazardPrefab = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

                Instantiate(chosenHazardPrefab, spawnPoint.position, Quaternion.identity, obstaclesContainer);
            }
        }
    }

    int GetHazardCountByScore()
    {
        return Mathf.Min(5, 1 + GameController.score / 100);
    }

    void ClearHazards()
    {
        foreach (Transform child in obstaclesContainer)
        {
            Destroy(child.gameObject);
        }
    }
}