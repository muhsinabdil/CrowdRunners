using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;
    [SerializeField] private Sprite optionsOnSprite;
    [SerializeField] private Sprite optionsOffSprite;
    [SerializeField] private Image soundsButtonImage;
    [SerializeField] private Image hapticsButtonImage;

    [Header("Settings")]
    private bool soundsState = true;
    private bool hapticsState = true;
    // Start is called before the first frame update
    void Start()
    {
        Setup();
    }

    private void Setup()
    {
        if (soundsState)
        {
            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSoundsState()
    {
        soundsState = !soundsState;
        if (soundsState)
        {

            EnableSounds();
        }
        else
        {
            DisableSounds();
        }
    }


    private void DisableSounds()
    {
        soundsButtonImage.sprite = optionsOffSprite;//! sprite değitirdik
        soundsManager.DisableSounds();//! sesi kapattık
    }
    private void EnableSounds()
    {
        soundsButtonImage.sprite = optionsOnSprite;//! sprite değitirdik
        soundsManager.EnableSounds();//! sesi açtık
    }

    private void ChangeHapticsState()
    {
        hapticsState = !hapticsState;
        if (hapticsState)
        {
            hapticsButtonImage.sprite = optionsOnSprite;
        }
        else
        {
            hapticsButtonImage.sprite = optionsOffSprite;
        }
    }
}
