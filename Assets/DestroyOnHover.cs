using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyOnHover : MonoBehaviour
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        DestroyButton();
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }
}
