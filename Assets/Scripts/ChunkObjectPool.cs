using System.Collections.Generic;
using UnityEngine;

public class ChunkObjectPool:MonoBehaviour
{
    [SerializeField] private ChunkFactory chunkFactory;
    [SerializeField] private int initialPoolSize = 5;

    private List<GameObject> objectPool;
    private List<int> freeIndices;

    private void InitObjectPool()
    {
        objectPool = new List<GameObject>(initialPoolSize);
        for(int i = 0; i < initialPoolSize; i++)
        {
            GameObject chunk = chunkFactory.CreateChunk();
            chunk.SetActive(false);
            objectPool.Add(chunk);
        }

        freeIndices = new List<int>(initialPoolSize);
        for (int i = 0; i < objectPool.Count; i++)
            freeIndices.Add(i);
    }

    public GameObject GetChunk()
    {
        if(objectPool == null)
            InitObjectPool();

        if (freeIndices.Count == 0)
        {
            GameObject newChunk = chunkFactory.CreateChunk();
            objectPool.Add(newChunk);
            return newChunk;
        }

        int random = Random.Range(0, freeIndices.Count);
        GameObject chunk = objectPool[freeIndices[random]];
        chunk.SetActive(true);
        freeIndices.RemoveAt(random);

        return chunk;
    }

    public void ReturnChunk(GameObject chunk)
    {
        chunk.SetActive(false);
        freeIndices.Add(objectPool.IndexOf(chunk));
    }
}

