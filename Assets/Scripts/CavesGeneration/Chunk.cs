using UnityEngine;

public sealed class Chunk : MonoBehaviour
{
    public const int CHUNK_WIDTH = 16;// 64;
    public const int CHUNK_HEIGHT = 128;
    public GameObject gameObj;
    public Vector2 chunkPosition;
    public Bounds bounds;
    public bool isVisible;
    public float[,,] terrainMap;
    public Vector2 currentVisibleChunkCoord;
}