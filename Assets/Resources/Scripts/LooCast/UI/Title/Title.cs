using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LooCast.UI.Title
{
    public class Title : MonoBehaviour
    {
        private Animator animator;
        [SerializeField]
        private float syncBPM = 83.0f;

        private void Start()
        {
            animator = GetComponent<Animator>();
            animator.speed = syncBPM / 120.0f;
        }
    } 
}
