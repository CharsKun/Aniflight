using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageSelectData : MonoBehaviour
{
    public Button stage2;
    public Button stage3;
    public Button stage4;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("Stage2") >= 1)
        {
            stage2.GetComponent<Button>().interactable = true;
        }

        if(PlayerPrefs.GetInt("Stage3") >= 1)
        {
            stage3.GetComponent<Button>().interactable = true;
        }

        if(PlayerPrefs.GetInt("Stage4") >= 1)
        {
            stage4.GetComponent<Button>().interactable = true;
        }

        Debug.Log(PlayerPrefs.GetInt("Stage2") + " " + PlayerPrefs.GetInt("Stage3") + " " + PlayerPrefs.GetInt("Stage4"));
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
