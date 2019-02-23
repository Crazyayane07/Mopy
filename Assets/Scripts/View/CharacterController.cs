using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.View
{
    public class CharacterController : MonoBehaviour2
    {
        private Vector3 setup;

        private float upForce = 400f;
        private Rigidbody2D rgb2d;

        private void Start()
        {
            setup = transform.position;
            rgb2d = GetComponent<Rigidbody2D>();

            MinigameService.OnMinigameOver += Subscribe;
        }
        
        void Update()
        {
            if(Input.GetKeyDown("space"))
            {
                rgb2d.AddForce(new Vector2(0, upForce));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Death"))
            {
                MinigameService.MinigameOver();
            }
            else if (collision.gameObject.tag.Equals("Wall"))
            {
                Debug.Log("XD");
                MinigameService.MinigameWon();
            }
        }

        private void Subscribe()
        {
            transform.position = setup;
        }
    }
}
