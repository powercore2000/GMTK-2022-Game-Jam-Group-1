using System.Collections;
using UnityEngine;
using TurnSystem;



namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        public TurnSystem.TurnSystem turnSystem = new TurnSystem.TurnSystem();

        private bool isMoving;
        private Entity player;
        void Start()
        {
<<<<<<< HEAD
            
            player = GetComponent<Player>();  
=======
            player = GetComponent<Entity>();  
>>>>>>> 4228d669b94869d4f53ba9ef996dfb5e08b793b8
        }

        public void Move(Vector2 newPos)
        {

            if(isMoving) return;
            StartCoroutine(MoveRoutine(newPos));
        
        }

        // will apply some smoothing, for now just raw and simple movement
        private IEnumerator MoveRoutine(Vector2 newPos)
        {
            turnSystem.StartEnemyCoroutine();
            Debug.Log("Should start enemy");
            isMoving = true;
            Vector2 currrentPos = gameObject.transform.position;
            float time = 0;
            while ((currrentPos - newPos).magnitude > 0.01f)
            {
                var dir = (newPos - currrentPos).normalized;
                var displacement =  speed * Time.deltaTime * dir;
                var moveAmount =  displacement + currrentPos;
                transform.position = moveAmount;
                currrentPos = transform.position;
                yield return null;
            }
            isMoving = false;

            turnSystem.HasMoved();
        }
    }
}
