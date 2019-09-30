using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject PlayButton;
    public void PauseButtonPress() {
        if (!GameController.instance.IsPaused()) {
            GameController.instance.Pause();
            PauseButton.SetActive(false);
            PlayButton.SetActive(true);
        }
    }

    public void PlayButtonPress() {
        if (GameController.instance.IsPaused()) {
            GameController.instance.UnPause();
            PauseButton.SetActive(true);
            PlayButton.SetActive(false);
        }
    }
}
