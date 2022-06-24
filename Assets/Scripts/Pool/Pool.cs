using UnityEngine;
using System.Collections.Generic;

public class Pool : MonoBehaviour
{
    [SerializeField] private GameObject baseObject;

    public int numberOfClones;

    private Transform parent;

    internal List<GameObject> clones;

    void Awake()
    {
        InstantiateClones();
    }

    private void InstantiateClones()
    {
        parent = GameObject.FindGameObjectWithTag("Pool Parent").transform;

        clones = new List<GameObject>();

        for (int i = 0; i < numberOfClones; i++)
        {
            if (parent)
            {
                clones.Add(Instantiate(baseObject, parent));
            }
            else
            {
                clones.Add(Instantiate(baseObject));
            }

            clones[i].SetActive(false);

            clones[i].GetComponent<PoolObject>().pool = this;
        }
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        GameObject cloneToSpawn = clones[0];

        cloneToSpawn.SetActive(true);

        cloneToSpawn.transform.position = position;

        cloneToSpawn.transform.rotation = rotation;

        clones.Add(cloneToSpawn);

        clones.RemoveAt(0);

        cloneToSpawn.GetComponent<PoolObject>().OnSpawn?.Invoke(cloneToSpawn);

        return cloneToSpawn;
    }

    public void Dispawn(GameObject gameObject)
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            if (clones[i] != gameObject)
            {
                continue;
            }

            gameObject.SetActive(false);

            clones.RemoveAt(i);

            clones.Insert(0, gameObject);

            return;
        }

        Debug.LogError("Object couldn't be dispawned as it wasn't found in the pool");
    }
}