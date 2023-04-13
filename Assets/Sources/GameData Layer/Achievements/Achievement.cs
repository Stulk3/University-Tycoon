using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Achivement", menuName = "Achivement", order = 4)]
public class Achievement : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _isDone = false;
    public string title => _title;
    public Sprite icon => _icon;
    public bool isDone => _isDone;

    private void Awake()
    {
        _title = "Default";
    }
    private void OnValidate()
    {
        _title = this.name;
    }
    public void Done()
    {
        _isDone = true;
    }
    
}
