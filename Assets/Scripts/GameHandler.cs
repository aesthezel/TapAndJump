using UnityEngine;

public class GameHandler : MonoBehaviour
{

    [Header("Set-up")]
    [SerializeField] private UIHandler uiHandler;
    [SerializeField] private JumpWithTap jumperInput;
    [SerializeField] private FloorHandler floorHandler;

    [Header("Gameplay values")]
    [SerializeField] private float spawnSpeed;

    private uint count;

    private bool firstStart;
    public bool FirstStart
    {
        get { return firstStart; }
        set { firstStart = value; }
    }
    
    private bool isPaused = true;
    public bool IsPaused
    {
        get { return isPaused; }
        set 
        {
            uiHandler.GetPauseTitle().gameObject.SetActive(value);
            isPaused = value; 
        }
    }

    #region Class Logic
    public void StartGame()
    {
        FirstStart = true;
        floorHandler.Stop = true;
        uiHandler.GetPauseTitle().gameObject.SetActive(true);
        uiHandler.DisableClickPanel();
        uiHandler.ChangeTextOnPauseTitle("GOO JUMP");
        uiHandler.ChangeTextOnPauseButton("PLAY");
    }

    public void PerformClickToJump()
    {
        if(jumperInput.GetJumperState() == EntityState.Idle)
        {
            jumperInput.Jump();
            uiHandler.SetNumberToCounter(++count);
        }
    }

    public void PerformMiddleButton()
    {
        if(FirstStart)
        {
            FirstStart = !FirstStart;
            floorHandler.PerformSpawn(spawnSpeed);
        }

        PauseGame();
    }

    public void GetReward(uint points)
    {
        uiHandler.SetNumberToCounter(count += points);
    }

    public void PauseGame()
    {
        IsPaused = !IsPaused;
        floorHandler.Stop = !floorHandler.Stop;
        uiHandler.DisableClickPanel();
        uiHandler.ChangeTextOnPauseButton(IsPaused == true ? "RESUME" : "PAUSE");
    }

    public void EndGame()
    {
        PauseGame();
        uiHandler.ChangeTextOnPauseTitle("GAME OVER");
        uiHandler.ChangeTextOnPauseButton("TRY AGAIN");
        floorHandler.Stop = true;
    }
    #endregion

    #region MonoBehaviour API
    private void OnEnable() 
    {
        floorHandler.DoReward += GetReward;
        floorHandler.DoDamage += EndGame;
    }

    private void Start()
    {
        StartGame();
    }

    private void OnDisable() 
    {
        floorHandler.DoReward -= GetReward;
        floorHandler.DoDamage -= EndGame;
    }
    #endregion
}
