using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSoundScript : MonoBehaviour
{
    private static BackgroundSoundScript original;
    private void Awake()
    {
        if (original != this)
        {
            if (original != null)
                Destroy(original.gameObject);
            DontDestroyOnLoad(gameObject);
            original = this;
        }
    }
}
