using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject creditsPanel;
    public Toggle soundToggle;
    public Text highScoreText;

    void Start()
    {
        instructionsPanel.SetActive(false);
        creditsPanel.SetActive(false);
        soundToggle.isOn = PlayerPrefs.GetInt("sound", 1) == 1;

        ShowHighScore();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SceneGame1"); 
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void HideCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ToggleSound(bool isOn)
    {
        PlayerPrefs.SetInt("sound", isOn ? 1 : 0);
        AudioListener.volume = isOn ? 1 : 0;
    }

    private void ShowHighScore()
    {
        string playerName = PlayerPrefs.GetString("highscore_name", "N/A");
        int score = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = $"Puntaje Máximo: {playerName} - {score}";
    }
}
