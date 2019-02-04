using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DontDestroyAudio : MonoBehaviour
{
    void Awake()
    {
        if (PauseMenu.LoadingMenu) {

            Destroy(gameObject);
        }


        DontDestroyOnLoad(transform.gameObject);
    }


}
