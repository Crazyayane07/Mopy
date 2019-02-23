using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOP.View
{
    public class WindowView : MonoBehaviour2
    {
        private Vector3 beginnig;
        public float speed;
        public Transform target;
        private Vector3 targetPosition;

        private void Start()
        {
            beginnig = transform.position;
            targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            MinigameService.OnMinigameOver += SetUp;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }

        public void SetUp()
        {
            transform.position = beginnig;
            gameObject.SetActive(true);
        }
    }
}
