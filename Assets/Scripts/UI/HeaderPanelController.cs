using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderPanelController : MonoBehaviour
{
    [SerializeField]
    private  HamburguerMenuController  hamburguerMenu;
    
    private Button MenuButton;

    
    // Start is called before the first frame update
    void Start()
    {
        MenuButton = GameObject.Find("MenuButton").GetComponent<Button>();
        MenuButton.onClick.AddListener(OpenHamburgerMenu);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OpenHamburgerMenu(){
        hamburguerMenu.OpenMenu();
    }


}
