using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour, IUnityAdsListener
{
    public GameObject Pause;
    string GooglePlayId = "3999049";
    bool TestRun = true;
    string myPlacementId = "rewardedVideo";

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlayId, TestRun);
    }
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
        Advertisement.Show();
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

    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(myPlacementId))
        {
            Advertisement.Show(myPlacementId);
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (showResult == ShowResult.Finished)
        {
            PlayerPrefs.SetInt("Archer", 1);
        }
    }

    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, show the ad:
        if (placementId == myPlacementId)
        {
            // Optional actions to take when the placement becomes ready(For example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }

    public void ShowAd()
    {
        Advertisement.Show(myPlacementId);
        SceneManager.LoadScene("CharacterSelection");
    }
}
