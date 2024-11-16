using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;
using System;

public class University : MonoBehaviour
{
    public static University instance;

    public event Action<int> onMoneyChanged;
    public event Action<int> onIncomeChanged;
    public event Action<int> onCorruptionChanged;
    public event Action<int> onReputationChanged;
    public event Action<int> onStudentsChanged;

    public event Action<int> onMaxStudentsChanged;

    [Header("Direct Fields")]
    [SerializeField] private string _title;
    [Space(4f)]
    [SerializeField] private int _money;
    [SerializeField] private int _income;
    [SerializeField] private int _corruption;
    [SerializeField] private int _reputation;
    [SerializeField] private int _students;

    public static int Money => instance._money;
    public static int Income => instance._income;
    public static int Corruption => instance._corruption;
    public static int Reputation => instance._reputation;
    public static int Students => instance._students;


    [Header("Indirect Fields")]
    [SerializeField] private int _maxStudents = 100;
    [SerializeField] private int _maxIncome = 1000;
    [SerializeField] private int _buildingsCount;


    public static int MaxStudents => instance._maxStudents;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        onMoneyChanged?.Invoke(_money);
        onIncomeChanged?.Invoke(_income);
        onCorruptionChanged?.Invoke(_corruption);
        onReputationChanged?.Invoke(_reputation);
        onStudentsChanged?.Invoke(_students);

        onMaxStudentsChanged?.Invoke(_maxStudents);
    }
    public void SetMoney(int money)
    {
        _money = money;
    }

    public void SetIncome(int income)
    {
        _income = income;
    }

    public void SetCorruption(int corruption)
    {
        _corruption = corruption;
    }

    public void SetReputation(int reputation)
    {
        _reputation = reputation;
    }

    public void SetStudents(int students)
    {
        _students = students;
    }
    public void MakeImpact(CardEvent data)
    {
        if(data != null)
        {

            ImpactMoney(data.MoneyImpact);

            ImpactIncome(data.IncomeImpact);

            ImpactCorruption(data.CorruptionImpact);

            ImpactReputation(data.ReputationImpact);

            ImpactStudents(data.StudentsImpact);
        }

    }
    public void AddIncome()
    {
        _money += _income;
        onMoneyChanged?.Invoke(_money);
    }
    private void ImpactMoney(int money)
    {
        _money += money;
        onMoneyChanged?.Invoke(_money);
    }
    private void ImpactIncome(int income)
    {
        _income += income;
        onIncomeChanged?.Invoke(_income);
    }
    private void ImpactCorruption(int corruption)
    {
        _corruption += corruption;
        onCorruptionChanged?.Invoke(_corruption);
    }
    private void ImpactReputation(int reputation)
    {
        _reputation += reputation;
        onReputationChanged?.Invoke(_reputation);
    }
    private void ImpactStudents(int students)
    {
        _students += students;
        onStudentsChanged?.Invoke(_students);
    }
}
