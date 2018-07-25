using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    public AudioClip gameOverClip;

	public void PlayMusic(AudioClip music)
    {
        FirstSceneController firstSceneController = Director.GetInstance().CurrentScenceController as FirstSceneController;
        AudioSource.PlayClipAtPoint(music, firstSceneController.player.transform.position);
    }

    public void OnEnable()
    {
        EventHandler.GameOverChange += GameOver;
    }

    public void OnDisable()
    {
        EventHandler.GameOverChange -= GameOver;
    }

    void GameOver()
    {
        PlayMusic(gameOverClip);
    }
}
