using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    List<GameObject> asteroidList = new List<GameObject>();
    public Vector2 camExtent;
    [SerializeField] private float minSpawnDistance;
    [SerializeField] private GameObject ship;
    [SerializeField] private GameObject asteroidParent;
    private Vector2 spawnLoc;

    public GameObject Asteroid_Large;
    public GameObject Asteroid_Medium;
    public GameObject Asteroid_Small;
    [SerializeField] private int spawnAsteroidCount;

    private static int[] bias = { 0,0,0,0,0,1,1,1,2};
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        NewWave();
    }

    private void Update()
    {
        if(asteroidParent.transform.childCount < 1)
        {
            NewWave();
        }
    }
    public void genNewLoc()
    {
        spawnLoc = new Vector2(Random.Range(-camExtent.x, camExtent.x), Random.Range(-camExtent.y, camExtent.y));
        if (Vector2.Distance(spawnLoc, ship.transform.position) < minSpawnDistance)
        {
            genNewLoc();
        }
    }

    public void NewWave()
    {
        camExtent = Boundries.Instance.screenBounds;
        Debug.Log(Boundries.Instance.screenBounds);
        asteroidList.Add(Asteroid_Large);
        asteroidList.Add(Asteroid_Medium);
        asteroidList.Add(Asteroid_Small);
        do
        {
            genNewLoc();
            index = Random.Range(0, bias.Length);
            Instantiate(asteroidList[bias[index]], spawnLoc, Quaternion.identity, asteroidParent.transform);
        }
        while (gameObject.transform.childCount < spawnAsteroidCount);
    }
}