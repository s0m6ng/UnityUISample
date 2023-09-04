public class Actor
{
    public int m_HP = 0;
    public int m_Attack = 0;

/*    public Actor(int hp, int attack)
    {
        m_HP = hp;
        m_Attack = attack;
    }*/
    public void SetDamage(int value)
    {
        m_HP -= value;
    }
    public void SetHeal(int value)
    {
        m_HP += value;
    }
}
