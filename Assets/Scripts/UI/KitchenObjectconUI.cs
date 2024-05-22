using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class KitchenObjectconUI : MonoBehaviour
{
    [SerializeField] private Image iconImage;
    
    public void Show(Sprite sprite) 
    {
        gameObject.SetActive(true);
        iconImage.sprite = sprite;
    }
    public void Hide() 
    {
        gameObject.SetActive(false);
    }

}
