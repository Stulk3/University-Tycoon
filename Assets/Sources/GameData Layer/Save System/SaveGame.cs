using UnityEngine;
using System.IO;

public class SaveGame : MonoBehaviour
{

    private GameData gameData;

    private void Awake()
    {
        gameData = new GameData();
        
    }
    private void OnDisable()
    {
        Save();
    }
    public void Save()
    {
        gameData.money = University.Money;
        gameData.income = University.Income;
        gameData.corruption = University.Corruption;
        gameData.reputation = University.Reputation;
        gameData.students = University.Students;

        string dataAsJson = JsonUtility.ToJson(gameData);
        string filePath = Application.persistentDataPath + "/gameData.json";
        File.WriteAllText(filePath, dataAsJson);
    }
    private void Start()
    {
        Load();
    }
    public void Load()
    {
        string filePath = Application.persistentDataPath + "/gameData.json";
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(dataAsJson);

            University.instance.SetMoney(gameData.money);
            University.instance.SetIncome(gameData.income);
            University.instance.SetCorruption(gameData.corruption);
            University.instance.SetReputation(gameData.reputation);
            University.instance.SetStudents(gameData.students);
        }
    }

}