using UnityEngine;

class RandomFromListChunkFactory : ChunkFactory
{
    [SerializeField] private Transform ChunksParent;
    [SerializeField] private ChunkPresets presets;

    public override GameObject CreateChunk()
    {
        int random = Random.Range(0, presets.Presets.Length);
        GameObject chunk = GameObject.Instantiate(presets.Presets[random],ChunksParent);
        return chunk;
    }
}

