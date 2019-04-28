using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEffect : MonoBehaviour {

    public GameObject SettingUI;
    public GameObject CreditUI;
    public GameObject BtnUI;

    private void Start()
    {
        ShowBtnUI();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void SettingBtn()
    {
        BtnUI.SetActive(false);
        SettingUI.SetActive(true);
    }
    public void CreditBtn()
    {
        BtnUI.SetActive(false);
        CreditUI.SetActive(true);
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void ShowBtnUI()
    {
        SettingUI.SetActive(false);
        CreditUI.SetActive(false);
        BtnUI.SetActive(true);
    }
}
