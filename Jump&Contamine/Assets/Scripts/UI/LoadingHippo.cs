using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingHippo : MonoBehaviour
{
    public GameObject transition;

    public float transitionTimer = 2f;

    public void Start()
    {
        PlayerPrefs.SetInt("Sounds", 0);
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetActive(true);

        yield return new WaitForSeconds(transitionTimer);

        SceneManager.LoadScene(levelIndex);

    }
}
