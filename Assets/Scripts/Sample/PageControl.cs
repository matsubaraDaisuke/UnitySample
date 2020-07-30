using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageControl : MonoBehaviour
{
    [SerializeField]
    private Button NextButton, PrevButton;

    [SerializeField]
    private TopController topController;

    // Start is called before the first frame update
    void Start()
    {
        NextButton.onClick.AddListener(OnClickNextButton);
        PrevButton.onClick.AddListener(OnClickPrevButton);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnClickNextButton()
    {
        topController.OnClickNextButton();       
    }

    private void OnClickPrevButton()
    {
        topController.OnClickPrevButton();
    }
}
