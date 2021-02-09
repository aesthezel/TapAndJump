using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private Text counterText;
    [SerializeField] private Text pauseText;
    [SerializeField] private Image clickPanel;

    private bool isPaused = false;
    public bool IsPaused
    {
        get { return isPaused; }
        set 
        {
            pauseText.gameObject.SetActive(value);
            isPaused = value; 
        }
    }

    #region Class Logic
    public void SetNumberToCounter(int number) => counterText.text = number.ToString();

    public void DisableClickPanel() => clickPanel.raycastTarget = !clickPanel.raycastTarget;


    public void PauseGame()
    {
        IsPaused = !IsPaused;
        DisableClickPanel();
        // Time.timeScale = IsPaused == true ? 0 : 1; // If you want keep the Physics (ball fall) don't stop the time.
    }
    #endregion
}
