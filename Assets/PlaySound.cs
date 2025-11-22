using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaySound : MonoBehaviour
{

    [SerializeField] private Sprite activeButtonSprite;
    [SerializeField] private Sprite disabledButtonSprite;
    [SerializeField] private Image button;
    [SerializeField] private AudioSource audio;


    public void Update()
    {
        if (!audio.isPlaying)
        {

            activateButton();
            
        }
    }


    public void PlayAudio(){
        if (audio.isPlaying)
        {
            activateButton();
            audio.Stop();
        }
        else
        {
            disableButton();
            audio.Play();
        }
    }

    private void activateButton()
    {
        button.sprite = activeButtonSprite;
    }

    private void disableButton()
    {
        button.sprite = disabledButtonSprite;
    }
}
