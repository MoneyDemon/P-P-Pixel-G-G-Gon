using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private string _savePath;

    private void Awake()
    {
        _savePath = Application.persistentDataPath + "/SaveData.json";
        Debug.Log($"Save Path: {_savePath}");
    }

    private void Start()
    {
        SaveGame("Bunt", 100);
    }
    public void SaveGame(string _playerName, int _wave)
    {
        SaveData _saveData = new SaveData();

        _saveData._playerName = _playerName;
        _saveData._highestWave = _wave;

        string _json = JsonUtility.ToJson(_saveData, true);

        File.WriteAllText(_savePath, _json);

        Debug.Log("===== SAVED =====");
        Debug.Log($"Name: {_playerName}");
        Debug.Log($"Wave: {_wave}");
        Debug.Log(_json);
    }

    public SaveData LoadGame()
    {
        if (File.Exists(_savePath))
        {
            string _json = File.ReadAllText(_savePath);

            SaveData _saveData =
                JsonUtility.FromJson<SaveData>(_json);

            Debug.Log($"Loaded Name: {_saveData._playerName}");
            Debug.Log($"Loaded Wave: {_saveData._highestWave}");

            return _saveData;
        }

        Debug.Log("No Save Found!");

        return null;
    }
}