using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Splashscreen : MonoBehaviour
{
    public static Splashscreen Instance;

    [SerializeField] private CanvasGroup bjg;
    [SerializeField] private float bjgTime, fadeOutDuration;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        StartCoroutine(HideBJG());
    }
    private IEnumerator HideBJG()
    {
        bjg.gameObject.SetActive(true);
        yield return new WaitForSeconds(bjgTime);
        bjg.DOFade(0, fadeOutDuration);
        yield return new WaitForSeconds(fadeOutDuration);
        bjg.gameObject.SetActive(false);

        this.gameObject.SetActive(false);
    }
}
