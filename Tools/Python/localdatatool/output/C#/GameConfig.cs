
using System.Collections.Generic;
public class _unit_of_Role {
	public float antiBroken;
	public float attackTime;
	public float defense;
	public float dodge;
	public float hit;
	public int hp;
	public int id;
	public int model;
	public string name;
	public float shootDistane;
	public string[] skill;
	public float speed;
	public int start;
	public _unit_of_Role() { }
	public _unit_of_Role(float _antiBroken, float _attackTime, float _defense, float _dodge, float _hit, int _hp, int _id, int _model, string _name, float _shootDistane, string[] _skill, float _speed, int _start) {
		shootDistane = _shootDistane;
		speed = _speed;
		id = _id;
		attackTime = _attackTime;
		skill = _skill;
		hp = _hp;
		name = _name;
		model = _model;
		start = _start;
		hit = _hit;
		dodge = _dodge;
		defense = _defense;
		antiBroken = _antiBroken;
	}
}
public class _unit_of_Scene {
	public int arrange;
	public int id;
	public string path;
	public int road;
	public _unit_of_Scene() { }
	public _unit_of_Scene(int _arrange, int _id, string _path, int _road) {
		arrange = _arrange;
		path = _path;
		road = _road;
		id = _id;
	}
}
public class GameConfig {
	private static Dictionary<int, _unit_of_Scene> _Scene = null;
	private static Dictionary<int, _unit_of_Role> _Role = null;
	public static Dictionary<int, _unit_of_Scene> Scene
	{
		get
		{
			if (_Scene == null)
			{
				init_Scene();
			}
			return _Scene;
		}
	}
	public static Dictionary<int, _unit_of_Role> Role
	{
		get
		{
			if (_Role == null)
			{
				init_Role();
			}
			return _Role;
		}
	}
	private static void init_Scene()
	{
		if (GameConfigLogFun != null) GameConfigLogFun("config init : Scene	mount : 9");
		_Scene = new Dictionary<int, _unit_of_Scene>(10);
		_Scene.Add(1, new _unit_of_Scene(1, 1, "", 3));
		_Scene.Add(2, new _unit_of_Scene(1, 2, "", 3));
		_Scene.Add(3, new _unit_of_Scene(1, 3, "", 3));
		_Scene.Add(4, new _unit_of_Scene(1, 4, "", 3));
		_Scene.Add(5, new _unit_of_Scene(1, 5, "", 3));
		_Scene.Add(6, new _unit_of_Scene(1, 6, "", 3));
		_Scene.Add(7, new _unit_of_Scene(1, 7, "", 3));
		_Scene.Add(8, new _unit_of_Scene(1, 8, "", 3));
		_Scene.Add(9, new _unit_of_Scene(1, 9, "", 3));
	}
	private static void init_Role()
	{
		if (GameConfigLogFun != null) GameConfigLogFun("config init : Role	mount : 9");
		_Role = new Dictionary<int, _unit_of_Role>(10);
		_Role.Add(101, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 101, 1001, "\u72c2\u8840\u6597\u795e", 30.0f, new string[]{"M0001:2"}, 20.0f, 1));
		_Role.Add(102, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 102, 1002, "\u5b88\u62a4\u5de8\u9f99\u6d77\u9f99", 30.0f, new string[]{"M0001:3"}, 20.0f, 1));
		_Role.Add(103, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 103, 1003, "\u5149\u5143\u7d20\u4f7f\u7d22\u9686", 30.0f, new string[]{"M0001:4"}, 20.0f, 1));
		_Role.Add(104, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 104, 1004, "\u94c1\u7532\u9f99\u9f9f\u62c9\u83f2\u5c14", 30.0f, new string[]{"M0001:5"}, 20.0f, 1));
		_Role.Add(105, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 105, 1005, "\u5815\u5929\u4f7f", 30.0f, new string[]{"M0001:6"}, 20.0f, 1));
		_Role.Add(106, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 106, 1006, "\u6076\u9b54\u796d\u7940", 30.0f, new string[]{"M0001:7"}, 20.0f, 1));
		_Role.Add(107, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 107, 1007, "\u94a2\u94c1\u5de8\u70ae\u6851\u6258\u65af", 30.0f, new string[]{"M0001:8"}, 20.0f, 1));
		_Role.Add(108, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 108, 1008, "\u8d24\u8005\u5361\u62c9\u5c14", 30.0f, new string[]{"M0001:9"}, 20.0f, 1));
		_Role.Add(109, new _unit_of_Role(0.5f, 0.5f, 0.5f, 0.5f, 0.5f, 300, 109, 1009, "\u9cc4\u9c7c\u9093\u8fea", 30.0f, new string[]{"M0001:10"}, 20.0f, 1));
	}
	public delegate void GameConfigLog(string log);
    public static GameConfigLog GameConfigLogFun;
	static GameConfig() {
	}
}
