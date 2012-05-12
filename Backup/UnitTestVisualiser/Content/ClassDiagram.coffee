class ClassDiagram
  get_Layer: =>
    classGroup = new Kinetic.Group({draggable: true})
    classLayer = new Kinetic.Layer();
    classGroup.draggable(true)
    box = @_create_box()
    classGroup.add(box);
    class_name = @_get_className()
    classGroup.add(class_name)
    classLayer.add(classGroup)
    classLayer

  _get_className: =>
    complexText = new Kinetic.Text({
          x: 65,
          y: 40,
          text: "Customer",
          fontSize: 13,
          fontFamily: "Verdana",
          textStroke: "#333",
          textFill: "#333",
          textStrokeWidth: 0.1,
          padding: 10,
          align: "center",
          verticalAlign: "middle"});

  _create_box: =>     
    rectX = 20;
    rectY = 25;
    box = new Kinetic.Rect({
                x: rectX,
                y: rectY,
                width: 200,
                height: 150,
                cornerRadius: 5,
                fill: "#ffffff",
                stroke: "black",
                strokeWidth: 1
            });

exports = this
exports.ClassDiagram = ClassDiagram