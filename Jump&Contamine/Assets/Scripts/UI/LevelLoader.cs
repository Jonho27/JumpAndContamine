using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTimer = 1f;


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex + 1)));
    }

    public void LoadMenuLevel()
    {
        StartCoroutine(LoadLevel((SceneManager.GetActiveScene().buildIndex - 1)));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTimer);

        SceneManager.LoadScene(levelIndex);

    }
}
