using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private float floorSpeed;

    private Rigidbody2D rb2D;
    
    #region Class Logic
    public void ResetToStartPosition() => transform.position = startPosition;
    public void MoveTheFloor() => rb2D.velocity = Vector2.left * floorSpeed * Time.deltaTime;
    #endregion

    #region MonoBehaviour API
    private void Awake() => rb2D = GetComponent<Rigidbody2D>();
    #endregion
}
