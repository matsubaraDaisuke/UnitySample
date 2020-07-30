using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollRectSnap : ScrollRect
{
    [SerializeField]
    public int horizontalPages = 3; // horizontalの分割数
    public int verticalPages = 3;  // verticalの分割数

    [HideInInspector]
    public int HorizontalPageIndex { private set; get; }
    [HideInInspector]
    public int VerticalPageIndex { private set; get; }

    [SerializeField]public float smooth = 10f;  // スナップ係数
    private Vector2 targetPosition; // スナップ先座標
    private bool isDrag = false; // フラグ


    protected override void Start()
    {
        base.Start();
        normalizedPosition = content.GetComponent<RectTransform>().pivot;
        targetPosition = FindSnapPosition(Vector2.zero);
    }

    void Update()
    {
        if (!isDrag && normalizedPosition != targetPosition)
        {
            normalizedPosition = Vector2.Lerp(normalizedPosition, targetPosition, smooth * Time.deltaTime);
        }
    }

    public override void OnBeginDrag(PointerEventData eventData)
    {
        base.OnBeginDrag(eventData);
        isDrag = true;
    }

    public override void OnEndDrag(PointerEventData eventData)
    {
        base.OnEndDrag(eventData);
        targetPosition = FindSnapPosition(eventData.delta);
        isDrag = false;
    }

    /// <summary>
    /// Changes the horizontal page.
    /// </summary>
    /// <param name="pageIndex">Page index.</param>
    /// <param name="quickMove">If set to <c>true</c> 瞬間的に移動する.</param>
    public void ChangeHorizontalPage( int pageIndex, bool quickMove = false )
    {
        if (horizontal)
        {
            HorizontalPageIndex = pageIndex;
            targetPosition.x = HorizontalPageIndex / (horizontalPages - 1f);

            if( quickMove ) {
                normalizedPosition = targetPosition;
            }
        }
    }
    /// <summary>
    /// Changes the vertical page.
    /// </summary>
    /// <param name="pageIndex">Page index.</param>
    /// <param name="quickMove">If set to <c>true</c> 瞬間的に移動する.</param>
    public void ChangeVerticalPage(int pageIndex, bool quickMove = false)
    {
        if (vertical)
        {
            VerticalPageIndex = pageIndex;
            targetPosition.y = VerticalPageIndex / (verticalPages - 1f);
            if (quickMove)
            {
                normalizedPosition = targetPosition;
            }
        }
    }

    // スナップ先座標を取得する
    Vector2 FindSnapPosition( Vector2 delta )
    {
        float x = 0, y = 0;
        Vector2 center;

        float frickValue = 0.001f;

        delta.x /= Screen.width;

        if( delta.x > frickValue ) {
            delta.x = 1.0f;
        } else if (delta.x < -frickValue) {
            delta.x = -1.0f;
        }
        delta.y /= Screen.height;
        if( delta.y > frickValue ) {
            delta.y = 1.0f;
        } else if (delta.x < -frickValue){
            delta.y = -1.0f;
        }
        if (horizontal)
        {
            if (horizontalPages > 1)
            {
                // フリック分を追加
                var normalizedX = horizontalNormalizedPosition + (-delta.x/horizontalPages);
                var pageIndex = 0;
                for (int page = 0; page < horizontalPages; page++)
                {
                    center.x = (2f * page - 1f) / ((horizontalPages - 1f) * 2f);
                    if (normalizedX >= center.x)
                    {
                        x = page / (horizontalPages - 1f);
                        pageIndex = page;
                    }
                }

                HorizontalPageIndex = pageIndex;
            }
        }
        else
        {
            x = horizontalNormalizedPosition;
        }

        if (vertical)
        {
            if (verticalPages > 1)
            {
                // フリック分を追加
                var normalizedX = verticalNormalizedPosition + (-delta.y/verticalPages);
                var pageIndex = 0;
                for (int page = 0; page < verticalPages; page++)
                {
                    center.y = (2f * page - 1f) / ((verticalPages - 1f) * 2f);
                    if (normalizedX >= center.y)
                    {
                        y = page / (verticalPages - 1f);
                        pageIndex = page;
                    }
                }
                VerticalPageIndex = pageIndex;
            }
        }
        else
        {
            y = verticalNormalizedPosition;
        }
        return new Vector2(x, y);
    }
}