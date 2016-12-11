﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float lifetime = 1;
	public Vector2 direction = Vector2.right;
	public float speed;

	[HideInInspector]
	public GameObject source;

	void Start () {

	}

	void Update () {
		if (lifetime < -1f)
			return;

		if (lifetime <= 0f) {
			Destroy(gameObject);
		}

		lifetime -= Time.deltaTime;
		GetComponent<Rigidbody2D> ().velocity = direction * speed * Time.deltaTime;
		//transform.Translate (direction * speed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter2D(Collider2D target) {
		if (target.gameObject.CompareTag ("Enemy")) {
			return;
		}

		if (target.gameObject.CompareTag ("Player")) {
			target.GetComponent<Health> ().hp--;
		}

		Destroy (gameObject);
	}

	/*public virtual void Spawn(Transform trans, Vector3 offset, float speed, GameObject src) {
		Vector3 shift = trans.rotation * offset;

		Projectile clone = Instantiate(this, trans.position + shift, trans.rotation);
		clone.GetComponent<Rigidbody2D>().AddForce(trans.rotation * Vector3.up * speed);
		source = src;
		clone.transform.parent = source.transform;
	}*/
}