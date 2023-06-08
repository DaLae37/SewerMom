using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingSceneManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject developerPanel;
    public GameObject licensePanel;

    public Slider volumeSlider;
    public Text volumeText;
    // Start is called before the first frame update
    void Start()
    {
        //TODO : 볼륨 불러오기
        volumeSlider.value = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetVolume()
    {
        //TODO : 볼륨 저장
        int volume = (int)volumeSlider.value;
        volumeText.text = volume.ToString();
    }

    public void ResetGame()
    {
        //TODO : 게임 초기화
    }

    public void OnSettingPanel()
    {
        CloseAllPanel();
        settingPanel.SetActive(true);
    }

    public void OnDeveloperPanel()
    {
        CloseAllPanel();
        developerPanel.SetActive(true);
    }

    public void OnLicensePanel()
    {
        CloseAllPanel();
        licensePanel.SetActive(true);
    }

    void CloseAllPanel()
    {
        settingPanel.SetActive(false);
        developerPanel.SetActive(false);
        licensePanel.SetActive(false);
    }
}
