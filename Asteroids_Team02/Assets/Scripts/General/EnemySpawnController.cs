using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private int enemiesToSpawn;
    private GameObject[] waypoints;
    private int currentWP; 

    public int multiplicityFactor = 2;

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;

    //waypoints here
    private void Awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
    }

    private GameObject getEnemyChoice()
    {
        int enNum = Random.Range(1, 6);
        switch (enNum)
        {
            case 1:
                return enemy1;
            case 2:
                return enemy2;
            case 3:
                return enemy3;
            case 4:
                return enemy4;
            case 5:
                return enemy5;
            default:
                return enemy1;
        }

    }

    private IEnumerator Spawn(int frequency, int amount)
    {
       
        for (int i = 0; i < amount; i++)
        {
            
            currentWP = Random.Range(0, waypoints.Length); //no need for -1 because Rand is noninclusive on final val.
            //instantiate all at once      

            Instantiate(getEnemyChoice(), waypoints[currentWP].transform.position, waypoints[currentWP].transform.rotation);

            if (amount > 4)
            {
                yield return new WaitForSeconds(frequency);
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        enemiesToSpawn = GameInfo.LevelIteration * multiplicityFactor;
        StartCoroutine(Spawn(5, enemiesToSpawn));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
