using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.View
{
    public class MinigameBackgroundView : MonoBehaviour2
    {
        private Vector2 beginnig;
        public float speed;
        private Vector2 targetPosition;


        void Start()
        {
            beginnig = transform.position;
            MinigameService.OnMinigameOver += SetUp;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector2.left*speed*Time.deltaTime);
        }

        private void SetUp()
        {
            transform.position = beginnig;
        }
    }
}
