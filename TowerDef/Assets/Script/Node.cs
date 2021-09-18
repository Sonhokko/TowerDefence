using UnityEngine.EventSystems;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private Color hoverColor;
    [SerializeField] private Color notEnoughMoney;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private GameObject buildEffectPref;
    private Color startColor;
    private Renderer rend;

    private GameObject turret;

    public bool isUpgraded = false;
    public TurretBlueprint turretBlueprint {get; private set;}
    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.canBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= blueprint.cost;

        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        turretBlueprint = blueprint;

        GameObject buildEffect = Instantiate(buildEffectPref, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;

        if (buildManager.enoughMoney)
            rend.material.color = hoverColor;
        else
            rend.material.color = notEnoughMoney;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradedCost)
        {
            Debug.Log("Not enough money");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradedCost;

        Destroy(this.turret);

        GameObject turret = Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        GameObject buildEffect = Instantiate(buildEffectPref, GetBuildPosition(), Quaternion.identity);
        Destroy(buildEffect, 5f);

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        Destroy(this.turret);
        turretBlueprint = null;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
