using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupManager : MonoBehaviour
{
    #region Singleton

    public static DamagePopupManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Something went Wrong");
            Destroy(gameObject);
        }
    }
    #endregion

    [SerializeField] 
    private GameObject damagePopupPrefab;
    

    public void DisplayDamagePopup(float amount, Transform popupParent)
    {
        GameObject damagePopup = Instantiate(damagePopupPrefab, popupParent.transform.position, Quaternion.identity, popupParent);
        damagePopup.GetComponent<DamagePopup>().SetUp(amount);
    }
}
