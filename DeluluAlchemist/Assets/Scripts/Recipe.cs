
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public string recName;
    public Ingredient ing1, ing2, ing3;
    public string[] descriptions;
    public Color potionColor;
}
