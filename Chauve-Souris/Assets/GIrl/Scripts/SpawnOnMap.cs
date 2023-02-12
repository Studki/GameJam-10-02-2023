using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnMap : MonoBehaviour
{
    public int mapSize = 10;

    // Start is called before the first frame update
    void Start()
    {
        int randX = Random.Range(-4, mapSize * 10 - 4);
        int randZ = Random.Range(-4, mapSize * 10 - 4);
        transform.position = new Vector3(randX, 0.5f, randZ);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            int randX = Random.Range(-4, mapSize * 10 - 4);
            int randZ = Random.Range(-4, mapSize * 10 - 4);
            transform.position = new Vector3(randX, 0.5f, randZ);
        }
    }
}
