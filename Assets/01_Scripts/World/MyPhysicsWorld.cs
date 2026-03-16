using UnityEngine;
using UnityEngine.LowLevelPhysics2D;

/// <summary>
/// PhysicsWorld 사용법
/// 
/// Body 생성
/// CreateBody(PhysicsBodyDefinition def) : PhysicsBody
/// MyPhysicsWorld.Instance.World.CreateBody(def)
/// 
/// Shape 생성
/// CreateShape(Geometry geometry, PhysicsShapeDefinition shapeDef) : void
/// PhysicsBody body = _world.CreateBody(bodyDef);
/// body.CreateShape(geometry, shapeDef);
/// 
/// 
/// Box Shape 생성
/// groundBody.CreateShape(
///     PolygonGeometry.CreateBox(
///         size: new Vector2(x: width, y: height),
///         radius: 0f,
///         transform: new PhysicsTransform(
///             position: new Vector2(x: x좌표, y: y좌표),
///             rotation: PhysicsRotate.identity
///         ),
///     PhysicsShapeDefinition.defaultDefinition)
/// );
/// 
/// 
/// 
/// </summary>
public class MyPhysicsWorld : MonoBehaviour
{
    public static MyPhysicsWorld Instance { get; private set; }

    private PhysicsWorld _world;
    public PhysicsWorld World => _world;

    //[SerializeField] private PhysicsLowLevelSettings2D settings;
    [SerializeField] private bool simulateInFixedUpdate = true;

    [SerializeField] private PhysicsShapeDefinition shapeDef;
    [SerializeField] private PhysicsBodyDefinition bodyDef;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        CreateWorld();
    }

    private void FixedUpdate()
    {
        if (!simulateInFixedUpdate) return;

        Simulate(Time.fixedDeltaTime);
    }
    private void CreateWorld()
    {
        _world = PhysicsWorld.defaultWorld;
    }
    public void Simulate(float deltaTime)
    {
        _world.Simulate(deltaTime);
    }
}