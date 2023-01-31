using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> : MonoBehaviour where T : ObjectPoolingElement
{
    [SerializeField] T prefab;

    protected List<T> list = new List<T>();

    protected void Initialize()
    {
        this.prefab.gameObject.SetActive(false);
    }

    protected void Clear()
    {
        foreach (var item in list)
        {
            item.gameObject.SetActive(false);
        }
    }

    protected T GetInstance()
    {
        foreach (var item in list)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                return item;
            }
        }
        var instance = Instantiate(prefab, transform);
        instance.Initialize();
        instance.gameObject.SetActive(true);
        return instance;
    }
}
