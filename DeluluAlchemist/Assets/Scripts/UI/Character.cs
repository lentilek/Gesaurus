using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public static Character Instance;

    [SerializeField] private GameObject negative, neutral, positive;

    private void Awake()
    {
        Instance = this;
        Emotion(-1);
    }

    public void Emotion(int i)
    {
        negative.SetActive(false);
        neutral.SetActive(false);
        positive.SetActive(false);
        if (i == 0)
        {
            neutral.SetActive(true);
        }
        else if (i == 1)
        {
            positive.SetActive(true);
        }else if (i == -1)
        {
            negative.SetActive(true);
        }
    }
}
