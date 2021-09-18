using UnityEngine;

[System.Serializable]
public class TurretBlueprint
{
    public int cost;
    public GameObject prefab;

    public int upgradedCost;
    public GameObject upgradedPrefab;

    public int GetSellAmount()
    {
        return cost / 2;
    }
}
