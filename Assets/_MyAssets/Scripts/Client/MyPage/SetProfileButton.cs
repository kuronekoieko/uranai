using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetProfileButton : MonoBehaviour
{
    [SerializeField] Button button;

    public void OnStart()
    {
        button.onClick.AddListener(OnClickButton);
    }

    void OnClickButton()
    {
        UIManager.i.GetModal<EditProfileModal>().Open();
    }


}