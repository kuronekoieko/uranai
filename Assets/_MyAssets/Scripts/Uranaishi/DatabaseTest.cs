using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DatabaseTest : MonoBehaviour
{
    [SerializeField] InputField userIdIF;
    [SerializeField] InputField userNameIF;
    [SerializeField] Button sendButton;
    [SerializeField] Button imageButton;
    [SerializeField] Image image;
    string iconLocalFilePath;
    Uranaishi uranaishi;

    void Start()
    {
        uranaishi = new Uranaishi();
        uranaishi.id = "901";
        userIdIF.text = uranaishi.id.ToString();

        sendButton.onClick.AddListener(SendData);
        imageButton.onClick.AddListener(SetIcon);


        FirebaseDatabaseManager.i.GetUserData(uranaishi, () =>
        {
            userNameIF.text = uranaishi.name.ToString();


            FirebaseStorageManager.i.DownloadFile(uranaishi, (texture) =>
            {
                image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            });

        });




    }

    void SendData()
    {

        uranaishi.id = userIdIF.text;

        uranaishi.name = userNameIF.text;

        FirebaseStorageManager.i.UploadFromLocalFile(uranaishi, iconLocalFilePath);

        FirebaseDatabaseManager.i.SetUserData(uranaishi);
    }

    void SetIcon()
    {
        PickImage(512);
    }


    /// <summary>
    /// https://note.com/npaka/n/nc9fcedf31b33
    /// </summary>
    /// <param name="maxSize"></param>
    void PickImage(int maxSize)
    {
        // 画像の読み込み
        NativeGallery.Permission permission = NativeGallery.GetImageFromGallery((path) =>
        {

            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // 画像パスからTexture2Dを生成
                Texture2D texture = NativeGallery.LoadImageAtPath(path, maxSize);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                // https://blog.narumium.net/2017/01/30/%E3%80%90unity%E3%80%91image%E3%81%AB%E3%83%86%E3%82%AF%E3%82%B9%E3%83%81%E3%83%A3%E3%82%92%E8%A8%AD%E5%AE%9A%E3%81%99%E3%82%8B/ 
                image.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
                iconLocalFilePath = path;
            }
        });
        Debug.Log("Permission result: " + permission);

    }

}
