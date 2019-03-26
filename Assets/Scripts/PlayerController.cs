using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float force;
	private int count;
    private Rigidbody rb;
	[SerializeField]
	private Text countText;

	[SerializeField]
	private Text winText;
	private int numberOfCubes;
    // Start is called before the first frame update
    void Start()
    {
		this.count = 0;
        this.rb = GetComponent<Rigidbody>();
		this.countText.text = "Count= " + this.count;
		this.winText.text = "";
		this.numberOfCubes = GameObject.FindGameObjectsWithTag("Pick Up").Length;
    }

    // Update is called once per frame
    void Update()
    {        
    }

    private void FixedUpdate()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(horizontal, 0, vertical) * force);
    }

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Pick Up"))
		{
			Destroy(other.gameObject);
			count ++;
			this.countText.text = "Count= " + this.count;

			if(count == this.numberOfCubes)
				this.winText.text = "You won!!!";
		}
	}
}
