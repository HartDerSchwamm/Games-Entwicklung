using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standartTurretPrefab;
    public GameObject laserTurretPrefab;


    private TurretBlueprint turretToBuild;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in Scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild { get { return turretToBuild != null; } }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn (Node node)
    {
       GameObject turret = (GameObject) Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
    }
    

}
