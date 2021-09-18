using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TurretBlueprint turretPref;
    [SerializeField] private TurretBlueprint missileTurretPref;
    [SerializeField] private TurretBlueprint laserBeamerPref;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectTurret() => buildManager.SelectTurretToBuild(turretPref);

    public void SelectMissileTurret() => buildManager.SelectTurretToBuild(missileTurretPref);

    public void SelectLaserBeamer() => buildManager.SelectTurretToBuild(laserBeamerPref);

}
