using UnityEngine;
using System.Collections;
public class WebLoadingBillboard : MonoBehaviour
{
    public void Operate() 
    {
        WManagers.Images.GetWebImage(OnWebImage);
        print("-");
    }
    private void OnWebImage(Texture2D image)
    {
        print("+");
        GetComponent<Renderer>().material.mainTexture = image;
    }
}
