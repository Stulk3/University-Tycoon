using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyWord", menuName = "Cards/KeyWord", order = 1)]
public class KeyWord : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Color _color;

    public string title => _title;
    public Color color => _color;

    private void Awake()
    {
        _title = "Default";
    }
    private void OnValidate()
    {
        _title = this.name;
    }
    
}
