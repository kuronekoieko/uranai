using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetProfileButton : MonoBehaviour
{
    [SerializeField] Button button;
    bool isMe;
    public void OnStart(bool isMe)
    {
        button.onClick.AddListener(OnClickButton);
        this.isMe = isMe;
    }


    void OnClickButton()
    {
        UIManager.i.GetModal<EditProfileModal>().Open(isMe);
    }


}