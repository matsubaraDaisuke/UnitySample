using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopController : MonoBehaviour
{

    /// <summary>
    /// スクロールビュー
    /// </summary>
    [SerializeField]
    public ScrollRectSnap scrollRectSnap;

    /// <summary>
    /// ページコントローラー
    /// まるポチと戻る、次へボタンの表示
    /// </summary>
    [SerializeField]
    public PageControl pageControl;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 戻るボタン
    /// </summary>
    public void OnClickPrevButton()
    {
        ChangePage(scrollRectSnap.HorizontalPageIndex-1);
    }

    /// <summary>
    /// 次へボタン
    /// </summary>
    public void OnClickNextButton()
    {
        ChangePage(scrollRectSnap.HorizontalPageIndex+1);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageIndex"></param>
    private void ChangePage( int pageIndex ) {
        pageIndex = Math.Min(scrollRectSnap.horizontalPages-1, pageIndex);
        pageIndex = Math.Max(0, pageIndex);

        scrollRectSnap.ChangeHorizontalPage(pageIndex);

    }


}
