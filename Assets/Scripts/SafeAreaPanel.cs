using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeAreaPanel : MonoBehaviour {

	private RectTransform panel;
	Rect lastSafeArea = new Rect(0, 0, 0, 0);

    [SerializeField]
	public Text DebugText;

	// Use this for initialization
	void Start () {
		panel = GetComponent <RectTransform>();
        CheckSafeArea();
	}

	void ApplySafeArea(Rect area)
	{
		var anchorMin = area.position;
		var anchorMax = area.position + area.size;
		anchorMin.x /= Screen.width;
		anchorMin.y /= Screen.height;
		anchorMax.x /= Screen.width;
		anchorMax.y /= Screen.height;
		panel.anchorMin = anchorMin;
		panel.anchorMax = anchorMax;

		lastSafeArea = area;
	}

	// Update is called once per frame
	void Update () 
	{
        CheckSafeArea();
	}

    private void CheckSafeArea()
    {
        Rect safeArea = GetSafeArea();

        if (safeArea != lastSafeArea)
        {
            ApplySafeArea(safeArea);
        }

        if (DebugText != null)
        {
            DebugText.text = "safeArea:" + safeArea.ToString();
        }
        //      DebugModeController.AddLog ("w:" + Screen.width + " h:" + Screen.height);
    }


    public static Rect GetSafeArea() {
        Rect safeArea = Screen.safeArea;
        // iPhone7はx:0 y:0 width:750 height:1294が返ってくる
        // iphone7の解像度は750x1334

        //iPhoneX縦画面シミュレート
        //safeArea.y = 34 * 3;
        //safeArea.height -= (44+34) * 3;

        //iPhoneX横画面シミュレート
        //safeArea.x = 44;
        //safeArea.y = 21;
        //safeArea.width -= 88;
        //safeArea.height -= 21;

#if UNITY_IOS || UNITY_EDITOR
        if ((int)Screen.width < (int)Screen.height)
        {
            if ((int)Screen.height == (int)safeArea.height)
            {
                // ステータスバー分だけ入れる
                safeArea.height -= Constants.IosStatusBarHeight;
            }
        }
#endif

        return safeArea;
    }


    public static int TopMargin( int topPixel )
    {
        var topMargin = (topPixel * Screen.width / Constants.DefaultScreenWidth);
        topMargin += (Screen.height - GetSafeArea().height - GetSafeArea().y);
        return (int)topMargin;
    }

    public static int BottomMargin( int bottomPixel )
    {
        var bottomMargin = (bottomPixel * Screen.width / Constants.DefaultScreenWidth);
        bottomMargin += GetSafeArea().y;

        return (int)bottomMargin;
    }

    public static int BottomMarginFromPosition(int bottomPosition)
    {
        var bottomMargin = (bottomPosition * Screen.width / Constants.DefaultScreenWidth);
        bottomMargin = GetSafeArea().height - bottomMargin;
        bottomMargin += GetSafeArea().y;

        return (int)bottomMargin;
    }

    public static int LeftMargin(int leftPixel)
    {
        var leftMargin = (leftPixel * Screen.width / Constants.DefaultScreenWidth);
        return (int)leftMargin;
    }

    public static int SafeAreaHeight()
    {
        return (int)((Screen.height - GetSafeArea().height) / (Screen.width / Constants.DefaultScreenWidth));
    }
}
