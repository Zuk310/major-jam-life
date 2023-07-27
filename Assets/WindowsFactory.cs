using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsFactory : MonoBehaviour
{

    Camera cam;
    public GameObject window;
    public int numOfWindows = 50;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        for (int i = 0; i < numOfWindows; i++)
        {
            GameObject newObject = Instantiate(window, new Vector3(Random.Range(-7.82f,7.82f), Random.Range(-3.4f, 3.4f), 0), Quaternion.identity);
            newObject.GetComponent<SpriteRenderer>().sortingOrder = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
