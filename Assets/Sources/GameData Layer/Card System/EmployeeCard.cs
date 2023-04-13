using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CardSystem;

public class EmployeeCard : Card
{
    private Color _backgroundColor;
    private Sprite _headSprite;
    private Sprite _glassesSprite;
    private Sprite _bodySprite;
    private Sprite _accessoriesSprite;

    public Color BackgroundColor => _backgroundColor;
    public Sprite HeadSprite => _headSprite; 
    public Sprite GlassesSprite => _glassesSprite;
    public Sprite BodySprite => _bodySprite; 
    public Sprite AccessoriesSprite => _accessoriesSprite;

    public EmployeeCard(Color backgroundColor, Sprite headSprite, Sprite glassesSprite, Sprite bodySprite, Sprite accessoriesSprite)
    {
        _backgroundColor = backgroundColor;
        _headSprite = headSprite;
        _glassesSprite = glassesSprite;
        _bodySprite = bodySprite;
        _accessoriesSprite = accessoriesSprite;
    }

    public EmployeeCard(Color backgroundColor, Sprite headSprite, Sprite glassesSprite, Sprite bodySprite)
    {
        _backgroundColor = backgroundColor;
        _headSprite = headSprite;
        _glassesSprite = glassesSprite;
        _bodySprite = bodySprite;
    }
}
