using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsFactory : MonoBehaviour
{

    Camera cam;
    public GameObject window;

    public int numOfWindows = 50;
    public int minWindowsPerInterval = 1;
    public int maxWindowsPerInterval = 3;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 2f;
    public int maxNumOfWindows  =10;

    private int currentNumOfWindows = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        StartCoroutine(SpawnWindowsCoroutine());
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // Coroutine to spawn windows over time
    IEnumerator SpawnWindowsCoroutine()
    {
        while (currentNumOfWindows < maxNumOfWindows)
        {
            int windowsToSpawn = Random.Range(minWindowsPerInterval, maxWindowsPerInterval + 1);

            Vector3 randomPosition = new Vector3(Random.Range(-7.82f, 7.82f), Random.Range(-3.4f, 3.4f), 0);
            GameObject newObject = Instantiate(window, randomPosition, Quaternion.identity);
            newObject.GetComponent<SpriteRenderer>().sortingOrder = currentNumOfWindows;

            float randomSpawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(randomSpawnInterval);
        }
    }

    public void DestroyAllWindows()
    {
        GameObject[] windows = GameObject.FindGameObjectsWithTag("Window");
        maxNumOfWindows = 0; // Prevent SpawnWindowsCoroutine loop from running

        foreach (GameObject window in windows)
        {
            Destroy(window);
        }

    }
}
