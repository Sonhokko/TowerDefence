using UnityEngine;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private NodeUI nodeUI;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public static BuildManager instance;
    public bool canBuild {get {return turretToBuild != null;}}
    public bool enoughMoney {get {return PlayerStats.Money >= turretToBuild.cost;}}

    private void Awake()
    {
        instance = this;
    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return turretToBuild;
    }



}
