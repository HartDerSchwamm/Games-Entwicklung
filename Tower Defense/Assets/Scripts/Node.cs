using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{   
    [Header("Optional")]
    public GameObject turret;


    private Vector3 positionOffSet = new Vector3(0f,0.5f,0f);
    private Color hoverColor = Color.blue;
    private Color occupied = Color.red;
    private Color startColor;
    private Renderer rend;

    BuildManager buildmanager;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildmanager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildmanager.CanBuild)
        {
            return;
        }
        if (turret != null)
        {
            rend.material.color = occupied;
            return;
        }
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildmanager.CanBuild)
        {
            return;
        }

        if (turret != null)
        {
        print("Belegt!");
        return;
        }
        buildmanager.BuildTurretOn(this);
    }
}
