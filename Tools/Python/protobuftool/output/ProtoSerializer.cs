//
using System;
using System.Collections.Generic;
using System.IO;
using ProtoBuf;
public enum ProtoNameIds {
    CS_LOGIN = 1,
    SC_LOGIN = 2,
    CS_LOGIN_RECONNECTION = 3,
    SC_LOGIN_RECONNECTION = 4,
    CS_LOGIN_LOGOFF = 5,
    SC_LOGIN_REPEAT = 6,
    CS_LOGIN_HEARTBEAT = 7,
    SC_LOGIN_HEARTBEAT = 8,
    CS_LOGIN_PROTO_COUNT = 9,
    CS_LOGIN_PROTO_CLEAN = 10,
    SC_LOGIN_PROTO_COUNT = 11,
    SC_LOGIN_PROTO_CLEAN = 12,
    SC_LOGIN_ROLE_LIST = 13,
    CS_LOGIN_ROLE_LIST = 14,
    CS_LOGIN_ROLE_CHOOSE = 15,
    CS_LOGIN_ROLE_CREATE = 16,
    SC_LOGIN_ROLE_RESPONSE = 17,
    SC_PLAYER_INFO = 101,
    SC_PLAYER_SYS_NOTICE = 102,
    CS_PLAYER_INFO_MODIFY = 103,
    SC_PLAYER_INFO_MODIFY = 104,
    CS_PLAYER_SKILL_UPGRADE = 105,
    SC_PLAYER_SKILL_UPGRADE = 106,
    CS_PLAYER_DRESS_QUERY = 107,
    SC_PLAYER_DRESS_UPDATE = 108,
    CS_PLAYER_DRESS_USE = 109,
    SC_PLAYER_DRESS_USE = 110,
    CS_PLAYER_TITLE_QUERY = 111,
    SC_PLAYER_TITLE_UPDATE = 112,
    CS_PLAYER_TITLE_USE = 113,
    SC_PLAYER_TITLE_USE = 114,
    CS_PLAYER_DETAIL_INFO_QUERY = 115,
    SC_PLAYER_DETAIL_INFO_QUERY = 116,
    CS_PLAYER_GUIDE_INFO = 117,
    SC_PLAYER_GUIDE_INFO = 118,
    SC_PLAYER_SKILL_CHANGE = 119,
    CS_PLAYER_LIMIT = 120,
    SC_PLAYER_LIMIT = 121,
    CS_GALAXY_UPGRADE = 150,
    SC_GALAXY_UPGRADE_REPLY = 151,
    SC_GALAXY_INFO = 152,
    SC_TRAINING_SKILL_INFO = 160,
    CS_TRAINING_SKILL_UPGRADE = 161,
    SC_TRAINING_SKILL_UPGRADE_REPLY = 162,
    CS_MAP_ACTION = 200,
    SC_MAP_ACTION = 201,
    SC_MAP_ENTER_SCENE = 202,
    CS_MAP_ENTER_SCENE = 203,
    CS_MAP_SKILL_HIT = 205,
    SC_MAP_SKILL_HIT = 206,
    CS_MAP_ENTER_CITY = 207,
    CS_MAP_LUA_RUN_TIME = 208,
    SC_MAP_LUA_RUN_TIME = 209,
    SC_BATTLE_INFO = 301,
    SC_BATTLE_STATE = 302,
    SC_BATTLE_OBJECT_ADD = 303,
    SC_BATTLE_OBJECT_REMOVE = 304,
    SC_BATTLE_OBJECT_STEALTH_ADD = 305,
    SC_BATTLE_OBJECT_STEALTH_REMOVE = 306,
    SC_BATTLE_CAMERA_BOSS = 307,
    SC_BATTLE_CAMERA_NORMAL = 308,
    SC_BATTLE_OBJECT_AI_ADD = 309,
    SC_BATTLE_OBJECT_AI_REMOVE = 310,
    SC_ITEM_ADD = 501,
    SC_ITEM_UPDATE = 502,
    SC_ITEM_DELETE = 503,
    SC_ITEM_INIT = 504,
    CS_ITEM_SORT = 505,
    SC_ITEM_EQUIP_UPDATE = 506,
    CS_ITEM_EQUIP_TAKE_ON = 507,
    SC_ITEM_EQUIP_TAKE_ON = 508,
    CS_ITEM_EQUIP_TAKE_OFF = 509,
    SC_ITEM_EQUIP_TAKE_OFF = 510,
    CS_ITEM_SALE = 511,
    SC_ITEM_SALE = 512,
    CS_ITEM_EQUIP_UPGRADE = 513,
    SC_ITEM_EQUIP_UPGRADE = 514,
    CS_ITEM_EQUIP_STRENGTHEN = 515,
    SC_ITEM_EQUIP_STRENGTHEN = 516,
    CS_ITEM_USE = 517,
    SC_ITEM_USE = 518,
    CS_ITEM_COMPOSE = 519,
    SC_ITEM_COMPOSE = 520,
    CS_ITEM_DECOMPOSE = 521,
    SC_ITEM_DECOMPOSE = 522,
    CS_ITEM_EQUIP_GEMSTONE_INLAY = 523,
    SC_ITEM_EQUIP_GEMSTONE_INLAY = 524,
    CS_ITEM_EQUIP_POLISH = 525,
    SC_ITEM_EQUIP_POLISH = 526,
    CS_ITEM_EQUIP_INHERIT = 527,
    SC_ITEM_EQUIP_INHERIT = 528,
    SC_ITEM_EQUIP_RESONATE = 530,
    CS_ITEM_GEMSTONE_COMPOSE = 531,
    SC_ITEM_GEMSTONE_COMPOSE = 532,
    CS_CHAT = 601,
    SC_CHAT = 602,
    SC_CHAT_NOTICE = 603,
    CS_COMMON_OPERATION_VERIFY = 701,
    SC_COMMON_OPERATION_VERIFY = 702,
    SC_COMMON_CURRENCY = 704,
    SC_COMMON_ENERCY_TIME = 705,
    SC_DUP_FIGHT_INFO = 801,
    CS_CHAPTER_FIGHT_ENTER = 802,
    SC_CHAPTER_FIGHT_ENTER_RESPONSE = 803,
    CS_DUP_FIGHT_PUSH = 804,
    SC_DUP_FIGHT_PUSH = 805,
    SC_CHAPTER_FIGHT_CHEST = 806,
    CS_CHAPTER_FIGHT_OPEN_CHEST = 807,
    SC_CHAPTER_FIGHT_OPEN_CHEST = 808,
    SC_FRIEND_LIST = 901,
    SC_FRIEND_ADD = 902,
    SC_FRIEND_DEL = 903,
    CS_FRIEND_ADD_REQUEST = 904,
    SC_FRIEND_ADD_RESPONESE = 905,
    CS_FRIEND_DEL_REQUEST = 906,
    SC_FRIEND_DEL_RESPONESE = 907,
    CS_FRIEND_ADD_BLACK = 908,
    CS_FRIEND_REMOVE_BLACK = 909,
    CS_FRIEND_APPLY_HANDLE = 910,
    CS_FRIEND_SEARCH_REQUEST = 911,
    SC_FRIEND_SEARCH_RESPONE = 912,
    CS_FRIEND_RECOMMOND = 913,
    CS_FRIEND_GIVE = 914,
    CS_FRIEND_RECEIVE = 915,
    SC_FRIEND_GIVE_LIST = 916,
    SC_FRIEND_RECEIVE_LIST = 917,
    CS_RANDOM_FIGHT_INFO = 1001,
    SC_RANDOM_FIGHT_INFO = 1002,
    CS_RANDOM_FIGHT_REFRESH = 1003,
    CS_ALL_FIGHT_INFO = 1004,
    SC_ALL_FIGHT_INFO_RESPONESE = 1005,
    CS_RANDOM_FIGHT_ENTER = 1006,
    SC_RANDOM_FIGHT_ENTER_RESPONSE = 1007,
    CS_PASS_FIGHT_QUERY_REQUEST = 1101,
    SC_PASS_FIGHT_QUERY_RESPONE = 1102,
    CS_PASS_FIGHT_RESET_REQUEST = 1103,
    SC_PASS_FIGHT_RESET_RESPONE = 1104,
    CS_PASS_FIGHT_DUP_REQUEST = 1105,
    SC_PASS_FIGHT_DUP_RESPONE = 1106,
    CS_PASS_FIGHT_DUP_CANCEL_REQUEST = 1107,
    SC_PASS_FIGHT_DUP_REWARD = 1108,
    CS_PASS_FIGHT_FIGHT_REQUEST = 1109,
    SC_PASS_FIGHT_FIGHT_RESPONE = 1110,
    SC_PASS_FIGHT_QUIT_STAGE = 1111,
    CS_PASS_FIGHT_OPEN_CHESTS_REQUEST = 1112,
    SC_PASS_FIGHT_OPEN_CHESTS_RESPONE = 1113,
    CS_WELFARE_FIGHT_FIGHT_REQUEST = 1201,
    SC_WELFARE_FIGHT_FIGHT_RESPONSE = 1202,
    CS_WELFARE_FIGHT_QUERY_REQUEST = 1206,
    SC_WELFARE_FIGHT_QUERY_RESPONSE = 1207,
    SC_PET_LIST = 1301,
    SC_PET_UPDATE = 1302,
    CS_PET_FIGHT = 1303,
    SC_PET_FIGHT = 1304,
    CS_PET_FEED = 1305,
    SC_PET_FEED = 1306,
    CS_PET_EQUIP_INLAY = 1307,
    SC_PET_EQUIP_INLAY = 1308,
    CS_SHOP_BONUS_POINT_QUERY = 1401,
    SC_SHOP_BONUS_POINT_QUERY_RESPONSE = 1402,
    CS_SHOP_BONUS_POINT_BUY = 1403,
    SC_SHOP_BONUS_POINT_BUY_RESPONSE = 1404,
    CS_SHOP_MYSTERY_QUERY = 1501,
    SC_SHOP_MYSTERY_QUERY_RESPONSE = 1502,
    CS_SHOP_MYSTERY_REFRESH = 1503,
    CS_SHOP_MYSTERY_BUY = 1504,
    SC_SHOP_MYSTERY_BUY_RESPONSE = 1505,
    CS_SHOP_COMMON_QUERY = 1601,
    SC_SHOP_COMMON_QUERY_RESPONSE = 1602,
    CS_SHOP_COMMON_BUY = 1603,
    SC_SHOP_COMMON_BUY_RESPONSE = 1604,
    CS_SHOP_COMMON_GIFT = 1605,
    CS_SHOP_COMMON_GIFT_RESPONSE = 1606,
    SC_MISSION_INFO = 1700,
    CS_MISSION_COMPLETE = 1701,
    SC_MISSION_COMPLETE_REPLY = 1702,
    CS_MISSION_GET = 1703,
    SC_MAIL_LIST_QUERY_RESPONE = 1802,
    SC_MAIL_INFO_NOTICE = 1803,
    CS_MAIL_GET_REWARD = 1804,
    SC_MAIL_GET_REWARD = 1805,
    CS_MAIL_LOOKUP = 1806,
    SC_MAIL_LOOKUP = 1807,
    CS_MAIL_ALL_GET_REWARD = 1809,
    SC_MAIL_ALL_GET_REWARD = 1810,
    SC_GUILD_WAR_DOOR = 1901,
    CS_GUILD_WAR_ENTER = 1903,
    SC_GUILD_WAR_ENTER_RESPONSE = 1904,
    SC_GUILD_WAR_BILLING = 1905,
    SC_GUILD_WAR_UPDATE_INFO = 1906,
    SC_GUILD_UPDATE = 2000,
    CS_GUILD_MEMEBER_QUERY = 2001,
    SC_GUILD_MEMBER_UPDATE = 2002,
    CS_GUILD_MEMEBER_OPERATION = 2003,
    CS_GUILD_LIST_QUERY = 2004,
    SC_GUILD_LIST_UPDATE = 2005,
    CS_GUILD_SEARCH = 2006,
    SC_GUILD_SEARCH_RESPONSE = 2007,
    CS_GUILD_CREATE = 2008,
    CS_GUILD_QUIT = 2009,
    CS_GUILD_APPLY = 2010,
    SC_GUILD_APPLY_RESPONSE = 2011,
    CS_GUILD_APPLY_ONEKEY = 2012,
    SC_GUILD_APPLY_ONEKEY_RESPONSE = 2013,
    CS_GUILD_APPLY_REPLY = 2014,
    CS_GUILD_APPLY_LIST_QUERY = 2015,
    SC_GUILD_APPLY_LIST_UPDATE = 2016,
    SC_GUILD_LOG_UPDATE = 2017,
    SC_GUILD_LOG_INIT = 2018,
    CS_RANKING_LIST_QUERY_REQUEST = 2101,
    SC_RANKING_LIST_QUERY_RESPONE = 2102,
    SC_RANKING_UPDATE_NOTICE = 2103,
    SC_GUID_RANKING_RESPONSE = 2104,
    SC_VIP_INFO = 2201,
    SC_VIP_TIMES = 2202,
    CS_VIP_BUY_TIMES = 2203,
    SC_VIP_BUY_TIMES = 2204,
    CS_VIP_USE_BUN = 2205,
    SC_VIP_USE_BUN_RESULT = 2206,
    CS_VIP_BUY_GOLD = 2207,
    SC_VIP_BUY_GOLD = 2208,
    SC_VIP_RECHARGE = 2209,
    CS_COMMON_FIGHT_KILL_MONSTER = 2301,
    CS_COMMON_FIGHT_DEAD = 2302,
    CS_COMMON_FIGHT_RELIVE = 2303,
    SC_COMMON_FIGHT_RELIVE_RESPONSE = 2304,
    CS_COMMON_FIGHT_QUIT = 2305,
    SC_COMMON_FIGHT_QUIT_REPONSE = 2306,
    SC_FIRST_FIGHT_END = 2307,
    CS_MASTER_FIGHT_ENTER = 2401,
    SC_MASTER_FIGHT_ENTER_RESPONSE = 2402,
    CS_TEAM_CREATE = 2501,
    SC_TEAM_CREATE_REPLY = 2502,
    CS_TEAM_QUIT = 2503,
    SC_TEAM_QUIT_REPLY = 2504,
    SC_TEAM_MEMBER_CHANGE = 2505,
    SC_TEAM_INFO = 2506,
    CS_TEAM_INVITE_AGREE = 2507,
    SC_TEAM_INVITE_AGREE_REPLY = 2508,
    CS_TEAM_INVITE_LIST = 2509,
    SC_TEAM_INVITE_LIST_REPLY = 2510,
    CS_TEAM_INVITE = 2511,
    SC_TEAM_INVITE_REPLY = 2512,
    SC_TEAM_INVITE_LIST_CHANGE = 2513,
    CS_TEAM_KICK = 2514,
    SC_TEAM_KICK_REPLY = 2515,
    SC_TEAM_BE_KICKED = 2516,
    CS_TEAM_LEADER_TRANSFER = 2517,
    SC_TEAM_LEADER_TRANSFER_REPLY = 2518,
    CS_TEAM_START_ACTIVITY = 2519,
    SC_TEAM_START_ACTIVITY_REPLY = 2520,
    SC_TEAM_ACTIVITY = 2521,
    CS_TEAM_ACTIVITY_AGREE = 2522,
    SC_TEAM_ACTIVITY_AGREE_REPLY = 2523,
    SC_TEAM_READY_INFO = 2524,
    CS_TEAM_AUTO_MATCH = 2525,
    SC_TEAM_AUTO_MATCH = 2526,
    CS_PERSONAL_AUTO_MATCH = 2527,
    SC_PERSONAL_AUTO_MATCH = 2528,
    SC_PERSONAL_AUTO_MATCH_STATE = 2529,
    CS_AUTO_MATCH_TEAM_LIST = 2530,
    SC_AUTO_MATCH_TEAM_LIST = 2531,
    CS_TEAM_APPLY = 2532,
    SC_TEAM_APPLY = 2533,
    CS_GET_TEAM_APPLY_LIST = 2534,
    SC_TEAM_APPLY_LIST = 2535,
    CS_CLEAN_APPLY_LIST = 2536,
    CS_TEAM_APPLY_AGREE = 2537,
    SC_ACTIVITY_SIGN_INFO = 2601,
    CS_ACTIVITY_SIGN = 2602,
    SC_ACTIVITY_SIGN_REPLY = 2603,
    SC_ACTIVITY_LIST = 2604,
    SC_ACTIVITY_ENERGY_INFO = 2605,
    CS_ACTIVITY_ENERGY = 2606,
    SC_ACTIVITY_ENERGY_REPLY = 2607,
    SC_ACTIVITY_FUND_INFO = 2608,
    CS_ACTIVITY_FUND_BUY = 2609,
    SC_ACTIVITY_FUND_BUY_REPLY = 2610,
    CS_ACTIVITY_FUND_AWARD = 2611,
    SC_ACTIVITY_FUND_AWARD_REPLY = 2612,
    SC_NORMAL_ACTIVITY_INFO = 2613,
    CS_NORMAL_ACTIVITY_AWARD = 2614,
    SC_NORMAL_ACTIVITY_AWARD_REPLY = 2615,
    SC_ACTIVITY_VIP_INFO = 2616,
    CS_ACTIVITY_VIP_BUY = 2617,
    SC_ACTIVITY_VIP_BUY_REPLY = 2618,
    CS_ARENA_INFO = 2701,
    SC_ARENA_INFO_REPLY = 2702,
    CS_ARENA_BUTTON = 2703,
    SC_ARENA_BUTTON_REPLY = 2704,
    CS_ARENA_CHALLENGE = 2705,
    SC_ARENA_CHALLENGE_REPLY = 2706,
    CS_ARENA_CHALLENGE_ACCOUNT = 2707,
    CS_ARENA_RECORD = 2708,
    SC_ARENA_RECORD_REPLY = 2709,
    CS_ARENA_TIMES = 2710,
    SC_ARENA_TIMES_REPLY = 2711,
}
public class ProtoIdNames
{
    public static Dictionary<ProtoNameIds, string> protoIdNames = new Dictionary<ProtoNameIds, string>();
    static ProtoIdNames() {
        protoIdNames.Add(ProtoNameIds.CS_LOGIN, "network.cs_login");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN, "network.sc_login");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_RECONNECTION, "network.cs_login_reconnection");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_RECONNECTION, "network.sc_login_reconnection");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_LOGOFF, "network.cs_login_logoff");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_REPEAT, "network.sc_login_repeat");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_HEARTBEAT, "network.cs_login_heartbeat");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_HEARTBEAT, "network.sc_login_heartbeat");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_PROTO_COUNT, "network.cs_login_proto_count");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_PROTO_CLEAN, "network.cs_login_proto_clean");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_PROTO_COUNT, "network.sc_login_proto_count");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_PROTO_CLEAN, "network.sc_login_proto_clean");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_ROLE_LIST, "network.sc_login_role_list");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_ROLE_LIST, "network.cs_login_role_list");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_ROLE_CHOOSE, "network.cs_login_role_choose");
        protoIdNames.Add(ProtoNameIds.CS_LOGIN_ROLE_CREATE, "network.cs_login_role_create");
        protoIdNames.Add(ProtoNameIds.SC_LOGIN_ROLE_RESPONSE, "network.sc_login_role_response");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_INFO, "network.sc_player_info");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_SYS_NOTICE, "network.sc_player_sys_notice");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_INFO_MODIFY, "network.cs_player_info_modify");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_INFO_MODIFY, "network.sc_player_info_modify");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_SKILL_UPGRADE, "network.cs_player_skill_upgrade");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_SKILL_UPGRADE, "network.sc_player_skill_upgrade");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_DRESS_QUERY, "network.cs_player_dress_query");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_DRESS_UPDATE, "network.sc_player_dress_update");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_DRESS_USE, "network.cs_player_dress_use");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_DRESS_USE, "network.sc_player_dress_use");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_TITLE_QUERY, "network.cs_player_title_query");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_TITLE_UPDATE, "network.sc_player_title_update");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_TITLE_USE, "network.cs_player_title_use");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_TITLE_USE, "network.sc_player_title_use");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_DETAIL_INFO_QUERY, "network.cs_player_detail_info_query");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_DETAIL_INFO_QUERY, "network.sc_player_detail_info_query");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_GUIDE_INFO, "network.cs_player_guide_info");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_GUIDE_INFO, "network.sc_player_guide_info");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_SKILL_CHANGE, "network.sc_player_skill_change");
        protoIdNames.Add(ProtoNameIds.CS_PLAYER_LIMIT, "network.cs_player_limit");
        protoIdNames.Add(ProtoNameIds.SC_PLAYER_LIMIT, "network.sc_player_limit");
        protoIdNames.Add(ProtoNameIds.CS_GALAXY_UPGRADE, "network.cs_galaxy_upgrade");
        protoIdNames.Add(ProtoNameIds.SC_GALAXY_UPGRADE_REPLY, "network.sc_galaxy_upgrade_reply");
        protoIdNames.Add(ProtoNameIds.SC_GALAXY_INFO, "network.sc_galaxy_info");
        protoIdNames.Add(ProtoNameIds.SC_TRAINING_SKILL_INFO, "network.sc_training_skill_info");
        protoIdNames.Add(ProtoNameIds.CS_TRAINING_SKILL_UPGRADE, "network.cs_training_skill_upgrade");
        protoIdNames.Add(ProtoNameIds.SC_TRAINING_SKILL_UPGRADE_REPLY, "network.sc_training_skill_upgrade_reply");
        protoIdNames.Add(ProtoNameIds.CS_MAP_ACTION, "network.cs_map_action");
        protoIdNames.Add(ProtoNameIds.SC_MAP_ACTION, "network.sc_map_action");
        protoIdNames.Add(ProtoNameIds.SC_MAP_ENTER_SCENE, "network.sc_map_enter_scene");
        protoIdNames.Add(ProtoNameIds.CS_MAP_ENTER_SCENE, "network.cs_map_enter_scene");
        protoIdNames.Add(ProtoNameIds.CS_MAP_SKILL_HIT, "network.cs_map_skill_hit");
        protoIdNames.Add(ProtoNameIds.SC_MAP_SKILL_HIT, "network.sc_map_skill_hit");
        protoIdNames.Add(ProtoNameIds.CS_MAP_ENTER_CITY, "network.cs_map_enter_city");
        protoIdNames.Add(ProtoNameIds.CS_MAP_LUA_RUN_TIME, "network.cs_map_lua_run_time");
        protoIdNames.Add(ProtoNameIds.SC_MAP_LUA_RUN_TIME, "network.sc_map_lua_run_time");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_INFO, "network.sc_battle_info");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_STATE, "network.sc_battle_state");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_ADD, "network.sc_battle_object_add");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_REMOVE, "network.sc_battle_object_remove");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_ADD, "network.sc_battle_object_stealth_add");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_REMOVE, "network.sc_battle_object_stealth_remove");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_CAMERA_BOSS, "network.sc_battle_camera_boss");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_CAMERA_NORMAL, "network.sc_battle_camera_normal");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_AI_ADD, "network.sc_battle_object_ai_add");
        protoIdNames.Add(ProtoNameIds.SC_BATTLE_OBJECT_AI_REMOVE, "network.sc_battle_object_ai_remove");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_ADD, "network.sc_item_add");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_UPDATE, "network.sc_item_update");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_DELETE, "network.sc_item_delete");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_INIT, "network.sc_item_init");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_SORT, "network.cs_item_sort");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_UPDATE, "network.sc_item_equip_update");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_TAKE_ON, "network.cs_item_equip_take_on");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_TAKE_ON, "network.sc_item_equip_take_on");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_TAKE_OFF, "network.cs_item_equip_take_off");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_TAKE_OFF, "network.sc_item_equip_take_off");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_SALE, "network.cs_item_sale");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_SALE, "network.sc_item_sale");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_UPGRADE, "network.cs_item_equip_upgrade");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_UPGRADE, "network.sc_item_equip_upgrade");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_STRENGTHEN, "network.cs_item_equip_strengthen");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_STRENGTHEN, "network.sc_item_equip_strengthen");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_USE, "network.cs_item_use");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_USE, "network.sc_item_use");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_COMPOSE, "network.cs_item_compose");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_COMPOSE, "network.sc_item_compose");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_DECOMPOSE, "network.cs_item_decompose");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_DECOMPOSE, "network.sc_item_decompose");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_GEMSTONE_INLAY, "network.cs_item_equip_gemstone_inlay");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_GEMSTONE_INLAY, "network.sc_item_equip_gemstone_inlay");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_POLISH, "network.cs_item_equip_polish");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_POLISH, "network.sc_item_equip_polish");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_EQUIP_INHERIT, "network.cs_item_equip_inherit");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_INHERIT, "network.sc_item_equip_inherit");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_EQUIP_RESONATE, "network.sc_item_equip_resonate");
        protoIdNames.Add(ProtoNameIds.CS_ITEM_GEMSTONE_COMPOSE, "network.cs_item_gemstone_compose");
        protoIdNames.Add(ProtoNameIds.SC_ITEM_GEMSTONE_COMPOSE, "network.sc_item_gemstone_compose");
        protoIdNames.Add(ProtoNameIds.CS_CHAT, "network.cs_chat");
        protoIdNames.Add(ProtoNameIds.SC_CHAT, "network.sc_chat");
        protoIdNames.Add(ProtoNameIds.SC_CHAT_NOTICE, "network.sc_chat_notice");
        protoIdNames.Add(ProtoNameIds.CS_COMMON_OPERATION_VERIFY, "network.cs_common_operation_verify");
        protoIdNames.Add(ProtoNameIds.SC_COMMON_OPERATION_VERIFY, "network.sc_common_operation_verify");
        protoIdNames.Add(ProtoNameIds.SC_COMMON_CURRENCY, "network.sc_common_currency");
        protoIdNames.Add(ProtoNameIds.SC_COMMON_ENERCY_TIME, "network.sc_common_enercy_time");
        protoIdNames.Add(ProtoNameIds.SC_DUP_FIGHT_INFO, "network.sc_dup_fight_info");
        protoIdNames.Add(ProtoNameIds.CS_CHAPTER_FIGHT_ENTER, "network.cs_chapter_fight_enter");
        protoIdNames.Add(ProtoNameIds.SC_CHAPTER_FIGHT_ENTER_RESPONSE, "network.sc_chapter_fight_enter_response");
        protoIdNames.Add(ProtoNameIds.CS_DUP_FIGHT_PUSH, "network.cs_dup_fight_push");
        protoIdNames.Add(ProtoNameIds.SC_DUP_FIGHT_PUSH, "network.sc_dup_fight_push");
        protoIdNames.Add(ProtoNameIds.SC_CHAPTER_FIGHT_CHEST, "network.sc_chapter_fight_chest");
        protoIdNames.Add(ProtoNameIds.CS_CHAPTER_FIGHT_OPEN_CHEST, "network.cs_chapter_fight_open_chest");
        protoIdNames.Add(ProtoNameIds.SC_CHAPTER_FIGHT_OPEN_CHEST, "network.sc_chapter_fight_open_chest");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_LIST, "network.sc_friend_list");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_ADD, "network.sc_friend_add");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_DEL, "network.sc_friend_del");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_ADD_REQUEST, "network.cs_friend_add_request");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_ADD_RESPONESE, "network.sc_friend_add_responese");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_DEL_REQUEST, "network.cs_friend_del_request");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_DEL_RESPONESE, "network.sc_friend_del_responese");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_ADD_BLACK, "network.cs_friend_add_black");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_REMOVE_BLACK, "network.cs_friend_remove_black");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_APPLY_HANDLE, "network.cs_friend_apply_handle");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_SEARCH_REQUEST, "network.cs_friend_search_request");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_SEARCH_RESPONE, "network.sc_friend_search_respone");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_RECOMMOND, "network.cs_friend_recommond");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_GIVE, "network.cs_friend_give");
        protoIdNames.Add(ProtoNameIds.CS_FRIEND_RECEIVE, "network.cs_friend_receive");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_GIVE_LIST, "network.sc_friend_give_list");
        protoIdNames.Add(ProtoNameIds.SC_FRIEND_RECEIVE_LIST, "network.sc_friend_receive_list");
        protoIdNames.Add(ProtoNameIds.CS_RANDOM_FIGHT_INFO, "network.cs_random_fight_info");
        protoIdNames.Add(ProtoNameIds.SC_RANDOM_FIGHT_INFO, "network.sc_random_fight_info");
        protoIdNames.Add(ProtoNameIds.CS_RANDOM_FIGHT_REFRESH, "network.cs_random_fight_refresh");
        protoIdNames.Add(ProtoNameIds.CS_ALL_FIGHT_INFO, "network.cs_all_fight_info");
        protoIdNames.Add(ProtoNameIds.SC_ALL_FIGHT_INFO_RESPONESE, "network.sc_all_fight_info_responese");
        protoIdNames.Add(ProtoNameIds.CS_RANDOM_FIGHT_ENTER, "network.cs_random_fight_enter");
        protoIdNames.Add(ProtoNameIds.SC_RANDOM_FIGHT_ENTER_RESPONSE, "network.sc_random_fight_enter_response");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_QUERY_REQUEST, "network.cs_pass_fight_query_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_QUERY_RESPONE, "network.sc_pass_fight_query_respone");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_RESET_REQUEST, "network.cs_pass_fight_reset_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_RESET_RESPONE, "network.sc_pass_fight_reset_respone");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_DUP_REQUEST, "network.cs_pass_fight_dup_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_DUP_RESPONE, "network.sc_pass_fight_dup_respone");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_DUP_CANCEL_REQUEST, "network.cs_pass_fight_dup_cancel_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_DUP_REWARD, "network.sc_pass_fight_dup_reward");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_FIGHT_REQUEST, "network.cs_pass_fight_fight_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_FIGHT_RESPONE, "network.sc_pass_fight_fight_respone");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_QUIT_STAGE, "network.sc_pass_fight_quit_stage");
        protoIdNames.Add(ProtoNameIds.CS_PASS_FIGHT_OPEN_CHESTS_REQUEST, "network.cs_pass_fight_open_chests_request");
        protoIdNames.Add(ProtoNameIds.SC_PASS_FIGHT_OPEN_CHESTS_RESPONE, "network.sc_pass_fight_open_chests_respone");
        protoIdNames.Add(ProtoNameIds.CS_WELFARE_FIGHT_FIGHT_REQUEST, "network.cs_welfare_fight_fight_request");
        protoIdNames.Add(ProtoNameIds.SC_WELFARE_FIGHT_FIGHT_RESPONSE, "network.sc_welfare_fight_fight_response");
        protoIdNames.Add(ProtoNameIds.CS_WELFARE_FIGHT_QUERY_REQUEST, "network.cs_welfare_fight_query_request");
        protoIdNames.Add(ProtoNameIds.SC_WELFARE_FIGHT_QUERY_RESPONSE, "network.sc_welfare_fight_query_response");
        protoIdNames.Add(ProtoNameIds.SC_PET_LIST, "network.sc_pet_list");
        protoIdNames.Add(ProtoNameIds.SC_PET_UPDATE, "network.sc_pet_update");
        protoIdNames.Add(ProtoNameIds.CS_PET_FIGHT, "network.cs_pet_fight");
        protoIdNames.Add(ProtoNameIds.SC_PET_FIGHT, "network.sc_pet_fight");
        protoIdNames.Add(ProtoNameIds.CS_PET_FEED, "network.cs_pet_feed");
        protoIdNames.Add(ProtoNameIds.SC_PET_FEED, "network.sc_pet_feed");
        protoIdNames.Add(ProtoNameIds.CS_PET_EQUIP_INLAY, "network.cs_pet_equip_inlay");
        protoIdNames.Add(ProtoNameIds.SC_PET_EQUIP_INLAY, "network.sc_pet_equip_inlay");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_BONUS_POINT_QUERY, "network.cs_shop_bonus_point_query");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_BONUS_POINT_QUERY_RESPONSE, "network.sc_shop_bonus_point_query_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_BONUS_POINT_BUY, "network.cs_shop_bonus_point_buy");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_BONUS_POINT_BUY_RESPONSE, "network.sc_shop_bonus_point_buy_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_MYSTERY_QUERY, "network.cs_shop_mystery_query");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_MYSTERY_QUERY_RESPONSE, "network.sc_shop_mystery_query_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_MYSTERY_REFRESH, "network.cs_shop_mystery_refresh");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_MYSTERY_BUY, "network.cs_shop_mystery_buy");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_MYSTERY_BUY_RESPONSE, "network.sc_shop_mystery_buy_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_COMMON_QUERY, "network.cs_shop_common_query");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_COMMON_QUERY_RESPONSE, "network.sc_shop_common_query_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_COMMON_BUY, "network.cs_shop_common_buy");
        protoIdNames.Add(ProtoNameIds.SC_SHOP_COMMON_BUY_RESPONSE, "network.sc_shop_common_buy_response");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_COMMON_GIFT, "network.cs_shop_common_gift");
        protoIdNames.Add(ProtoNameIds.CS_SHOP_COMMON_GIFT_RESPONSE, "network.cs_shop_common_gift_response");
        protoIdNames.Add(ProtoNameIds.SC_MISSION_INFO, "network.sc_mission_info");
        protoIdNames.Add(ProtoNameIds.CS_MISSION_COMPLETE, "network.cs_mission_complete");
        protoIdNames.Add(ProtoNameIds.SC_MISSION_COMPLETE_REPLY, "network.sc_mission_complete_reply");
        protoIdNames.Add(ProtoNameIds.CS_MISSION_GET, "network.cs_mission_get");
        protoIdNames.Add(ProtoNameIds.SC_MAIL_LIST_QUERY_RESPONE, "network.sc_mail_list_query_respone");
        protoIdNames.Add(ProtoNameIds.SC_MAIL_INFO_NOTICE, "network.sc_mail_info_notice");
        protoIdNames.Add(ProtoNameIds.CS_MAIL_GET_REWARD, "network.cs_mail_get_reward");
        protoIdNames.Add(ProtoNameIds.SC_MAIL_GET_REWARD, "network.sc_mail_get_reward");
        protoIdNames.Add(ProtoNameIds.CS_MAIL_LOOKUP, "network.cs_mail_lookup");
        protoIdNames.Add(ProtoNameIds.SC_MAIL_LOOKUP, "network.sc_mail_lookup");
        protoIdNames.Add(ProtoNameIds.CS_MAIL_ALL_GET_REWARD, "network.cs_mail_all_get_reward");
        protoIdNames.Add(ProtoNameIds.SC_MAIL_ALL_GET_REWARD, "network.sc_mail_all_get_reward");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_WAR_DOOR, "network.sc_guild_war_door");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_WAR_ENTER, "network.cs_guild_war_enter");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_WAR_ENTER_RESPONSE, "network.sc_guild_war_enter_response");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_WAR_BILLING, "network.sc_guild_war_billing");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_WAR_UPDATE_INFO, "network.sc_guild_war_update_info");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_UPDATE, "network.sc_guild_update");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_MEMEBER_QUERY, "network.cs_guild_memeber_query");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_MEMBER_UPDATE, "network.sc_guild_member_update");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_MEMEBER_OPERATION, "network.cs_guild_memeber_operation");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_LIST_QUERY, "network.cs_guild_list_query");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_LIST_UPDATE, "network.sc_guild_list_update");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_SEARCH, "network.cs_guild_search");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_SEARCH_RESPONSE, "network.sc_guild_search_response");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_CREATE, "network.cs_guild_create");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_QUIT, "network.cs_guild_quit");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_APPLY, "network.cs_guild_apply");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_APPLY_RESPONSE, "network.sc_guild_apply_response");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_APPLY_ONEKEY, "network.cs_guild_apply_onekey");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_APPLY_ONEKEY_RESPONSE, "network.sc_guild_apply_onekey_response");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_APPLY_REPLY, "network.cs_guild_apply_reply");
        protoIdNames.Add(ProtoNameIds.CS_GUILD_APPLY_LIST_QUERY, "network.cs_guild_apply_list_query");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_APPLY_LIST_UPDATE, "network.sc_guild_apply_list_update");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_LOG_UPDATE, "network.sc_guild_log_update");
        protoIdNames.Add(ProtoNameIds.SC_GUILD_LOG_INIT, "network.sc_guild_log_init");
        protoIdNames.Add(ProtoNameIds.CS_RANKING_LIST_QUERY_REQUEST, "network.cs_ranking_list_query_request");
        protoIdNames.Add(ProtoNameIds.SC_RANKING_LIST_QUERY_RESPONE, "network.sc_ranking_list_query_respone");
        protoIdNames.Add(ProtoNameIds.SC_RANKING_UPDATE_NOTICE, "network.sc_ranking_update_notice");
        protoIdNames.Add(ProtoNameIds.SC_GUID_RANKING_RESPONSE, "network.sc_guid_ranking_response");
        protoIdNames.Add(ProtoNameIds.SC_VIP_INFO, "network.sc_vip_info");
        protoIdNames.Add(ProtoNameIds.SC_VIP_TIMES, "network.sc_vip_times");
        protoIdNames.Add(ProtoNameIds.CS_VIP_BUY_TIMES, "network.cs_vip_buy_times");
        protoIdNames.Add(ProtoNameIds.SC_VIP_BUY_TIMES, "network.sc_vip_buy_times");
        protoIdNames.Add(ProtoNameIds.CS_VIP_USE_BUN, "network.cs_vip_use_bun");
        protoIdNames.Add(ProtoNameIds.SC_VIP_USE_BUN_RESULT, "network.sc_vip_use_bun_result");
        protoIdNames.Add(ProtoNameIds.CS_VIP_BUY_GOLD, "network.cs_vip_buy_gold");
        protoIdNames.Add(ProtoNameIds.SC_VIP_BUY_GOLD, "network.sc_vip_buy_gold");
        protoIdNames.Add(ProtoNameIds.SC_VIP_RECHARGE, "network.sc_vip_recharge");
        protoIdNames.Add(ProtoNameIds.CS_COMMON_FIGHT_KILL_MONSTER, "network.cs_common_fight_kill_monster");
        protoIdNames.Add(ProtoNameIds.CS_COMMON_FIGHT_DEAD, "network.cs_common_fight_dead");
        protoIdNames.Add(ProtoNameIds.CS_COMMON_FIGHT_RELIVE, "network.cs_common_fight_relive");
        protoIdNames.Add(ProtoNameIds.SC_COMMON_FIGHT_RELIVE_RESPONSE, "network.sc_common_fight_relive_response");
        protoIdNames.Add(ProtoNameIds.CS_COMMON_FIGHT_QUIT, "network.cs_common_fight_quit");
        protoIdNames.Add(ProtoNameIds.SC_COMMON_FIGHT_QUIT_REPONSE, "network.sc_common_fight_quit_reponse");
        protoIdNames.Add(ProtoNameIds.SC_FIRST_FIGHT_END, "network.sc_first_fight_end");
        protoIdNames.Add(ProtoNameIds.CS_MASTER_FIGHT_ENTER, "network.cs_master_fight_enter");
        protoIdNames.Add(ProtoNameIds.SC_MASTER_FIGHT_ENTER_RESPONSE, "network.sc_master_fight_enter_response");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_CREATE, "network.cs_team_create");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_CREATE_REPLY, "network.sc_team_create_reply");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_QUIT, "network.cs_team_quit");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_QUIT_REPLY, "network.sc_team_quit_reply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_MEMBER_CHANGE, "network.sc_team_member_change");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_INFO, "network.sc_team_info");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_INVITE_AGREE, "network.cs_team_invite_agree");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_INVITE_AGREE_REPLY, "network.sc_team_invite_agree_reply");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_INVITE_LIST, "network.cs_team_invite_list");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_INVITE_LIST_REPLY, "network.sc_team_invite_list_reply");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_INVITE, "network.cs_team_invite");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_INVITE_REPLY, "network.sc_team_invite_reply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_INVITE_LIST_CHANGE, "network.sc_team_invite_list_change");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_KICK, "network.cs_team_kick");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_KICK_REPLY, "network.sc_team_kick_reply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_BE_KICKED, "network.sc_team_be_kicked");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_LEADER_TRANSFER, "network.cs_team_leader_transfer");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_LEADER_TRANSFER_REPLY, "network.sc_team_leader_transfer_reply");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_START_ACTIVITY, "network.cs_team_start_activity");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_START_ACTIVITY_REPLY, "network.sc_team_start_activity_reply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_ACTIVITY, "network.sc_team_activity");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_ACTIVITY_AGREE, "network.cs_team_activity_agree");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_ACTIVITY_AGREE_REPLY, "network.sc_team_activity_agree_reply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_READY_INFO, "network.sc_team_ready_info");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_AUTO_MATCH, "network.cs_team_auto_match");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_AUTO_MATCH, "network.sc_team_auto_match");
        protoIdNames.Add(ProtoNameIds.CS_PERSONAL_AUTO_MATCH, "network.cs_personal_auto_match");
        protoIdNames.Add(ProtoNameIds.SC_PERSONAL_AUTO_MATCH, "network.sc_personal_auto_match");
        protoIdNames.Add(ProtoNameIds.SC_PERSONAL_AUTO_MATCH_STATE, "network.sc_personal_auto_match_state");
        protoIdNames.Add(ProtoNameIds.CS_AUTO_MATCH_TEAM_LIST, "network.cs_auto_match_team_list");
        protoIdNames.Add(ProtoNameIds.SC_AUTO_MATCH_TEAM_LIST, "network.sc_auto_match_team_list");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_APPLY, "network.cs_team_apply");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_APPLY, "network.sc_team_apply");
        protoIdNames.Add(ProtoNameIds.CS_GET_TEAM_APPLY_LIST, "network.cs_get_team_apply_list");
        protoIdNames.Add(ProtoNameIds.SC_TEAM_APPLY_LIST, "network.sc_team_apply_list");
        protoIdNames.Add(ProtoNameIds.CS_CLEAN_APPLY_LIST, "network.cs_clean_apply_list");
        protoIdNames.Add(ProtoNameIds.CS_TEAM_APPLY_AGREE, "network.cs_team_apply_agree");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_SIGN_INFO, "network.sc_activity_sign_info");
        protoIdNames.Add(ProtoNameIds.CS_ACTIVITY_SIGN, "network.cs_activity_sign");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_SIGN_REPLY, "network.sc_activity_sign_reply");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_LIST, "network.sc_activity_list");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_ENERGY_INFO, "network.sc_activity_energy_info");
        protoIdNames.Add(ProtoNameIds.CS_ACTIVITY_ENERGY, "network.cs_activity_energy");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_ENERGY_REPLY, "network.sc_activity_energy_reply");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_FUND_INFO, "network.sc_activity_fund_info");
        protoIdNames.Add(ProtoNameIds.CS_ACTIVITY_FUND_BUY, "network.cs_activity_fund_buy");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_FUND_BUY_REPLY, "network.sc_activity_fund_buy_reply");
        protoIdNames.Add(ProtoNameIds.CS_ACTIVITY_FUND_AWARD, "network.cs_activity_fund_award");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_FUND_AWARD_REPLY, "network.sc_activity_fund_award_reply");
        protoIdNames.Add(ProtoNameIds.SC_NORMAL_ACTIVITY_INFO, "network.sc_normal_activity_info");
        protoIdNames.Add(ProtoNameIds.CS_NORMAL_ACTIVITY_AWARD, "network.cs_normal_activity_award");
        protoIdNames.Add(ProtoNameIds.SC_NORMAL_ACTIVITY_AWARD_REPLY, "network.sc_normal_activity_award_reply");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_VIP_INFO, "network.sc_activity_vip_info");
        protoIdNames.Add(ProtoNameIds.CS_ACTIVITY_VIP_BUY, "network.cs_activity_vip_buy");
        protoIdNames.Add(ProtoNameIds.SC_ACTIVITY_VIP_BUY_REPLY, "network.sc_activity_vip_buy_reply");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_INFO, "network.cs_arena_info");
        protoIdNames.Add(ProtoNameIds.SC_ARENA_INFO_REPLY, "network.sc_arena_info_reply");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_BUTTON, "network.cs_arena_button");
        protoIdNames.Add(ProtoNameIds.SC_ARENA_BUTTON_REPLY, "network.sc_arena_button_reply");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_CHALLENGE, "network.cs_arena_challenge");
        protoIdNames.Add(ProtoNameIds.SC_ARENA_CHALLENGE_REPLY, "network.sc_arena_challenge_reply");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_CHALLENGE_ACCOUNT, "network.cs_arena_challenge_account");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_RECORD, "network.cs_arena_record");
        protoIdNames.Add(ProtoNameIds.SC_ARENA_RECORD_REPLY, "network.sc_arena_record_reply");
        protoIdNames.Add(ProtoNameIds.CS_ARENA_TIMES, "network.cs_arena_times");
        protoIdNames.Add(ProtoNameIds.SC_ARENA_TIMES_REPLY, "network.sc_arena_times_reply");
    }
}
public class ProtoSerializer
{
    public static object ParseFrom(ProtoNameIds protoType, Stream stream)
    {
        switch (protoType) {
            case ProtoNameIds.CS_LOGIN: return Serializer.Deserialize<network.cs_login>(stream);
            case ProtoNameIds.SC_LOGIN: return Serializer.Deserialize<network.sc_login>(stream);
            case ProtoNameIds.CS_LOGIN_RECONNECTION: return Serializer.Deserialize<network.cs_login_reconnection>(stream);
            case ProtoNameIds.SC_LOGIN_RECONNECTION: return Serializer.Deserialize<network.sc_login_reconnection>(stream);
            case ProtoNameIds.CS_LOGIN_LOGOFF: return Serializer.Deserialize<network.cs_login_logoff>(stream);
            case ProtoNameIds.SC_LOGIN_REPEAT: return Serializer.Deserialize<network.sc_login_repeat>(stream);
            case ProtoNameIds.CS_LOGIN_HEARTBEAT: return Serializer.Deserialize<network.cs_login_heartbeat>(stream);
            case ProtoNameIds.SC_LOGIN_HEARTBEAT: return Serializer.Deserialize<network.sc_login_heartbeat>(stream);
            case ProtoNameIds.CS_LOGIN_PROTO_COUNT: return Serializer.Deserialize<network.cs_login_proto_count>(stream);
            case ProtoNameIds.CS_LOGIN_PROTO_CLEAN: return Serializer.Deserialize<network.cs_login_proto_clean>(stream);
            case ProtoNameIds.SC_LOGIN_PROTO_COUNT: return Serializer.Deserialize<network.sc_login_proto_count>(stream);
            case ProtoNameIds.SC_LOGIN_PROTO_CLEAN: return Serializer.Deserialize<network.sc_login_proto_clean>(stream);
            case ProtoNameIds.SC_LOGIN_ROLE_LIST: return Serializer.Deserialize<network.sc_login_role_list>(stream);
            case ProtoNameIds.CS_LOGIN_ROLE_LIST: return Serializer.Deserialize<network.cs_login_role_list>(stream);
            case ProtoNameIds.CS_LOGIN_ROLE_CHOOSE: return Serializer.Deserialize<network.cs_login_role_choose>(stream);
            case ProtoNameIds.CS_LOGIN_ROLE_CREATE: return Serializer.Deserialize<network.cs_login_role_create>(stream);
            case ProtoNameIds.SC_LOGIN_ROLE_RESPONSE: return Serializer.Deserialize<network.sc_login_role_response>(stream);
            case ProtoNameIds.SC_PLAYER_INFO: return Serializer.Deserialize<network.sc_player_info>(stream);
            case ProtoNameIds.SC_PLAYER_SYS_NOTICE: return Serializer.Deserialize<network.sc_player_sys_notice>(stream);
            case ProtoNameIds.CS_PLAYER_INFO_MODIFY: return Serializer.Deserialize<network.cs_player_info_modify>(stream);
            case ProtoNameIds.SC_PLAYER_INFO_MODIFY: return Serializer.Deserialize<network.sc_player_info_modify>(stream);
            case ProtoNameIds.CS_PLAYER_SKILL_UPGRADE: return Serializer.Deserialize<network.cs_player_skill_upgrade>(stream);
            case ProtoNameIds.SC_PLAYER_SKILL_UPGRADE: return Serializer.Deserialize<network.sc_player_skill_upgrade>(stream);
            case ProtoNameIds.CS_PLAYER_DRESS_QUERY: return Serializer.Deserialize<network.cs_player_dress_query>(stream);
            case ProtoNameIds.SC_PLAYER_DRESS_UPDATE: return Serializer.Deserialize<network.sc_player_dress_update>(stream);
            case ProtoNameIds.CS_PLAYER_DRESS_USE: return Serializer.Deserialize<network.cs_player_dress_use>(stream);
            case ProtoNameIds.SC_PLAYER_DRESS_USE: return Serializer.Deserialize<network.sc_player_dress_use>(stream);
            case ProtoNameIds.CS_PLAYER_TITLE_QUERY: return Serializer.Deserialize<network.cs_player_title_query>(stream);
            case ProtoNameIds.SC_PLAYER_TITLE_UPDATE: return Serializer.Deserialize<network.sc_player_title_update>(stream);
            case ProtoNameIds.CS_PLAYER_TITLE_USE: return Serializer.Deserialize<network.cs_player_title_use>(stream);
            case ProtoNameIds.SC_PLAYER_TITLE_USE: return Serializer.Deserialize<network.sc_player_title_use>(stream);
            case ProtoNameIds.CS_PLAYER_DETAIL_INFO_QUERY: return Serializer.Deserialize<network.cs_player_detail_info_query>(stream);
            case ProtoNameIds.SC_PLAYER_DETAIL_INFO_QUERY: return Serializer.Deserialize<network.sc_player_detail_info_query>(stream);
            case ProtoNameIds.CS_PLAYER_GUIDE_INFO: return Serializer.Deserialize<network.cs_player_guide_info>(stream);
            case ProtoNameIds.SC_PLAYER_GUIDE_INFO: return Serializer.Deserialize<network.sc_player_guide_info>(stream);
            case ProtoNameIds.SC_PLAYER_SKILL_CHANGE: return Serializer.Deserialize<network.sc_player_skill_change>(stream);
            case ProtoNameIds.CS_PLAYER_LIMIT: return Serializer.Deserialize<network.cs_player_limit>(stream);
            case ProtoNameIds.SC_PLAYER_LIMIT: return Serializer.Deserialize<network.sc_player_limit>(stream);
            case ProtoNameIds.CS_GALAXY_UPGRADE: return Serializer.Deserialize<network.cs_galaxy_upgrade>(stream);
            case ProtoNameIds.SC_GALAXY_UPGRADE_REPLY: return Serializer.Deserialize<network.sc_galaxy_upgrade_reply>(stream);
            case ProtoNameIds.SC_GALAXY_INFO: return Serializer.Deserialize<network.sc_galaxy_info>(stream);
            case ProtoNameIds.SC_TRAINING_SKILL_INFO: return Serializer.Deserialize<network.sc_training_skill_info>(stream);
            case ProtoNameIds.CS_TRAINING_SKILL_UPGRADE: return Serializer.Deserialize<network.cs_training_skill_upgrade>(stream);
            case ProtoNameIds.SC_TRAINING_SKILL_UPGRADE_REPLY: return Serializer.Deserialize<network.sc_training_skill_upgrade_reply>(stream);
            case ProtoNameIds.CS_MAP_ACTION: return Serializer.Deserialize<network.cs_map_action>(stream);
            case ProtoNameIds.SC_MAP_ACTION: return Serializer.Deserialize<network.sc_map_action>(stream);
            case ProtoNameIds.SC_MAP_ENTER_SCENE: return Serializer.Deserialize<network.sc_map_enter_scene>(stream);
            case ProtoNameIds.CS_MAP_ENTER_SCENE: return Serializer.Deserialize<network.cs_map_enter_scene>(stream);
            case ProtoNameIds.CS_MAP_SKILL_HIT: return Serializer.Deserialize<network.cs_map_skill_hit>(stream);
            case ProtoNameIds.SC_MAP_SKILL_HIT: return Serializer.Deserialize<network.sc_map_skill_hit>(stream);
            case ProtoNameIds.CS_MAP_ENTER_CITY: return Serializer.Deserialize<network.cs_map_enter_city>(stream);
            case ProtoNameIds.CS_MAP_LUA_RUN_TIME: return Serializer.Deserialize<network.cs_map_lua_run_time>(stream);
            case ProtoNameIds.SC_MAP_LUA_RUN_TIME: return Serializer.Deserialize<network.sc_map_lua_run_time>(stream);
            case ProtoNameIds.SC_BATTLE_INFO: return Serializer.Deserialize<network.sc_battle_info>(stream);
            case ProtoNameIds.SC_BATTLE_STATE: return Serializer.Deserialize<network.sc_battle_state>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_ADD: return Serializer.Deserialize<network.sc_battle_object_add>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_REMOVE: return Serializer.Deserialize<network.sc_battle_object_remove>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_ADD: return Serializer.Deserialize<network.sc_battle_object_stealth_add>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_REMOVE: return Serializer.Deserialize<network.sc_battle_object_stealth_remove>(stream);
            case ProtoNameIds.SC_BATTLE_CAMERA_BOSS: return Serializer.Deserialize<network.sc_battle_camera_boss>(stream);
            case ProtoNameIds.SC_BATTLE_CAMERA_NORMAL: return Serializer.Deserialize<network.sc_battle_camera_normal>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_AI_ADD: return Serializer.Deserialize<network.sc_battle_object_ai_add>(stream);
            case ProtoNameIds.SC_BATTLE_OBJECT_AI_REMOVE: return Serializer.Deserialize<network.sc_battle_object_ai_remove>(stream);
            case ProtoNameIds.SC_ITEM_ADD: return Serializer.Deserialize<network.sc_item_add>(stream);
            case ProtoNameIds.SC_ITEM_UPDATE: return Serializer.Deserialize<network.sc_item_update>(stream);
            case ProtoNameIds.SC_ITEM_DELETE: return Serializer.Deserialize<network.sc_item_delete>(stream);
            case ProtoNameIds.SC_ITEM_INIT: return Serializer.Deserialize<network.sc_item_init>(stream);
            case ProtoNameIds.CS_ITEM_SORT: return Serializer.Deserialize<network.cs_item_sort>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_UPDATE: return Serializer.Deserialize<network.sc_item_equip_update>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_TAKE_ON: return Serializer.Deserialize<network.cs_item_equip_take_on>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_TAKE_ON: return Serializer.Deserialize<network.sc_item_equip_take_on>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_TAKE_OFF: return Serializer.Deserialize<network.cs_item_equip_take_off>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_TAKE_OFF: return Serializer.Deserialize<network.sc_item_equip_take_off>(stream);
            case ProtoNameIds.CS_ITEM_SALE: return Serializer.Deserialize<network.cs_item_sale>(stream);
            case ProtoNameIds.SC_ITEM_SALE: return Serializer.Deserialize<network.sc_item_sale>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_UPGRADE: return Serializer.Deserialize<network.cs_item_equip_upgrade>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_UPGRADE: return Serializer.Deserialize<network.sc_item_equip_upgrade>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_STRENGTHEN: return Serializer.Deserialize<network.cs_item_equip_strengthen>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_STRENGTHEN: return Serializer.Deserialize<network.sc_item_equip_strengthen>(stream);
            case ProtoNameIds.CS_ITEM_USE: return Serializer.Deserialize<network.cs_item_use>(stream);
            case ProtoNameIds.SC_ITEM_USE: return Serializer.Deserialize<network.sc_item_use>(stream);
            case ProtoNameIds.CS_ITEM_COMPOSE: return Serializer.Deserialize<network.cs_item_compose>(stream);
            case ProtoNameIds.SC_ITEM_COMPOSE: return Serializer.Deserialize<network.sc_item_compose>(stream);
            case ProtoNameIds.CS_ITEM_DECOMPOSE: return Serializer.Deserialize<network.cs_item_decompose>(stream);
            case ProtoNameIds.SC_ITEM_DECOMPOSE: return Serializer.Deserialize<network.sc_item_decompose>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_GEMSTONE_INLAY: return Serializer.Deserialize<network.cs_item_equip_gemstone_inlay>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_GEMSTONE_INLAY: return Serializer.Deserialize<network.sc_item_equip_gemstone_inlay>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_POLISH: return Serializer.Deserialize<network.cs_item_equip_polish>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_POLISH: return Serializer.Deserialize<network.sc_item_equip_polish>(stream);
            case ProtoNameIds.CS_ITEM_EQUIP_INHERIT: return Serializer.Deserialize<network.cs_item_equip_inherit>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_INHERIT: return Serializer.Deserialize<network.sc_item_equip_inherit>(stream);
            case ProtoNameIds.SC_ITEM_EQUIP_RESONATE: return Serializer.Deserialize<network.sc_item_equip_resonate>(stream);
            case ProtoNameIds.CS_ITEM_GEMSTONE_COMPOSE: return Serializer.Deserialize<network.cs_item_gemstone_compose>(stream);
            case ProtoNameIds.SC_ITEM_GEMSTONE_COMPOSE: return Serializer.Deserialize<network.sc_item_gemstone_compose>(stream);
            case ProtoNameIds.CS_CHAT: return Serializer.Deserialize<network.cs_chat>(stream);
            case ProtoNameIds.SC_CHAT: return Serializer.Deserialize<network.sc_chat>(stream);
            case ProtoNameIds.SC_CHAT_NOTICE: return Serializer.Deserialize<network.sc_chat_notice>(stream);
            case ProtoNameIds.CS_COMMON_OPERATION_VERIFY: return Serializer.Deserialize<network.cs_common_operation_verify>(stream);
            case ProtoNameIds.SC_COMMON_OPERATION_VERIFY: return Serializer.Deserialize<network.sc_common_operation_verify>(stream);
            case ProtoNameIds.SC_COMMON_CURRENCY: return Serializer.Deserialize<network.sc_common_currency>(stream);
            case ProtoNameIds.SC_COMMON_ENERCY_TIME: return Serializer.Deserialize<network.sc_common_enercy_time>(stream);
            case ProtoNameIds.SC_DUP_FIGHT_INFO: return Serializer.Deserialize<network.sc_dup_fight_info>(stream);
            case ProtoNameIds.CS_CHAPTER_FIGHT_ENTER: return Serializer.Deserialize<network.cs_chapter_fight_enter>(stream);
            case ProtoNameIds.SC_CHAPTER_FIGHT_ENTER_RESPONSE: return Serializer.Deserialize<network.sc_chapter_fight_enter_response>(stream);
            case ProtoNameIds.CS_DUP_FIGHT_PUSH: return Serializer.Deserialize<network.cs_dup_fight_push>(stream);
            case ProtoNameIds.SC_DUP_FIGHT_PUSH: return Serializer.Deserialize<network.sc_dup_fight_push>(stream);
            case ProtoNameIds.SC_CHAPTER_FIGHT_CHEST: return Serializer.Deserialize<network.sc_chapter_fight_chest>(stream);
            case ProtoNameIds.CS_CHAPTER_FIGHT_OPEN_CHEST: return Serializer.Deserialize<network.cs_chapter_fight_open_chest>(stream);
            case ProtoNameIds.SC_CHAPTER_FIGHT_OPEN_CHEST: return Serializer.Deserialize<network.sc_chapter_fight_open_chest>(stream);
            case ProtoNameIds.SC_FRIEND_LIST: return Serializer.Deserialize<network.sc_friend_list>(stream);
            case ProtoNameIds.SC_FRIEND_ADD: return Serializer.Deserialize<network.sc_friend_add>(stream);
            case ProtoNameIds.SC_FRIEND_DEL: return Serializer.Deserialize<network.sc_friend_del>(stream);
            case ProtoNameIds.CS_FRIEND_ADD_REQUEST: return Serializer.Deserialize<network.cs_friend_add_request>(stream);
            case ProtoNameIds.SC_FRIEND_ADD_RESPONESE: return Serializer.Deserialize<network.sc_friend_add_responese>(stream);
            case ProtoNameIds.CS_FRIEND_DEL_REQUEST: return Serializer.Deserialize<network.cs_friend_del_request>(stream);
            case ProtoNameIds.SC_FRIEND_DEL_RESPONESE: return Serializer.Deserialize<network.sc_friend_del_responese>(stream);
            case ProtoNameIds.CS_FRIEND_ADD_BLACK: return Serializer.Deserialize<network.cs_friend_add_black>(stream);
            case ProtoNameIds.CS_FRIEND_REMOVE_BLACK: return Serializer.Deserialize<network.cs_friend_remove_black>(stream);
            case ProtoNameIds.CS_FRIEND_APPLY_HANDLE: return Serializer.Deserialize<network.cs_friend_apply_handle>(stream);
            case ProtoNameIds.CS_FRIEND_SEARCH_REQUEST: return Serializer.Deserialize<network.cs_friend_search_request>(stream);
            case ProtoNameIds.SC_FRIEND_SEARCH_RESPONE: return Serializer.Deserialize<network.sc_friend_search_respone>(stream);
            case ProtoNameIds.CS_FRIEND_RECOMMOND: return Serializer.Deserialize<network.cs_friend_recommond>(stream);
            case ProtoNameIds.CS_FRIEND_GIVE: return Serializer.Deserialize<network.cs_friend_give>(stream);
            case ProtoNameIds.CS_FRIEND_RECEIVE: return Serializer.Deserialize<network.cs_friend_receive>(stream);
            case ProtoNameIds.SC_FRIEND_GIVE_LIST: return Serializer.Deserialize<network.sc_friend_give_list>(stream);
            case ProtoNameIds.SC_FRIEND_RECEIVE_LIST: return Serializer.Deserialize<network.sc_friend_receive_list>(stream);
            case ProtoNameIds.CS_RANDOM_FIGHT_INFO: return Serializer.Deserialize<network.cs_random_fight_info>(stream);
            case ProtoNameIds.SC_RANDOM_FIGHT_INFO: return Serializer.Deserialize<network.sc_random_fight_info>(stream);
            case ProtoNameIds.CS_RANDOM_FIGHT_REFRESH: return Serializer.Deserialize<network.cs_random_fight_refresh>(stream);
            case ProtoNameIds.CS_ALL_FIGHT_INFO: return Serializer.Deserialize<network.cs_all_fight_info>(stream);
            case ProtoNameIds.SC_ALL_FIGHT_INFO_RESPONESE: return Serializer.Deserialize<network.sc_all_fight_info_responese>(stream);
            case ProtoNameIds.CS_RANDOM_FIGHT_ENTER: return Serializer.Deserialize<network.cs_random_fight_enter>(stream);
            case ProtoNameIds.SC_RANDOM_FIGHT_ENTER_RESPONSE: return Serializer.Deserialize<network.sc_random_fight_enter_response>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_QUERY_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_query_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_QUERY_RESPONE: return Serializer.Deserialize<network.sc_pass_fight_query_respone>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_RESET_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_reset_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_RESET_RESPONE: return Serializer.Deserialize<network.sc_pass_fight_reset_respone>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_DUP_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_dup_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_DUP_RESPONE: return Serializer.Deserialize<network.sc_pass_fight_dup_respone>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_DUP_CANCEL_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_dup_cancel_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_DUP_REWARD: return Serializer.Deserialize<network.sc_pass_fight_dup_reward>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_FIGHT_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_fight_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_FIGHT_RESPONE: return Serializer.Deserialize<network.sc_pass_fight_fight_respone>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_QUIT_STAGE: return Serializer.Deserialize<network.sc_pass_fight_quit_stage>(stream);
            case ProtoNameIds.CS_PASS_FIGHT_OPEN_CHESTS_REQUEST: return Serializer.Deserialize<network.cs_pass_fight_open_chests_request>(stream);
            case ProtoNameIds.SC_PASS_FIGHT_OPEN_CHESTS_RESPONE: return Serializer.Deserialize<network.sc_pass_fight_open_chests_respone>(stream);
            case ProtoNameIds.CS_WELFARE_FIGHT_FIGHT_REQUEST: return Serializer.Deserialize<network.cs_welfare_fight_fight_request>(stream);
            case ProtoNameIds.SC_WELFARE_FIGHT_FIGHT_RESPONSE: return Serializer.Deserialize<network.sc_welfare_fight_fight_response>(stream);
            case ProtoNameIds.CS_WELFARE_FIGHT_QUERY_REQUEST: return Serializer.Deserialize<network.cs_welfare_fight_query_request>(stream);
            case ProtoNameIds.SC_WELFARE_FIGHT_QUERY_RESPONSE: return Serializer.Deserialize<network.sc_welfare_fight_query_response>(stream);
            case ProtoNameIds.SC_PET_LIST: return Serializer.Deserialize<network.sc_pet_list>(stream);
            case ProtoNameIds.SC_PET_UPDATE: return Serializer.Deserialize<network.sc_pet_update>(stream);
            case ProtoNameIds.CS_PET_FIGHT: return Serializer.Deserialize<network.cs_pet_fight>(stream);
            case ProtoNameIds.SC_PET_FIGHT: return Serializer.Deserialize<network.sc_pet_fight>(stream);
            case ProtoNameIds.CS_PET_FEED: return Serializer.Deserialize<network.cs_pet_feed>(stream);
            case ProtoNameIds.SC_PET_FEED: return Serializer.Deserialize<network.sc_pet_feed>(stream);
            case ProtoNameIds.CS_PET_EQUIP_INLAY: return Serializer.Deserialize<network.cs_pet_equip_inlay>(stream);
            case ProtoNameIds.SC_PET_EQUIP_INLAY: return Serializer.Deserialize<network.sc_pet_equip_inlay>(stream);
            case ProtoNameIds.CS_SHOP_BONUS_POINT_QUERY: return Serializer.Deserialize<network.cs_shop_bonus_point_query>(stream);
            case ProtoNameIds.SC_SHOP_BONUS_POINT_QUERY_RESPONSE: return Serializer.Deserialize<network.sc_shop_bonus_point_query_response>(stream);
            case ProtoNameIds.CS_SHOP_BONUS_POINT_BUY: return Serializer.Deserialize<network.cs_shop_bonus_point_buy>(stream);
            case ProtoNameIds.SC_SHOP_BONUS_POINT_BUY_RESPONSE: return Serializer.Deserialize<network.sc_shop_bonus_point_buy_response>(stream);
            case ProtoNameIds.CS_SHOP_MYSTERY_QUERY: return Serializer.Deserialize<network.cs_shop_mystery_query>(stream);
            case ProtoNameIds.SC_SHOP_MYSTERY_QUERY_RESPONSE: return Serializer.Deserialize<network.sc_shop_mystery_query_response>(stream);
            case ProtoNameIds.CS_SHOP_MYSTERY_REFRESH: return Serializer.Deserialize<network.cs_shop_mystery_refresh>(stream);
            case ProtoNameIds.CS_SHOP_MYSTERY_BUY: return Serializer.Deserialize<network.cs_shop_mystery_buy>(stream);
            case ProtoNameIds.SC_SHOP_MYSTERY_BUY_RESPONSE: return Serializer.Deserialize<network.sc_shop_mystery_buy_response>(stream);
            case ProtoNameIds.CS_SHOP_COMMON_QUERY: return Serializer.Deserialize<network.cs_shop_common_query>(stream);
            case ProtoNameIds.SC_SHOP_COMMON_QUERY_RESPONSE: return Serializer.Deserialize<network.sc_shop_common_query_response>(stream);
            case ProtoNameIds.CS_SHOP_COMMON_BUY: return Serializer.Deserialize<network.cs_shop_common_buy>(stream);
            case ProtoNameIds.SC_SHOP_COMMON_BUY_RESPONSE: return Serializer.Deserialize<network.sc_shop_common_buy_response>(stream);
            case ProtoNameIds.CS_SHOP_COMMON_GIFT: return Serializer.Deserialize<network.cs_shop_common_gift>(stream);
            case ProtoNameIds.CS_SHOP_COMMON_GIFT_RESPONSE: return Serializer.Deserialize<network.cs_shop_common_gift_response>(stream);
            case ProtoNameIds.SC_MISSION_INFO: return Serializer.Deserialize<network.sc_mission_info>(stream);
            case ProtoNameIds.CS_MISSION_COMPLETE: return Serializer.Deserialize<network.cs_mission_complete>(stream);
            case ProtoNameIds.SC_MISSION_COMPLETE_REPLY: return Serializer.Deserialize<network.sc_mission_complete_reply>(stream);
            case ProtoNameIds.CS_MISSION_GET: return Serializer.Deserialize<network.cs_mission_get>(stream);
            case ProtoNameIds.SC_MAIL_LIST_QUERY_RESPONE: return Serializer.Deserialize<network.sc_mail_list_query_respone>(stream);
            case ProtoNameIds.SC_MAIL_INFO_NOTICE: return Serializer.Deserialize<network.sc_mail_info_notice>(stream);
            case ProtoNameIds.CS_MAIL_GET_REWARD: return Serializer.Deserialize<network.cs_mail_get_reward>(stream);
            case ProtoNameIds.SC_MAIL_GET_REWARD: return Serializer.Deserialize<network.sc_mail_get_reward>(stream);
            case ProtoNameIds.CS_MAIL_LOOKUP: return Serializer.Deserialize<network.cs_mail_lookup>(stream);
            case ProtoNameIds.SC_MAIL_LOOKUP: return Serializer.Deserialize<network.sc_mail_lookup>(stream);
            case ProtoNameIds.CS_MAIL_ALL_GET_REWARD: return Serializer.Deserialize<network.cs_mail_all_get_reward>(stream);
            case ProtoNameIds.SC_MAIL_ALL_GET_REWARD: return Serializer.Deserialize<network.sc_mail_all_get_reward>(stream);
            case ProtoNameIds.SC_GUILD_WAR_DOOR: return Serializer.Deserialize<network.sc_guild_war_door>(stream);
            case ProtoNameIds.CS_GUILD_WAR_ENTER: return Serializer.Deserialize<network.cs_guild_war_enter>(stream);
            case ProtoNameIds.SC_GUILD_WAR_ENTER_RESPONSE: return Serializer.Deserialize<network.sc_guild_war_enter_response>(stream);
            case ProtoNameIds.SC_GUILD_WAR_BILLING: return Serializer.Deserialize<network.sc_guild_war_billing>(stream);
            case ProtoNameIds.SC_GUILD_WAR_UPDATE_INFO: return Serializer.Deserialize<network.sc_guild_war_update_info>(stream);
            case ProtoNameIds.SC_GUILD_UPDATE: return Serializer.Deserialize<network.sc_guild_update>(stream);
            case ProtoNameIds.CS_GUILD_MEMEBER_QUERY: return Serializer.Deserialize<network.cs_guild_memeber_query>(stream);
            case ProtoNameIds.SC_GUILD_MEMBER_UPDATE: return Serializer.Deserialize<network.sc_guild_member_update>(stream);
            case ProtoNameIds.CS_GUILD_MEMEBER_OPERATION: return Serializer.Deserialize<network.cs_guild_memeber_operation>(stream);
            case ProtoNameIds.CS_GUILD_LIST_QUERY: return Serializer.Deserialize<network.cs_guild_list_query>(stream);
            case ProtoNameIds.SC_GUILD_LIST_UPDATE: return Serializer.Deserialize<network.sc_guild_list_update>(stream);
            case ProtoNameIds.CS_GUILD_SEARCH: return Serializer.Deserialize<network.cs_guild_search>(stream);
            case ProtoNameIds.SC_GUILD_SEARCH_RESPONSE: return Serializer.Deserialize<network.sc_guild_search_response>(stream);
            case ProtoNameIds.CS_GUILD_CREATE: return Serializer.Deserialize<network.cs_guild_create>(stream);
            case ProtoNameIds.CS_GUILD_QUIT: return Serializer.Deserialize<network.cs_guild_quit>(stream);
            case ProtoNameIds.CS_GUILD_APPLY: return Serializer.Deserialize<network.cs_guild_apply>(stream);
            case ProtoNameIds.SC_GUILD_APPLY_RESPONSE: return Serializer.Deserialize<network.sc_guild_apply_response>(stream);
            case ProtoNameIds.CS_GUILD_APPLY_ONEKEY: return Serializer.Deserialize<network.cs_guild_apply_onekey>(stream);
            case ProtoNameIds.SC_GUILD_APPLY_ONEKEY_RESPONSE: return Serializer.Deserialize<network.sc_guild_apply_onekey_response>(stream);
            case ProtoNameIds.CS_GUILD_APPLY_REPLY: return Serializer.Deserialize<network.cs_guild_apply_reply>(stream);
            case ProtoNameIds.CS_GUILD_APPLY_LIST_QUERY: return Serializer.Deserialize<network.cs_guild_apply_list_query>(stream);
            case ProtoNameIds.SC_GUILD_APPLY_LIST_UPDATE: return Serializer.Deserialize<network.sc_guild_apply_list_update>(stream);
            case ProtoNameIds.SC_GUILD_LOG_UPDATE: return Serializer.Deserialize<network.sc_guild_log_update>(stream);
            case ProtoNameIds.SC_GUILD_LOG_INIT: return Serializer.Deserialize<network.sc_guild_log_init>(stream);
            case ProtoNameIds.CS_RANKING_LIST_QUERY_REQUEST: return Serializer.Deserialize<network.cs_ranking_list_query_request>(stream);
            case ProtoNameIds.SC_RANKING_LIST_QUERY_RESPONE: return Serializer.Deserialize<network.sc_ranking_list_query_respone>(stream);
            case ProtoNameIds.SC_RANKING_UPDATE_NOTICE: return Serializer.Deserialize<network.sc_ranking_update_notice>(stream);
            case ProtoNameIds.SC_GUID_RANKING_RESPONSE: return Serializer.Deserialize<network.sc_guid_ranking_response>(stream);
            case ProtoNameIds.SC_VIP_INFO: return Serializer.Deserialize<network.sc_vip_info>(stream);
            case ProtoNameIds.SC_VIP_TIMES: return Serializer.Deserialize<network.sc_vip_times>(stream);
            case ProtoNameIds.CS_VIP_BUY_TIMES: return Serializer.Deserialize<network.cs_vip_buy_times>(stream);
            case ProtoNameIds.SC_VIP_BUY_TIMES: return Serializer.Deserialize<network.sc_vip_buy_times>(stream);
            case ProtoNameIds.CS_VIP_USE_BUN: return Serializer.Deserialize<network.cs_vip_use_bun>(stream);
            case ProtoNameIds.SC_VIP_USE_BUN_RESULT: return Serializer.Deserialize<network.sc_vip_use_bun_result>(stream);
            case ProtoNameIds.CS_VIP_BUY_GOLD: return Serializer.Deserialize<network.cs_vip_buy_gold>(stream);
            case ProtoNameIds.SC_VIP_BUY_GOLD: return Serializer.Deserialize<network.sc_vip_buy_gold>(stream);
            case ProtoNameIds.SC_VIP_RECHARGE: return Serializer.Deserialize<network.sc_vip_recharge>(stream);
            case ProtoNameIds.CS_COMMON_FIGHT_KILL_MONSTER: return Serializer.Deserialize<network.cs_common_fight_kill_monster>(stream);
            case ProtoNameIds.CS_COMMON_FIGHT_DEAD: return Serializer.Deserialize<network.cs_common_fight_dead>(stream);
            case ProtoNameIds.CS_COMMON_FIGHT_RELIVE: return Serializer.Deserialize<network.cs_common_fight_relive>(stream);
            case ProtoNameIds.SC_COMMON_FIGHT_RELIVE_RESPONSE: return Serializer.Deserialize<network.sc_common_fight_relive_response>(stream);
            case ProtoNameIds.CS_COMMON_FIGHT_QUIT: return Serializer.Deserialize<network.cs_common_fight_quit>(stream);
            case ProtoNameIds.SC_COMMON_FIGHT_QUIT_REPONSE: return Serializer.Deserialize<network.sc_common_fight_quit_reponse>(stream);
            case ProtoNameIds.SC_FIRST_FIGHT_END: return Serializer.Deserialize<network.sc_first_fight_end>(stream);
            case ProtoNameIds.CS_MASTER_FIGHT_ENTER: return Serializer.Deserialize<network.cs_master_fight_enter>(stream);
            case ProtoNameIds.SC_MASTER_FIGHT_ENTER_RESPONSE: return Serializer.Deserialize<network.sc_master_fight_enter_response>(stream);
            case ProtoNameIds.CS_TEAM_CREATE: return Serializer.Deserialize<network.cs_team_create>(stream);
            case ProtoNameIds.SC_TEAM_CREATE_REPLY: return Serializer.Deserialize<network.sc_team_create_reply>(stream);
            case ProtoNameIds.CS_TEAM_QUIT: return Serializer.Deserialize<network.cs_team_quit>(stream);
            case ProtoNameIds.SC_TEAM_QUIT_REPLY: return Serializer.Deserialize<network.sc_team_quit_reply>(stream);
            case ProtoNameIds.SC_TEAM_MEMBER_CHANGE: return Serializer.Deserialize<network.sc_team_member_change>(stream);
            case ProtoNameIds.SC_TEAM_INFO: return Serializer.Deserialize<network.sc_team_info>(stream);
            case ProtoNameIds.CS_TEAM_INVITE_AGREE: return Serializer.Deserialize<network.cs_team_invite_agree>(stream);
            case ProtoNameIds.SC_TEAM_INVITE_AGREE_REPLY: return Serializer.Deserialize<network.sc_team_invite_agree_reply>(stream);
            case ProtoNameIds.CS_TEAM_INVITE_LIST: return Serializer.Deserialize<network.cs_team_invite_list>(stream);
            case ProtoNameIds.SC_TEAM_INVITE_LIST_REPLY: return Serializer.Deserialize<network.sc_team_invite_list_reply>(stream);
            case ProtoNameIds.CS_TEAM_INVITE: return Serializer.Deserialize<network.cs_team_invite>(stream);
            case ProtoNameIds.SC_TEAM_INVITE_REPLY: return Serializer.Deserialize<network.sc_team_invite_reply>(stream);
            case ProtoNameIds.SC_TEAM_INVITE_LIST_CHANGE: return Serializer.Deserialize<network.sc_team_invite_list_change>(stream);
            case ProtoNameIds.CS_TEAM_KICK: return Serializer.Deserialize<network.cs_team_kick>(stream);
            case ProtoNameIds.SC_TEAM_KICK_REPLY: return Serializer.Deserialize<network.sc_team_kick_reply>(stream);
            case ProtoNameIds.SC_TEAM_BE_KICKED: return Serializer.Deserialize<network.sc_team_be_kicked>(stream);
            case ProtoNameIds.CS_TEAM_LEADER_TRANSFER: return Serializer.Deserialize<network.cs_team_leader_transfer>(stream);
            case ProtoNameIds.SC_TEAM_LEADER_TRANSFER_REPLY: return Serializer.Deserialize<network.sc_team_leader_transfer_reply>(stream);
            case ProtoNameIds.CS_TEAM_START_ACTIVITY: return Serializer.Deserialize<network.cs_team_start_activity>(stream);
            case ProtoNameIds.SC_TEAM_START_ACTIVITY_REPLY: return Serializer.Deserialize<network.sc_team_start_activity_reply>(stream);
            case ProtoNameIds.SC_TEAM_ACTIVITY: return Serializer.Deserialize<network.sc_team_activity>(stream);
            case ProtoNameIds.CS_TEAM_ACTIVITY_AGREE: return Serializer.Deserialize<network.cs_team_activity_agree>(stream);
            case ProtoNameIds.SC_TEAM_ACTIVITY_AGREE_REPLY: return Serializer.Deserialize<network.sc_team_activity_agree_reply>(stream);
            case ProtoNameIds.SC_TEAM_READY_INFO: return Serializer.Deserialize<network.sc_team_ready_info>(stream);
            case ProtoNameIds.CS_TEAM_AUTO_MATCH: return Serializer.Deserialize<network.cs_team_auto_match>(stream);
            case ProtoNameIds.SC_TEAM_AUTO_MATCH: return Serializer.Deserialize<network.sc_team_auto_match>(stream);
            case ProtoNameIds.CS_PERSONAL_AUTO_MATCH: return Serializer.Deserialize<network.cs_personal_auto_match>(stream);
            case ProtoNameIds.SC_PERSONAL_AUTO_MATCH: return Serializer.Deserialize<network.sc_personal_auto_match>(stream);
            case ProtoNameIds.SC_PERSONAL_AUTO_MATCH_STATE: return Serializer.Deserialize<network.sc_personal_auto_match_state>(stream);
            case ProtoNameIds.CS_AUTO_MATCH_TEAM_LIST: return Serializer.Deserialize<network.cs_auto_match_team_list>(stream);
            case ProtoNameIds.SC_AUTO_MATCH_TEAM_LIST: return Serializer.Deserialize<network.sc_auto_match_team_list>(stream);
            case ProtoNameIds.CS_TEAM_APPLY: return Serializer.Deserialize<network.cs_team_apply>(stream);
            case ProtoNameIds.SC_TEAM_APPLY: return Serializer.Deserialize<network.sc_team_apply>(stream);
            case ProtoNameIds.CS_GET_TEAM_APPLY_LIST: return Serializer.Deserialize<network.cs_get_team_apply_list>(stream);
            case ProtoNameIds.SC_TEAM_APPLY_LIST: return Serializer.Deserialize<network.sc_team_apply_list>(stream);
            case ProtoNameIds.CS_CLEAN_APPLY_LIST: return Serializer.Deserialize<network.cs_clean_apply_list>(stream);
            case ProtoNameIds.CS_TEAM_APPLY_AGREE: return Serializer.Deserialize<network.cs_team_apply_agree>(stream);
            case ProtoNameIds.SC_ACTIVITY_SIGN_INFO: return Serializer.Deserialize<network.sc_activity_sign_info>(stream);
            case ProtoNameIds.CS_ACTIVITY_SIGN: return Serializer.Deserialize<network.cs_activity_sign>(stream);
            case ProtoNameIds.SC_ACTIVITY_SIGN_REPLY: return Serializer.Deserialize<network.sc_activity_sign_reply>(stream);
            case ProtoNameIds.SC_ACTIVITY_LIST: return Serializer.Deserialize<network.sc_activity_list>(stream);
            case ProtoNameIds.SC_ACTIVITY_ENERGY_INFO: return Serializer.Deserialize<network.sc_activity_energy_info>(stream);
            case ProtoNameIds.CS_ACTIVITY_ENERGY: return Serializer.Deserialize<network.cs_activity_energy>(stream);
            case ProtoNameIds.SC_ACTIVITY_ENERGY_REPLY: return Serializer.Deserialize<network.sc_activity_energy_reply>(stream);
            case ProtoNameIds.SC_ACTIVITY_FUND_INFO: return Serializer.Deserialize<network.sc_activity_fund_info>(stream);
            case ProtoNameIds.CS_ACTIVITY_FUND_BUY: return Serializer.Deserialize<network.cs_activity_fund_buy>(stream);
            case ProtoNameIds.SC_ACTIVITY_FUND_BUY_REPLY: return Serializer.Deserialize<network.sc_activity_fund_buy_reply>(stream);
            case ProtoNameIds.CS_ACTIVITY_FUND_AWARD: return Serializer.Deserialize<network.cs_activity_fund_award>(stream);
            case ProtoNameIds.SC_ACTIVITY_FUND_AWARD_REPLY: return Serializer.Deserialize<network.sc_activity_fund_award_reply>(stream);
            case ProtoNameIds.SC_NORMAL_ACTIVITY_INFO: return Serializer.Deserialize<network.sc_normal_activity_info>(stream);
            case ProtoNameIds.CS_NORMAL_ACTIVITY_AWARD: return Serializer.Deserialize<network.cs_normal_activity_award>(stream);
            case ProtoNameIds.SC_NORMAL_ACTIVITY_AWARD_REPLY: return Serializer.Deserialize<network.sc_normal_activity_award_reply>(stream);
            case ProtoNameIds.SC_ACTIVITY_VIP_INFO: return Serializer.Deserialize<network.sc_activity_vip_info>(stream);
            case ProtoNameIds.CS_ACTIVITY_VIP_BUY: return Serializer.Deserialize<network.cs_activity_vip_buy>(stream);
            case ProtoNameIds.SC_ACTIVITY_VIP_BUY_REPLY: return Serializer.Deserialize<network.sc_activity_vip_buy_reply>(stream);
            case ProtoNameIds.CS_ARENA_INFO: return Serializer.Deserialize<network.cs_arena_info>(stream);
            case ProtoNameIds.SC_ARENA_INFO_REPLY: return Serializer.Deserialize<network.sc_arena_info_reply>(stream);
            case ProtoNameIds.CS_ARENA_BUTTON: return Serializer.Deserialize<network.cs_arena_button>(stream);
            case ProtoNameIds.SC_ARENA_BUTTON_REPLY: return Serializer.Deserialize<network.sc_arena_button_reply>(stream);
            case ProtoNameIds.CS_ARENA_CHALLENGE: return Serializer.Deserialize<network.cs_arena_challenge>(stream);
            case ProtoNameIds.SC_ARENA_CHALLENGE_REPLY: return Serializer.Deserialize<network.sc_arena_challenge_reply>(stream);
            case ProtoNameIds.CS_ARENA_CHALLENGE_ACCOUNT: return Serializer.Deserialize<network.cs_arena_challenge_account>(stream);
            case ProtoNameIds.CS_ARENA_RECORD: return Serializer.Deserialize<network.cs_arena_record>(stream);
            case ProtoNameIds.SC_ARENA_RECORD_REPLY: return Serializer.Deserialize<network.sc_arena_record_reply>(stream);
            case ProtoNameIds.CS_ARENA_TIMES: return Serializer.Deserialize<network.cs_arena_times>(stream);
            case ProtoNameIds.SC_ARENA_TIMES_REPLY: return Serializer.Deserialize<network.sc_arena_times_reply>(stream);
            default: break;
        }
        return null;
    }
    public static void Serialize(ProtoNameIds protoType, Stream stream, object proto)
    {
        switch (protoType)
        {
            case ProtoNameIds.CS_LOGIN: Serializer.Serialize(stream, (network.cs_login)proto); break;
            case ProtoNameIds.SC_LOGIN: Serializer.Serialize(stream, (network.sc_login)proto); break;
            case ProtoNameIds.CS_LOGIN_RECONNECTION: Serializer.Serialize(stream, (network.cs_login_reconnection)proto); break;
            case ProtoNameIds.SC_LOGIN_RECONNECTION: Serializer.Serialize(stream, (network.sc_login_reconnection)proto); break;
            case ProtoNameIds.CS_LOGIN_LOGOFF: Serializer.Serialize(stream, (network.cs_login_logoff)proto); break;
            case ProtoNameIds.SC_LOGIN_REPEAT: Serializer.Serialize(stream, (network.sc_login_repeat)proto); break;
            case ProtoNameIds.CS_LOGIN_HEARTBEAT: Serializer.Serialize(stream, (network.cs_login_heartbeat)proto); break;
            case ProtoNameIds.SC_LOGIN_HEARTBEAT: Serializer.Serialize(stream, (network.sc_login_heartbeat)proto); break;
            case ProtoNameIds.CS_LOGIN_PROTO_COUNT: Serializer.Serialize(stream, (network.cs_login_proto_count)proto); break;
            case ProtoNameIds.CS_LOGIN_PROTO_CLEAN: Serializer.Serialize(stream, (network.cs_login_proto_clean)proto); break;
            case ProtoNameIds.SC_LOGIN_PROTO_COUNT: Serializer.Serialize(stream, (network.sc_login_proto_count)proto); break;
            case ProtoNameIds.SC_LOGIN_PROTO_CLEAN: Serializer.Serialize(stream, (network.sc_login_proto_clean)proto); break;
            case ProtoNameIds.SC_LOGIN_ROLE_LIST: Serializer.Serialize(stream, (network.sc_login_role_list)proto); break;
            case ProtoNameIds.CS_LOGIN_ROLE_LIST: Serializer.Serialize(stream, (network.cs_login_role_list)proto); break;
            case ProtoNameIds.CS_LOGIN_ROLE_CHOOSE: Serializer.Serialize(stream, (network.cs_login_role_choose)proto); break;
            case ProtoNameIds.CS_LOGIN_ROLE_CREATE: Serializer.Serialize(stream, (network.cs_login_role_create)proto); break;
            case ProtoNameIds.SC_LOGIN_ROLE_RESPONSE: Serializer.Serialize(stream, (network.sc_login_role_response)proto); break;
            case ProtoNameIds.SC_PLAYER_INFO: Serializer.Serialize(stream, (network.sc_player_info)proto); break;
            case ProtoNameIds.SC_PLAYER_SYS_NOTICE: Serializer.Serialize(stream, (network.sc_player_sys_notice)proto); break;
            case ProtoNameIds.CS_PLAYER_INFO_MODIFY: Serializer.Serialize(stream, (network.cs_player_info_modify)proto); break;
            case ProtoNameIds.SC_PLAYER_INFO_MODIFY: Serializer.Serialize(stream, (network.sc_player_info_modify)proto); break;
            case ProtoNameIds.CS_PLAYER_SKILL_UPGRADE: Serializer.Serialize(stream, (network.cs_player_skill_upgrade)proto); break;
            case ProtoNameIds.SC_PLAYER_SKILL_UPGRADE: Serializer.Serialize(stream, (network.sc_player_skill_upgrade)proto); break;
            case ProtoNameIds.CS_PLAYER_DRESS_QUERY: Serializer.Serialize(stream, (network.cs_player_dress_query)proto); break;
            case ProtoNameIds.SC_PLAYER_DRESS_UPDATE: Serializer.Serialize(stream, (network.sc_player_dress_update)proto); break;
            case ProtoNameIds.CS_PLAYER_DRESS_USE: Serializer.Serialize(stream, (network.cs_player_dress_use)proto); break;
            case ProtoNameIds.SC_PLAYER_DRESS_USE: Serializer.Serialize(stream, (network.sc_player_dress_use)proto); break;
            case ProtoNameIds.CS_PLAYER_TITLE_QUERY: Serializer.Serialize(stream, (network.cs_player_title_query)proto); break;
            case ProtoNameIds.SC_PLAYER_TITLE_UPDATE: Serializer.Serialize(stream, (network.sc_player_title_update)proto); break;
            case ProtoNameIds.CS_PLAYER_TITLE_USE: Serializer.Serialize(stream, (network.cs_player_title_use)proto); break;
            case ProtoNameIds.SC_PLAYER_TITLE_USE: Serializer.Serialize(stream, (network.sc_player_title_use)proto); break;
            case ProtoNameIds.CS_PLAYER_DETAIL_INFO_QUERY: Serializer.Serialize(stream, (network.cs_player_detail_info_query)proto); break;
            case ProtoNameIds.SC_PLAYER_DETAIL_INFO_QUERY: Serializer.Serialize(stream, (network.sc_player_detail_info_query)proto); break;
            case ProtoNameIds.CS_PLAYER_GUIDE_INFO: Serializer.Serialize(stream, (network.cs_player_guide_info)proto); break;
            case ProtoNameIds.SC_PLAYER_GUIDE_INFO: Serializer.Serialize(stream, (network.sc_player_guide_info)proto); break;
            case ProtoNameIds.SC_PLAYER_SKILL_CHANGE: Serializer.Serialize(stream, (network.sc_player_skill_change)proto); break;
            case ProtoNameIds.CS_PLAYER_LIMIT: Serializer.Serialize(stream, (network.cs_player_limit)proto); break;
            case ProtoNameIds.SC_PLAYER_LIMIT: Serializer.Serialize(stream, (network.sc_player_limit)proto); break;
            case ProtoNameIds.CS_GALAXY_UPGRADE: Serializer.Serialize(stream, (network.cs_galaxy_upgrade)proto); break;
            case ProtoNameIds.SC_GALAXY_UPGRADE_REPLY: Serializer.Serialize(stream, (network.sc_galaxy_upgrade_reply)proto); break;
            case ProtoNameIds.SC_GALAXY_INFO: Serializer.Serialize(stream, (network.sc_galaxy_info)proto); break;
            case ProtoNameIds.SC_TRAINING_SKILL_INFO: Serializer.Serialize(stream, (network.sc_training_skill_info)proto); break;
            case ProtoNameIds.CS_TRAINING_SKILL_UPGRADE: Serializer.Serialize(stream, (network.cs_training_skill_upgrade)proto); break;
            case ProtoNameIds.SC_TRAINING_SKILL_UPGRADE_REPLY: Serializer.Serialize(stream, (network.sc_training_skill_upgrade_reply)proto); break;
            case ProtoNameIds.CS_MAP_ACTION: Serializer.Serialize(stream, (network.cs_map_action)proto); break;
            case ProtoNameIds.SC_MAP_ACTION: Serializer.Serialize(stream, (network.sc_map_action)proto); break;
            case ProtoNameIds.SC_MAP_ENTER_SCENE: Serializer.Serialize(stream, (network.sc_map_enter_scene)proto); break;
            case ProtoNameIds.CS_MAP_ENTER_SCENE: Serializer.Serialize(stream, (network.cs_map_enter_scene)proto); break;
            case ProtoNameIds.CS_MAP_SKILL_HIT: Serializer.Serialize(stream, (network.cs_map_skill_hit)proto); break;
            case ProtoNameIds.SC_MAP_SKILL_HIT: Serializer.Serialize(stream, (network.sc_map_skill_hit)proto); break;
            case ProtoNameIds.CS_MAP_ENTER_CITY: Serializer.Serialize(stream, (network.cs_map_enter_city)proto); break;
            case ProtoNameIds.CS_MAP_LUA_RUN_TIME: Serializer.Serialize(stream, (network.cs_map_lua_run_time)proto); break;
            case ProtoNameIds.SC_MAP_LUA_RUN_TIME: Serializer.Serialize(stream, (network.sc_map_lua_run_time)proto); break;
            case ProtoNameIds.SC_BATTLE_INFO: Serializer.Serialize(stream, (network.sc_battle_info)proto); break;
            case ProtoNameIds.SC_BATTLE_STATE: Serializer.Serialize(stream, (network.sc_battle_state)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_ADD: Serializer.Serialize(stream, (network.sc_battle_object_add)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_REMOVE: Serializer.Serialize(stream, (network.sc_battle_object_remove)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_ADD: Serializer.Serialize(stream, (network.sc_battle_object_stealth_add)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_STEALTH_REMOVE: Serializer.Serialize(stream, (network.sc_battle_object_stealth_remove)proto); break;
            case ProtoNameIds.SC_BATTLE_CAMERA_BOSS: Serializer.Serialize(stream, (network.sc_battle_camera_boss)proto); break;
            case ProtoNameIds.SC_BATTLE_CAMERA_NORMAL: Serializer.Serialize(stream, (network.sc_battle_camera_normal)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_AI_ADD: Serializer.Serialize(stream, (network.sc_battle_object_ai_add)proto); break;
            case ProtoNameIds.SC_BATTLE_OBJECT_AI_REMOVE: Serializer.Serialize(stream, (network.sc_battle_object_ai_remove)proto); break;
            case ProtoNameIds.SC_ITEM_ADD: Serializer.Serialize(stream, (network.sc_item_add)proto); break;
            case ProtoNameIds.SC_ITEM_UPDATE: Serializer.Serialize(stream, (network.sc_item_update)proto); break;
            case ProtoNameIds.SC_ITEM_DELETE: Serializer.Serialize(stream, (network.sc_item_delete)proto); break;
            case ProtoNameIds.SC_ITEM_INIT: Serializer.Serialize(stream, (network.sc_item_init)proto); break;
            case ProtoNameIds.CS_ITEM_SORT: Serializer.Serialize(stream, (network.cs_item_sort)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_UPDATE: Serializer.Serialize(stream, (network.sc_item_equip_update)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_TAKE_ON: Serializer.Serialize(stream, (network.cs_item_equip_take_on)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_TAKE_ON: Serializer.Serialize(stream, (network.sc_item_equip_take_on)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_TAKE_OFF: Serializer.Serialize(stream, (network.cs_item_equip_take_off)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_TAKE_OFF: Serializer.Serialize(stream, (network.sc_item_equip_take_off)proto); break;
            case ProtoNameIds.CS_ITEM_SALE: Serializer.Serialize(stream, (network.cs_item_sale)proto); break;
            case ProtoNameIds.SC_ITEM_SALE: Serializer.Serialize(stream, (network.sc_item_sale)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_UPGRADE: Serializer.Serialize(stream, (network.cs_item_equip_upgrade)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_UPGRADE: Serializer.Serialize(stream, (network.sc_item_equip_upgrade)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_STRENGTHEN: Serializer.Serialize(stream, (network.cs_item_equip_strengthen)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_STRENGTHEN: Serializer.Serialize(stream, (network.sc_item_equip_strengthen)proto); break;
            case ProtoNameIds.CS_ITEM_USE: Serializer.Serialize(stream, (network.cs_item_use)proto); break;
            case ProtoNameIds.SC_ITEM_USE: Serializer.Serialize(stream, (network.sc_item_use)proto); break;
            case ProtoNameIds.CS_ITEM_COMPOSE: Serializer.Serialize(stream, (network.cs_item_compose)proto); break;
            case ProtoNameIds.SC_ITEM_COMPOSE: Serializer.Serialize(stream, (network.sc_item_compose)proto); break;
            case ProtoNameIds.CS_ITEM_DECOMPOSE: Serializer.Serialize(stream, (network.cs_item_decompose)proto); break;
            case ProtoNameIds.SC_ITEM_DECOMPOSE: Serializer.Serialize(stream, (network.sc_item_decompose)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_GEMSTONE_INLAY: Serializer.Serialize(stream, (network.cs_item_equip_gemstone_inlay)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_GEMSTONE_INLAY: Serializer.Serialize(stream, (network.sc_item_equip_gemstone_inlay)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_POLISH: Serializer.Serialize(stream, (network.cs_item_equip_polish)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_POLISH: Serializer.Serialize(stream, (network.sc_item_equip_polish)proto); break;
            case ProtoNameIds.CS_ITEM_EQUIP_INHERIT: Serializer.Serialize(stream, (network.cs_item_equip_inherit)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_INHERIT: Serializer.Serialize(stream, (network.sc_item_equip_inherit)proto); break;
            case ProtoNameIds.SC_ITEM_EQUIP_RESONATE: Serializer.Serialize(stream, (network.sc_item_equip_resonate)proto); break;
            case ProtoNameIds.CS_ITEM_GEMSTONE_COMPOSE: Serializer.Serialize(stream, (network.cs_item_gemstone_compose)proto); break;
            case ProtoNameIds.SC_ITEM_GEMSTONE_COMPOSE: Serializer.Serialize(stream, (network.sc_item_gemstone_compose)proto); break;
            case ProtoNameIds.CS_CHAT: Serializer.Serialize(stream, (network.cs_chat)proto); break;
            case ProtoNameIds.SC_CHAT: Serializer.Serialize(stream, (network.sc_chat)proto); break;
            case ProtoNameIds.SC_CHAT_NOTICE: Serializer.Serialize(stream, (network.sc_chat_notice)proto); break;
            case ProtoNameIds.CS_COMMON_OPERATION_VERIFY: Serializer.Serialize(stream, (network.cs_common_operation_verify)proto); break;
            case ProtoNameIds.SC_COMMON_OPERATION_VERIFY: Serializer.Serialize(stream, (network.sc_common_operation_verify)proto); break;
            case ProtoNameIds.SC_COMMON_CURRENCY: Serializer.Serialize(stream, (network.sc_common_currency)proto); break;
            case ProtoNameIds.SC_COMMON_ENERCY_TIME: Serializer.Serialize(stream, (network.sc_common_enercy_time)proto); break;
            case ProtoNameIds.SC_DUP_FIGHT_INFO: Serializer.Serialize(stream, (network.sc_dup_fight_info)proto); break;
            case ProtoNameIds.CS_CHAPTER_FIGHT_ENTER: Serializer.Serialize(stream, (network.cs_chapter_fight_enter)proto); break;
            case ProtoNameIds.SC_CHAPTER_FIGHT_ENTER_RESPONSE: Serializer.Serialize(stream, (network.sc_chapter_fight_enter_response)proto); break;
            case ProtoNameIds.CS_DUP_FIGHT_PUSH: Serializer.Serialize(stream, (network.cs_dup_fight_push)proto); break;
            case ProtoNameIds.SC_DUP_FIGHT_PUSH: Serializer.Serialize(stream, (network.sc_dup_fight_push)proto); break;
            case ProtoNameIds.SC_CHAPTER_FIGHT_CHEST: Serializer.Serialize(stream, (network.sc_chapter_fight_chest)proto); break;
            case ProtoNameIds.CS_CHAPTER_FIGHT_OPEN_CHEST: Serializer.Serialize(stream, (network.cs_chapter_fight_open_chest)proto); break;
            case ProtoNameIds.SC_CHAPTER_FIGHT_OPEN_CHEST: Serializer.Serialize(stream, (network.sc_chapter_fight_open_chest)proto); break;
            case ProtoNameIds.SC_FRIEND_LIST: Serializer.Serialize(stream, (network.sc_friend_list)proto); break;
            case ProtoNameIds.SC_FRIEND_ADD: Serializer.Serialize(stream, (network.sc_friend_add)proto); break;
            case ProtoNameIds.SC_FRIEND_DEL: Serializer.Serialize(stream, (network.sc_friend_del)proto); break;
            case ProtoNameIds.CS_FRIEND_ADD_REQUEST: Serializer.Serialize(stream, (network.cs_friend_add_request)proto); break;
            case ProtoNameIds.SC_FRIEND_ADD_RESPONESE: Serializer.Serialize(stream, (network.sc_friend_add_responese)proto); break;
            case ProtoNameIds.CS_FRIEND_DEL_REQUEST: Serializer.Serialize(stream, (network.cs_friend_del_request)proto); break;
            case ProtoNameIds.SC_FRIEND_DEL_RESPONESE: Serializer.Serialize(stream, (network.sc_friend_del_responese)proto); break;
            case ProtoNameIds.CS_FRIEND_ADD_BLACK: Serializer.Serialize(stream, (network.cs_friend_add_black)proto); break;
            case ProtoNameIds.CS_FRIEND_REMOVE_BLACK: Serializer.Serialize(stream, (network.cs_friend_remove_black)proto); break;
            case ProtoNameIds.CS_FRIEND_APPLY_HANDLE: Serializer.Serialize(stream, (network.cs_friend_apply_handle)proto); break;
            case ProtoNameIds.CS_FRIEND_SEARCH_REQUEST: Serializer.Serialize(stream, (network.cs_friend_search_request)proto); break;
            case ProtoNameIds.SC_FRIEND_SEARCH_RESPONE: Serializer.Serialize(stream, (network.sc_friend_search_respone)proto); break;
            case ProtoNameIds.CS_FRIEND_RECOMMOND: Serializer.Serialize(stream, (network.cs_friend_recommond)proto); break;
            case ProtoNameIds.CS_FRIEND_GIVE: Serializer.Serialize(stream, (network.cs_friend_give)proto); break;
            case ProtoNameIds.CS_FRIEND_RECEIVE: Serializer.Serialize(stream, (network.cs_friend_receive)proto); break;
            case ProtoNameIds.SC_FRIEND_GIVE_LIST: Serializer.Serialize(stream, (network.sc_friend_give_list)proto); break;
            case ProtoNameIds.SC_FRIEND_RECEIVE_LIST: Serializer.Serialize(stream, (network.sc_friend_receive_list)proto); break;
            case ProtoNameIds.CS_RANDOM_FIGHT_INFO: Serializer.Serialize(stream, (network.cs_random_fight_info)proto); break;
            case ProtoNameIds.SC_RANDOM_FIGHT_INFO: Serializer.Serialize(stream, (network.sc_random_fight_info)proto); break;
            case ProtoNameIds.CS_RANDOM_FIGHT_REFRESH: Serializer.Serialize(stream, (network.cs_random_fight_refresh)proto); break;
            case ProtoNameIds.CS_ALL_FIGHT_INFO: Serializer.Serialize(stream, (network.cs_all_fight_info)proto); break;
            case ProtoNameIds.SC_ALL_FIGHT_INFO_RESPONESE: Serializer.Serialize(stream, (network.sc_all_fight_info_responese)proto); break;
            case ProtoNameIds.CS_RANDOM_FIGHT_ENTER: Serializer.Serialize(stream, (network.cs_random_fight_enter)proto); break;
            case ProtoNameIds.SC_RANDOM_FIGHT_ENTER_RESPONSE: Serializer.Serialize(stream, (network.sc_random_fight_enter_response)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_QUERY_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_query_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_QUERY_RESPONE: Serializer.Serialize(stream, (network.sc_pass_fight_query_respone)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_RESET_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_reset_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_RESET_RESPONE: Serializer.Serialize(stream, (network.sc_pass_fight_reset_respone)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_DUP_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_dup_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_DUP_RESPONE: Serializer.Serialize(stream, (network.sc_pass_fight_dup_respone)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_DUP_CANCEL_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_dup_cancel_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_DUP_REWARD: Serializer.Serialize(stream, (network.sc_pass_fight_dup_reward)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_FIGHT_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_fight_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_FIGHT_RESPONE: Serializer.Serialize(stream, (network.sc_pass_fight_fight_respone)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_QUIT_STAGE: Serializer.Serialize(stream, (network.sc_pass_fight_quit_stage)proto); break;
            case ProtoNameIds.CS_PASS_FIGHT_OPEN_CHESTS_REQUEST: Serializer.Serialize(stream, (network.cs_pass_fight_open_chests_request)proto); break;
            case ProtoNameIds.SC_PASS_FIGHT_OPEN_CHESTS_RESPONE: Serializer.Serialize(stream, (network.sc_pass_fight_open_chests_respone)proto); break;
            case ProtoNameIds.CS_WELFARE_FIGHT_FIGHT_REQUEST: Serializer.Serialize(stream, (network.cs_welfare_fight_fight_request)proto); break;
            case ProtoNameIds.SC_WELFARE_FIGHT_FIGHT_RESPONSE: Serializer.Serialize(stream, (network.sc_welfare_fight_fight_response)proto); break;
            case ProtoNameIds.CS_WELFARE_FIGHT_QUERY_REQUEST: Serializer.Serialize(stream, (network.cs_welfare_fight_query_request)proto); break;
            case ProtoNameIds.SC_WELFARE_FIGHT_QUERY_RESPONSE: Serializer.Serialize(stream, (network.sc_welfare_fight_query_response)proto); break;
            case ProtoNameIds.SC_PET_LIST: Serializer.Serialize(stream, (network.sc_pet_list)proto); break;
            case ProtoNameIds.SC_PET_UPDATE: Serializer.Serialize(stream, (network.sc_pet_update)proto); break;
            case ProtoNameIds.CS_PET_FIGHT: Serializer.Serialize(stream, (network.cs_pet_fight)proto); break;
            case ProtoNameIds.SC_PET_FIGHT: Serializer.Serialize(stream, (network.sc_pet_fight)proto); break;
            case ProtoNameIds.CS_PET_FEED: Serializer.Serialize(stream, (network.cs_pet_feed)proto); break;
            case ProtoNameIds.SC_PET_FEED: Serializer.Serialize(stream, (network.sc_pet_feed)proto); break;
            case ProtoNameIds.CS_PET_EQUIP_INLAY: Serializer.Serialize(stream, (network.cs_pet_equip_inlay)proto); break;
            case ProtoNameIds.SC_PET_EQUIP_INLAY: Serializer.Serialize(stream, (network.sc_pet_equip_inlay)proto); break;
            case ProtoNameIds.CS_SHOP_BONUS_POINT_QUERY: Serializer.Serialize(stream, (network.cs_shop_bonus_point_query)proto); break;
            case ProtoNameIds.SC_SHOP_BONUS_POINT_QUERY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_bonus_point_query_response)proto); break;
            case ProtoNameIds.CS_SHOP_BONUS_POINT_BUY: Serializer.Serialize(stream, (network.cs_shop_bonus_point_buy)proto); break;
            case ProtoNameIds.SC_SHOP_BONUS_POINT_BUY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_bonus_point_buy_response)proto); break;
            case ProtoNameIds.CS_SHOP_MYSTERY_QUERY: Serializer.Serialize(stream, (network.cs_shop_mystery_query)proto); break;
            case ProtoNameIds.SC_SHOP_MYSTERY_QUERY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_mystery_query_response)proto); break;
            case ProtoNameIds.CS_SHOP_MYSTERY_REFRESH: Serializer.Serialize(stream, (network.cs_shop_mystery_refresh)proto); break;
            case ProtoNameIds.CS_SHOP_MYSTERY_BUY: Serializer.Serialize(stream, (network.cs_shop_mystery_buy)proto); break;
            case ProtoNameIds.SC_SHOP_MYSTERY_BUY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_mystery_buy_response)proto); break;
            case ProtoNameIds.CS_SHOP_COMMON_QUERY: Serializer.Serialize(stream, (network.cs_shop_common_query)proto); break;
            case ProtoNameIds.SC_SHOP_COMMON_QUERY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_common_query_response)proto); break;
            case ProtoNameIds.CS_SHOP_COMMON_BUY: Serializer.Serialize(stream, (network.cs_shop_common_buy)proto); break;
            case ProtoNameIds.SC_SHOP_COMMON_BUY_RESPONSE: Serializer.Serialize(stream, (network.sc_shop_common_buy_response)proto); break;
            case ProtoNameIds.CS_SHOP_COMMON_GIFT: Serializer.Serialize(stream, (network.cs_shop_common_gift)proto); break;
            case ProtoNameIds.CS_SHOP_COMMON_GIFT_RESPONSE: Serializer.Serialize(stream, (network.cs_shop_common_gift_response)proto); break;
            case ProtoNameIds.SC_MISSION_INFO: Serializer.Serialize(stream, (network.sc_mission_info)proto); break;
            case ProtoNameIds.CS_MISSION_COMPLETE: Serializer.Serialize(stream, (network.cs_mission_complete)proto); break;
            case ProtoNameIds.SC_MISSION_COMPLETE_REPLY: Serializer.Serialize(stream, (network.sc_mission_complete_reply)proto); break;
            case ProtoNameIds.CS_MISSION_GET: Serializer.Serialize(stream, (network.cs_mission_get)proto); break;
            case ProtoNameIds.SC_MAIL_LIST_QUERY_RESPONE: Serializer.Serialize(stream, (network.sc_mail_list_query_respone)proto); break;
            case ProtoNameIds.SC_MAIL_INFO_NOTICE: Serializer.Serialize(stream, (network.sc_mail_info_notice)proto); break;
            case ProtoNameIds.CS_MAIL_GET_REWARD: Serializer.Serialize(stream, (network.cs_mail_get_reward)proto); break;
            case ProtoNameIds.SC_MAIL_GET_REWARD: Serializer.Serialize(stream, (network.sc_mail_get_reward)proto); break;
            case ProtoNameIds.CS_MAIL_LOOKUP: Serializer.Serialize(stream, (network.cs_mail_lookup)proto); break;
            case ProtoNameIds.SC_MAIL_LOOKUP: Serializer.Serialize(stream, (network.sc_mail_lookup)proto); break;
            case ProtoNameIds.CS_MAIL_ALL_GET_REWARD: Serializer.Serialize(stream, (network.cs_mail_all_get_reward)proto); break;
            case ProtoNameIds.SC_MAIL_ALL_GET_REWARD: Serializer.Serialize(stream, (network.sc_mail_all_get_reward)proto); break;
            case ProtoNameIds.SC_GUILD_WAR_DOOR: Serializer.Serialize(stream, (network.sc_guild_war_door)proto); break;
            case ProtoNameIds.CS_GUILD_WAR_ENTER: Serializer.Serialize(stream, (network.cs_guild_war_enter)proto); break;
            case ProtoNameIds.SC_GUILD_WAR_ENTER_RESPONSE: Serializer.Serialize(stream, (network.sc_guild_war_enter_response)proto); break;
            case ProtoNameIds.SC_GUILD_WAR_BILLING: Serializer.Serialize(stream, (network.sc_guild_war_billing)proto); break;
            case ProtoNameIds.SC_GUILD_WAR_UPDATE_INFO: Serializer.Serialize(stream, (network.sc_guild_war_update_info)proto); break;
            case ProtoNameIds.SC_GUILD_UPDATE: Serializer.Serialize(stream, (network.sc_guild_update)proto); break;
            case ProtoNameIds.CS_GUILD_MEMEBER_QUERY: Serializer.Serialize(stream, (network.cs_guild_memeber_query)proto); break;
            case ProtoNameIds.SC_GUILD_MEMBER_UPDATE: Serializer.Serialize(stream, (network.sc_guild_member_update)proto); break;
            case ProtoNameIds.CS_GUILD_MEMEBER_OPERATION: Serializer.Serialize(stream, (network.cs_guild_memeber_operation)proto); break;
            case ProtoNameIds.CS_GUILD_LIST_QUERY: Serializer.Serialize(stream, (network.cs_guild_list_query)proto); break;
            case ProtoNameIds.SC_GUILD_LIST_UPDATE: Serializer.Serialize(stream, (network.sc_guild_list_update)proto); break;
            case ProtoNameIds.CS_GUILD_SEARCH: Serializer.Serialize(stream, (network.cs_guild_search)proto); break;
            case ProtoNameIds.SC_GUILD_SEARCH_RESPONSE: Serializer.Serialize(stream, (network.sc_guild_search_response)proto); break;
            case ProtoNameIds.CS_GUILD_CREATE: Serializer.Serialize(stream, (network.cs_guild_create)proto); break;
            case ProtoNameIds.CS_GUILD_QUIT: Serializer.Serialize(stream, (network.cs_guild_quit)proto); break;
            case ProtoNameIds.CS_GUILD_APPLY: Serializer.Serialize(stream, (network.cs_guild_apply)proto); break;
            case ProtoNameIds.SC_GUILD_APPLY_RESPONSE: Serializer.Serialize(stream, (network.sc_guild_apply_response)proto); break;
            case ProtoNameIds.CS_GUILD_APPLY_ONEKEY: Serializer.Serialize(stream, (network.cs_guild_apply_onekey)proto); break;
            case ProtoNameIds.SC_GUILD_APPLY_ONEKEY_RESPONSE: Serializer.Serialize(stream, (network.sc_guild_apply_onekey_response)proto); break;
            case ProtoNameIds.CS_GUILD_APPLY_REPLY: Serializer.Serialize(stream, (network.cs_guild_apply_reply)proto); break;
            case ProtoNameIds.CS_GUILD_APPLY_LIST_QUERY: Serializer.Serialize(stream, (network.cs_guild_apply_list_query)proto); break;
            case ProtoNameIds.SC_GUILD_APPLY_LIST_UPDATE: Serializer.Serialize(stream, (network.sc_guild_apply_list_update)proto); break;
            case ProtoNameIds.SC_GUILD_LOG_UPDATE: Serializer.Serialize(stream, (network.sc_guild_log_update)proto); break;
            case ProtoNameIds.SC_GUILD_LOG_INIT: Serializer.Serialize(stream, (network.sc_guild_log_init)proto); break;
            case ProtoNameIds.CS_RANKING_LIST_QUERY_REQUEST: Serializer.Serialize(stream, (network.cs_ranking_list_query_request)proto); break;
            case ProtoNameIds.SC_RANKING_LIST_QUERY_RESPONE: Serializer.Serialize(stream, (network.sc_ranking_list_query_respone)proto); break;
            case ProtoNameIds.SC_RANKING_UPDATE_NOTICE: Serializer.Serialize(stream, (network.sc_ranking_update_notice)proto); break;
            case ProtoNameIds.SC_GUID_RANKING_RESPONSE: Serializer.Serialize(stream, (network.sc_guid_ranking_response)proto); break;
            case ProtoNameIds.SC_VIP_INFO: Serializer.Serialize(stream, (network.sc_vip_info)proto); break;
            case ProtoNameIds.SC_VIP_TIMES: Serializer.Serialize(stream, (network.sc_vip_times)proto); break;
            case ProtoNameIds.CS_VIP_BUY_TIMES: Serializer.Serialize(stream, (network.cs_vip_buy_times)proto); break;
            case ProtoNameIds.SC_VIP_BUY_TIMES: Serializer.Serialize(stream, (network.sc_vip_buy_times)proto); break;
            case ProtoNameIds.CS_VIP_USE_BUN: Serializer.Serialize(stream, (network.cs_vip_use_bun)proto); break;
            case ProtoNameIds.SC_VIP_USE_BUN_RESULT: Serializer.Serialize(stream, (network.sc_vip_use_bun_result)proto); break;
            case ProtoNameIds.CS_VIP_BUY_GOLD: Serializer.Serialize(stream, (network.cs_vip_buy_gold)proto); break;
            case ProtoNameIds.SC_VIP_BUY_GOLD: Serializer.Serialize(stream, (network.sc_vip_buy_gold)proto); break;
            case ProtoNameIds.SC_VIP_RECHARGE: Serializer.Serialize(stream, (network.sc_vip_recharge)proto); break;
            case ProtoNameIds.CS_COMMON_FIGHT_KILL_MONSTER: Serializer.Serialize(stream, (network.cs_common_fight_kill_monster)proto); break;
            case ProtoNameIds.CS_COMMON_FIGHT_DEAD: Serializer.Serialize(stream, (network.cs_common_fight_dead)proto); break;
            case ProtoNameIds.CS_COMMON_FIGHT_RELIVE: Serializer.Serialize(stream, (network.cs_common_fight_relive)proto); break;
            case ProtoNameIds.SC_COMMON_FIGHT_RELIVE_RESPONSE: Serializer.Serialize(stream, (network.sc_common_fight_relive_response)proto); break;
            case ProtoNameIds.CS_COMMON_FIGHT_QUIT: Serializer.Serialize(stream, (network.cs_common_fight_quit)proto); break;
            case ProtoNameIds.SC_COMMON_FIGHT_QUIT_REPONSE: Serializer.Serialize(stream, (network.sc_common_fight_quit_reponse)proto); break;
            case ProtoNameIds.SC_FIRST_FIGHT_END: Serializer.Serialize(stream, (network.sc_first_fight_end)proto); break;
            case ProtoNameIds.CS_MASTER_FIGHT_ENTER: Serializer.Serialize(stream, (network.cs_master_fight_enter)proto); break;
            case ProtoNameIds.SC_MASTER_FIGHT_ENTER_RESPONSE: Serializer.Serialize(stream, (network.sc_master_fight_enter_response)proto); break;
            case ProtoNameIds.CS_TEAM_CREATE: Serializer.Serialize(stream, (network.cs_team_create)proto); break;
            case ProtoNameIds.SC_TEAM_CREATE_REPLY: Serializer.Serialize(stream, (network.sc_team_create_reply)proto); break;
            case ProtoNameIds.CS_TEAM_QUIT: Serializer.Serialize(stream, (network.cs_team_quit)proto); break;
            case ProtoNameIds.SC_TEAM_QUIT_REPLY: Serializer.Serialize(stream, (network.sc_team_quit_reply)proto); break;
            case ProtoNameIds.SC_TEAM_MEMBER_CHANGE: Serializer.Serialize(stream, (network.sc_team_member_change)proto); break;
            case ProtoNameIds.SC_TEAM_INFO: Serializer.Serialize(stream, (network.sc_team_info)proto); break;
            case ProtoNameIds.CS_TEAM_INVITE_AGREE: Serializer.Serialize(stream, (network.cs_team_invite_agree)proto); break;
            case ProtoNameIds.SC_TEAM_INVITE_AGREE_REPLY: Serializer.Serialize(stream, (network.sc_team_invite_agree_reply)proto); break;
            case ProtoNameIds.CS_TEAM_INVITE_LIST: Serializer.Serialize(stream, (network.cs_team_invite_list)proto); break;
            case ProtoNameIds.SC_TEAM_INVITE_LIST_REPLY: Serializer.Serialize(stream, (network.sc_team_invite_list_reply)proto); break;
            case ProtoNameIds.CS_TEAM_INVITE: Serializer.Serialize(stream, (network.cs_team_invite)proto); break;
            case ProtoNameIds.SC_TEAM_INVITE_REPLY: Serializer.Serialize(stream, (network.sc_team_invite_reply)proto); break;
            case ProtoNameIds.SC_TEAM_INVITE_LIST_CHANGE: Serializer.Serialize(stream, (network.sc_team_invite_list_change)proto); break;
            case ProtoNameIds.CS_TEAM_KICK: Serializer.Serialize(stream, (network.cs_team_kick)proto); break;
            case ProtoNameIds.SC_TEAM_KICK_REPLY: Serializer.Serialize(stream, (network.sc_team_kick_reply)proto); break;
            case ProtoNameIds.SC_TEAM_BE_KICKED: Serializer.Serialize(stream, (network.sc_team_be_kicked)proto); break;
            case ProtoNameIds.CS_TEAM_LEADER_TRANSFER: Serializer.Serialize(stream, (network.cs_team_leader_transfer)proto); break;
            case ProtoNameIds.SC_TEAM_LEADER_TRANSFER_REPLY: Serializer.Serialize(stream, (network.sc_team_leader_transfer_reply)proto); break;
            case ProtoNameIds.CS_TEAM_START_ACTIVITY: Serializer.Serialize(stream, (network.cs_team_start_activity)proto); break;
            case ProtoNameIds.SC_TEAM_START_ACTIVITY_REPLY: Serializer.Serialize(stream, (network.sc_team_start_activity_reply)proto); break;
            case ProtoNameIds.SC_TEAM_ACTIVITY: Serializer.Serialize(stream, (network.sc_team_activity)proto); break;
            case ProtoNameIds.CS_TEAM_ACTIVITY_AGREE: Serializer.Serialize(stream, (network.cs_team_activity_agree)proto); break;
            case ProtoNameIds.SC_TEAM_ACTIVITY_AGREE_REPLY: Serializer.Serialize(stream, (network.sc_team_activity_agree_reply)proto); break;
            case ProtoNameIds.SC_TEAM_READY_INFO: Serializer.Serialize(stream, (network.sc_team_ready_info)proto); break;
            case ProtoNameIds.CS_TEAM_AUTO_MATCH: Serializer.Serialize(stream, (network.cs_team_auto_match)proto); break;
            case ProtoNameIds.SC_TEAM_AUTO_MATCH: Serializer.Serialize(stream, (network.sc_team_auto_match)proto); break;
            case ProtoNameIds.CS_PERSONAL_AUTO_MATCH: Serializer.Serialize(stream, (network.cs_personal_auto_match)proto); break;
            case ProtoNameIds.SC_PERSONAL_AUTO_MATCH: Serializer.Serialize(stream, (network.sc_personal_auto_match)proto); break;
            case ProtoNameIds.SC_PERSONAL_AUTO_MATCH_STATE: Serializer.Serialize(stream, (network.sc_personal_auto_match_state)proto); break;
            case ProtoNameIds.CS_AUTO_MATCH_TEAM_LIST: Serializer.Serialize(stream, (network.cs_auto_match_team_list)proto); break;
            case ProtoNameIds.SC_AUTO_MATCH_TEAM_LIST: Serializer.Serialize(stream, (network.sc_auto_match_team_list)proto); break;
            case ProtoNameIds.CS_TEAM_APPLY: Serializer.Serialize(stream, (network.cs_team_apply)proto); break;
            case ProtoNameIds.SC_TEAM_APPLY: Serializer.Serialize(stream, (network.sc_team_apply)proto); break;
            case ProtoNameIds.CS_GET_TEAM_APPLY_LIST: Serializer.Serialize(stream, (network.cs_get_team_apply_list)proto); break;
            case ProtoNameIds.SC_TEAM_APPLY_LIST: Serializer.Serialize(stream, (network.sc_team_apply_list)proto); break;
            case ProtoNameIds.CS_CLEAN_APPLY_LIST: Serializer.Serialize(stream, (network.cs_clean_apply_list)proto); break;
            case ProtoNameIds.CS_TEAM_APPLY_AGREE: Serializer.Serialize(stream, (network.cs_team_apply_agree)proto); break;
            case ProtoNameIds.SC_ACTIVITY_SIGN_INFO: Serializer.Serialize(stream, (network.sc_activity_sign_info)proto); break;
            case ProtoNameIds.CS_ACTIVITY_SIGN: Serializer.Serialize(stream, (network.cs_activity_sign)proto); break;
            case ProtoNameIds.SC_ACTIVITY_SIGN_REPLY: Serializer.Serialize(stream, (network.sc_activity_sign_reply)proto); break;
            case ProtoNameIds.SC_ACTIVITY_LIST: Serializer.Serialize(stream, (network.sc_activity_list)proto); break;
            case ProtoNameIds.SC_ACTIVITY_ENERGY_INFO: Serializer.Serialize(stream, (network.sc_activity_energy_info)proto); break;
            case ProtoNameIds.CS_ACTIVITY_ENERGY: Serializer.Serialize(stream, (network.cs_activity_energy)proto); break;
            case ProtoNameIds.SC_ACTIVITY_ENERGY_REPLY: Serializer.Serialize(stream, (network.sc_activity_energy_reply)proto); break;
            case ProtoNameIds.SC_ACTIVITY_FUND_INFO: Serializer.Serialize(stream, (network.sc_activity_fund_info)proto); break;
            case ProtoNameIds.CS_ACTIVITY_FUND_BUY: Serializer.Serialize(stream, (network.cs_activity_fund_buy)proto); break;
            case ProtoNameIds.SC_ACTIVITY_FUND_BUY_REPLY: Serializer.Serialize(stream, (network.sc_activity_fund_buy_reply)proto); break;
            case ProtoNameIds.CS_ACTIVITY_FUND_AWARD: Serializer.Serialize(stream, (network.cs_activity_fund_award)proto); break;
            case ProtoNameIds.SC_ACTIVITY_FUND_AWARD_REPLY: Serializer.Serialize(stream, (network.sc_activity_fund_award_reply)proto); break;
            case ProtoNameIds.SC_NORMAL_ACTIVITY_INFO: Serializer.Serialize(stream, (network.sc_normal_activity_info)proto); break;
            case ProtoNameIds.CS_NORMAL_ACTIVITY_AWARD: Serializer.Serialize(stream, (network.cs_normal_activity_award)proto); break;
            case ProtoNameIds.SC_NORMAL_ACTIVITY_AWARD_REPLY: Serializer.Serialize(stream, (network.sc_normal_activity_award_reply)proto); break;
            case ProtoNameIds.SC_ACTIVITY_VIP_INFO: Serializer.Serialize(stream, (network.sc_activity_vip_info)proto); break;
            case ProtoNameIds.CS_ACTIVITY_VIP_BUY: Serializer.Serialize(stream, (network.cs_activity_vip_buy)proto); break;
            case ProtoNameIds.SC_ACTIVITY_VIP_BUY_REPLY: Serializer.Serialize(stream, (network.sc_activity_vip_buy_reply)proto); break;
            case ProtoNameIds.CS_ARENA_INFO: Serializer.Serialize(stream, (network.cs_arena_info)proto); break;
            case ProtoNameIds.SC_ARENA_INFO_REPLY: Serializer.Serialize(stream, (network.sc_arena_info_reply)proto); break;
            case ProtoNameIds.CS_ARENA_BUTTON: Serializer.Serialize(stream, (network.cs_arena_button)proto); break;
            case ProtoNameIds.SC_ARENA_BUTTON_REPLY: Serializer.Serialize(stream, (network.sc_arena_button_reply)proto); break;
            case ProtoNameIds.CS_ARENA_CHALLENGE: Serializer.Serialize(stream, (network.cs_arena_challenge)proto); break;
            case ProtoNameIds.SC_ARENA_CHALLENGE_REPLY: Serializer.Serialize(stream, (network.sc_arena_challenge_reply)proto); break;
            case ProtoNameIds.CS_ARENA_CHALLENGE_ACCOUNT: Serializer.Serialize(stream, (network.cs_arena_challenge_account)proto); break;
            case ProtoNameIds.CS_ARENA_RECORD: Serializer.Serialize(stream, (network.cs_arena_record)proto); break;
            case ProtoNameIds.SC_ARENA_RECORD_REPLY: Serializer.Serialize(stream, (network.sc_arena_record_reply)proto); break;
            case ProtoNameIds.CS_ARENA_TIMES: Serializer.Serialize(stream, (network.cs_arena_times)proto); break;
            case ProtoNameIds.SC_ARENA_TIMES_REPLY: Serializer.Serialize(stream, (network.sc_arena_times_reply)proto); break;
            default: break;
        }
    }
}
