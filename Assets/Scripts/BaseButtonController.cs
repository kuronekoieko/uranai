using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BaseButtonController : MonoBehaviour
{
    public Button button
    {
        get
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            return _button;
        }
    }
    public Button _button;

    protected void AddListener(UnityAction action)
    {
        button.onClick.AddListener(action);
    }

}
