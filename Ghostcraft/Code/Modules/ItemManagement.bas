Attribute VB_Name = "ItemManagement"
Option Explicit
Option Base 1

Public Items_Collection As tItem_Collection

Public Function ITEMS_GetRecordNumber(ItemGUID As tGUID) As Long
    Dim i As Long

    For i = 1 To Items_Collection.Count
        If CompareGUIDs(Items_Collection.Items(i).ItemID, ItemGUID) Then
            ITEMS_GetRecordNumber = i
            Exit Function
        End If
    Next i

    ITEMS_GetRecordNumber = -1
End Function

Public Function CreateNewItem() As tGUID
    Dim tmpGUID As tGUID

    tmpGUID = CreateNewGUID(Object_Item)

    With Items_Collection
        .Count = .Count + 1
        ReDim Preserve .Items(.Count)
        With .Items(.Count)
            .ItemID = tmpGUID
            .Class = 2
            .SubClass = 7
            .DisplayID = &H606
            .BuyPrice = 1
            .SellPrice = 1
            .Description = "Badaboom!"
            .DisplayName(1) = "Shortsword"
            .DisplayName(2) = "Shortsword"
            .DisplayName(3) = "Shortsword"
            .DisplayName(4) = "Shortsword"
        End With
    End With
    CreateNewItem = tmpGUID
End Function

Public Sub ItemManagement_AddItemToCollection(GUID As tGUID)
    Dim tmpUpdateList As tUpdateFields
    Dim tmpRecordNumber As Long, i As Long

    If CompareGUIDs(GUID, CombineToGUID(0, 0)) Then Exit Sub

    tmpRecordNumber = ITEMS_GetRecordNumber(GUID)

    Object_Item_Collection.Count = Object_Item_Collection.Count + 1
    ReDim Preserve Object_Item_Collection.Objects(Object_Item_Collection.Count)

    With Object_Item_Collection.Objects(Object_Item_Collection.Count)
        With .Base
            .f000_GUID = GUID
            .f002_TYPE = Object_Item
            .f003_ENTRY = 25
        End With

        With .Item
            .f006_OWNER_GUID = GUID
            .f010_CREATOR_GUID = GUID
            .f041_PROPERTY_SEED = 1
            .f042_RANDOM_PROPERTIES_ID = 1
        End With
    End With

    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 0, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 1, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 2, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 3, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 6, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 7, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 10, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 11, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 41, False
    AddUpdateFieldToTemporaryUpdateList tmpUpdateList, 42, False

    AddUpdateFields GUID, tmpUpdateList
End Sub
