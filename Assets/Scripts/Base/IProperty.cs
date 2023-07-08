namespace Property
{
    public interface IProperty <T, V>
    {
        T Value { get; set; }
        V GetType();
    }

    public enum EProperty
    {
        Health_Point,
        Health_Point_Max,
        Mana_Point,
        Mana_Point_Max,
        Attack_Power,
        Attack_Speed,
        Defense_Amount,
        Move_Speed,
        Move_Speed_Default
    }

    public enum EOperator
    {
        Plus,
        Minus,
        Mutiply,
        Divide
    }
}