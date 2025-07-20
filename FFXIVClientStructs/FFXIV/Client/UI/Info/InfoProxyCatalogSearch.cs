using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info;

// Client::UI::Info::InfoProxyCatalogSearch
//   Client::UI::Info::InfoProxyPageInterface
//     Client::UI::Info::InfoProxyInterface
[InfoProxy(InfoProxyId.CatalogSearch)]
[GenerateInterop]
[Inherits<InfoProxyPageInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C8)]
public unsafe partial struct InfoProxyCatalogSearch {

    [FieldOffset(0x20)] public byte SearchingMode; // 0x14 if searching else 0xA
    [FieldOffset(0x21)] public byte ItemSearchCategory; // ItemSearchCategory.RowId
    [FieldOffset(0x22)] public bool HasMaxLevelFilter; // If the current category can be filtered by max level
    [FieldOffset(0x23)] public byte MaxLevel; // "Lv." input value, only updated upon actual search
    [FieldOffset(0x24)] public byte SelectedClassJob; // Job Dropdown (ClassJob.RowId), 0 is "All"

    [FieldOffset(0x28)] public Utf8String Query;
    // Non-partial search result entries, was a size of 20 before due to being mistaken for ItemSearchResult.History
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray100<Entry> _entries;

    // Indexes over the pages, will be larger than the normal (page * 100) if the server filtered items while filling the page
    // Example Category(Body) + Job(All) = 802 items, GLD + Lv <= 76 = 313 items; first page is 587 and next 689
    // ItemSearchCategory filtered items sorted by EquipmentSort take 100 GLD rows and count how many were iterated, thats NextPageIndex
    // Some Sorting, though seems different per category...
    //  - Equipment: (LevelEquip DESC, LevelItem.RowId DESC, Unknown4 ASC)
    //  - Seasonal: (LevelEquip DESC, Unknown4 ASC, ItemSortCategory.Param ASC)
    //  - Registrable: (LevelEquip DESC, ItemSortCategory.Param ASC, Unknown4 ASC)
    //  - Housing: (ItemSortCategory.Param ASC, LevelEquip DESC, Unknown4 ASC)
    [FieldOffset(0x3B0)] public uint PreviousPageIndex;
    [FieldOffset(0x3B4)] public uint NextPageIndex;

    [FieldOffset(0x3B8)] public uint MaxPerPage; // 100 only when the ItemSearch is open

    [FieldOffset(0x3BC)] public byte IsLoadingWishlist;
    [FieldOffset(0x3C0)] public byte isPushingItems;

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Entry {
        [FieldOffset(0x0)] public uint ItemId;
        [FieldOffset(0x4)] public ushort Count; // Was mistakenly a uint hiding the Demand
        [FieldOffset(0x6)] public ushort Demand;
    }
}
