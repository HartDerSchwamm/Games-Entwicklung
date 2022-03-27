using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint laserTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }



}
