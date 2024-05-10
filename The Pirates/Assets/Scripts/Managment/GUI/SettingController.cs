using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingController : MonoBehaviour
{
    #region Public Variables
    public AudioMixer audioMixer;
    public Dropdown dropdownResolution;
    #endregion

    #region Private Variables
    private Resolution[] resolutions;
    #endregion

    #region Public Methods
    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("sfx1Volume",volume);
        audioMixer.SetFloat("sfx2Volume",volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
    public void SetUIVolume(float volume)
    {
        audioMixer.SetFloat("UIVolume", volume);
    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality); 
    }
    public void SetMute(bool isMute)
    {
        isMute = !isMute;
        AudioListener.volume = isMute ? 0 : 1;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);   
    }
    #endregion

    #region Private Methods
    void Start()
    {
        resolutions = Screen.resolutions;
        dropdownResolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolution = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolution = i;
            }
        }

        dropdownResolution.AddOptions(options);
        dropdownResolution.value = currentResolution;
        dropdownResolution.RefreshShownValue();
    }//Starttttt




    void Update()
    {

    }//Updateeeee

    #endregion
}//EndClasssss
