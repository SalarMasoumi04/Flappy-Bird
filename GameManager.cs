using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        FlyBehaviour.Died += GameOver;
    }

    private void OnDisable()
    {
        FlyBehaviour.Died -= GameOver;
    }

    private void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}