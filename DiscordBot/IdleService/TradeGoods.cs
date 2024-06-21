using Discord.Interactions;

namespace DiscordBot.IdleService;

public enum TradeGoods
{
    [ChoiceDisplay("Common Electronics")]
    CommonElectronics,

    [ChoiceDisplay("Common Industrial Goods")]
    CommonIndustrialGoods,

    [ChoiceDisplay("Common Manufactured Goods")]
    CommonManufacturedGoods,

    [ChoiceDisplay("Common Raw Materials")]
    CommonRawMaterials,

    [ChoiceDisplay("Common Consumables")]
    CommonConsumables,

    [ChoiceDisplay("Common Ore")]
    CommonOre,

    [ChoiceDisplay("Advanced Electronics")]
    AdvancedElectronics,

    [ChoiceDisplay("Advanced Machine Parts")]
    AdvancedMachineParts,

    [ChoiceDisplay("Advanced Manufactured Goods")]
    AdvancedManufacturedGoods,

    [ChoiceDisplay("Advanced Vehicles")]
    AdvancedVehicles,

    [ChoiceDisplay("Advanced Weapons")]
    AdvancedWeapons,

    [ChoiceDisplay("Biochemicals")]
    Biochemicals,

    [ChoiceDisplay("Crystals & Gems")]
    CrystalsAndGems,

    [ChoiceDisplay("Cybernetics")]
    Cybernetics,

    [ChoiceDisplay("Live Animals")]
    LiveAnimals,

    //[ChoiceDisplay("Luxury Consumables")]
    //LuxuryConsumables,

    [ChoiceDisplay("Luxury Goods")]
    LuxuryGoods,

    [ChoiceDisplay("Medical Supplies")]
    MedicalSupplies,

    [ChoiceDisplay("Petrochemicals")]
    Petrochemicals,

    [ChoiceDisplay("Pharmaceuticals")]
    Pharmaceuticals,

    [ChoiceDisplay("Polymers")]
    Polymers,

    [ChoiceDisplay("Precious Metals")]
    PreciousMetals,

    [ChoiceDisplay("Radioactives")]
    Radioactives,

    [ChoiceDisplay("Robots")]
    Robots,

    [ChoiceDisplay("Spices")]
    Spices,

    [ChoiceDisplay("Textiles")]
    Textiles,
    /*
    [ChoiceDisplay("Uncommon Ore")]
    UncommonOre,

    [ChoiceDisplay("Uncommon Raw Materials")]
    UncommonRawMaterials,
    
    [ChoiceDisplay("Vehicles")]
    Vehicles,

    [ChoiceDisplay("Wood")]
    Wood,

    [ChoiceDisplay("Illegal Biochemicals")]
    IllegalBiochemicals,

    [ChoiceDisplay("Illegal Cybernetics")]
    IllegalCybernetics,

    [ChoiceDisplay("Illegal Drugs")]
    IllegalDrugs,

    [ChoiceDisplay("Illegal Luxuries")]
    IllegalLuxuries,

    [ChoiceDisplay("Illegal Weapons")]
    IllegalWeapons,
    */
}
