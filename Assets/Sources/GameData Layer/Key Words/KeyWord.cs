using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyWord", menuName = "Cards/Key Word", order = 2)]
public class KeyWord : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Color32 _color;

    public string Title => _title;
    public Color32 Color => _color;

    private void Awake()
    {
        _title = "Default";
    }
    private void OnValidate()
    {
        _title = name;
    }

}