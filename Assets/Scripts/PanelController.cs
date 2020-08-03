using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField]
    private Button yesNoButton;

    [SerializeField]
    private Button yesButton;

    [SerializeField]
    private YesNoDialog yesNoDialog;

    // Start is called before the first frame update
    void Start()
    {
        yesButton.onClick.AddListener( callYesDialog );
        yesNoButton.onClick.AddListener( callYesNoDialog );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void callYesDialog(){

        yesNoDialog. Open("yesダイアログです", "Yes",  (isYes) => {

                Debug.Log("yesが押されました");               

        });

    }

    private void callYesNoDialog(){
        yesNoDialog. Open("yesNoダイアログです", "Yes", "No", (isYes) => {

            if(isYes){
                Debug.Log("yesが押されました");              
            }else{
                Debug.Log("noが押されました");  
            }
        });
    }
    
}
