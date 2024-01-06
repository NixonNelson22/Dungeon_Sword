using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject EnemyLookat;
    Vector3 reference;
    Animator animator;
    void Start()
    {
	animator = GetComponent<Animator>();   
        reference = reference.normalized *10;
    }

    // Update is called once per frame
    void Update()
    {
	RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down),out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            transform.position = new Vector3( hit.point.x , hit.point.y + 1f, hit.point.z );
        } 

	while(true)
	{

	}
    }
    private void OnCollisionEnter(Collision collision)
    {
	    //do something
	    //destroy object 
	foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.red);
	    if(contact.otherCollider.name != "Terrain")
	    {
		    Death();
	    }
        }

    }
    IEnumerator Death()
    {
	    yield return new WaitForSeconds(2f);
		animator.Play("death");
	    	Destroy(gameObject,1f);
    }
}
