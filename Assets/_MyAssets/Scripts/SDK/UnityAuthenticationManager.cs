using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;

public class UnityAuthenticationManager : Singleton<UnityAuthenticationManager>
{

    public async void Initialize()
    {
        await UnityServices.InitializeAsync();

    }


}
