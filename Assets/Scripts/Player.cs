using UnityEngine;
using System.Collections;

namespace LudumDare36 {
    [RequireComponent(typeof(Prime31.CharacterController2D))]

    public class Player : MonoBehaviour {

        private float moveSpeed = 15;
        private float jumpSpeed = 35;
        private float gravity = -50f;
        private float sceneLoadOffset = 1;

        public Investigatable couldInvestigate = null;
        public Investigatable currentlyInvestigating = null;

        private Prime31.CharacterController2D cc;
        private Vector3 velocity = Vector3.zero;
        public Vector3 Velocity { get { return velocity; } }
        private bool isJumping = false;

        public bool CanControl {
            get {
                return currentlyInvestigating == null;
            }
        }
        
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

        public void SetCanInvestigate(Investigatable obj) {
            couldInvestigate = obj;
        }
        public void ClearCanInvestigate(Investigatable obj) {
            if (couldInvestigate = obj) {
                couldInvestigate = null;
            }
        }

        #region Unity callbacks
        public void Start() {
            cc = GetComponent<Prime31.CharacterController2D>();
        }

        public void Update() {
            if (Input.GetButtonDown("Jump")) {
                if (currentlyInvestigating) {
                    GameState.Instance.SendMessage("HideDialog");
                    currentlyInvestigating = null;
                } else {
                    if (couldInvestigate != null) {
                        currentlyInvestigating = couldInvestigate;
                        GameState.Instance.SendMessage("ShowDialog",
                            currentlyInvestigating);
                    } else {
                        if (cc.isGrounded) {
                            isJumping = true;
                        }
                    }
                }
            }
        }
        public void FixedUpdate() {

            if (CanControl) {
                velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
            } else {
                velocity.x = 0;
            }
            if (cc.isGrounded) {
                if (isJumping && CanControl) {
                    velocity.y = jumpSpeed;
                    isJumping = false;
                } else {
                    // set y velocity to a token value to keep it grounded
                   velocity.y = gravity * Time.deltaTime;
                }
            } else {
                velocity += new Vector3(0, gravity * Time.deltaTime, 0);
            }
            cc.move(velocity * Time.deltaTime);
        }
        #endregion
    }
}