using UnityEngine;

public interface ISpell{
    string Name { get; set; }
    GameObject Effect { get; set; }
    //RarityTypes Rarity { get; set; }
    bool LineOfSight { get; set; }

    float BaseCoolDownTime { get; set; }
    float CoolDownVariance { get; set; }
    float CoolDownTimer { get; }
    bool OnCoolDown { get; }

    void Cast();
    void Update();


}