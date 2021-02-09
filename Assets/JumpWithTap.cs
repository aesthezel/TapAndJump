using UnityEngine;

public class JumpWithTap : MonoBehaviour
{
    [SerializeField] private UIHandler uiHandler;
    [SerializeField] private float jumpPower = 5f;
    
    private Rigidbody2D rb2D;
    private int counter;

    #region Class Logic
    public void Jump()
    {
        rb2D.velocity = Vector2.up * jumpPower;
        uiHandler.SetNumberToCounter(++counter);
    }
    #endregion

    #region MonoBehaviour API
    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    #endregion
}
