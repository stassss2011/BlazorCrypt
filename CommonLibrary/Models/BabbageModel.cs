using CommonLibrary.Attacks;
using CommonLibrary.Attacks.Defaults;

namespace CommonLibrary.Models;

public class BabbageModel : IAttackModel
{
    private BabbageAttack? _attack;

    public BabbageModel()
    {
        Text = "";
        MaxKeyLen = BabbageAttackDefaults.MaxKeyLenght;
    }

    public int MaxKeyLen { get; set; }
    public string Text { get; set; }

    public string Attack()
    {
        CheckAttack();
        return _attack?.ForceDecrypt(Text) ?? throw new NullReferenceException();
    }

    public void Reset()
    {
        MaxKeyLen = BabbageAttackDefaults.MaxKeyLenght;
        Text = "";
    }

    private void CheckAttack()
    {
        _attack ??= new BabbageAttack(MaxKeyLen);
        if (_attack?.MaxKeyLenght != MaxKeyLen)
            _attack = new BabbageAttack(MaxKeyLen);
    }
}