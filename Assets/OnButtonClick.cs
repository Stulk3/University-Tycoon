using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SwipeableView;

public class OnButtonClick : MonoBehaviour
{
    public void SwipeRight()
    {
        if (BasicScene.SwipeableView.IsAutoSwiping) return;
        BasicScene.SwipeableView.AutoSwipe(SwipeDirection.Right);
        AudioManager.instance.PlaySound(AudioManager.penSound);
    }
    public void SwipeLeft()
    {
        if (BasicScene.SwipeableView.IsAutoSwiping) return;
        BasicScene.SwipeableView.AutoSwipe(SwipeDirection.Left);
        AudioManager.instance.PlaySound(AudioManager.trashSound);
    }
    public void DocumentsSelection()
    {

        if (!UserInterface.DocumentsSelector.activeSelf)
        {
            UserInterface.DocumentsSelector.SetActive(true);
            UserInterface.ConstructionSelector.SetActive(false);
            UserInterface.ShopSelector.SetActive(false);
            UserInterface.ProfileSelector.SetActive(false);
        }
    }
    public void ConstructionSelection()
    {
        if (!UserInterface.ConstructionSelector.activeSelf)
        {
            UserInterface.DocumentsSelector.SetActive(false);
            UserInterface.ConstructionSelector.SetActive(true);
            UserInterface.ShopSelector.SetActive(false);
            UserInterface.ProfileSelector.SetActive(false);
        }
    }
    public void ShopSelection()
    {
        if (!UserInterface.ShopSelector.activeSelf)
        {
            UserInterface.DocumentsSelector.SetActive(false);
            UserInterface.ConstructionSelector.SetActive(false);
            UserInterface.ShopSelector.SetActive(true);
            UserInterface.ProfileSelector.SetActive(false);
        }
    }
    public void ProfileSelection()
    {
        if (!UserInterface.ProfileSelector.activeSelf)
        {
            UserInterface.DocumentsSelector.SetActive(false);
            UserInterface.ConstructionSelector.SetActive(false);
            UserInterface.ShopSelector.SetActive(false);
            UserInterface.ProfileSelector.SetActive(true);
        }
    }
}
