using UnityEngine;
using System.Collections;

namespace LudumDare36 {
    [RequireComponent(typeof(Prime31.CharacterController2D))]

    public class Player : MonoBehaviour {

        private float moveSpeed = 15;
        private float jumpSpeed = 35;
        private float gravity = -50f;

        private Prime31.CharacterController2D cc;
        private Vector3 velocity = Vector3.zero;
        public Vector3 Velocity { get { return velocity; } }
        private bool isJumping = false;

        private float sceneLoadOffset = 1;
        
        public void MoveToScreen(GameScreen newScreen) {
            Vector3 offset = transform.localPosition;
            
            // flip us on the left-right sides of the screen
            offset.x = -offset.x;
            if (offset.x > 0) {
                offset.x -= sceneLoadOffset;
            } else {
                offset.x += sceneLoadOffset;
            }
            transform.parent = newScreen.transform;
            transform.localPosition = offset;
        }

        #region Unity callbacks
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
        #endregion
    }
}