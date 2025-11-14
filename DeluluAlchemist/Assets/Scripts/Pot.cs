using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Pot : MonoBehaviour
{
    public static Pot Instance;

    public Recipe[] recipes;

    /*[HideInInspector] */public IngredientButton ing1, ing2, ing3;

    public Image image1, image2, image3, potionColor;
    [HideInInspector] public bool isTherePotion;
    [SerializeField] private Color regularPotion, weirdPotion;

    private void Awake()
    {
        Instance = this;
        isTherePotion = false;
    }
    private void Update()
    {
        if (ing1 != null)
        {
            image1.sprite = ing1.ingredient.pot;
        }
        else
        {
            image1.sprite = null;
        }
        if (ing2 != null)
        {
            image2.sprite = ing2.ingredient.pot;
        }
        else
        {
            image2.sprite = null;
        }
        if (ing3 != null)
        {
            image3.sprite = ing3.ingredient.pot;
        }
        else
        {
            image3.sprite = null;
        }
    }
    public int FindEmptySlot(IngredientButton ing)
    {
        if (ing1 == null)
        {
            ing1 = ing;
            return 1;
        }
        else if (ing2 == null)
        {
            ing2 = ing;
            return 2;
        }
        else if (ing3 == null)
        {
            ing3 = ing;
            return 3;
        }
        return 0;
    }
    public void EmptySlot(int index)
    {
        if (index == 1)
        {
            ing1 = null;
        }else if (index == 2)
        {
            ing2 = null;
        }else if(index == 3)
        {
            ing3 = null;
        }
    }
    public void UndoIng(int i)
    {
        if (ing1 != null && i == 1)
        {
            ing1.UndoIngredient();
        }
        else if (ing2 != null && i == 2)
        {
            ing2.UndoIngredient();
        }
        if (ing3 != null && i == 3)
        {
            ing3.UndoIngredient();
        }
    }
    public void Mix()
    {
        if (ing1 != null && ing2 != null && ing3 != null)
        {
            isTherePotion = true;
            bool goodPotion = false;
            foreach (var rec in recipes)
            {
                if (rec.ing.Contains(ing1.ingredient) && rec.ing.Contains(ing2.ingredient) 
                    && rec.ing.Contains(ing3.ingredient))
                {
                    potionColor.color = rec.potionColor;
                    goodPotion = true;
                    break;
                }
            }
            if (goodPotion)
            {
                //
            }
            else
            {
                potionColor.color = weirdPotion;
            }
        }
    }
}
