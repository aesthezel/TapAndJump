using UnityEngine;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    [Header("Game UI")]
    [SerializeField] private Text counterText;

    [Header("Pause UI")]
    [SerializeField] private Text pauseTitle;
    [SerializeField] private Text pauseButtonText;
    [SerializeField] private Image clickPanel;

    #region Class Logic
    public Text GetPauseTitle() => pauseTitle;
    public void SetNumberToCounter(uint number) => counterText.text = number.ToString();
    public void DisableClickPanel() => clickPanel.raycastTarget = !clickPanel.raycastTarget;
    public void ChangeTextOnPauseTitle(string message) => pauseTitle.text = message;
    public void ChangeTextOnPauseButton(string text) => pauseButtonText.text = text;
    #endregion
}
