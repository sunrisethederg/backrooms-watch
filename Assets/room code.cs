using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    public int numSegments = 10;
    public float minWallLength = 1f;
    public float maxWallLength = 5f;

    void Start()
    {
        GenerateWalls();
    }

    void GenerateWalls()
    {
        Vector3[] wallPositions = new Vector3[numSegments];
        Quaternion[] wallRotations = new Quaternion[numSegments];

        for (int i = 0; i < numSegments; i++)
        {
            // Generate random position
            Vector3 randomPosition = GetRandomPosition(wallPositions);
            wallPositions[i] = randomPosition;

            // Generate random rotation
            Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            wallRotations[i] = randomRotation;

            // Generate random length
            float randomLength = Random.Range(minWallLength, maxWallLength);

            // Instantiate wall prefab
            GameObject wall = Instantiate(wallPrefab, randomPosition, randomRotation);
            wall.transform.localScale = new Vector3(randomLength, 7.082763f, 0.5f);
        }
    }

    Vector3 GetRandomPosition(Vector3[] positions)
    {
        Vector3 randomPosition;
        bool positionFound = false;
        do
        {
            randomPosition = new Vector3(Random.Range(-23.127485f, 23.127485f), 0f, Random.Range(-23.127485f, 23.127485f));
            positionFound = true;

            // Check if position overlaps with existing positions
            foreach (Vector3 existingPosition in positions)
            {
                if (Vector3.Distance(randomPosition, existingPosition) < minWallLength)
                {
                    positionFound = false;
                    break;
                }
            }
        } while (!positionFound);

        return randomPosition;
    }
}