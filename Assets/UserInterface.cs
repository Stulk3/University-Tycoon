using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserInterface : MonoBehaviour
{
    public static UserInterface instance;

    [Header("Indicators")]
    [SerializeField] private TMP_Text _moneyIndicator;
    [SerializeField] private TMP_Text _incomeIndicator;
    
    [Space(5f)]
    [Header("Previews")]
    [SerializeField] private TextMeshProUGUI _corruptionPreview;
    [SerializeField] private TextMeshProUGUI _studentsPreview;
    [SerializeField] private TextMeshProUGUI _moneyPreview;
    [SerializeField] private TextMeshProUGUI _incomePreview;
    public static TextMeshProUGUI CorruptionPreview => instance._corruptionPreview;
    public static TextMeshProUGUI ReputationPreview => instance._studentsPreview;
    public static TextMeshProUGUI MoneyPreview => instance._moneyPreview;
    public static TextMeshProUGUI IncomePreview => instance._incomePreview;

    [Space(5f)]
    [Header("Selectors")]
    [SerializeField] private GameObject _documentsSelector;
    [SerializeField] private GameObject _constructionSelector;
    [SerializeField] private GameObject _shopSelector;
    [SerializeField] private GameObject _profileSelector;

    [Space(5f)]
    [Header("Right Selection Button")]
    [SerializeField] private GameObject _rightButton;
    [SerializeField] private SpriteRenderer _rightIcon;
    [Space(5f)]
    [Header("Left Selection Button")]
    [SerializeField] private GameObject _leftButton;
    [SerializeField] private  SpriteRenderer _leftIcon;

    [Space(5f)]
    [Header("Icons")]
    [SerializeField] private Sprite _trashIcon;


    [Space(5f)]
    [Header("Sections")]
    [SerializeField] private GameObject _documents;
    [SerializeField] private GameObject _construction;
    [SerializeField] private GameObject _shop;
    [SerializeField] private GameObject _profile;
    public static GameObject DocumentsSelector => instance._documentsSelector;
    public static GameObject ConstructionSelector => instance._constructionSelector;
    public static GameObject ShopSelector => instance._shopSelector;
    public static GameObject ProfileSelector => instance._profileSelector;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void OnEnable()
    {
        SubscibeToUniversityValuesChanged();
    }

    private void OnDisable()
    {
        UnsubscibeToUniversityValuesChanged();
    }

    private void SubscibeToUniversityValuesChanged()
    {
        University.instance.onMoneyChanged += UpdateMoneyValue;
        University.instance.onIncomeChanged += UpdateIncomeValue;
        University.instance.onCorruptionChanged += UpdateCorruptionValue;
        University.instance.onReputationChanged += UpdateReputationValue;
        University.instance.onStudentsChanged += UpdateStudentsValue;
    }
    private void UnsubscibeToUniversityValuesChanged()
    {
        University.instance.onMoneyChanged -= UpdateMoneyValue;
        University.instance.onIncomeChanged -= UpdateIncomeValue;
        University.instance.onCorruptionChanged -= UpdateCorruptionValue;
        University.instance.onReputationChanged -= UpdateReputationValue;
        University.instance.onStudentsChanged -= UpdateStudentsValue;
    }

    private void UpdateMoneyValue(int value)
    {
        _moneyIndicator.text = value.ToString() + "K";
    }
    private void UpdateIncomeValue(int value)
    {
        if(value > 0)
        {
            _incomeIndicator.text = "+" + value.ToString() + "K";
            _incomeIndicator.color = new Color32(0, 180, 0, 255);
        }
        else if(value == 0)
        {
            _incomeIndicator.text = value.ToString() + "K";
            _incomeIndicator.color = Color.yellow;
        }
        else if (value < 0)
        {
            _incomeIndicator.text = value.ToString() + "K";
            _incomeIndicator.color = new Color32(180, 0, 0, 255);
        }
    }

    private void UpdateCorruptionValue(int value)
    {
       
    }
    private void UpdateReputationValue(int value)
    {
       
    }
    private void UpdateStudentsValue(int value)
    {
        
    }
    public void SelectDocumentsSection()
    {
        _documents.SetActive(true);
        _construction.SetActive(false);
        _shop.SetActive(false);
        _profile.SetActive(false);
    }

    public void SelectConstructionSection()
    {
        _documents.SetActive(false);
        _construction.SetActive(true);
        _shop.SetActive(false);
        _profile.SetActive(false);
    }

    public void SelectShopSection()
    {
        _documents.SetActive(false);
        _construction.SetActive(false);
        _shop.SetActive(true);
        _profile.SetActive(false);
    }

    public void SelectProfileSection()
    {
        _documents.SetActive(false);
        _construction.SetActive(false);
        _shop.SetActive(false);
        _profile.SetActive(true);
    }
}
