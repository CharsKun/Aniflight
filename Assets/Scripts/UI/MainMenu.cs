using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Pause;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void backtoPreviousButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void stage1()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void stage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void stage3()
    {
        SceneManager.LoadScene("Stage3");
    }

    public void stage4()
    {
        SceneManager.LoadScene("Stage4");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void StageSelection()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
        Pause.SetActive(true);
    }

    public void ResetData()
    {
        PlayerPrefs.SetInt("Stage2", 0);
        PlayerPrefs.SetInt("Stage3", 0);
        PlayerPrefs.SetInt("Stage4", 0);
        PlayerPrefs.SetInt("Stage5", 0);
        PlayerPrefs.SetInt("Archer", 0);
        PlayerPrefs.SetInt("Mage", 0);
    }
}
