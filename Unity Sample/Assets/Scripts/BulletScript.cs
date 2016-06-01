using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public Rigidbody mrig;
    public string nonTarget;
	// Use this for initialization
	void Start () {

        if (mrig == null)
        {
            mrig = gameObject.GetComponent<Rigidbody>();
        }
        Invoke("StopBullet", 2.0f);

    }
	public void ShootTowards(Transform _Targetpos,Vector3 _StartPos, float _force)
    {
        transform.position = _StartPos;
        transform.LookAt(_Targetpos);
        mrig.AddForce(transform.forward.normalized * _force);
    }
	void StopBullet()
    {
        if(IsInvoking("StopBullet"))
        {
            CancelInvoke("StopBullet");
        }
        gameObject.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
       if(!other.CompareTag(nonTarget))
        {
            StopBullet();
            other.gameObject.SendMessage("TakeHit", SendMessageOptions.DontRequireReceiver);
        }
    }
}
