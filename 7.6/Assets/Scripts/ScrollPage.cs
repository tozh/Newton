﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class ScrollPage : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    ScrollRect rect;
    //页面：0，1，2，3  索引从0开始
    //每页占的比列：0/3=0  1/3=0.333  2/3=0.6666 3/3=1
    //float[] pages = { 0f, 0.333f, 0.6666f, 1f };
    List<float> pages = new List<float>();
    int currentPageIndex = -1;

    //滑动速度
    public float smooting = 4;

    //滑动的起始坐标
    float targethorizontal = 0;

    //是否拖拽结束
    bool isDrag = false;

    /// <summary>
    /// 用于返回一个页码，-1说明page的数据为0
    /// </summary>
    public System.Action<int,int> OnPageChanged;

    float startime = 0f;
    float delay = 0.1f;

    // Use this for initialization
    void Start()
    {
        rect = transform.GetComponent<ScrollRect>();
        //rect.horizontalNormalizedPosition = 0;
        //UpdatePages();      
        startime = Time.time;
    }
    
    void Update()
    {
        if (Time.time < startime + delay) return;
        UpdatePages();
        //如果不判断。当在拖拽的时候要也会执行插值，所以会出现闪烁的效果
        //这里只要在拖动结束的时候。在进行插值
        if (!isDrag && pages.Count>0)
        {
            rect.horizontalNormalizedPosition = Mathf.Lerp(rect.horizontalNormalizedPosition, targethorizontal, Time.deltaTime * smooting);
            
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;

        float posX = rect.horizontalNormalizedPosition;
        int index = 0;
        //假设离第一位最近
        float offset = Mathf.Abs(pages[index] - posX);
        for (int i = 1; i < pages.Count; i++)
        {
            float temp = Mathf.Abs(pages[i] - posX);
            if (temp < offset)
            {
                index = i;

                //保存当前的偏移量
                //如果到最后一页。反翻页。所以要保存该值，如果不保存。你试试效果就知道
                offset = temp;
            }
        }

        if(index!=currentPageIndex)
        {
            currentPageIndex = index;
            OnPageChanged(pages.Count, currentPageIndex);
        }

        /*
         因为这样效果不好。没有滑动效果。比较死板。所以改为插值
         */
        //rect.horizontalNormalizedPosition = page[index];


        targethorizontal = pages[index];
    }

    void UpdatePages()
    {
        // 获取子对象的数量
        int count = this.rect.content.childCount;
        int temp = 0;
        for(int i=0; i<count; i++)
        {
            if(this.rect.content.GetChild(i).gameObject.activeSelf)
            {
                temp++;
            }
        }
        count = temp;
        
        if (pages.Count!=count)
        {
            if (count != 0)
            {
                pages.Clear();
                for (int i = 0; i < count; i++)
                {
                    float page = 0;
                    if(count!=1)
                        page = i / ((float)(count - 1));
                    pages.Add(page);
                    //Debug.Log(i.ToString() + " page:" + page.ToString());
                }
            }
            OnEndDrag(null);
        }
    }
}
