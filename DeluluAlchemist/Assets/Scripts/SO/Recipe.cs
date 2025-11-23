
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public string recName;
    public int index;
    public string[] descriptions;
    public Color potionColor;
    public Ingredient[] ing;
    public string[] ingNames;

    public void GetNames()
    {
        for (int i =0; i < ing.Length; i++)
        {
            ingNames[i] = ing[i].name;
        }
    }
}
