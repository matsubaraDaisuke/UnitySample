using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YesNoDialog : MonoBehaviour
{

    public enum ButtonType {
        YesNo,
        Yes,
    };

    struct DispData {
        public string title;
        public string body;
        public string yesText;
        public string noText;
        public ButtonType btnType;

        public DispData(string title, string body, ButtonType btnType) {
            this.title = title;
            this.body = body;
            this.btnType = btnType;
            this.yesText = "OK";
            this.noText = "キャンセル";
        }
        public DispData(string title, string body, ButtonType btnType, string yesText, string noText) {
            this.title = title;
            this.body = body;
            this.btnType = btnType;
            this.yesText = yesText;
            this.noText = noText;
        }
    };

    public delegate void EndDelegate(bool isYes);
    EndDelegate endDelegate;

    public Text BodyText;
    public Text YesText;
    public Text NoText;
    public Text OkText;

    public GameObject YesPanel;
    public GameObject YesNoPanel;
    public GameObject BasePanel;

    // Start is called before the first frame update
    void Start()
    {
        //BasePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsOpen()
    {
        return gameObject.activeSelf;
    }


    // yesNoButtonの場合
    public void Open(string bodyText, string yesText, string noText, EndDelegate endDel=null)
    {
        gameObject.SetActive( true );

        BodyText.text = bodyText;
        if( YesText ) {
            YesText.text = yesText;
        }
        if( NoText ) {
            NoText.text = noText;
        }
        /*
        if( OkText ) {
            OkText.text = dispData[dispType].yesText;
        }
        */
        SetButtonType( ButtonType.YesNo );

        if (endDel != null)
        {
            endDelegate = endDel;
        } else {
            endDelegate = (isYes) => { };
        }
        BasePanel.SetActive(true);

    }

    // yesButtonの場合
    public void Open(string bodyText, string okText, EndDelegate endDel=null)
    {
        gameObject.SetActive( true );
        Debug.Log("call open");

        BodyText.text = bodyText;

        if( OkText ) {
            OkText.text = okText;
        }

        SetButtonType( ButtonType.Yes );

        if (endDel != null)
        {
            endDelegate = endDel;
        } else {
            endDelegate = (isYes) => { };
        }
        BasePanel.SetActive(true);

    }

    public void Close()
    {
        BasePanel.SetActive(false);
        gameObject.SetActive( false );
    }

    public void SetButtonType(ButtonType btnType) {
        if (btnType == ButtonType.YesNo) {
           YesPanel.SetActive( false );
           YesNoPanel.SetActive( true );
        }
        else {
           YesPanel.SetActive( true );
           YesNoPanel.SetActive( false );
        }
    }

    public void OnYesButton()
    {
        if (endDelegate != null)
        {
            endDelegate(true);
        }
        Close();
    }

    public void OnNoButton()
    {
        if (endDelegate != null)
        {
            endDelegate(false);
        }
        Close();
    }

}
