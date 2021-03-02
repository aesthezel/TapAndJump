using UnityEngine;

public enum EntityState
{
    Idle,
    Jumping
}

public class JumpWithTap : MonoBehaviour
{
    [SerializeField] private EntityState jumperState;
    [SerializeField] private float jumpPower = 5f;
    private Rigidbody2D rb2D;

    #region Class Logic

    public EntityState GetJumperState() => jumperState;

    public void Jump()
    {
        rb2D.velocity = Vector2.up * jumpPower;
        jumperState = EntityState.Jumping;
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            jumperState = EntityState.Idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        var obstacle = other.gameObject.GetComponent<IHitteable>();
        if(obstacle != null)
        {
            obstacle.PerformHit();
        }
    }

    #region MonoBehaviour API
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    #endregion
}
