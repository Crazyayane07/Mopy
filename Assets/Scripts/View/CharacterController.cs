using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.View
{
    public class CharacterController : MonoBehaviour2
    {
        public float upForce = 5f;
        private Rigidbody2D rgb2d;

        private void Start()
        {
            rgb2d = GetComponent<Rigidbody2D>();
        }
        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown("space"))
            {
                rgb2d.AddForce(new Vector2(0, upForce));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag.Equals("Death"))
            {
                Debug.Log("died");
            }
        }
    }
}
