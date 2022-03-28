using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] 
    private RectTransform lever;
    private RectTransform rectTransform;

    [SerializeField, Range(10f,150f)] 
    private float leverRange;
    
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin");

        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");

        var inputDir = eventData.position - rectTransform.anchoredPosition;

        var clampedDir = inputDir.magnitude < leverRange ? inputDir : inputDir.normalized * leverRange;

        lever.anchoredPosition = clampedDir;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End");

        lever.anchoredPosition = Vector2.zero;
    }
}
