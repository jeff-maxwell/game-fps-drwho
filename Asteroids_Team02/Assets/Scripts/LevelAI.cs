using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelAI : MonoBehaviour
{
    public GameObject dalek;
    GameObject[] waypoints;
    int currentWP;

    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }
    void Start()
    {   
        for (int x = 0; x < 5; x++)
        {
            currentWP = Random.Range(0, waypoints.Length - 1);
            GameObject b = Instantiate(dalek, waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
