using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{

    public GameObject floorPrefab;
    public GameObject wallPrefab;

    private List<GameObject> floorList = new List<GameObject>();
    private List<GameObject> wallList = new List<GameObject>();
    public int mapSize = 10;

    void Start()
    {
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int y = 0; y < mapSize; y++)
            {
                GameObject floor = Instantiate(floorPrefab, new Vector3(x * 10, 0, y * 10), Quaternion.identity);
                floor.transform.parent = transform;
                floorList.Add(floor);
                createFourWalls(floor);
            }
        }
    }

    void createFourWalls(GameObject floor)
    {
        GameObject wall1 = Instantiate(wallPrefab, new Vector3(floor.transform.position.x + 4.5f, 0, floor.transform.position.z), Quaternion.identity);
        wall1.transform.parent = transform;
        wallList.Add(wall1);
        GameObject wall2 = Instantiate(wallPrefab, new Vector3(floor.transform.position.x - 4.5f, 0, floor.transform.position.z), Quaternion.identity);
        wall2.transform.parent = transform;
        wallList.Add(wall2);
        GameObject wall3 = Instantiate(wallPrefab, new Vector3(floor.transform.position.x, 0, floor.transform.position.z + 4.5f), Quaternion.identity);
        wall3.transform.parent = transform;
        wallList.Add(wall3);
        GameObject wall4 = Instantiate(wallPrefab, new Vector3(floor.transform.position.x, 0, floor.transform.position.z - 4.5f), Quaternion.identity);
        wall4.transform.parent = transform;
        wallList.Add(wall4);
        wall1.transform.Rotate(0, 90, 0);
        wall2.transform.Rotate(0, 90, 0);
    }
}