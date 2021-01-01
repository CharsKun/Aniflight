using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public void Knight()
    {
        PlayerPrefs.SetInt("Character", 1);
        SceneManager.LoadScene("StageSelection");
    }

    public void Archer()
    {
        PlayerPrefs.SetInt("Character", 2);
        SceneManager.LoadScene("StageSelection");
    }
}
