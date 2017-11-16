' This file contains predefined race and class initialisations,
' server calls race and class init functions on creating character.
'
'Last  update: 12.04.2007


Imports System
Imports Microsoft.VisualBasic
Imports vbWoW.WorldServer

Namespace Scripts
	Public Module CharacterCreation

        Public Sub StartOther(ByRef c As CharacterObject)
            If c.Access > WS_Commands.AccessLevel.GameMaster Then c.Copper = 10000 Else c.Copper = 100
            c.XP = 0
            c.ActionButtons(CType(0, Byte)) = New TActionButton(&H19CB, 0, 0)
        End Sub

        Public Sub StartItems(ByRef c As CharacterObject)
            c.ItemADD(6948, 0, INVENTORY_SLOT_ITEM_1)           'Hearthstone

            'Gift Vouchers
            'c.ItemADD(14646, 0, INVENTORY_SLOT_ITEM_16)      'Northshire Gift Voucher - Human
            'c.ItemADD(14648, 0, INVENTORY_SLOT_ITEM_16)      'Shadowglen Gift Voucher - Elf
            'c.ItemADD(14647, 0, INVENTORY_SLOT_ITEM_16)      'Coldridge Valley Gift Voucher - Dwarf Gnome
            'c.ItemADD(14651, 0, INVENTORY_SLOT_ITEM_16)      'Deathknell Gift Voucher - Undead
            'c.ItemADD(14650, 0, INVENTORY_SLOT_ITEM_16)      'Camp Narache Gift Voucher - Tauren
            'c.ItemADD(14649, 0, INVENTORY_SLOT_ITEM_16)      'Valley of Trials Gift Voucher - Orc Troll
            'c.ItemADD(22888, 0, INVENTORY_SLOT_ITEM_16)      'Ammen Vale Gift Voucher - Draenei
            'c.ItemADD(20938, 0, INVENTORY_SLOT_ITEM_16)      'Sunstrider Isle Gift Voucher - Blood Elf

            'WARRIOR **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(38, 0, EQUIPMENT_SLOT_BODY)           'Recruit's Shirt
                c.ItemADD(39, 0, EQUIPMENT_SLOT_LEGS)           'Recruit's Pants
                c.ItemADD(40, 0, EQUIPMENT_SLOT_FEET)           'Recruit's Boots
                c.ItemADD(25, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Sword
                c.ItemADD(2362, 0, EQUIPMENT_SLOT_OFFHAND)      'Worn Wooden Shield
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_NIGHT_ELF AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(6120, 0, EQUIPMENT_SLOT_BODY)         'Recruit's Shirt
                c.ItemADD(6121, 0, EQUIPMENT_SLOT_LEGS)         'Recruit's Pants
                c.ItemADD(6122, 0, EQUIPMENT_SLOT_FEET)         'Recruit's Boots
                c.ItemADD(25, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Sword
                c.ItemADD(2362, 0, EQUIPMENT_SLOT_OFFHAND)      'Worn Wooden Shield
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_DWARF AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(38, 0, EQUIPMENT_SLOT_BODY)           'Recruit's Shirt
                c.ItemADD(39, 0, EQUIPMENT_SLOT_LEGS)           'Recruit's Pants
                c.ItemADD(40, 0, EQUIPMENT_SLOT_FEET)           'Recruit's Boots
                c.ItemADD(12282, 0, EQUIPMENT_SLOT_MAINHAND)    'Worn Battleaxe
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_GNOME AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(38, 0, EQUIPMENT_SLOT_BODY)           'Recruit's Shirt
                c.ItemADD(39, 0, EQUIPMENT_SLOT_LEGS)           'Recruit's Pants
                c.ItemADD(40, 0, EQUIPMENT_SLOT_FEET)           'Recruit's Boots
                c.ItemADD(25, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Sword
                c.ItemADD(2362, 0, EQUIPMENT_SLOT_OFFHAND)      'Worn Wooden Shield
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_UNDEAD AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(6125, 0, EQUIPMENT_SLOT_BODY)         'Brawler's Harness
                c.ItemADD(139, 0, EQUIPMENT_SLOT_LEGS)          'Brawler's Pants
                c.ItemADD(140, 0, EQUIPMENT_SLOT_FEET)          'Brawler's Boots
                c.ItemADD(25, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Sword
                c.ItemADD(2362, 0, EQUIPMENT_SLOT_OFFHAND)      'Worn Wooden Shield
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_2, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_ORC AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(6125, 0, EQUIPMENT_SLOT_BODY)         'Brawler's Harness
                c.ItemADD(139, 0, EQUIPMENT_SLOT_LEGS)          'Brawler's Pants
                c.ItemADD(140, 0, EQUIPMENT_SLOT_FEET)          'Brawler's Boots
                c.ItemADD(12282, 0, EQUIPMENT_SLOT_MAINHAND)    'Worn Battleaxe
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(6125, 0, EQUIPMENT_SLOT_BODY)         'Brawler's Harness
                c.ItemADD(139, 0, EQUIPMENT_SLOT_LEGS)          'Brawler's Pants
                c.ItemADD(140, 0, EQUIPMENT_SLOT_FEET)          'Brawler's Boots
                c.ItemADD(37, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Axe
                c.ItemADD(2362, 0, EQUIPMENT_SLOT_OFFHAND)      'Worn Wooden Shield
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_TAUREN AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(6125, 0, EQUIPMENT_SLOT_BODY)         'Brawler's Harness
                c.ItemADD(139, 0, EQUIPMENT_SLOT_LEGS)          'Brawler's Pants
                c.ItemADD(140, 0, EQUIPMENT_SLOT_FEET)          'Brawler's Boots
                c.ItemADD(2361, 0, EQUIPMENT_SLOT_MAINHAND)     'Battleworn Hammer
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_2, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_WARRIOR Then
                c.ItemADD(23473, 0, EQUIPMENT_SLOT_BODY)        'Recruit's Shirt
                c.ItemADD(23474, 0, EQUIPMENT_SLOT_LEGS)        'Recruit's Pants
                c.ItemADD(23475, 0, EQUIPMENT_SLOT_FEET)        'Recruit's Boots
                c.ItemADD(23346, 0, EQUIPMENT_SLOT_MAINHAND)    'Battleworn Claymore
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_2, 5)    'Tough Hunk of Bread
            End If


            'PALADIN **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_PALADIN Then
                c.ItemADD(45, 0, EQUIPMENT_SLOT_BODY)           'Squire's Shirt
                c.ItemADD(44, 0, EQUIPMENT_SLOT_LEGS)           'Squire's Pants
                c.ItemADD(43, 0, EQUIPMENT_SLOT_FEET)           'Squire's Boots
                c.ItemADD(2361, 0, EQUIPMENT_SLOT_MAINHAND)     'Battleworn Hammer
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(2070, 0, INVENTORY_SLOT_ITEM_3, 5)    'Darnassian Bleu
            End If
            If c.Race = Races.RACE_DWARF AndAlso c.Classe = Classes.CLASS_PALADIN Then
                c.ItemADD(6117, 0, EQUIPMENT_SLOT_BODY)         'Squire's Shirt
                c.ItemADD(6118, 0, EQUIPMENT_SLOT_LEGS)         'Squire's Pants
                c.ItemADD(43, 0, EQUIPMENT_SLOT_FEET)           'Squire's Boots
                c.ItemADD(2361, 0, EQUIPMENT_SLOT_MAINHAND)     'Battleworn Hammer
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_PALADIN Then
                c.ItemADD(24143, 0, EQUIPMENT_SLOT_BODY)        'Initiate's Shirt
                c.ItemADD(24145, 0, EQUIPMENT_SLOT_LEGS)        'Initiate's Pants
                c.ItemADD(24146, 0, EQUIPMENT_SLOT_FEET)        'Initiate's Boots
                c.ItemADD(2361, 0, EQUIPMENT_SLOT_MAINHAND)     'Battleworn Hammer
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_PALADIN Then
                c.ItemADD(6117, 0, EQUIPMENT_SLOT_BODY)         'Squire's Shirt
                c.ItemADD(6118, 0, EQUIPMENT_SLOT_LEGS)         'Squire's Pants
                c.ItemADD(43, 0, EQUIPMENT_SLOT_FEET)           'Squire's Boots
                c.ItemADD(2361, 0, EQUIPMENT_SLOT_MAINHAND)     'Battleworn Hammer
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If

            'HUNTER **********************************************************************************************************
            If c.Race = Races.RACE_NIGHT_ELF AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(148, 0, EQUIPMENT_SLOT_BODY)          'Rugged Trapper's Shirt
                c.ItemADD(147, 0, EQUIPMENT_SLOT_LEGS)          'Rugged Trapper's Pants
                c.ItemADD(129, 0, EQUIPMENT_SLOT_FEET)          'Rugged Trapper's Boots
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(2504, 0, EQUIPMENT_SLOT_RANGED)       'Worn Shortbow
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
                c.ItemADD(2101, 0, INVENTORY_SLOT_BAG_1)        'Light Quiver
                c.ItemADD(2512, INVENTORY_SLOT_BAG_1, 0, 100)   'Rough Arrow
            End If
            If c.Race = Races.RACE_DWARF AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(148, 0, EQUIPMENT_SLOT_BODY)          'Rugged Trapper's Shirt
                c.ItemADD(147, 0, EQUIPMENT_SLOT_LEGS)          'Rugged Trapper's Pants
                c.ItemADD(129, 0, EQUIPMENT_SLOT_FEET)          'Rugged Trapper's Boots
                c.ItemADD(37, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Axe
                c.ItemADD(2508, 0, EQUIPMENT_SLOT_RANGED)       'Old Blunderbuss
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
                c.ItemADD(2102, 0, INVENTORY_SLOT_BAG_1)        'Small Ammo Pouch
                c.ItemADD(2516, INVENTORY_SLOT_BAG_1, 0, 100)   'Light Shot
            End If
            If c.Race = Races.RACE_ORC AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(127, 0, EQUIPMENT_SLOT_BODY)          'Trapper's Shirt
                c.ItemADD(6126, 0, EQUIPMENT_SLOT_LEGS)         'Trapper's Pants
                c.ItemADD(6127, 0, EQUIPMENT_SLOT_FEET)         'Trapper's Boots
                c.ItemADD(37, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Axe
                c.ItemADD(2504, 0, EQUIPMENT_SLOT_RANGED)       'Worn Shortbow
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
                c.ItemADD(2101, 0, INVENTORY_SLOT_BAG_1)        'Light Quiver
                c.ItemADD(2512, INVENTORY_SLOT_BAG_1, 0, 100)   'Rough Arrow
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(127, 0, EQUIPMENT_SLOT_BODY)          'Trapper's Shirt
                c.ItemADD(6126, 0, EQUIPMENT_SLOT_LEGS)         'Trapper's Pants
                c.ItemADD(6127, 0, EQUIPMENT_SLOT_FEET)         'Trapper's Boots
                c.ItemADD(37, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Axe
                c.ItemADD(2504, 0, EQUIPMENT_SLOT_RANGED)       'Worn Shortbow
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
                c.ItemADD(2101, 0, INVENTORY_SLOT_BAG_1)        'Light Quiver
                c.ItemADD(2512, INVENTORY_SLOT_BAG_1, 0, 100)   'Rough Arrow
            End If
            If c.Race = Races.RACE_TAUREN AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(127, 0, EQUIPMENT_SLOT_BODY)          'Trapper's Shirt
                c.ItemADD(6126, 0, EQUIPMENT_SLOT_LEGS)         'Trapper's Pants
                c.ItemADD(6127, 0, EQUIPMENT_SLOT_FEET)         'Trapper's Boots
                c.ItemADD(37, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Short Axe
                c.ItemADD(2508, 0, EQUIPMENT_SLOT_RANGED)       'Old Blunderbuss
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
                c.ItemADD(2102, 0, INVENTORY_SLOT_BAG_1)        'Small Ammo Pouch
                c.ItemADD(2516, INVENTORY_SLOT_BAG_1, 0, 100)   'Light Shot
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(20901, 0, EQUIPMENT_SLOT_BODY)        'Warder's Shirt
                c.ItemADD(20899, 0, EQUIPMENT_SLOT_LEGS)        'Warder's Pants
                c.ItemADD(20900, 0, EQUIPMENT_SLOT_FEET)        'Warder's Boots
                c.ItemADD(20982, 0, EQUIPMENT_SLOT_MAINHAND)    'Sharp Dagger
                c.ItemADD(20980, 0, EQUIPMENT_SLOT_RANGED)      'Warder's Shortbow
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
                c.ItemADD(2101, 0, INVENTORY_SLOT_BAG_1)        'Light Quiver
                c.ItemADD(2512, INVENTORY_SLOT_BAG_1, 0, 100)   'Rough Arrow
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_HUNTER Then
                c.ItemADD(23345, 0, EQUIPMENT_SLOT_BODY)        'Scout's Shirt
                c.ItemADD(23344, 0, EQUIPMENT_SLOT_LEGS)        'Scout's Pants
                c.ItemADD(23348, 0, EQUIPMENT_SLOT_FEET)        'Scout's Boots
                c.ItemADD(25, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Shortsword
                c.ItemADD(23347, 0, EQUIPMENT_SLOT_RANGED)      'Weathered Crossbow
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
                c.ItemADD(2101, 0, INVENTORY_SLOT_BAG_1)        'Light Quiver
                c.ItemADD(2512, INVENTORY_SLOT_BAG_1, 0, 100)   'Rough Arrow
            End If

            'ROGUE **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(49, 0, EQUIPMENT_SLOT_BODY)           'Footpad's Shirt
                c.ItemADD(48, 0, EQUIPMENT_SLOT_LEGS)           'Footpad's Pants
                c.ItemADD(47, 0, EQUIPMENT_SLOT_FEET)           'Footpad's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(2947, 0, EQUIPMENT_SLOT_RANGED, 100)  'Small Throwing Knife
                c.ItemADD(2070, 0, INVENTORY_SLOT_ITEM_2, 5)    'Darnassian Bleu
            End If
            If c.Race = Races.RACE_NIGHT_ELF AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(49, 0, EQUIPMENT_SLOT_BODY)           'Footpad's Shirt
                c.ItemADD(48, 0, EQUIPMENT_SLOT_LEGS)           'Footpad's Pants
                c.ItemADD(47, 0, EQUIPMENT_SLOT_FEET)           'Footpad's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(2947, 0, EQUIPMENT_SLOT_RANGED, 100)  'Small Throwing Knife
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_2, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_DWARF AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(49, 0, EQUIPMENT_SLOT_BODY)           'Footpad's Shirt
                c.ItemADD(48, 0, EQUIPMENT_SLOT_LEGS)           'Footpad's Pants
                c.ItemADD(47, 0, EQUIPMENT_SLOT_FEET)           'Footpad's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(3111, 0, EQUIPMENT_SLOT_RANGED, 100)  'Crude Throwing Axe
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_2, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_GNOME AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(49, 0, EQUIPMENT_SLOT_BODY)           'Footpad's Shirt
                c.ItemADD(48, 0, EQUIPMENT_SLOT_LEGS)           'Footpad's Pants
                c.ItemADD(47, 0, EQUIPMENT_SLOT_FEET)           'Footpad's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(2947, 0, EQUIPMENT_SLOT_RANGED, 100)  'Small Throwing Knife
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_UNDEAD AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(2105, 0, EQUIPMENT_SLOT_BODY)         'Thug Shirt
                c.ItemADD(120, 0, EQUIPMENT_SLOT_LEGS)          'Thug Pants
                c.ItemADD(121, 0, EQUIPMENT_SLOT_FEET)          'Thug Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(2947, 0, EQUIPMENT_SLOT_RANGED, 100)  'Small Throwing Knife
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_2, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_ORC AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(2105, 0, EQUIPMENT_SLOT_BODY)         'Thug Shirt
                c.ItemADD(120, 0, EQUIPMENT_SLOT_LEGS)          'Thug Pants
                c.ItemADD(121, 0, EQUIPMENT_SLOT_FEET)          'Thug Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(3111, 0, EQUIPMENT_SLOT_RANGED, 100)  'Crude Throwing Axe
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(6136, 0, EQUIPMENT_SLOT_BODY)         'Thug Shirt
                c.ItemADD(6137, 0, EQUIPMENT_SLOT_LEGS)         'Thug Pants
                c.ItemADD(6138, 0, EQUIPMENT_SLOT_FEET)         'Thug Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(3111, 0, EQUIPMENT_SLOT_RANGED, 100)  'Crude Throwing Axe
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_ROGUE Then
                c.ItemADD(20897, 0, EQUIPMENT_SLOT_BODY)        'Lookout's Tunic
                c.ItemADD(20896, 0, EQUIPMENT_SLOT_LEGS)        'Lookout's Pants
                c.ItemADD(20898, 0, EQUIPMENT_SLOT_FEET)        'Lookout's Shoes
                c.ItemADD(20982, 0, EQUIPMENT_SLOT_MAINHAND)    'Sharp Dagger
                c.ItemADD(25861, 0, EQUIPMENT_SLOT_RANGED, 100) 'Small Throwing Knife
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_2, 5)     'Tough Jerky
            End If

            'DRUID **********************************************************************************************************
            If c.Race = Races.RACE_NIGHT_ELF AndAlso c.Classe = Classes.CLASS_DRUID Then
                c.ItemADD(127, 0, EQUIPMENT_SLOT_BODY)          'Novice's Shirt
                c.ItemADD(6123, 0, EQUIPMENT_SLOT_CHEST)        'Novice's Robe
                c.ItemADD(44, 0, EQUIPMENT_SLOT_LEGS)           'Novice's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Novice's Boots
                c.ItemADD(3661, 0, EQUIPMENT_SLOT_MAINHAND)     'Handcrafted Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4536, 0, INVENTORY_SLOT_ITEM_3, 5)    'Shiny Red Apple
            End If
            If c.Race = Races.RACE_TAUREN AndAlso c.Classe = Classes.CLASS_DRUID Then
                c.ItemADD(127, 0, EQUIPMENT_SLOT_BODY)          'Novice's Shirt
                c.ItemADD(6139, 0, EQUIPMENT_SLOT_CHEST)        'Novice's Robe
                c.ItemADD(6124, 0, EQUIPMENT_SLOT_LEGS)         'Novice's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Novice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4536, 0, INVENTORY_SLOT_ITEM_3, 5)    'Shiny Red Apple
            End If

            'SHAMAN **********************************************************************************************************
            If c.Race = Races.RACE_ORC AndAlso c.Classe = Classes.CLASS_SHAMAN Then
                c.ItemADD(154, 0, EQUIPMENT_SLOT_BODY)          'Primitive Mantle
                c.ItemADD(153, 0, EQUIPMENT_SLOT_LEGS)          'Primitive Kilt
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Novice's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_SHAMAN Then
                c.ItemADD(6134, 0, EQUIPMENT_SLOT_BODY)         'Primitive Mantle
                c.ItemADD(6135, 0, EQUIPMENT_SLOT_LEGS)         'Primitive Kilt
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Novice's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_TAUREN AndAlso c.Classe = Classes.CLASS_SHAMAN Then
                c.ItemADD(154, 0, EQUIPMENT_SLOT_BODY)          'Primitive Mantle
                c.ItemADD(153, 0, EQUIPMENT_SLOT_LEGS)          'Primitive Kilt
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Novice's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_SHAMAN Then
                c.ItemADD(23345, 0, EQUIPMENT_SLOT_BODY)        'Scout's Shirt
                c.ItemADD(23344, 0, EQUIPMENT_SLOT_LEGS)        'Scout's Pants
                c.ItemADD(23348, 0, EQUIPMENT_SLOT_FEET)        'Scout's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If

            'PRIEST **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(6098, 0, EQUIPMENT_SLOT_CHEST)        'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(2070, 0, INVENTORY_SLOT_ITEM_3, 5)    'Darnassian Bleu
            End If
            If c.Race = Races.RACE_NIGHT_ELF AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(6119, 0, EQUIPMENT_SLOT_CHEST)        'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(2070, 0, INVENTORY_SLOT_ITEM_3, 5)    'Darnassian Bleu
            End If
            If c.Race = Races.RACE_DWARF AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(6098, 0, EQUIPMENT_SLOT_CHEST)        'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_UNDEAD AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(6144, 0, EQUIPMENT_SLOT_CHEST)        'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(6144, 0, EQUIPMENT_SLOT_CHEST)        'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(53, 0, EQUIPMENT_SLOT_BODY)           'Neophyte's Shirt
                c.ItemADD(20891, 0, EQUIPMENT_SLOT_CHEST)       'Neophyte's Robe
                c.ItemADD(52, 0, EQUIPMENT_SLOT_LEGS)           'Neophyte's Pants
                c.ItemADD(51, 0, EQUIPMENT_SLOT_FEET)           'Neophyte's Boots
                c.ItemADD(20981, 0, EQUIPMENT_SLOT_MAINHAND)    'Neophyte's Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_PRIEST Then
                c.ItemADD(6097, 0, EQUIPMENT_SLOT_BODY)         'Acolyte's Shirt
                c.ItemADD(23322, 0, EQUIPMENT_SLOT_CHEST)       'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(36, 0, EQUIPMENT_SLOT_MAINHAND)       'Worn Mace
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If

            'MAGE **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(6096, 0, EQUIPMENT_SLOT_BODY)         'Apprentice's Shirt
                c.ItemADD(56, 0, EQUIPMENT_SLOT_CHEST)          'Apprentice's Robe
                c.ItemADD(1395, 0, EQUIPMENT_SLOT_LEGS)         'Apprentice's Pants
                c.ItemADD(55, 0, EQUIPMENT_SLOT_FEET)           'Apprentice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(2070, 0, INVENTORY_SLOT_ITEM_3, 5)    'Darnassian Bleu
            End If
            If c.Race = Races.RACE_GNOME AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(6096, 0, EQUIPMENT_SLOT_BODY)         'Apprentice's Shirt
                c.ItemADD(56, 0, EQUIPMENT_SLOT_CHEST)          'Apprentice's Robe
                c.ItemADD(1395, 0, EQUIPMENT_SLOT_LEGS)         'Apprentice's Pants
                c.ItemADD(55, 0, EQUIPMENT_SLOT_FEET)           'Apprentice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4536, 0, INVENTORY_SLOT_ITEM_3, 5)    'Shiny Red Apple
            End If
            If c.Race = Races.RACE_UNDEAD AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(6096, 0, EQUIPMENT_SLOT_BODY)         'Apprentice's Shirt
                c.ItemADD(6140, 0, EQUIPMENT_SLOT_CHEST)        'Apprentice's Robe
                c.ItemADD(1395, 0, EQUIPMENT_SLOT_LEGS)         'Apprentice's Pants
                c.ItemADD(55, 0, EQUIPMENT_SLOT_FEET)           'Apprentice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_TROLL AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(6096, 0, EQUIPMENT_SLOT_BODY)         'Apprentice's Shirt
                c.ItemADD(6140, 0, EQUIPMENT_SLOT_CHEST)        'Apprentice's Robe
                c.ItemADD(1395, 0, EQUIPMENT_SLOT_LEGS)         'Apprentice's Pants
                c.ItemADD(55, 0, EQUIPMENT_SLOT_FEET)           'Apprentice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(6096, 0, EQUIPMENT_SLOT_BODY)         'Apprentice's Shirt
                c.ItemADD(20893, 0, EQUIPMENT_SLOT_CHEST)       'Apprentice's Robe
                c.ItemADD(20894, 0, EQUIPMENT_SLOT_LEGS)        'Apprentice's Pants
                c.ItemADD(20895, 0, EQUIPMENT_SLOT_FEET)        'Apprentice's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If
            If c.Race = Races.RACE_DRAENEI AndAlso c.Classe = Classes.CLASS_MAGE Then
                c.ItemADD(23473, 0, EQUIPMENT_SLOT_BODY)        'Recruit's Shirt
                c.ItemADD(23479, 0, EQUIPMENT_SLOT_CHEST)       'Recruit's Robe
                c.ItemADD(23474, 0, EQUIPMENT_SLOT_LEGS)        'Recruit's Pants
                c.ItemADD(23475, 0, EQUIPMENT_SLOT_FEET)        'Recruit's Boots
                c.ItemADD(35, 0, EQUIPMENT_SLOT_MAINHAND)       'Bent Staff
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4540, 0, INVENTORY_SLOT_ITEM_3, 5)    'Tough Hunk of Bread
            End If

            'WARLOCK **********************************************************************************************************
            If c.Race = Races.RACE_HUMAN AndAlso c.Classe = Classes.CLASS_WARLOCK Then
                c.ItemADD(964, 0, EQUIPMENT_SLOT_BODY)          'Acolyte's Shirt
                c.ItemADD(57, 0, EQUIPMENT_SLOT_CHEST)          'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_GNOME AndAlso c.Classe = Classes.CLASS_WARLOCK Then
                c.ItemADD(964, 0, EQUIPMENT_SLOT_BODY)          'Acolyte's Shirt
                c.ItemADD(57, 0, EQUIPMENT_SLOT_CHEST)          'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_UNDEAD AndAlso c.Classe = Classes.CLASS_WARLOCK Then
                c.ItemADD(6097, 0, EQUIPMENT_SLOT_BODY)         'Acolyte's Shirt
                c.ItemADD(6129, 0, EQUIPMENT_SLOT_CHEST)        'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
            If c.Race = Races.RACE_ORC AndAlso c.Classe = Classes.CLASS_WARLOCK Then
                c.ItemADD(6097, 0, EQUIPMENT_SLOT_BODY)         'Acolyte's Shirt
                c.ItemADD(6129, 0, EQUIPMENT_SLOT_CHEST)        'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(117, 0, INVENTORY_SLOT_ITEM_3, 5)     'Tough Jerky
            End If
            If c.Race = Races.RACE_BLOOD_ELF AndAlso c.Classe = Classes.CLASS_WARLOCK Then
                c.ItemADD(6097, 0, EQUIPMENT_SLOT_BODY)         'Acolyte's Shirt
                c.ItemADD(20892, 0, EQUIPMENT_SLOT_CHEST)       'Acolyte's Robe
                c.ItemADD(1396, 0, EQUIPMENT_SLOT_LEGS)         'Acolyte's Pants
                c.ItemADD(59, 0, EQUIPMENT_SLOT_FEET)           'Acolyte's Shoes
                c.ItemADD(2092, 0, EQUIPMENT_SLOT_MAINHAND)     'Worn Dagger
                c.ItemADD(159, 0, INVENTORY_SLOT_ITEM_2, 5)     'Refreshing Spring Water
                c.ItemADD(4604, 0, INVENTORY_SLOT_ITEM_3, 5)    'Forest Mushroom Cap
            End If
        End Sub
        Public Sub StartClass(ByRef c As CharacterObject)
            c.Life.Base = 0
            c.Life.Current = 0
            c.Mana.Base = 0
            c.Mana.Current = 0
            c.Rage.Current = 0
            c.Rage.Base = 0
            c.Energy.Current = 0
            c.Energy.Base = 0
            c.ManaType = GetClassManaType(c.Classe)

            With c
                'CLASS_DRUID
                If .Classe = Classes.CLASS_DRUID Then
                    c.Strength.Base = c.Strength.Base + 1
                    c.Intellect.Base = c.Intellect.Base + 2
                    c.Spirit.Base = c.Spirit.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 54)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 70)
                    c.Mana.Current = c.Mana.Maximum
                    c.Rage.Current = 0
                    c.Rage.Base = 100
                    c.Energy.Current = 0
                    c.Energy.Base = 100

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth
                    c.LearnSpell(9077)          'Leather
                    c.LearnSkill(414, 1, 1)     'Leather
                    c.LearnSpell(227)           'Staves
                    c.LearnSkill(136, 1, 5)     'Staves

                    '--- Class Skills ---
                    c.LearnSkill(134, 1, 1)   'Feral Combat
                    c.LearnSkill(573, 1, 1)   'Restoration
                    c.LearnSkill(574, 1, 1)   'Balance

                    '--- Other ---
                    c.LearnSpell(5176)       'Wrath
                    c.LearnSpell(5185)       'Healing Touch
                    c.LearnSpell(27764)      'Fetish 

                    Select Case c.Race
                        Case Races.RACE_NIGHT_ELF
                            c.LearnSpell(1180)           'Daggers
                            c.LearnSkill(173, 1, 5)      'Daggers
                        Case Races.RACE_TAUREN
                            c.LearnSpell(198)            'Maces
                            c.LearnSkill(54, 1, 5)       'Maces
                    End Select
                    Exit Sub
                End If

                'CLASS_HUNTER
                If .Classe = Classes.CLASS_HUNTER Then
                    c.Agility.Base = c.Agility.Base + 3
                    c.Stamina.Base = c.Stamina.Base + 1
                    c.Spirit.Base = c.Spirit.Base + 1
                    c.Life.Base = CalculateStartingLIFE(c, 46)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 85)
                    c.Mana.Current = c.Mana.Maximum

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth
                    c.LearnSpell(9077)          'Leather
                    c.LearnSkill(414, 1, 1)     'Leather

                    '--- Class Skills ---
                    c.LearnSkill(50, 1, 1)      'Beast Mastery
                    c.LearnSkill(51, 1, 1)      'Survival - Outdoorsmanship
                    c.LearnSkill(163, 1, 1)     'Marksmanship - Ranged Combat

                    '--- Other ---
                    c.LearnSpell(75)            'Auto Shot
                    c.LearnSpell(2973)          'Raptor Strike

                    Select Case c.Race
                        Case Races.RACE_ORC
                            c.LearnSpell(196)               'Axes
                            c.LearnSpell(264)               'Bows
                            c.LearnSpell(2480)              'Shoot Bow
                            c.LearnSkill(44, 1, 5)          'Axes
                            c.LearnSkill(45, 1, 5)          'Bows
                        Case Races.RACE_DWARF
                            c.LearnSpell(196)               'Axes
                            c.LearnSpell(266)               'Guns
                            c.LearnSpell(7918)              'Shoot Gun
                            c.LearnSkill(44, 1, 5)          'Axes
                            c.LearnSkill(46, 1, 5)          'Guns
                        Case Races.RACE_NIGHT_ELF
                            c.LearnSpell(264)               'Bows
                            c.LearnSpell(1180)              'Daggers
                            c.LearnSpell(2480)              'Shoot Bow
                            c.LearnSkill(45, 1, 5)          'Bows
                            c.LearnSkill(173, 1, 5)         'Daggers
                        Case Races.RACE_TAUREN
                            c.LearnSpell(196)               'Axes
                            c.LearnSpell(266)               'Guns
                            c.LearnSpell(7918)              'Shoot Gun
                            c.LearnSkill(44, 1, 5)          'Axes
                            c.LearnSkill(46, 1, 5)          'Guns
                        Case Races.RACE_TROLL
                            c.LearnSpell(196)               'Axes
                            c.LearnSpell(264)               'Bows
                            c.LearnSpell(2480)              'Shoot Bow
                            c.LearnSkill(44, 1, 5)          'Axes
                            c.LearnSkill(45, 1, 5)          'Bows
                        Case Races.RACE_BLOOD_ELF
                            c.LearnSpell(264)               'Bows
                            c.LearnSpell(1180)              'Daggers
                            c.LearnSpell(2480)              'Shoot Bow
                            c.LearnSkill(45, 1, 5)          'Bows
                            c.LearnSkill(173, 1, 5)         'Daggers
                        Case Races.RACE_DRAENEI
                            c.LearnSpell(7919)              'Crossbow
                            c.LearnSpell(1180)              'Daggers
                            c.LearnSpell(2480)              'Shoot Bow
                            c.LearnSkill(226, 1, 5)         'Crossbow
                            c.LearnSkill(173, 1, 5)         'Daggers
                    End Select
                End If

                'CLASS_MAGE
                If .Classe = Classes.CLASS_MAGE Then
                    c.Intellect.Base = c.Intellect.Base + 3
                    c.Spirit.Base = c.Spirit.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 52)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 120)
                    c.Mana.Current = c.Mana.Maximum

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth

                    '--- Class Skills ---
                    c.LearnSkill(6, 1, 1)       'Frost
                    c.LearnSkill(8, 1, 1)       'Fire
                    c.LearnSkill(237, 1, 1)     'Arcane Magic

                    '--- Other ---
                    c.LearnSpell(5009)          'Wands
                    c.LearnSkill(228, 1, 5)     'Wands
                    c.LearnSpell(5019)          'Shoot
                    c.LearnSpell(227)           'Staves
                    c.LearnSkill(136, 1, 5)     'Staves
                    c.LearnSpell(133)           'Fireball
                    c.LearnSpell(168)           'Frost Armor
                    Exit Sub
                End If

                'CLASS_PALADIN
                If .Classe = Classes.CLASS_PALADIN Then
                    c.Strength.Base = c.Strength.Base + 2
                    c.Spirit.Base = c.Spirit.Base + 1
                    c.Stamina.Base = c.Stamina.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 38)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 80)
                    c.Mana.Current = c.Mana.Maximum

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth
                    c.LearnSpell(9077)          'Leather
                    c.LearnSkill(414, 1, 1)     'Leather
                    c.LearnSpell(8737)          'Mail
                    c.LearnSkill(413, 1, 1)     'Mail
                    c.LearnSpell(9116)          'Shield
                    c.LearnSkill(433, 1, 1)     'Shield
                    c.LearnSpell(27762)         'Libram

                    '--- Class Skills ---
                    c.LearnSkill(184, 1, 1)     'Retribution
                    c.LearnSkill(267, 1, 1)     'Protection
                    c.LearnSkill(594, 1, 1)     'Holy

                    '--- Other ---
                    c.LearnSpell(107)           'Block
                    c.LearnSpell(635)           'Holy Light
                    c.LearnSpell(21084)         'Seal of Righteousness

                    Select Case c.Race
                        Case Races.RACE_HUMAN
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(199)               'Two-Handed Maces
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(160, 1, 5)         'Two-Handed Maces
                        Case Races.RACE_DWARF
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(199)               'Two-Handed Maces
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(160, 1, 5)         'Two-Handed Maces
                        Case Races.RACE_BLOOD_ELF
                            c.LearnSpell(201)               'Swords
                            c.LearnSpell(202)               'Two-Handed Swords
                            c.LearnSkill(43, 1, 5)          'Swords
                            c.LearnSkill(55, 1, 5)          'Two-Handed Swords
                        Case Races.RACE_DRAENEI
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(199)               'Two-Handed Maces
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(160, 1, 5)         'Two-Handed Maces
                    End Select
                    Exit Sub
                End If

                'CLASS_PRIEST
                If .Classe = Classes.CLASS_PRIEST Then
                    c.Intellect.Base = c.Intellect.Base + 2
                    c.Spirit.Base = c.Spirit.Base + 3
                    c.Life.Base = CalculateStartingLIFE(c, 52)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 130)
                    c.Mana.Current = c.Mana.Maximum

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth

                    '--- Class Skills ---
                    c.LearnSkill(56, 1, 1)      'Holy
                    c.LearnSkill(78, 1, 1)      'Shadow Magic
                    c.LearnSkill(613, 1, 1)     'Discipline

                    '--- Other ---
                    c.LearnSpell(5009)          'Wands
                    c.LearnSkill(228, 1, 5)     'Wands
                    c.LearnSpell(5019)          'Shoot
                    c.LearnSpell(198)           'Maces
                    c.LearnSkill(54, 1, 5)      'Maces
                    c.LearnSpell(585)           'Smite
                    c.LearnSpell(2050)          'Lesser Heal
                    Exit Sub
                End If

                'CLASS_ROGUE
                If .Classe = Classes.CLASS_ROGUE Then
                    c.Strength.Base = c.Strength.Base + 1
                    c.Stamina.Base = c.Stamina.Base + 1
                    c.Agility.Base = c.Agility.Base + 3
                    c.Life.Base = CalculateStartingLIFE(c, 45)
                    c.Life.Current = c.Life.Maximum
                    c.Energy.Current = 0
                    c.Energy.Base = 100

                    '--- Armor ---
                    c.LearnSpell(9078)       'Cloth
                    c.LearnSkill(415, 1, 1)  'Cloth
                    c.LearnSpell(9077)       'Leather
                    c.LearnSkill(414, 1, 1)  'Leather

                    '--- Class Skills ---
                    c.LearnSkill(38, 1, 1)   'Combat
                    c.LearnSkill(39, 1, 1)   'Subtlety
                    c.LearnSkill(253, 1, 1)  'Assassination

                    '--- Other ---
                    c.LearnSpell(2567)          'Thrown
                    c.LearnSkill(176, 1, 5)     'Thrown
                    c.LearnSpell(2764)          'Throw
                    c.LearnSpell(1180)          'Daggers
                    c.LearnSkill(173, 1, 5)     'Daggers
                    c.LearnSpell(1752)          'Sinister Strike
                    c.LearnSpell(2098)          'Eviscerate

                    c.AttackTimeBase(0) = 1900

                    Select Case c.Race
                        Case Races.RACE_HUMAN
                        Case Races.RACE_NIGHT_ELF
                        Case Races.RACE_DWARF
                        Case Races.RACE_GNOME
                        Case Races.RACE_UNDEAD
                        Case Races.RACE_ORC
                        Case Races.RACE_TROLL
                    End Select
                    Exit Sub
                End If

                'CLASS_SHAMAN
                If .Classe = Classes.CLASS_SHAMAN Then
                    c.Strength.Base = c.Strength.Base + 1
                    c.Stamina.Base = c.Stamina.Base + 1
                    c.Intellect.Base = c.Intellect.Base + 1
                    c.Spirit.Base = c.Spirit.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 47)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 75)
                    c.Mana.Current = c.Mana.Maximum

                    ' --- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth
                    c.LearnSpell(9077)          'Leather
                    c.LearnSkill(414, 1, 1)     'Leather
                    c.LearnSpell(9116)          'Shield
                    c.LearnSkill(433, 1, 1)     'Shield

                    ' --- Class Skills ---
                    c.LearnSkill(373, 1, 1)     'Enhancement
                    c.LearnSkill(374, 1, 1)     'Restoration
                    c.LearnSkill(375, 1, 1)     'Elemental Combat

                    ' --- Other ---
                    c.LearnSpell(107)           'Block
                    c.LearnSpell(403)           'Lightning Bolt
                    c.LearnSpell(331)           'Healing Wave
                    c.LearnSpell(27763)         'Totem

                    Select Case c.Race
                        Case Races.RACE_ORC
                            c.LearnSpell(196)               'Axes
                            c.LearnSpell(197)               'Two-Handed Axes
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(227)               'Staves
                            c.LearnSkill(44, 1, 5)          'Axes
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(136, 1, 5)         'Staves
                            c.LearnSkill(172, 1, 5)         'Two-Handed Axes
                        Case Races.RACE_TROLL
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(227)               'Staves
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(136, 1, 5)         'Staves
                        Case Races.RACE_TAUREN
                            c.LearnSpell(198)               'Maces
                            c.LearnSpell(227)               'Staves
                            c.LearnSkill(54, 1, 5)          'Maces
                            c.LearnSkill(136, 1, 5)         'Staves
                    End Select
                    Exit Sub
                End If

                'CLASS_WARLOCK
                If .Classe = Classes.CLASS_WARLOCK Then
                    c.Stamina.Base = c.Stamina.Base + 1
                    c.Intellect.Base = c.Intellect.Base + 2
                    c.Spirit.Base = c.Spirit.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 43)
                    c.Life.Current = c.Life.Maximum
                    c.Mana.Base = CalculateStartingMANA(c, 110)
                    c.Mana.Current = c.Mana.Maximum

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth

                    '--- Class Skills ---
                    c.LearnSkill(354, 1, 1)     'Demonology
                    c.LearnSkill(355, 1, 1)     'Affliction
                    c.LearnSkill(593, 1, 1)     'Destruction

                    '--- Other ---
                    c.LearnSpell(5009)          'Wands
                    c.LearnSkill(228, 1, 5)     'Wands
                    c.LearnSpell(5019)          'Shoot
                    c.LearnSpell(1180)          'Daggers
                    c.LearnSkill(173, 1, 5)     'Daggers
                    c.LearnSpell(686)           'Shadow Bolt
                    c.LearnSpell(687)           'Demon Skin
                    Exit Sub
                End If

                'CLASS_WARRIOR
                If .Classe = Classes.CLASS_WARRIOR Then
                    c.Strength.Base = c.Strength.Base + 3
                    c.Stamina.Base = c.Stamina.Base + 2
                    c.Life.Base = CalculateStartingLIFE(c, 40)
                    c.Life.Current = c.Life.Maximum
                    c.Rage.Base = 1000
                    c.Rage.Current = 0
                    c.Rage.Bonus = 0

                    '--- Armor ---
                    c.LearnSpell(9078)          'Cloth
                    c.LearnSkill(415, 1, 1)     'Cloth
                    c.LearnSpell(9077)          'Leather
                    c.LearnSkill(414, 1, 1)     'Leather
                    c.LearnSpell(8737)          'Mail
                    c.LearnSkill(413, 1, 1)     'Mail
                    c.LearnSpell(9116)          'Shield
                    c.LearnSkill(433, 1, 1)     'Shield

                    '--- Class Skills ---
                    c.LearnSkill(26, 1, 1)      'Arms
                    c.LearnSkill(256, 1, 1)     'Fury
                    c.LearnSkill(257, 1, 1)     'Protection

                    '--- Other ---
                    c.LearnSpell(107)           'Block
                    c.LearnSpell(2457)          'Battle Stance
                    c.LearnSpell(78)            'Heroic Strike

                    Select Case c.Race
                        Case Races.RACE_HUMAN
                            c.LearnSpell(196)             'Axes
                            c.LearnSpell(198)             'Maces
                            c.LearnSpell(201)             'Swords
                            c.LearnSpell(202)             'Two-Handed Swords
                            c.LearnSkill(43, 1, 5)        'Swords
                            c.LearnSkill(44, 1, 5)        'Axes
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(55, 1, 5)        'Two-Handed Swords
                        Case Races.RACE_NIGHT_ELF
                            c.LearnSpell(198)             'Maces
                            c.LearnSpell(201)             'Swords
                            c.LearnSpell(1180)            'Daggers
                            c.LearnSkill(43, 1, 5)        'Swords
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(173, 1, 5)       'Daggers
                        Case Races.RACE_DWARF
                            c.LearnSpell(196)             'Axes
                            c.LearnSpell(197)             'Two-Handed Axes
                            c.LearnSpell(198)             'Maces
                            c.LearnSkill(44, 1, 5)        'Axes
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(172, 1, 5)       'Two-Handed Axes
                        Case Races.RACE_GNOME
                            c.LearnSpell(198)             'Maces
                            c.LearnSpell(201)             'Swords
                            c.LearnSpell(1180)            'Daggers
                            c.LearnSkill(43, 1, 5)        'Swords
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(173, 1, 5)       'Daggers
                        Case Races.RACE_ORC
                            c.LearnSpell(196)             'Axes
                            c.LearnSpell(197)             'Two-Handed Axes
                            c.LearnSkill(44, 1, 5)        'Axes
                            c.LearnSkill(172, 1, 5)       'Two-Handed Axes
                        Case Races.RACE_UNDEAD
                            c.LearnSpell(201)             'Swords
                            c.LearnSpell(202)             'Two-Handed Swords
                            c.LearnSpell(1180)            'Daggers
                            c.LearnSkill(43, 1, 5)        'Swords
                            c.LearnSkill(55, 1, 5)        'Two-Handed Swords
                            c.LearnSkill(173, 1, 5)       'Daggers
                        Case Races.RACE_TAUREN
                            c.LearnSpell(196)             'Axes
                            c.LearnSpell(198)             'Maces
                            c.LearnSpell(199)             'Two-Handed Maces
                            c.LearnSkill(44, 1, 5)        'Axes
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(160, 1, 5)       'Two-Handed Maces
                        Case Races.RACE_TROLL
                            c.LearnSpell(196)             'Axes
                            c.LearnSpell(1180)            'Daggers
                            c.LearnSpell(2567)            'Thrown
                            c.LearnSpell(2764)            'Throw
                            c.LearnSkill(44, 1, 5)        'Axes
                            c.LearnSkill(173, 1, 5)       'Daggers
                            c.LearnSkill(176, 1, 5)       'Thrown
                        Case Races.RACE_DRAENEI
                            c.LearnSpell(198)             'Maces
                            c.LearnSpell(201)             'Swords
                            c.LearnSpell(1180)            'Daggers
                            c.LearnSkill(43, 1, 5)        'Swords
                            c.LearnSkill(54, 1, 5)        'Maces
                            c.LearnSkill(173, 1, 5)       'Daggers
                    End Select
                    Exit Sub
                End If
            End With
        End Sub

        Public Sub StartRace(ByRef c As CharacterObject)
            With c
                c.Model = GetRaceModel(.Race, .Gender)

                c.LearnSpell(3365)          'Opening
                c.LearnSpell(6233)          'Closing
                c.LearnSpell(8386)          'Attacking
                c.LearnSpell(6478)          'Opening (Kneeling)
                c.LearnSpell(22810)         'Opening (No Text)
                c.LearnSpell(6477)          'Opening (Tinkering)
                c.LearnSpell(6247)          'Opening (Quick)
                c.LearnSpell(6246)          'Closing (Quick)
                c.LearnSpell(21651)         'Opening (Slow)
                c.LearnSpell(21652)         'Closing (Slow)

                c.LearnSpell(22027)         'Remove Insignia
                c.LearnSpell(2479)          'Honorless Target
                c.LearnSpell(3050)          'Detect

                c.LearnSpell(7355)          'Stuck
                c.LearnSpell(9125)          'Generic
                c.LearnSpell(2382)          'Generic
                c.LearnSpell(7267)          'Grovel

                c.LearnSpell(522)           'SPELLDEFENSE (DND)
                'c.LearnSpell(107)           'Block

                c.LearnSpell(203)           'Unarmed
                c.LearnSkill(162, 1, 5)     'Unarmed
                c.LearnSpell(204)           'Defense
                c.LearnSkill(95, 1, 5)      'Defense
                c.LearnSpell(81)            'Dodge
                c.LearnSpell(6603)          'Attack
                c.LearnSkill(155, 1, 1)     'Swimming
                c.LearnSpell(7266)          'Duel

                c.LearnSkill(183, 300, 300) 'Generic (DND)


                'RACE_DWARF
                If .Race = Races.RACE_DWARF Then
                    c.MapID = 0
                    c.ZoneID = 1
                    c.positionX = DWARF_START_POSITIONX
                    c.positionY = DWARF_START_POSITIONY
                    c.positionZ = DWARF_START_POSITIONZ
                    c.Strength.Base = 22
                    c.Agility.Base = 16
                    c.Stamina.Base = 23
                    c.Intellect.Base = 19
                    c.Spirit.Base = 19
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Dwarf
                    c.bindpoint_positionX = DWARF_START_POSITIONX
                    c.bindpoint_positionY = DWARF_START_POSITIONY
                    c.bindpoint_positionZ = DWARF_START_POSITIONZ
                    c.bindpoint_map_id = 0
                    c.bindpoint_zone_id = 1

                    c.LearnSkill(98, 300, 300)      'Language: Common
                    c.LearnSpell(668)               'Language: Common
                    c.LearnSkill(111, 300, 300)     'Language: Dwarven
                    c.LearnSpell(672)               'Language: Dwarven

                    c.LearnSpell(2481)              'Find Treasure
                    c.LearnSpell(20594)             'Stoneform
                    c.LearnSpell(20595)             'Gun Specialization
                    c.LearnSpell(20596)             'Frost Resistance

                    c.InitializeReputation(Factions.Stormwind)
                    c.InitializeReputation(Factions.GnomereganExiles)
                    c.InitializeReputation(Factions.Darnassus)
                    c.InitializeReputation(Factions.Ironforge)
                    'c.SetReputation(Factions.IronForge, +100)

                    c.TaxiZones.Set(6, True)
                    Exit Sub
                End If

                'RACE_GNOME
                If .Race = Races.RACE_GNOME Then
                    c.MapID = 0
                    c.ZoneID = 1
                    c.positionX = GNOME_START_POSITIONX
                    c.positionY = GNOME_START_POSITIONY
                    c.positionZ = GNOME_START_POSITIONZ
                    c.Strength.Base = 15
                    c.Agility.Base = 23
                    c.Stamina.Base = 19
                    c.Intellect.Base = 24
                    c.Spirit.Base = 20
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Gnome
                    c.bindpoint_positionX = GNOME_START_POSITIONX
                    c.bindpoint_positionY = GNOME_START_POSITIONY
                    c.bindpoint_positionZ = GNOME_START_POSITIONZ
                    c.bindpoint_map_id = 0
                    c.bindpoint_zone_id = 1

                    c.LearnSkill(98, 300, 300)      'Language: Common
                    c.LearnSpell(668)               'Language: Common
                    c.LearnSkill(313, 300, 300)     'Language: Gnomish
                    c.LearnSpell(7340)              'Language: Gnomish
                    c.LearnSkill(753, 1, 1)         'SKILL_RACIAL_GNOME

                    c.LearnSpell(20589)             'Escape Artist
                    c.LearnSpell(20591)             'Expansive Mind
                    c.LearnSpell(20592)             'Arcane Resistance
                    c.LearnSpell(20593)             'Engineering Specialization

                    c.InitializeReputation(Factions.Stormwind)
                    c.InitializeReputation(Factions.GnomereganExiles)
                    c.InitializeReputation(Factions.Darnassus)
                    c.InitializeReputation(Factions.Ironforge)
                    'c.SetReputation(Factions.GnomereganExiles, +100)

                    c.TaxiZones.Set(6, True)
                    Exit Sub
                End If

                'RACE_HUMAN
                If .Race = Races.RACE_HUMAN Then
                    c.MapID = 0
                    c.ZoneID = 12
                    c.positionX = HUMAN_START_POSITIONX
                    c.positionY = HUMAN_START_POSITIONY
                    c.positionZ = HUMAN_START_POSITIONZ
                    c.Strength.Base = 20
                    c.Agility.Base = 20
                    c.Stamina.Base = 20
                    c.Intellect.Base = 19
                    c.Spirit.Base = 21
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Human
                    c.bindpoint_positionX = HUMAN_START_POSITIONX
                    c.bindpoint_positionY = HUMAN_START_POSITIONY
                    c.bindpoint_positionZ = HUMAN_START_POSITIONZ
                    c.bindpoint_map_id = 0
                    c.bindpoint_zone_id = 12

                    c.LearnSkill(98, 300, 300)      'Language: Common
                    c.LearnSpell(668)               'Language: Common
                    c.LearnSkill(754, 1, 1)         'SKILL_RACIAL_HUMAN

                    c.LearnSpell(20597)             'Sword Specialization
                    c.LearnSpell(20598)             'The Human Spirit
                    c.LearnSpell(20599)             'Diplomacy
                    c.LearnSpell(20600)             'Perception
                    c.LearnSpell(20864)             'Mace Specialization

                    c.InitializeReputation(Factions.Stormwind)
                    c.InitializeReputation(Factions.GnomereganExiles)
                    c.InitializeReputation(Factions.Darnassus)
                    c.InitializeReputation(Factions.Ironforge)
                    'c.SetReputation(Factions.Stormwind, +100)

                    c.TaxiZones.Set(2, True)
                    Exit Sub
                End If

                'RACE_NIGHT_ELF
                If .Race = Races.RACE_NIGHT_ELF Then
                    c.MapID = 1
                    c.ZoneID = 14
                    c.positionX = NIGHTELF_START_POSITIONX
                    c.positionY = NIGHTELF_START_POSITIONY
                    c.positionZ = NIGHTELF_START_POSITIONZ
                    c.Strength.Base = 17
                    c.Agility.Base = 25
                    c.Stamina.Base = 19
                    c.Intellect.Base = 20
                    c.Spirit.Base = 20
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_NightElf
                    c.bindpoint_positionX = NIGHTELF_START_POSITIONX
                    c.bindpoint_positionY = NIGHTELF_START_POSITIONY
                    c.bindpoint_positionZ = NIGHTELF_START_POSITIONZ
                    c.bindpoint_map_id = 1
                    c.bindpoint_zone_id = 14

                    c.LearnSkill(98, 300, 300)      'Language: Common
                    c.LearnSpell(668)               'Language: Common
                    c.LearnSkill(113, 300, 300)     'Language: Darnassian
                    c.LearnSpell(671)               'Language: Darnassian

                    c.LearnSpell(20580)             'Shadowmeld
                    c.LearnSpell(20582)             'Quickness
                    c.LearnSpell(20583)             'Nature Resistance
                    c.LearnSpell(20585)             'Wisp Spirit

                    c.InitializeReputation(Factions.Stormwind)
                    c.InitializeReputation(Factions.GnomereganExiles)
                    c.InitializeReputation(Factions.Darnassus)
                    c.InitializeReputation(Factions.Ironforge)
                    'c.SetReputation(Factions.Darnasus, +100)

                    c.TaxiZones.Set(26, True)
                    c.TaxiZones.Set(27, True)
                    Exit Sub
                End If

                'RACE_ORC
                If .Race = Races.RACE_ORC Then
                    c.MapID = 1
                    c.ZoneID = 14
                    c.positionX = ORC_START_POSITIONX
                    c.positionY = ORC_START_POSITIONY
                    c.positionZ = ORC_START_POSITIONZ
                    c.Strength.Base = 23
                    c.Agility.Base = 17
                    c.Stamina.Base = 22
                    c.Intellect.Base = 17
                    c.Spirit.Base = 23
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Orc
                    c.bindpoint_positionX = ORC_START_POSITIONX
                    c.bindpoint_positionY = ORC_START_POSITIONY
                    c.bindpoint_positionZ = ORC_START_POSITIONZ
                    c.bindpoint_map_id = 1
                    c.bindpoint_zone_id = 14

                    c.LearnSkill(109, 300, 300)     'Language: Orcish
                    c.LearnSpell(669)               'Language: Orcish

                    c.LearnSpell(20572)        'Blood Fury
                    c.LearnSpell(20573)        'Hardiness
                    c.LearnSpell(20574)        'Axe Specialization
                    c.LearnSpell(20575)        'Command

                    c.InitializeReputation(Factions.Orgrimmar)
                    c.InitializeReputation(Factions.Undercity)
                    c.InitializeReputation(Factions.ThunderBluff)
                    c.InitializeReputation(Factions.DarkspearTrolls)
                    'c.SetReputation(Factions.Orgrimmar, +100)
                    'c.SetReputation(Factions.Undercity, -50)

                    c.TaxiZones.Set(23, True)
                    Exit Sub
                End If

                'RACE_TAUREN
                If .Race = Races.RACE_TAUREN Then
                    c.MapID = 1
                    c.ZoneID = 215
                    c.positionX = TAUREN_START_POSITIONX
                    c.positionY = TAUREN_START_POSITIONY
                    c.positionZ = TAUREN_START_POSITIONZ
                    c.Strength.Base = 25
                    c.Agility.Base = 15
                    c.Stamina.Base = 22
                    c.Intellect.Base = 15
                    c.Spirit.Base = 22
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Tauren
                    c.bindpoint_positionX = TAUREN_START_POSITIONX
                    c.bindpoint_positionY = TAUREN_START_POSITIONY
                    c.bindpoint_positionZ = TAUREN_START_POSITIONZ
                    c.bindpoint_map_id = 1
                    c.bindpoint_zone_id = 215

                    c.LearnSkill(109, 300, 300)     'Language: Orcish
                    c.LearnSpell(669)               'Language: Orcish
                    c.LearnSkill(115, 300, 300)     'Language: Taurane
                    c.LearnSpell(670)               'Language: Taurane

                    c.LearnSpell(20549)        'War Stomp
                    c.LearnSpell(20550)        'Endurance
                    c.LearnSpell(20551)        'Nature Resistance
                    c.LearnSpell(20552)        'Cultivation

                    c.InitializeReputation(Factions.Orgrimmar)
                    c.InitializeReputation(Factions.Undercity)
                    c.InitializeReputation(Factions.ThunderBluff)
                    c.InitializeReputation(Factions.DarkspearTrolls)
                    'c.SetReputation(Factions.ThunderBluff, +100)
                    'c.SetReputation(Factions.Undercity, -50)

                    c.TaxiZones.Set(22, True)
                    Exit Sub
                End If

                'RACE_TROLL
                If .Race = Races.RACE_TROLL Then
                    c.MapID = 1
                    c.ZoneID = 14
                    c.positionX = TROLL_START_POSITIONX
                    c.positionY = TROLL_START_POSITIONY
                    c.positionZ = TROLL_START_POSITIONZ
                    c.Strength.Base = 21
                    c.Agility.Base = 22
                    c.Stamina.Base = 21
                    c.Intellect.Base = 16
                    c.Spirit.Base = 21
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Troll
                    c.bindpoint_positionX = TROLL_START_POSITIONX
                    c.bindpoint_positionY = TROLL_START_POSITIONY
                    c.bindpoint_positionZ = TROLL_START_POSITIONZ
                    c.bindpoint_map_id = 1
                    c.bindpoint_zone_id = 14

                    c.LearnSkill(109, 300, 300)     'Language: Orcish
                    c.LearnSpell(669)               'Language: Orcish
                    c.LearnSkill(315, 300, 300)     'Language: Trollish
                    c.LearnSpell(7341)              'Language: Trollish
                    c.LearnSkill(733, 1, 1)         'SKILL_RACIAL_TROLL

                    c.LearnSpell(20554)        'Berserking
                    c.LearnSpell(20555)        'Regeneration
                    c.LearnSpell(20557)        'Beast Slaying
                    c.LearnSpell(20558)        'Throwing Specialization

                    c.InitializeReputation(Factions.Orgrimmar)
                    c.InitializeReputation(Factions.Undercity)
                    c.InitializeReputation(Factions.ThunderBluff)
                    c.InitializeReputation(Factions.DarkspearTrolls)
                    'c.SetReputation(Factions.DarkspearTrolls, +100)
                    'c.SetReputation(Factions.Undercity, -50)

                    c.TaxiZones.Set(23, True)
                    Exit Sub
                End If

                'RACE_UNDEAD
                If .Race = Races.RACE_UNDEAD Then
                    c.MapID = 0
                    c.ZoneID = 85
                    c.positionX = UNDEAD_START_POSITIONX
                    c.positionY = UNDEAD_START_POSITIONY
                    c.positionZ = UNDEAD_START_POSITIONZ
                    c.Strength.Base = 19
                    c.Agility.Base = 18
                    c.Stamina.Base = 21
                    c.Intellect.Base = 18
                    c.Spirit.Base = 25
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Undead
                    c.bindpoint_positionX = UNDEAD_START_POSITIONX
                    c.bindpoint_positionY = UNDEAD_START_POSITIONY
                    c.bindpoint_positionZ = UNDEAD_START_POSITIONZ
                    c.bindpoint_map_id = 0
                    c.bindpoint_zone_id = 85

                    c.LearnSkill(109, 300, 300)     'Language: Orcish
                    c.LearnSpell(669)               'Language: Orcish
                    c.LearnSkill(673, 300, 300)     'Language: Gutterspeak
                    c.LearnSpell(17737)             'Language: Orcish

                    c.LearnSpell(5227)         'Underwater Breathing
                    c.LearnSpell(7744)         'Will of The Forsaken
                    c.LearnSpell(20577)        'Cannibalize
                    c.LearnSpell(20579)        'Shadow Resistance

                    c.InitializeReputation(Factions.Orgrimmar)
                    c.InitializeReputation(Factions.Undercity)
                    c.InitializeReputation(Factions.ThunderBluff)
                    c.InitializeReputation(Factions.DarkspearTrolls)
                    'c.SetReputation(Factions.Undercity, +100)
                    'c.SetReputation(Factions.Orgrimmar, -50)
                    'c.SetReputation(Factions.ThunderBluff, -50)
                    'c.SetReputation(Factions.DarkspearTrolls, -50)

                    c.TaxiZones.Set(11, True)
                    Exit Sub
                End If

                'RACE_DRAENEI
                If .Race = Races.RACE_DRAENEI Then
                    c.MapID = 530
                    'c.ZoneID = 
                    c.positionX = DRAENEI_START_POSITIONX
                    c.positionY = DRAENEI_START_POSITIONY
                    c.positionZ = DRAENEI_START_POSITIONZ
                    c.Strength.Base = 21
                    c.Agility.Base = 17
                    c.Stamina.Base = 19
                    c.Intellect.Base = 21
                    c.Spirit.Base = 22
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_Draenei
                    c.bindpoint_positionX = DRAENEI_START_POSITIONX
                    c.bindpoint_positionY = DRAENEI_START_POSITIONY
                    c.bindpoint_positionZ = DRAENEI_START_POSITIONZ
                    c.bindpoint_map_id = 530
                    'c.bindpoint_zone_id = 

                    c.LearnSkill(98, 300, 300)      'Language: Common
                    c.LearnSpell(668)               'Language: Common
                    c.LearnSkill(759, 300, 300)     'Language: Draenei
                    c.LearnSpell(29932)             'Language: Draenei
                    c.LearnSkill(760, 1, 1)         'SKILL_RACIAL_DREANEI

                    c.LearnSpell(28880)             'Gift of the Naaru
                    c.LearnSpell(28875)             'Gemcutting
                    c.LearnSpell(20579)             'Shadow Resistance
                    If c.Classe = Classes.CLASS_PRIEST Or c.Classe = Classes.CLASS_MAGE Or c.Classe = Classes.CLASS_SHAMAN Then
                        c.LearnSpell(28878)         'Inspiring Presence  (Priests, Mages, and Shaman)
                    Else
                        c.LearnSpell(6562)          'Heroic Presence  (Warriors, Paladins, and Hunters)
                    End If

                    'c.TaxiZones.Set(0, True)
                    Exit Sub
                End If

                'RACE_BLOOD_ELF
                If .Race = Races.RACE_BLOOD_ELF Then
                    c.MapID = 530
                    'c.ZoneID = 
                    c.positionX = BLOODELF_START_POSITIONX
                    c.positionY = BLOODELF_START_POSITIONY
                    c.positionZ = BLOODELF_START_POSITIONZ

                    c.Strength.Base = 17
                    c.Agility.Base = 22
                    c.Stamina.Base = 22
                    c.Intellect.Base = 24
                    c.Spirit.Base = 19
                    c.Size = 1.0F
                    c.Faction = Factions.PLAYER_BloodElf
                    c.bindpoint_positionX = BLOODELF_START_POSITIONX
                    c.bindpoint_positionY = BLOODELF_START_POSITIONY
                    c.bindpoint_positionZ = BLOODELF_START_POSITIONZ
                    c.bindpoint_map_id = 530
                    'c.bindpoint_zone_id = 

                    c.LearnSkill(109, 300, 300)     'Language: Orcish
                    c.LearnSpell(669)               'Language: Orcish
                    c.LearnSkill(137, 300, 300)     'Language: Thalassian
                    c.LearnSpell(813)               'Language: Thalassian
                    c.LearnSkill(756, 1, 1)         'SKILL_RACIAL_BLOODELF

                    c.LearnSpell(28734)             'Mana Tap
                    c.LearnSpell(28730)             'Arcane Torrent
                    c.LearnSpell(28877)             'Arcane Affinity
                    c.LearnSpell(822)               'Magic Resistance 

                    'c.TaxiZones.Set(0, True)
                    Exit Sub
                End If

            End With
        End Sub


	End Module
End namespace