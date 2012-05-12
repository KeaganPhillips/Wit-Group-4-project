$ ->
  stage = new Kinetic.Stage({
                container: "container",
                width: 1200,
                height: 800
            });
  x=77
  y=80
  all_classes = [{className: 'Customer', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}]}, {className: 'Hello World', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}]}, {className: 'Cus', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}]}, {className: 'Buyer', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}, {methodName: 'm3()'}]}, {className: 'Buyer', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}, {methodName: 'm3()'}, {methodName: 'm4()'}]}, {className: 'Customers', methods: [{methodName: 'm1()'},{ methodName: 'm2()'}]}]
  for class_data in all_classes	
    classDiagram = new ClassDiagram(x, y, class_data)
    stage.add(classDiagram.get_Layer());
    x = x + 220
    y = 330 if x>1000
    x = 77 if y is 330