using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    Resolution[] resolutions;

    public Dropdown ResolutionDropDown;

    void Start()
    {
        resolutions = Screen.resolutions;
        ResolutionDropDown.ClearOptions();

        List<string> options = new List<string>();

        int currentRes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentRes = i;
            }

        }


        ResolutionDropDown.AddOptions(options);
        ResolutionDropDown.value = currentRes;
        ResolutionDropDown.RefreshShownValue();

    }

    public void SetMainVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);

    }
    public void SetOtherVolume(float volume)
    {
        audioMixer.SetFloat("NZVolume", volume);

    }
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);

    }
    public void SetFull(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    public void SetRes(int resindex)
    {
        Resolution resolution = resolutions[resindex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }
}
