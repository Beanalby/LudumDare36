using UnityEngine;
using System.Collections;

namespace LudumDare36 {
    [RequireComponent(typeof(Prime31.CharacterController2D))]

    public class Player : MonoBehaviour {
        private float moveSpeed = 15;
        private float jumpSpeed = 35;
        private float gravity = -50f;

        private Prime31.CharacterController2D cc;
        private Vector3 velocity;
        private bool isJumping = false;

        public void Start() {
            cc = GetComponent<Prime31.CharacterController2D>();
        }

        public void Update() {
            if (cc.isGrounded && Input.GetButton("Jump")) {
                isJumping = true;
            }
        }
        public void FixedUpdate() {
            velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            if (cc.isGrounded) {
                if (isJumping) {
                    velocity.y = jumpSpeed;
                    isJumping = false;
                } else {
                    velocity.y = 0;
                }
            } else {
                velocity += new Vector3(0, gravity * Time.deltaTime, 0);
            }
            cc.move(velocity * Time.deltaTime);
        }
    }
}