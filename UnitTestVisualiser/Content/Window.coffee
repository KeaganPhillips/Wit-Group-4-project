$ ->
  stage = new Kinetic.Stage({
                container: "container",
                width: 1200,
                height: 800
            });
  classDiagram = new ClassDiagram()
  stage.add(classDiagram.get_Layer());