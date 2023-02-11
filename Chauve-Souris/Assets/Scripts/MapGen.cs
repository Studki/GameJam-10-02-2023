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
        cuteDoubleWall();
        for (int i = 0; i < wallList.Count; i++) {
            if (wallList[i].transform.position.x == -4.5 && wallList[i].transform.position.z == 0) {
                Destroy(wallList[i]);
                wallList.RemoveAt(i);
            }
            if (!checkIfWallIsEdge(wallList[i])) {
                int rand = Random.Range(0, 180);
                wallList[i].transform.Rotate(0, rand, 0);
            } else
            {
                wallList[i].gameObject.transform.GetChild(0).gameObject.transform.localScale = new Vector3(10, 5, 1);
            }
        }
    }

    void createFourWalls(GameObject floor)
    {
        createWall(new Vector3(floor.transform.position.x + 4.5f, 0, floor.transform.position.z), Quaternion.identity, 90);
        createWall(new Vector3(floor.transform.position.x - 4.5f, 0, floor.transform.position.z), Quaternion.identity, 90);
        createWall(new Vector3(floor.transform.position.x, 0, floor.transform.position.z + 4.5f), Quaternion.identity);
        createWall(new Vector3(floor.transform.position.x, 0, floor.transform.position.z - 4.5f), Quaternion.identity);
    }

    void createWall(Vector3 pos, Quaternion rot, int rotation = 0)
    {
        GameObject wall = Instantiate(wallPrefab, pos, rot);
        wall.transform.parent = transform;
        wallList.Add(wall);
        wall.transform.Rotate(0, rotation, 0);
    }

    void cuteDoubleWall() {
        for (int i = 0; i < wallList.Count; i++) {
            if (isWall(new Vector3(wallList[i].transform.position.x, wallList[i].transform.position.y, wallList[i].transform.position.z + 1))) {
                Destroy(wallList[i]);
                wallList.RemoveAt(i);
            }
            if (isWall(new Vector3(wallList[i].transform.position.x + 1, wallList[i].transform.position.y, wallList[i].transform.position.z))) {
                Destroy(wallList[i]);
                wallList.RemoveAt(i);
            }
        }
    }

    bool isWall(Vector3 pos) {
        for (int i = 0; i < wallList.Count; i++) {
            if (wallList[i].transform.position == pos) {
                return true;
            }
        }
        return false;
    }

    bool checkIfWallIsEdge(GameObject wall) {
        if (wall.transform.position.x == -4.5f || wall.transform.position.x == mapSize * 10 - 5.5f|| wall.transform.position.z == -4.5f || wall.transform.position.z == mapSize * 10 - 5.5f) {
            return true;
        }
        return false;
    }
}