using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string diamond15 = "com.virtualillusion.sevenstones.diamonds15";
    private string diamond36 = "com.virtualillusion.sevenstones.diamonds36";
    private string diamond87 = "com.virtualillusion.sevenstones.diamonds87";
    private string diamond210 = "com.virtualillusion.sevenstones.diamonds210";

    private void Awake()
    {
        if (Application.platform != RuntimePlatform.IPhonePlayer)
        {

        }
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == diamond15)
        {
            Debug.Log("You have gained 15 diamonds");
        }
        else if (product.definition.id == diamond36)
        {
            Debug.Log("You have gained 36 diamonds");
        }
        else if (product.definition.id == diamond87)
        {
            Debug.Log("You have gained 87 diamonds");
        }
        else if (product.definition.id == diamond210)
        {
            Debug.Log("You have gained 210 diamonds");
        }

        AudioManager.Instance.Play(1);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because " + failureReason);
    }

}
