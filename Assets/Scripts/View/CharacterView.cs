using System;
using System.Collections;
using UnityEngine;

namespace MOP.View
{
    public class CharacterView : MonoBehaviour2
    {
        public GameObject blend;

        private float speed = 600f;
        private Vector2 destination;
        

        public void Move(Vector2 posision, Action onEnd)
        {
            destination = posision;
            blend.SetActive(true);
            StartCoroutine("MoveCoroutine", onEnd);
        }

        public IEnumerator MoveCoroutine(Action onEnd)
        {
            while (Vector2.Distance(gameObject.transform.position, destination) > 0.1f)
            {
                transform.position = Vector2.MoveTowards(transform.position, destination, speed * Time.deltaTime);
                yield return new WaitForSeconds(Time.deltaTime);
            }

            if (Vector2.Distance(gameObject.transform.position, destination) <= 0.1f)
            {
                blend.SetActive(false);
                onEnd?.Invoke();
            }                
        }
    }
}
