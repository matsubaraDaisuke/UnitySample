using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HamburguerMenuController : MonoBehaviour
{

    private Button HomeSceneButton;
    private Button AddSceneButton;
    private Button SettingSceneButton;

    private Button CloseButton;

    public Animator MenuBoadAnimator;
    
    // Start is called before the first frame update
    void Start()
    {
        CloseButton = GameObject.Find("MenuPanel/MenuHeader/CloseButton").GetComponent<Button>();
        CloseButton.onClick.AddListener( ()=>{ Close(); });

        HomeSceneButton = GameObject.Find("MenuPanel/MenuContent/HomeSceneButton").GetComponent<Button>();
        AddSceneButton = GameObject.Find("MenuPanel/MenuContent/AddSceneButton").GetComponent<Button>();
        SettingSceneButton = GameObject.Find("MenuPanel/MenuContent/SettingSceneButton").GetComponent<Button>();

        HomeSceneButton.onClick.AddListener( () => { SceneManager.LoadScene("HomeScene"); } );
        AddSceneButton.onClick.AddListener( () => { SceneManager.LoadScene("AddScene"); } );
        SettingSceneButton.onClick.AddListener( () => { SceneManager.LoadScene("SettingScene"); } );

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        MenuBoadAnimator.speed = 1;
        MenuBoadAnimator.ResetTrigger("Close");
    }

    public void OpenMenu(){
        gameObject.SetActive( true );
    }

    public void Close()
    {
        //アニメーターのトリガーをオンにする
        //gameObject.SetActive( false );
        MenuBoadAnimator.SetTrigger("Close");
    }

    public void CloseMenu(){
        //MenuBoadAnimator.SetTrigger("Close");
        gameObject.SetActive( false );
    }
}
