using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class PlaySound : MonoBehaviour
{

    [SerializeField] private Sprite activeButtonSprite;
    [SerializeField] private Sprite disabledButtonSprite;
    [SerializeField] private UnityEngine.UI.Image button;
    [SerializeField] private AudioSource audio;

     private ObserverBehaviour observerBehaviour;

    void Start()
    {
        // Look for ObserverBehaviour in parent objects
        observerBehaviour = GetComponentInParent<ObserverBehaviour>();

        if (observerBehaviour == null)
        {
            Debug.LogError("No ObserverBehaviour found in parent hierarchy!");
            return;
        }

        observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;

    }

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

    public void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        bool hasFound = (targetStatus.Status == Status.TRACKED);
        if(!hasFound){
            audio.Stop();
            activateButton();
        }
    }
}
