using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Info;
using static FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentItemSearch
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
[Agent(AgentId.ItemSearch)]
[GenerateInterop]
[Inherits<AgentInterface>, Inherits<ChangeEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3888)]
public unsafe partial struct AgentItemSearch {
    [FieldOffset(0x90)] public InfoProxyItemSearch* InfoProxyItemSearch;
    [FieldOffset(0x98), Obsolete("Use InfoProxyCatalogSearch.Query")] public StringHolder* StringData;
    [FieldOffset(0x98)] public InfoProxyCatalogSearch* InfoProxyCatalogSearch;

    // [FieldOffset(0xA2C), FixedSizeArray] internal FixedSizeArray100<uint> _unkUints;
    [FieldOffset(0xA29)] public bool ListingPageLoaded;
    [FieldOffset(0xBBC), FixedSizeArray] internal FixedSizeArray100<uint> _listingPageItemIds;

    [FieldOffset(0xD4C)] public uint ListingPageShownItemCount; // Only what is actually shown, unobtained filtered

    [FieldOffset(0xD50)] public uint ListingPageItemCount;
    [FieldOffset(0xD58), FixedSizeArray] internal FixedSizeArray100<ListingItem> _listingPageItems;

    [FieldOffset(0x19D8)] public byte _unknownByte;
    [FieldOffset(0x19D9), FixedSizeArray] internal FixedSizeArray100<byte> _filteredItemIdIndexes;
    [FieldOffset(0x1A40)] public byte FilteredItemIdIndexCount;

    // Both this and JobDropDowns shift the entire struct upon new ClassJobs
    // [FieldOffset(0x1A46), FixedSizeArray] internal FixedSizeArray43<byte> _mainArmsLevels;
    [FieldOffset(0x1AA0)] public byte SelectedMainArmClassJob;
    [FieldOffset(0x1AA2)] public ushort unk_6F;
    [FieldOffset(0x1AA4)] public ushort ClassJobCount;
    // [FieldOffset(0x1AA8), FixedSizeArray] internal FixedSizeArray43<JobDropdownItem> _jobDropDowns;

    [FieldOffset(0x3128)] public byte ListingCurrentPage;
    [FieldOffset(0x3129)] public byte ListingPageCount;
    [FieldOffset(0x338C)] public uint ResultItemId;
    [FieldOffset(0x3394)] public uint ResultSelectedIndex;
    [FieldOffset(0x33A0)] public InventoryItem ResultHoveredItem;

    // [FieldOffset(0x370C), FixedSizeArray] internal FixedSizeArray50<ushort> _sortingStuff; // Todo try figure out what this was for again
    [FieldOffset(0x3770)] public ushort SortingDropdownCount;

    [FieldOffset(0x3868)] public uint* ItemBuffer;
    [FieldOffset(0x3870)] public uint ItemCount;

    [FieldOffset(0x3878)] public byte _unknownByte3;
    [FieldOffset(0x387B)] public byte IsResultsFromPartialSearch;

    [FieldOffset(0x387C)] public bool IsPartialSearching;
    [FieldOffset(0x387D)] public bool IsItemPushPending;

    [FieldOffset(0x387F)] public byte ItemBufferIsForFavorites;
    [FieldOffset(0x3880)] public byte IsFilteringUnobtained;
    [FieldOffset(0x3881)] public byte CanFilterUnobtained;

    [StructLayout(LayoutKind.Explicit, Size = 0x98)]
    public struct StringHolder {
        // [FieldOffset(0x10)] private int Unk90Size;
        [FieldOffset(0x28)] public Utf8String SearchParam;
        // [FieldOffset(0x90)] private nint Unk90Ptr;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct ListingItem {
        [FieldOffset(0x08)] public uint ItemId;

        [FieldOffset(0x18)] public ushort Index;
        [FieldOffset(0x1A)] public ushort OfferCount;
        [FieldOffset(0x1C)] public ushort Demand;
    }
}
