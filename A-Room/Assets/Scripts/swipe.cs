using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class swipe : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public int totalPages = 3;
    private int currentPage = 1;
    RectTransform r;
    private double differenceY=0;
    private bool moveUp;
    private int moving=0;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<RectTransform>();
        //Debug.Log(r.rect.height);
        panelLocation = transform.position;
    }
    public void OnDrag(PointerEventData data)
    {

        float differenceX = data.pressPosition.x - data.position.x;
        differenceY = data.pressPosition.y - data.position.y;
        if (Mathf.Abs((float)(differenceY)) > Mathf.Abs((float)(differenceX))&& moving!=2)
        {
            r.sizeDelta = new Vector2(r.sizeDelta.x, (float)(r.sizeDelta.y - differenceY * 0.09));
            moveUp = true;
            moving = 1;
        }
        else if (Mathf.Abs((float)(differenceX)) > Mathf.Abs((float)(differenceY))&& moving!=1) {
            transform.position = panelLocation - new Vector3(differenceX, 0, 0);
            moveUp = false;
            moving = 2;
        }
        
    }
    public void OnEndDrag(PointerEventData data)
    {
        float percentageX = (data.pressPosition.x - data.position.x) / Screen.width;
        if (moveUp)
        {
            if (r.sizeDelta.y <= 2500 && r.sizeDelta.y > 1700)
            {
                r.sizeDelta = new Vector2(r.sizeDelta.x, (float)(r.sizeDelta.y - differenceY * 0.09));

            }
            else if ( r.sizeDelta.y <= 1700 && r.sizeDelta.y > 1200)
            {

                StartCoroutine(SmoothMove(r.sizeDelta, 1700, easing));
            }
            else if (r.sizeDelta.y >= 2500)
            {

                StartCoroutine(SmoothMove(r.sizeDelta, 2500, easing));
            }
            else if(r.sizeDelta.y < 1200)
            {
                StartCoroutine(SmoothMove(r.sizeDelta, 0, easing));
            }
        }
        if (moveUp == false)
        {
            if (Mathf.Abs(percentageX) >= percentThreshold)
            {
                Vector3 newLocation = panelLocation;
                if (percentageX > 0 && currentPage < totalPages)
                {
                    currentPage++;
                    newLocation += new Vector3(-Screen.width, 0, 0);
                }
                else if (percentageX < 0 && currentPage > 1)
                {
                    currentPage--;
                    newLocation += new Vector3(Screen.width, 0, 0);
                }
                StartCoroutine(SmoothMoveX(transform.position, newLocation, easing));
                panelLocation = newLocation;
            }
            else
            {
                StartCoroutine(SmoothMoveX(transform.position, panelLocation, easing));
            }
        }
        moving = 0;
    }
    
    IEnumerator SmoothMoveX(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
    IEnumerator SmoothMove(Vector2 startpos, float hight, float seconds)
    {
        float t = 0f;
        Vector2 endpos = r.sizeDelta;
        endpos.y =hight;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            r.sizeDelta = Vector2.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            yield return null;
        }
    }
}