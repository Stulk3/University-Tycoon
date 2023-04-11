using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyWord", menuName = "Cards/KeyWord", order = 1)]
public class KeyWord : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private Color _color;

    private void Awake()
    {
        _name = "Default";
    }
    private void OnValidate()
    {
        _name = this.name;
    }
    
}
