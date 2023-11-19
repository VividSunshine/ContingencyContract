using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject towerPrefab;

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        //Ÿ�� �Ǽ� ���� ���� Ȯ��
        //1. ���� Ÿ���� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ� x
        if (tile.IsBuildTower == true )
        {
            return;
        }

        //Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;

        //������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        Instantiate(towerPrefab, tileTransform.position, Quaternion.identity);
    }
}