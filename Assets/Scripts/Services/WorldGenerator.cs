using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private int visibleChunks = 5;
    [SerializeField] private float chunkLength = 10;
    [SerializeField] private float setUnvisibleOffset = 1;
    [SerializeField] private Transform startPoint;

    [SerializeField] private ChunkObjectPool chunkPool;

    private ScoreCounter scoreCounter;
    private Queue<GameObject> activeChunks;

    private Vector3 roadDirection { get => Vector3.forward; }

    private int currentChunk = 0;
    private Vector3 currentChunkPosition;

    public void InitDependecies(ScoreCounter scoreCounter)
    {
        this.scoreCounter = scoreCounter;
    }

    private void Start()
    {
        activeChunks = new Queue<GameObject>();
        currentChunkPosition = startPoint.position - roadDirection * (chunkLength / 2);
        
        for(int i = 0; i < visibleChunks; i++)
        {
            GenerateNextChunk();
        }

    }

    private void Update()
    {
        if (currentChunk != (int)((scoreCounter.RawDistance - setUnvisibleOffset) / chunkLength))
        {
            currentChunk++;
            RemoveUnvisibleChunk();
            GenerateNextChunk();
        }
    }

    private void RemoveUnvisibleChunk()
    {
        GameObject unvisible = activeChunks.Dequeue();
        chunkPool.ReturnChunk(unvisible);
    }

    private void GenerateNextChunk()
    {
        GameObject newChunk = chunkPool.GetChunk();
        LocateChunk(newChunk);

        activeChunks.Enqueue(newChunk);
    }

    private void LocateChunk(GameObject chunk)
    {
        currentChunkPosition += roadDirection * chunkLength;
        chunk.transform.position = currentChunkPosition;
    }
}
