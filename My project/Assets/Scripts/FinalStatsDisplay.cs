using UnityEngine;
using TMPro;
using System.IO;

public class FinalStatsDisplay : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_Text timeText;
    public TMP_Text itemsText;
    
    private float totalTime;
    private int greenCount;
    private int redCount;
    private int starCount;

    void OnEnable()
    {
        totalTime = TimerManager.instance.GetTotalTime();
        timeText.text = $"Tiempo total: {totalTime:F2} segundos";

        PlayerCollector collector = FindObjectOfType<PlayerCollector>();
        if (collector != null)
        {
            greenCount = collector.GetItemCount("Green");
            redCount = collector.GetItemCount("Red");
            starCount = collector.GetItemCount("Star");

            itemsText.text = $"Verdes: {greenCount} | Rojas: {redCount} | Estrellas: {starCount}";
        }
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData
        {
            playerName = nameInput.text,
            time = totalTime,
            greenApples = greenCount,
            redApples = redCount,
            stars = starCount
        };

        string json = JsonUtility.ToJson(data, true);
        string path = Application.persistentDataPath + "/player_data.json";
        File.WriteAllText(path, json);
        Debug.Log("✅ Datos guardados en: " + path);
    }
}

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public float time;
    public int greenApples;
    public int redApples;
    public int stars;
}