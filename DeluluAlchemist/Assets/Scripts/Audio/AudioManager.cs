using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] trash, mix, clientGood, clientBad, 
        clientNothing, inPot, outPot, replenish, view, click, hover;
    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(transform.gameObject);
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void PlaySound(string clip)
    {
        switch (clip)
        {
            case "trash":
                audioSource.PlayOneShot(trash[Random.Range(0, trash.Length)], .22f); 
                break;
            case "mix":
                audioSource.PlayOneShot(mix[Random.Range(0, mix.Length)]);
                break;
            case "clientGood":
                audioSource.PlayOneShot(clientGood[Random.Range(0, clientGood.Length)]);
                break;
            case "clientBad":
                audioSource.PlayOneShot(clientBad[Random.Range(0, clientBad.Length)]);
                break;
            case "clientNothing":
                audioSource.PlayOneShot(clientNothing[Random.Range(0, clientNothing.Length)], 2f);
                break;
            case "outPot":
                audioSource.PlayOneShot(outPot[Random.Range(0, outPot.Length)], 6f);
                break;
            case "replenish":
                audioSource.PlayOneShot(replenish[Random.Range(0, replenish.Length)], 1.5f);
                break;
            case "inPot":
                audioSource.PlayOneShot(inPot[Random.Range(0, inPot.Length)], .7f);
                break;
            case "view":
                audioSource.PlayOneShot(view[Random.Range(0, view.Length)]);
                break;
            case "click":
                audioSource.PlayOneShot(click[Random.Range(0, click.Length)], .75f);
                break;
            case "hover":
                audioSource.PlayOneShot(hover[Random.Range(0, hover.Length)], .15f);
                break;
            default: break;
        }
    }
}
