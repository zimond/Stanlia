-- This script defines the rabbit Ruby from Animal Crossing

RubyTheRabbit = {
	Name = "Ruby",
	Age = 18,
	Desc: "A lovely rabbit from Animal Crossing",
	HP: 100,
	MaxHP: 100,
	Def: 20,
	Atk: 5,
	Tags: "NPC",
	BaseType: "People",
	Capacity: 5,
	Children: {
		{
			DefId: item#RabbitFur,
			Count: 2
		},
		{
			DefId: item#RubyGem,
			Count: 1
		}
	};
};

RubyTheRabbit.Talk = function()
	local lines = {"你好，我叫Ruby", "我是白毛红眼睛的Ruby", "人人都爱我，长得可爱真好"};
	math.randomseed(os.time())
	return lines[math.random(3)]
end