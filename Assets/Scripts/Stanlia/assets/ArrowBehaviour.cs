using UnityEngine;
using System.Collections;

namespace Stanlia.assets{
	public class ArrowBehaviour : MonoBehaviour {
		public int speed = 6;
		// Use this for initialization
		void Start () {
			rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
		}
		
		// Update is called once per frame
		void Update () {
		
		}
	}
}