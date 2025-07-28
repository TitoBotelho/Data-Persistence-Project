using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    public TMPro.TextMeshProUGUI BestScoreText;
    public TMPro.TMP_InputField NameInputField;

    void Start()
    {
        UpdateBestScoreText();
    }

    public void StartNew()
    {
        string playerName = NameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    public void ResetBestScore()
    {
        PlayerPrefs.DeleteKey("BestScore");
        PlayerPrefs.DeleteKey("BestScoreName");
        PlayerPrefs.Save();
        UpdateBestScoreText();
    }

    private void UpdateBestScoreText()
    {
        string bestScoreName = PlayerPrefs.GetString("BestScoreName", "Player");
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        BestScoreText.text = $"Best Score : {bestScoreName} : {bestScore}";
    }
}