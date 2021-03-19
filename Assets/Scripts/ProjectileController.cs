using UnityEngine;

public delegate void OutOfBoundsHandler();

public class ProjectileController : MonoBehaviour
{
    #region Field Declarations

    public Vector2 projectileDirection;
    public float projectileSpeed;
    public bool isPlayers;

    #endregion
    
    //public event OutOfBoundsHandler ProjectileOutOfBounds;

    #region Movement

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);

        if (ScreenBounds.OutOfBounds(transform.position))
        {
            if (isPlayers == true)
            {
                // 1
                //PlayerController playerShip = FindObjectOfType<PlayerController>();
                //playerShip.EnableProjectile();
                
                // 2
                // if (ProjectileOutOfBounds != null)
                // {
                //     ProjectileOutOfBounds();
                //     //СПИСОК ПОДПИСАННЫХ НА СОБЫТИЕ МЕТОДОВ
                //     // var observers = ProjectileOutOfBounds.GetInvocationList();
                //     // foreach (var observer in observers)
                //     // {
                //     //     print(observer.Method);
                //     // }
                // }
                
                // 3
                EventBroker.CallProjectileOutOfBounds();
            }
            Destroy(gameObject);
        }
    }

    #endregion
}
