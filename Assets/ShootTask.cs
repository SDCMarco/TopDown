using BehaviorDesigner.Runtime.Tasks;

public class ShootTask : Action
{
    public override TaskStatus OnUpdate()
    {
        gameObject.GetComponent<Character>().CharacterStartShoot();
        return TaskStatus.Success;
    }

}
