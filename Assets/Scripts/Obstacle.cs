using System;
using UnityEngine;

public enum ObstacleType
{
    Dangerous,
    Coin
}

public class Obstacle : MonoBehaviour, IHitteable
{
    [SerializeField] private ObstacleType obstacleType;
    private FloorHandler objectSpawner;

    #region Class Logic
    public ObstacleType GetObstacleType() => obstacleType;
    public FloorHandler SetObjectSpawner(FloorHandler spawner) => objectSpawner = spawner; 

    public void PerformHit()
    {
        if(objectSpawner.DoDamage != null && obstacleType == ObstacleType.Dangerous)
        {
            objectSpawner.DoDamage();
        }

        if(objectSpawner.DoReward != null && obstacleType == ObstacleType.Coin)
        {
            objectSpawner.DoReward(Convert.ToUInt32(UnityEngine.Random.Range(5, 20)));
            DestroyThisObstacle();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Finish"))
        {
            DestroyThisObstacle();
        }
    }
    
    public void DestroyThisObstacle() => Destroy(this.gameObject);
    #endregion
}
