using System;
using System.Collections;
using UnityEngine;

public class FloorHandler : MonoBehaviour
{
    public Action DoDamage;
    public Action<uint> DoReward;

    [SerializeField] private Transform spawnInit;
    [SerializeField] private Transform spawnRock;
    [SerializeField] private Transform[] spawnsForCoins;
    [SerializeField] private Obstacle[] obstaclesPrefab;

    [SerializeField] private FloorMovement movement;

    private bool stop;
    public bool Stop
    {
        get { return stop; }
        set 
        { 
            if(value == true)
            {
                StopSpawn();
            }
            stop = value; 
        }
    }
    

    private IEnumerator spawnCoroutine;

    #region Class Logic

    public void PerformSpawn(float timeSpeed)
    {
        Debug.Log("Works?");
        spawnCoroutine = SpawnObject(timeSpeed);
        StartCoroutine(spawnCoroutine);
    }

    public void StopSpawn()
    {
        if(spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }

    }

    public IEnumerator SpawnObject(float waitTime)
    {
        while(true)
        {
            yield return new WaitForSeconds(waitTime);

            Obstacle newObstacle = Instantiate(obstaclesPrefab[UnityEngine.Random.Range(0, obstaclesPrefab.Length)], spawnInit);
            newObstacle.SetObjectSpawner(this);
            if(newObstacle.GetObstacleType() == ObstacleType.Coin)
            {
                Transform newCoinPosition = spawnsForCoins[UnityEngine.Random.Range(0, spawnsForCoins.Length)];
                newObstacle.transform.position = newCoinPosition.position;
            }
            else
            {
                newObstacle.transform.position = spawnRock.position;
            }
        }
    }
 
    #endregion

    #region MonoBehaviour API
    private void Update()
    {
        if(Stop == false)
        {
            movement.MoveTheFloor();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Respawn"))
        {
            movement.ResetToStartPosition();
        }
    }
    #endregion
}