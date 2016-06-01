using UnityEngine;
using System.Collections;

public class PlayerGun : MonoBehaviour
{
    public Transform mFireLocation,mShootTowards;
    public float mShotForce, mShotTimer;
    float mLastShotTime;
    public ObjectPooler mBulletPool;

    GameObject tempBullet;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") > 0 && mLastShotTime < Time.time)
        {
           
            tempBullet = mBulletPool.GetReadyGameObjasGameObject();
            if(tempBullet != null)
            {
                mLastShotTime = mShotTimer + Time.time;
                tempBullet.GetComponent<BulletScript>().ShootTowards(mShootTowards, mFireLocation.position, mShotForce);
            }
        }

    }
}
