using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPooler : MonoBehaviour
{
    public string Description;
    public GameObject mObjectToPool;
    public int mNumofObjsToPool;
   
    GameObject[] mPoolofObjects;
    // Use this for initialization
    void Start()
    {
        mPoolofObjects = new GameObject[mNumofObjsToPool];
        for (int count = 0; count < mNumofObjsToPool; count++)
        {
            mPoolofObjects[count] = Instantiate(mObjectToPool) as GameObject;
            mPoolofObjects[count].SetActive(false);
        }
    }

    

    public GameObject GetReadyGameObjasGameObject()
    {
        for (int count = 0; count < mNumofObjsToPool; count++)
        {
            if (mPoolofObjects[count].activeInHierarchy)
            {
                mPoolofObjects[count].SetActive(true);
                return mPoolofObjects[count];
            }
        }
        return null;
    }
    public Comp GetReadyGameObjasCompnent<Comp>()
    {
        for (int count = 0; count < mNumofObjsToPool; count++)
        {
            if (mPoolofObjects[count].activeInHierarchy)
            {
                mPoolofObjects[count].SetActive(true);
                return mPoolofObjects[count].GetComponent<Comp>();
            }
        }
        return default(Comp);
    }
}
