using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FooterPanelController : MonoBehaviour
{
    //[SerializeField]
    private Button HomeTabButton;// = GameObject.Find("Base/HomeTabButton").GetComponent<Button>();
    private Button AddTabButton;
    private Button SettingTabButton;

    // Start is called before the first frame update
    void Start()
    {
       HomeTabButton = GameObject.Find("Base/HomeTabButton").GetComponent<Button>();
       AddTabButton = GameObject.Find("Base/AddTabButton").GetComponent<Button>();
       SettingTabButton = GameObject.Find("Base/SettingTabButton").GetComponent<Button>();

       HomeTabButton.onClick.AddListener(OnClickHomeTabButton);
       AddTabButton.onClick.AddListener(OnClickAddTabButton);
       SettingTabButton.onClick.AddListener(OnClickSettingTabButton);

    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnClickHomeTabButton(){
        SceneManager.LoadScene("HomeScene");        
    }

    private void OnClickAddTabButton(){
        SceneManager.LoadScene("AddScene");        
    }

    private void OnClickSettingTabButton(){
        SceneManager.LoadScene("SettingScene");        
    }

}
