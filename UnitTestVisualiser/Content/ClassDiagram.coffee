class ClassDiagram
  get_Layer: =>
    classGroup = new Kinetic.Group({draggable: true})
    classLayer = new Kinetic.Layer();
    classGroup.draggable(true)
    box = @_create_box()
    line = @_drawLine()

    classGroup.add(box);
    classGroup.add(line);
    method_1 = @_get_method()
    classGroup.add(method_1)

    class_name = @_get_className()
    classGroup.add(class_name)
	
    
    classLayer.add(classGroup)
    classLayer

  _get_method: =>
    complexText = new Kinetic.Text({
          x: 77,
          y: 60,
          text: "Public Methods",
          fontSize: 11,
          fontFamily: "Verdana",
          textStroke: "#333",
          textFill: "#333",
          textStrokeWidth: 0.1,
          align: "center",
          verticalAlign: "middle"});



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
   _drawLine: =>
     points = [
        x: 20
        y: 50
     ,
        x: 220
        y: 50
     ]
     line = new Kinetic.Line({
                points: points
                stroke: "black"
                strokeWidth: 1
                lineCap: "round"
                lineJoin: "round"
            });


exports = this
exports.ClassDiagram = ClassDiagram