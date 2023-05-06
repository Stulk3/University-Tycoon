using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Linq;

[CustomPropertyDrawer(typeof(CardEvent))]
public class CardDataDrawer : PropertyDrawer
{
    private SerializedProperty _quote;
    private SerializedProperty _moneyImpact;
    private SerializedProperty _incomeImpact;
    private SerializedProperty _corruptionImpact;
    private SerializedProperty _reputationImpact;
    private SerializedProperty _studentsImpact;

    private SerializedProperty _eventDirection;

    private float propertyHeightPadding = 3f;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        FillDrawProperties(property);

        Rect foldoutBox = new Rect(position.min.x, position.min.y, position.size.x, EditorGUIUtility.singleLineHeight);

        property.isExpanded = EditorGUI.Foldout(foldoutBox, property.isExpanded, label);
        DrawEventDirectionProperty(position);

        if (property.isExpanded)
        {
            DrawProperties(position);
        }

        EditorGUI.EndProperty();
    }
    
    private void FillDrawProperties(SerializedProperty property)
    {
        _quote = property.FindPropertyRelative("_quote");

        _moneyImpact = property.FindPropertyRelative("_moneyImpact");
        _incomeImpact = property.FindPropertyRelative("_incomeImpact");
        _corruptionImpact = property.FindPropertyRelative("_corruptionImpact");
        _reputationImpact = property.FindPropertyRelative("_reputationImpact");
        _studentsImpact = property.FindPropertyRelative("_studentsImpact");

        _eventDirection = property.FindPropertyRelative("_eventDirection");
    }


    private void DrawProperties(Rect position)
    {
        DrawQuoteProperty(position);

        DrawMoneyImpactProperty(position);
        DrawIncomeImpactProperty(position);
        DrawCorruptionImpactProperty(position);
        DrawReputationImpactProperty(position);
        DrawStudentsImpactProperty(position);
    }
    private void DrawEventDirectionProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;

        float xPosition = position.min.x;
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight);
        float width = position.size.x;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _eventDirection, new GUIContent("Event Direction"));
    }
    private void DrawQuoteProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 60;
        
        float xPosition = position.min.x;
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 2) + propertyHeightPadding;
        float width = position.size.x;
        float height = EditorGUIUtility.singleLineHeight * 2;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _quote, new GUIContent("Quote"));
    }

    private void DrawMoneyImpactProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;
        
        float xPosition = position.min.x + 1;
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 4) + propertyHeightPadding *2;
        float width = position.size.x * 0.45f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _moneyImpact, new GUIContent("Money Impact"));
    }
    private void DrawIncomeImpactProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;

        float xPosition = position.min.x + (position.width * 0.5f);
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 4) + propertyHeightPadding * 2;
        float width = position.size.x * 0.45f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _incomeImpact, new GUIContent("Income Impact"));
    }
    private void DrawCorruptionImpactProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;

        float xPosition = position.min.x + 1;
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 5) + propertyHeightPadding * 3;
        float width = position.size.x * 0.45f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _corruptionImpact, new GUIContent("Corruption Impact"));
    }
    private void DrawReputationImpactProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;

        float xPosition = position.min.x + (position.width * 0.5f);
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 5) + propertyHeightPadding * 3;
        float width = position.size.x * 0.45f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _reputationImpact, new GUIContent("Reputation Impact"));
    }
    private void DrawStudentsImpactProperty(Rect position)
    {
        EditorGUIUtility.labelWidth = 110;

        float xPosition = position.min.x;
        float yPosition = position.min.y + (EditorGUIUtility.singleLineHeight * 6) + propertyHeightPadding * 4;
        float width = position.size.x * 0.45f;
        float height = EditorGUIUtility.singleLineHeight;

        Rect drawArea = new Rect(xPosition, yPosition, width, height);

        EditorGUI.PropertyField(drawArea, _studentsImpact, new GUIContent("Students Impact"));
    }



    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        float totalLines = 2;

        if (property.isExpanded)
        {
            totalLines += 5;
        }
        return ((EditorGUIUtility.singleLineHeight * totalLines) + (propertyHeightPadding * totalLines));
    }
}
