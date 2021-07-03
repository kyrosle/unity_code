public abstract class EnemyBaseState //模板化方法
{
    public abstract void EnterState(Enemy enemy);//进入
    public abstract void OnUpdate(Enemy enemy);//update
}
