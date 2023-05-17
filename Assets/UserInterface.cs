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
}
