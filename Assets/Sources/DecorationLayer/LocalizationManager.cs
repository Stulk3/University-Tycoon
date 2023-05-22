using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    [SerializeField] private List<TMP_Text> localizedTextboxes = new List<TMP_Text>();

    private Dictionary<string, string> localizedTexts;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        LoadLocalizedText();
    }

    public void LoadLocalizedText()
    {
        localizedTexts = new Dictionary<string, string>();

        TextAsset textAsset = Resources.Load<TextAsset>("Localization/localizedText");

        string json = textAsset.text;

        LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(json);

        for (int i = 0; i < localizationData.items.Length; i++)
        {
            localizedTexts.Add(localizationData.items[i].key, localizationData.items[i].value);
        }

        UpdateLocalizedTexts();
    }

    public void UpdateLocalizedTexts()
    {
        foreach (TMP_Text textbox in localizedTextboxes)
        {
            if (localizedTexts.ContainsKey(textbox.name))
            {
                textbox.text = localizedTexts[textbox.name];
            }
        }
    }

    public void ChangeLanguage(Language language)
    {
        LanguageSettings.currentLanguage = language;

        LoadLocalizedText();
    }
}

public enum Language
{
    English,
    Russian
}

[System.Serializable]
public class LocalizationItem
{
    public string key;
    public string value;
}

[System.Serializable]
public class LocalizationData
{
    public LocalizationItem[] items;
}

public static class LanguageSettings
{
    public static Language currentLanguage;
}