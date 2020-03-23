using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
public class SettingsManager : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private SoundsManager soundsManager;//! ses yöneticisi classını alacak 
    [SerializeField] private VibrationManager vibrationManager;//! titreşim yöneticisi classını alacak
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
        if (hapticsState)
        {
            EnableHaptics();
        }
        else
        {
            DisableHaptics();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSoundsState()
    {
        //! durumu değiştireceğiz
        if (soundsState)
        {

            DisableSounds();
        }
        else
        {
            EnableSounds();
        }
        soundsState = !soundsState;
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

    public void ChangeHapticsState()
    {
        //! durumu değiştireceğiz
        if (hapticsState)
        {
            DisableHaptics();
        }
        else
        {
            EnableHaptics();
        }
        hapticsState = !hapticsState;
    }

    private void EnableHaptics()
    {
        hapticsButtonImage.sprite = optionsOnSprite;
        vibrationManager.DisableHaptics();

    }

    private void DisableHaptics()
    {
        hapticsButtonImage.sprite = optionsOffSprite;
        vibrationManager.EnableHaptics();

    }
}
