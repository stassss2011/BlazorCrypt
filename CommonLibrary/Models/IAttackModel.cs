namespace CommonLibrary.Models;

public interface IAttackModel
{
    public int MaxKeyLen { get; set; }
    public string Text { get; set; }

    public string Attack();

    public void Reset();

}