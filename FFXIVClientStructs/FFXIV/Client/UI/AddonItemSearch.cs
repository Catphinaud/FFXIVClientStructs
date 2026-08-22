using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonItemSearch
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
// ctor "48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 57 48 83 EC 20 48 8B D9 E8 ?? ?? ?? ?? 33 ED 48 8D 05 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? 48 89 03 48 89 AB"
[Addon("ItemSearch")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x4050)]
public unsafe partial struct AddonItemSearch {
    [FieldOffset(0x238)] public AtkComponentRadioButton* CurrentFilterButton;

    [FieldOffset(0x240)] public AtkCollisionNode* CurrentCollisionNode; // Temporarily added to fix some reversing

    [FieldOffset(0x248)] public SearchMode Mode;
    [FieldOffset(0x24C)] public int SelectedFilter;

    [FieldOffset(0x250)] public Utf8String SearchText;
    [FieldOffset(0x2B8)] public Utf8String SearchText2;

    [FieldOffset(0x320)] private Utf8String ResultsMiddleText;
    [FieldOffset(0x388)] private Utf8String SortingTooltip;
    [FieldOffset(0x3F0)] private Utf8String NextButtonTooltip;
    [FieldOffset(0x458)] private Utf8String PreviousButtonTooltip;

    [FieldOffset(0x4C0), FixedSizeArray] internal FixedSizeArray99<Utf8String> _filterLabels;

    [FieldOffset(0x2F00)] public AtkComponentTextInput* SearchTextInput;
    [FieldOffset(0x2F08)] public AtkComponentButton* SearchButton;

    [FieldOffset(0x2F10)] public AtkComponentButton* WishlistButton;

    [FieldOffset(0x2F18)] public AtkComponentNumericInput* ArmsLvInput;
    [FieldOffset(0x2F20)] public AtkComponentNumericInput* ArmorLvInput;
    [FieldOffset(0x2F28)] public AtkComponentDropDownList* ArmorJobDropdown;

    [FieldOffset(0x2F30)] public AtkComponentList* ResultsList;

    [FieldOffset(0x2F38)] public AtkComponentCheckBox* SortingDropdownCheckbox;
    [FieldOffset(0x2F40)] public AtkComponentDropDownList* SortingDropdown;

    [FieldOffset(0x2F48)] public AtkTextNode* ResultsMiddleTextNode;

    [FieldOffset(0x2F50)] public AtkComponentButton* NextPageButton;
    [FieldOffset(0x2F58)] public AtkComponentButton* PreviousPageButton;

    [FieldOffset(0x3380)] public AtkComponentCheckBox* PartialSearchCheckBox;

    [FieldOffset(0x3388)] public AtkTextNode* ResultsHeaderTextNode;
    [FieldOffset(0x3398)] public AtkImageNode* ResultsIconNode;
    [FieldOffset(0x33A0)] public AtkTextNode* PaginationTextNode;

    [FieldOffset(0x33B0)] public AtkComponentButton* FavoritesButton;

    [FieldOffset(0x33B8)] public AtkComponentCheckBox* FilterUnobtainedCheckbox;

    [FieldOffset(0x404B)] public bool PartialMatch;
    [FieldOffset(0x404C)] public bool CanFilterUnobtained;

    /**
     * @todo Hold onto the way filters are actually set up in
     * Sig: 48 85 D2 0F 84 ?? ?? ?? ?? 48 8B C4 44 89 48
     * AddonItemSearch.SetupFilterRadioBoxes(AddonItemSearch* addon, AtkValue* values, int categoryIndex, uint firstNodeId, int lastNodeId, int sheetCategory)
     *   AddonItemSearch.SetupFilterRadioBoxes(this,values,0,11,43,1);
     *   AddonItemSearch.SetupFilterRadioBoxes(this,values,1,52,61,2);
     *   AddonItemSearch.SetupFilterRadioBoxes(this,values,2,71,100,3);
     *   AddonItemSearch.SetupFilterRadioBoxes(this,values,3,104,123,4);
     */

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D AC 24")]
    public partial void RunSearch(bool ignoreFilters = false);

    [MemberFunction("E8 ?? ?? ?? ?? EB 41 41 8D 40 FD")]
    public partial void SetModeFilter(SearchMode mode, int filter);

    public enum SearchMode : uint {
        Normal = 0,
        ArmsFilter = 1,
        EquipmentFilter = 2,
        ItemsFilter = 3,
        HousingFilter = 4,
        Wishlist = 5,
        Favorites = 6,
        Unset = 7
    }
}
