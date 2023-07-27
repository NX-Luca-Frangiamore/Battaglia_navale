using Battaglia_navale;

Manager m = new Manager(10,10);



m.addNave(TypeBody.Lunga, 5, 0, 0);
m.addNave(TypeBody.Larga, 0, 5, 1);
m.printMappa();
m.loop();
m.addNave(TypeBody.Quadrata, 5, 3, 0);
m.loop();
m.printMappa();