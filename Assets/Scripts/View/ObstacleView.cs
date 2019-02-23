using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.View {
    public class ObstacleView : MonoBehaviour2
    {
        private Vector2 beginnig;
        public float speed;
        public Transform target;
        private Vector2 targetPosition;

        private void Start()
        {
            beginnig = transform.position;
            targetPosition = new Vector2(target.position.x, transform.position.y);
            MinigameService.OnMinigameOver += SetUp;
        }

        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        public void SetUp()
        {
            transform.position = beginnig;
            gameObject.SetActive(true);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag.Equals("Wall"))
            {
                gameObject.SetActive(false);
            }
        }
    }
}
