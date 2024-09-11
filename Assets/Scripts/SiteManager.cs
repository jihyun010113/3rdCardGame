using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiteManager : MonoBehaviour
{
    // Start is called before the first frame update

    public void OnClick_OpenURL_str(string url)
    {
        Application.OpenURL(url);
    }
}
