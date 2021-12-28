using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    
    [SerializeField] private float dissapearTime;
    [SerializeField] private float fadeOutSpeed;
    [SerializeField] private float moveYSpeed;
    
    private Transform playerTransform;
    private TextMeshPro textMesh;
    private Color textColor;
    


    public void SetUp(float amount)
    {
        textMesh = GetComponent<TextMeshPro>();
      
        playerTransform = Camera.main.transform;

        textColor = textMesh.color;
        textMesh.SetText(amount.ToString());
    }

    private void LateUpdate()
    {
        transform.position += new Vector3(0f, moveYSpeed * Time.deltaTime, 0f); // move DamagePopup upwards
        transform.LookAt(2 * transform.position - playerTransform.position); // to rotate the Text 180°.
        


        dissapearTime -= Time.deltaTime;
        if(dissapearTime <= 0f)
        {
            textColor.a -= fadeOutSpeed * Time.deltaTime;
            textMesh.color = textColor;
            if(textColor.a <= 0f)
            {
                Destroy(gameObject);
            }
        }
    }
}
