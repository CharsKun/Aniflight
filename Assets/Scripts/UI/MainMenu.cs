using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class MainMenu : MonoBehaviour, IUnityAdsListener
{
    public GameObject Pause;

    string GooglePlayId = "3999049";
    string myPlacementId = "rewardedVideo";

    bool TestRun = true;
    bool mulai = false;

    public GameObject SoundManager;
    public GameObject layerOption;
    public GameObject layerCredit;

    private float delay;

    private int sken=0;

    private void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlayId, TestRun);
        delay = 0;
    }

    private void Update()
    {
        if (mulai == true)
        {
            delay += Time.deltaTime;
        }

        if (delay >= 0.3f && sken ==1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }else if(delay >= 0.3f && sken == 2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }else if(delay >= 0.3f && sken == 11)
        {
            SceneManager.LoadScene("Stage1");
        }
        else if (delay >= 0.3f && sken == 12)
        {
            SceneManager.LoadScene("Stage2");
        }
        else if (delay >= 0.3f && sken == 13)
        {
            SceneManager.LoadScene("Stage3");
        }
        else if (delay >= 0.3f && sken == 14)
        {
            SceneManager.LoadScene("Stage4");
        }
        else if (delay >= 0.3f && sken == 15)
        {
            SceneManager.LoadScene("Stage5");
        }
        else if(delay >= 0.3f && sken == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (delay >= 0.3f && sken == 9)
        {
            Advertisement.Show();
            SceneManager.LoadScene("StageSelection");
        }
        

    }

    public void PlayGame()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 1;
    }

    public void backtoPreviousButton()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 2;
    }

    public void stage1()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 11;
    }

    public void stage2()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 12;
    }

    public void stage3()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 13;
    }

    public void stage4()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 14;
    }

    public void stage5()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 15;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 10;
    }

    public void StageSelection()
    {
        Time.timeScale = 1f;
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        mulai = true;
        sken = 9;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        this.gameObject.SetActive(false);
        SoundManager.GetComponent<SoundManager>().tombolKlik();
    }

    public void PauseMenu()
    {
        SoundManager.GetComponent<SoundManager>().paused();
        Time.timeScale = 0f;
        Pause.SetActive(true);
    }

    public void ResetData()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
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

    public void showOption()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        layerOption.SetActive(true);
    }

    public void hideOption()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        layerOption.SetActive(false);
    }

    public void showCredit()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        layerCredit.SetActive(true);
    }

    public void hideCredit()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        layerCredit.SetActive(false);
    }

    public void unlockAll()
    {
        SoundManager.GetComponent<SoundManager>().tombolKlik();
        PlayerPrefs.SetInt("Stage2", 1);
        PlayerPrefs.SetInt("Stage3", 1);
        PlayerPrefs.SetInt("Stage4", 1);
        PlayerPrefs.SetInt("Stage5", 1);
        PlayerPrefs.SetInt("Archer", 1);
        PlayerPrefs.SetInt("Mage", 1);
    }

}
