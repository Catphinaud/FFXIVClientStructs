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

    // [FieldOffset(0x22)] public byte MaybeHasJobLevelFilter; // Need to relook this up what this is
    [FieldOffset(0x23)] public byte LevelMax; // Need to relookup which level input this dictates
    [FieldOffset(0x24)] public byte ArmorJob;

    [FieldOffset(0x28)] public Utf8String Query;
    //These seem to be only used when non partial matching, was a size of 20 before due to being mistaken for ItemSearchResult.History somehow
    [FieldOffset(0x90), FixedSizeArray] internal FixedSizeArray100<Entry> _entries;

    // [FieldOffset(0x3B0)] public uint MaybeNextPage;
    // [FieldOffset(0x3B4)] public ushort MaybeSomePage; // Very unsure
    [FieldOffset(0x3B8)] public uint MaxPerPage;
    [FieldOffset(0x3C0)] public byte isPushingItems;

    [StructLayout(LayoutKind.Explicit, Size = 0x8)]
    public struct Entry {
        [FieldOffset(0x0)] public uint ItemId;
        [FieldOffset(0x4)] public ushort Count; // Was mistakenly a uint hiding the Demand
        [FieldOffset(0x6)] public ushort Demand;
    }
}
